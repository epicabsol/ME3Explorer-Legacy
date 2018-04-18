using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ME3Explorer.Packages;
using ME3Explorer.Scene3D;

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
                    Unreal.Classes.StaticMeshComponent com = Components[i].Component;
                    if (com.Translation.X != 0 || com.Translation.Y != 0 || com.Translation.Z != 0 || com.Rotation.X != 0 || com.Rotation.Y != 0 || com.Rotation.Z != 0)
                        System.Diagnostics.Debugger.Break();
                    SharpDX.Matrix YZConvert = SharpDX.Matrix.RotationX(SharpDX.MathUtil.PiOverTwo);
                    SharpDX.Matrix YZInverse = YZConvert;
                    YZInverse.Invert();
                    SharpDX.Matrix comTransform = SharpDX.Matrix.Translation(com.Translation.X, com.Translation.Y, com.Translation.Z) * SharpDX.Matrix.RotationYawPitchRoll(Components[i].Rotation.X, Components[i].Rotation.Y, Components[i].Rotation.Z) * SharpDX.Matrix.Scaling(-com.Scale3D.X * com.Scale, -com.Scale3D.Y * com.Scale, com.Scale3D.Z * com.Scale);
                    Components[i].Preview.Render(Window.Renderer, 0, YZConvert * comTransform * Actor.Matrices[i] * YZInverse);
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (ComponentProxy component in Components)
                component?.Preview.Dispose();
        }
    }
}
