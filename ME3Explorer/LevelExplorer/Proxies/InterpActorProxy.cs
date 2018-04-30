using ME3Explorer.Packages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX;

namespace ME3Explorer.LevelExplorer.Proxies
{
    [InstanceProxy("InterpActor")]
    public class InterpActorProxy : BaseProxy
    {
        // byte
        [Category("Collision")]
        public int Physics
        {
            get { return Actor.Physics; }
            set { Actor.Physics = value; }
        }

        // byte
        [Description("The role of this instance of Unreal with regards to networking this actor. See https://docs.unrealengine.com/en-us/Gameplay/Networking/Actors/Roles")]
        [Category("Network")]
        public int RemoteRole
        {
            get { return Actor.RemoteRole; }
            set { Actor.RemoteRole = value; }
        }

        [Category("Advanced")]
        public bool bHardAttach
        {
            get { return Actor.bHardAttach; }
            set { Actor.bHardAttach = value; }
        }

        [Category("Behavior")]
        public bool bStopOnEncroach
        {
            get { return Actor.bStopOnEncroach; }
            set { Actor.bStopOnEncroach = value; }
        }

        [Category("Advanced")]
        public bool bHiddenEdGroup
        {
            get { return Actor.bHiddenEdGroup; }
            set { Actor.bHiddenEdGroup = value; }
        }

        [Category("Collision")]
        public bool bNoEncroachCheck
        {
            get { return Actor.bNoEncroachCheck; }
            set { Actor.bNoEncroachCheck = value; }
        }

        [Category("Collision")]
        [Description("If a Pawn can be 'based' on this KActor. If not, they will 'bounce' off when they try to.")]
        public bool bPawnCanBaseOn
        {
            get { return Actor.bPawnCanBaseOn; }
            set { Actor.bPawnCanBaseOn = value; }
        }

        [Category("Collision")]
        public bool bBlockActors
        {
            get { return Actor.bBlockActors; }
            set { Actor.bBlockActors = value; }
        }

        [Category("Behavior")]
        public bool bBioSnapToBase
        {
            get { return Actor.bBioSnapToBase; }
            set { Actor.bBlockActors = value; }
        }

        [Category("Attachment")]
        public bool bIgnoreBaseRotation
        {
            get { return Actor.bIgnoreBaseRotation; }
            set { Actor.bIgnoreBaseRotation = value; }
        }

        // NameIndex
        [Category("Attachment")]
        public int BaseBoneName
        {
            get { return Actor.BaseBoneName; }
            set { Actor.BaseBoneName = value; }
        }

        // ObjectIndex
        [Category("Display")]
        public int LightEnvironment
        {
            get { return Actor.LightEnvironment; }
            set { Actor.LightEnvironment = value; }
        }

        // ObjectIndex
        [Category("Attachment")]
        public int Base
        {
            get { return Actor.Base; }
            set { Actor.Base = value; }
        }

        // ObejctIndex
        [Category("Attachment")]
        public int BaseSkelComponent
        {
            get { return Actor.BaseSkelComponent; }
            set { Actor.BaseSkelComponent = value; }
        }

        [Category("Advanced")]
        public float TickFrequencyAtEndDistance
        {
            get { return Actor.TickFrequencyAtEndDistance; }
            set { Actor.TickFrequencyAtEndDistance = value; }
        }

        [Category("Network")]
        public float NetUpdateFrequency
        {
            get { return Actor.NetUpdateFrequency; }
            set { Actor.NetUpdateFrequency = value; }
        }

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

        [Category("Advanced")]
        public bool bLockLocation
        {
            get { return Actor.bLockLocation; }
            set { Actor.bLockLocation = value; }
        }

        [Category("Display")]
        public bool bHidden
        {
            get { return Actor.bHidden; }
            set { Actor.bHidden = value; }
        }

        [Category("Attachment")]
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

        private Unreal.Classes.InterpActor Actor = null;
        private Unreal.Classes.StaticMeshComponent Component = null;
        private Scene3D.ModelPreview Preview = null;

        public InterpActorProxy(IExportEntry export, LevelExplorer window) : base(export, window)
        {
            Actor = new Unreal.Classes.InterpActor(window.pcc as ME3Package, export.Index);
            Component = Actor.STMC;
            if (Component?.STM != null)
                Preview = new Scene3D.ModelPreview(window.Renderer.Device, Component.STM, window.Renderer.TextureCache);
        }

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

        public override void NodeDoubleClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            base.NodeDoubleClicked(sender, e);
            Window.Renderer.Camera.Position = new SharpDX.Vector3(location.X, location.Z, -location.Y);
        }
    }
}
