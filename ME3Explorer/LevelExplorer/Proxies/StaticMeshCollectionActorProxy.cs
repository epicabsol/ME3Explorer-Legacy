using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ME3Explorer.Packages;
using ME3Explorer.Scene3D;
using SharpDX;

namespace ME3Explorer.LevelExplorer.Proxies
{
    [InstanceProxy("StaticMeshCollectionActor")]
    public class StaticMeshCollectionActorProxy : BaseProxy
    {
        public class ComponentProxy
        {
            public Vector3Helper Rotation
            {
                get { return Component.RotatorToDX(Component.Rotation); }
                set { Component.Rotation = Component.DXToRotator(value); }
            }

            public ModelPreview Preview = null;
            public Unreal.Classes.StaticMeshComponent Component = null;

            public Matrix RenderingMatrix(Matrix actorMatrix)
            {
                if (Component.Translation.X != 0 || Component.Translation.Y != 0 || Component.Translation.Z != 0 || Component.Rotation.X != 0 || Component.Rotation.Y != 0 || Component.Rotation.Z != 0)
                    System.Diagnostics.Debugger.Break();
                SharpDX.Matrix YZConvert = SharpDX.Matrix.RotationX(SharpDX.MathUtil.PiOverTwo);
                SharpDX.Matrix YZInverse = YZConvert;
                YZInverse.Invert();
                SharpDX.Matrix comTransform = SharpDX.Matrix.Translation(Component.Translation.X, Component.Translation.Y, Component.Translation.Z) * SharpDX.Matrix.RotationYawPitchRoll(Rotation.X, Rotation.Y, Rotation.Z) * SharpDX.Matrix.Scaling(-Component.Scale3D.X * Component.Scale, -Component.Scale3D.Y * Component.Scale, Component.Scale3D.Z * Component.Scale);
                return YZConvert * comTransform * actorMatrix * YZInverse;
            }

            public ComponentProxy(ModelPreview preview, Unreal.Classes.StaticMeshComponent component)
            {
                Preview = preview;
                Component = component;
            }
        }

        [Category("Collision")]
        public bool bCanStepUpOn
        {
            get { return Actor.bCanStepUpOn; }
            set { Actor.bCanStepUpOn = value; }
        }

        [Category("Editor")]
        public int Tag
        {
            get { return Actor.Tag; }
            set { Actor.Tag = value; }
        }

        [Category("Editor")]
        public float CreationTime
        {
            get { return Actor.CreationTime; }
            set { Actor.CreationTime = value; }
        }

        private Unreal.Classes.StaticMeshCollectionActor Actor = null;
        private List<ComponentProxy> Components = new List<ComponentProxy>();

        public StaticMeshCollectionActorProxy(IExportEntry export, LevelExplorer window) : base(export, window)
        {
            Actor = new Unreal.Classes.StaticMeshCollectionActor(window.pcc as ME3Package, export.Index);

            KFreonLib.Debugging.DebugOutput.PrintLn("Loading export " + export.Index);

            int i = 0;
            foreach (Unreal.Classes.StaticMeshComponent component in Actor.STMC)
            {
                i++;
                KFreonLib.Debugging.DebugOutput.PrintLn("    Loading object " + i);
                if (component.STM != null)
                    Components.Add(new ComponentProxy(new ModelPreview(window.Renderer.Device, component.STM, window.Renderer.TextureCache), component));
                else
                    Components.Add(null);
            }
        }

        public override void Render()
        {
            // flash for debugging purposes
           /*if (DateTime.Now.Millisecond / 100 % 2 == 0)
                return;*/

            for (int i = 0; i < Actor.Entries.Count; i++)
            {
                if (Components[i] != null)
                {
                    Matrix transform = Components[i].RenderingMatrix(Actor.Matrices[i]);
                    Components[i].Preview.Render(Window.Renderer, 0, transform);

                    if (IsSelected)
                    {
                        Window.Renderer.Wireframe = true;
                        Scene3D.SceneRenderControl.WorldConstants ViewConstants = new Scene3D.SceneRenderControl.WorldConstants(SharpDX.Matrix.Transpose(Window.Renderer.Camera.ProjectionMatrix), SharpDX.Matrix.Transpose(Window.Renderer.Camera.ViewMatrix), SharpDX.Matrix.Transpose(transform));
                        Window.SelectionEffect.PrepDraw(Window.Renderer.ImmediateContext);
                        Window.SelectionEffect.RenderObject(Window.Renderer.ImmediateContext, ViewConstants, Components[i].Preview.LODs[0].Mesh, new SharpDX.Direct3D11.ShaderResourceView[] { null });
                        Window.Renderer.Wireframe = false;
                    }
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (ComponentProxy component in Components)
                component?.Preview.Dispose();
        }

        public override void NodeDoubleClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            base.NodeDoubleClicked(sender, e);

            if (Components.Count == 0)
                return; // There's nothing to focus on!

            SharpDX.Vector3 min = Components[0].Component.Translation;
            SharpDX.Vector3 max = Components[0].Component.Translation;

            for (int i = 1; i < Components.Count; i++)
            {
                min = SharpDX.Vector3.Min(min, Actor.Matrices[i].TranslationVector);
                max = SharpDX.Vector3.Max(max, Actor.Matrices[i].TranslationVector);
            }

            SharpDX.Vector3 center = (min + max) / 2.0f;
            Window.Renderer.Camera.Position = new SharpDX.Vector3(center.X, center.Z, -center.Y);
        }
    }
}
