using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ME3Explorer;
using ME3Explorer.Packages;
using SharpDX;

namespace ME3Explorer.LevelExplorer.Proxies
{
    [InstanceProxy("StaticMeshActor")]
    public class StaticMeshActorProxy : BaseProxy
    {
        [Category("Collision")]
        public bool bCollideActors
        {
            get { return Actor.bCollideActors; }
            set { Actor.bCollideActors = value; }
        }

        [Category("Collision")]
        public bool bCanStepUpOn
        {
            get { return Actor.bCanStepUpOn; }
            set { Actor.bCanStepUpOn = value; }
        }

        [Category("Collision")]
        public bool bPathColliding
        {
            get { return Actor.bPathColliding; }
            set { Actor.bPathColliding = value; }
        }

        [Category("Transform")]
        public bool bLockLocation
        {
            get { return Actor.bLockLocation; }
            set { Actor.bLockLocation = value; }
        }

        [Category("Collision")]
        public bool OverridePhysicsMat
        {
            get { return Actor.OverridePhysMat; }
            set { Actor.OverridePhysMat = value; }
        }

        [Category("Display")]
        public bool bHidden
        {
            get { return Actor.bHidden; }
            set { Actor.bHidden = value; }
        }

        [Category("Display")]
        public bool bShadowParented
        {
            get { return Actor.bShadowParented; }
            set { Actor.bShadowParented = value; }
        }

        [Category("Collision")]
        public bool bCollideComplex
        {
            get { return Actor.bCollideComplex; }
            set { Actor.bCollideComplex = value; }
        }

        [Category("Editor")]
        public bool bHiddenEd
        {
            get { return Actor.bHiddenEd; }
            set { Actor.bHiddenEd = value; }
        }

        [Category("Editor")]
        public int Tag
        {
            get { return Actor.Tag; }
            set { Actor.Tag = value; }
        }

        [Category("Editor")]
        public int Group
        {
            get { return Actor.Group; }
            set { Actor.Group = value; }
        }

        [Category("Editor")]
        public int UniqueTag
        {
            get { return Actor.UniqueTag; }
            set { Actor.UniqueTag = value; }
        }

        [Category("Transform")]
        public float DrawScale
        {
            get { return Actor.DrawScale; }
            set { Actor.DrawScale = value; }
        }

        [Category("Editor")]
        public float CreationTime
        {
            get { return Actor.CreationTime; }
            set { Actor.CreationTime = value; }
        }

        [Category("Audio")]
        public float AudioOcclusion
        {
            get { return Actor.AudioOcclusion; }
            set { Actor.AudioOcclusion = value; }
        }

        [Category("Transform")]
        public Vector3Helper location
        {
            get { return Actor.location; }
            set { Actor.location = value; }
        }

        [Category("Transform")]
        public Vector3Helper Rotation
        {
            get { return Actor.RotatorToDX(Actor.Rotator); }
            set { Actor.Rotator = Actor.DxToRotator(value); }
        }

        [Category("Transform")]
        public Vector3Helper DrawScale3D
        {
            get { return Actor.DrawScale3D; }
            set { Actor.DrawScale3D = value; }
        }

        [Category("Display")]
        public int StaticMeshComponent
        {
            get { return Actor.StaticMeshComponent; }
            set { Actor.StaticMeshComponent = value; }
        }

        [Category("Collision")]
        public int CollisionComponent
        {
            get { return Actor.CollisionComponent; }
            set { Actor.CollisionComponent = value; }
        }

        private Unreal.Classes.StaticMeshActor Actor = null;
        private Unreal.Classes.StaticMeshComponent Component = null;
        private Scene3D.ModelPreview Preview = null;

        private Matrix RenderingMatrix
        {
            get
            {
                Unreal.Classes.StaticMeshComponent com = Component;
                SharpDX.Matrix YZConvert = SharpDX.Matrix.RotationX(SharpDX.MathUtil.PiOverTwo);
                SharpDX.Matrix YZInverse = YZConvert;
                YZInverse.Invert();
                if (com.Translation.X != 0 || com.Translation.Y != 0 || com.Translation.Z != 0 || com.Rotation.X != 0 || com.Rotation.Y != 0 || com.Rotation.Z != 0)
                    System.Diagnostics.Debugger.Break();
                SharpDX.Matrix comTransform = SharpDX.Matrix.Translation(com.Translation.X, com.Translation.Y, com.Translation.Z) * SharpDX.Matrix.RotationYawPitchRoll(com.RotatorToDX(com.Rotation).X, com.RotatorToDX(com.Rotation).Y, com.RotatorToDX(com.Rotation).Z) * SharpDX.Matrix.Scaling(-com.Scale3D.X * com.Scale, -com.Scale3D.Y * com.Scale, com.Scale3D.Z * com.Scale);
                SharpDX.Matrix actorTransform = SharpDX.Matrix.RotationYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z) * SharpDX.Matrix.Scaling(DrawScale3D.X * DrawScale, DrawScale3D.Y * DrawScale, DrawScale3D.Z * DrawScale) * SharpDX.Matrix.Translation(location.X, location.Y, location.Z);
                return YZConvert * comTransform * actorTransform * YZInverse;
            }
        }

        public StaticMeshActorProxy(IExportEntry export, LevelExplorer window) : base(export, window)
        {
            Actor = new Unreal.Classes.StaticMeshActor(window.pcc as ME3Package, export.Index);
            Component = Actor.STMC;
            if (Component?.STM != null)
                Preview = new Scene3D.ModelPreview(window.Renderer.Device, Component.STM, window.Renderer.TextureCache);
        }

        public override void Render()
        {
            if (bHidden || bHiddenEd)
                return;

            Preview?.Render(Window.Renderer, 0, RenderingMatrix);
            if (Preview != null && IsSelected)
            {
                bool wasWire = Window.Renderer.Wireframe;
                Window.Renderer.Wireframe = true;

                Scene3D.SceneRenderControl.WorldConstants ViewConstants = new Scene3D.SceneRenderControl.WorldConstants(SharpDX.Matrix.Transpose(Window.Renderer.Camera.ProjectionMatrix), SharpDX.Matrix.Transpose(Window.Renderer.Camera.ViewMatrix), SharpDX.Matrix.Transpose(RenderingMatrix));
                Window.SelectionEffect.PrepDraw(Window.Renderer.ImmediateContext);
                Window.SelectionEffect.RenderObject(Window.Renderer.ImmediateContext, ViewConstants, Preview.LODs[0].Mesh, new SharpDX.Direct3D11.ShaderResourceView[] { null });


                Window.Renderer.Wireframe = wasWire;
            }

            base.Render();
        }

        public override void Dispose()
        {
            Preview?.Dispose();
            Preview = null;
            base.Dispose();
        }

        public override void NodeDoubleClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            base.NodeDoubleClicked(sender, e);
            Window.Renderer.Camera.Position = new SharpDX.Vector3(location.X, location.Z, -location.Y);
        }

        public override float HitTest(Vector3 rayOrigin, Vector3 rayDirection)
        {
            if (Preview == null)
                return -1.0f;

            // Create transformation to take the ray from world space rendering coords (y-up) to model space Unreal coords
            Matrix finalTransform = RenderingMatrix;
            finalTransform.Invert();
            rayOrigin = Vector3.TransformCoordinate(rayOrigin, finalTransform);
            rayDirection = Vector3.TransformNormal(rayDirection, finalTransform);

            Ray ray = new Ray(rayOrigin, rayDirection);

            return Preview.LODs[0].Mesh.HitTest(ray);
        }
    }
}
