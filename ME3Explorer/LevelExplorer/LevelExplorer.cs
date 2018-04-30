using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ME3Explorer.Packages;
using ME3Explorer.Unreal.Classes;
using SharpDX;
using SharpDX.Direct3D11;
using ME3Explorer.Scene3D;

namespace ME3Explorer.LevelExplorer
{
    public partial class LevelExplorer : WinFormsBase
    {
        public IExportEntry LevelEntry { get; private set; }
        public Level LevelObject { get; private set; }

        public List<BaseProxy> Proxies = new List<BaseProxy>();

        private Mesh<PositionColorVertex> GridMesh;
        private Mesh<PositionColorVertex> Grid100Mesh; // 100 times as large as GridMesh. Can't just reuse because different color.
        public Effect<SceneRenderControl.WorldConstants, PositionColorVertex> PositionColorEffect = null;
        public Effect<SceneRenderControl.WorldConstants, WorldVertex> SelectionEffect = null;

        public LevelExplorer()
        {
            InitializeComponent();
            //Renderer.Camera.FirstPerson = true;
            Renderer.StrafeSpeed = 800.0f;
            SceneTree.NodeMouseDoubleClick += SceneTree_NodeMouseDoubleClick;
            SceneTree.AfterCheck += SceneTree_AfterCheck;
            Renderer.MouseClick += Renderer_MouseClick;
            Renderer.MouseDown += Renderer_MouseDown;
            KeyDown += LevelExplorer_KeyDown;
            KeyUp += LevelExplorer_KeyUp;
        }

        private void Renderer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Vector3 eyePos = Renderer.Camera.Position;
                if (!Renderer.Camera.FirstPerson)
                {
                    eyePos += Renderer.Camera.CameraForward * -Renderer.Camera.FocusDepth;
                }
                //Vector3 direction = Renderer.Camera.CameraForward;
                Vector3 direction = Vector3.Unproject(new Vector3(e.X, e.Y, 1.0f), 0, 0, Renderer.Width, Renderer.Height, Renderer.Camera.ZNear, Renderer.Camera.ZFar, Renderer.Camera.ViewMatrix * Renderer.Camera.ProjectionMatrix);
                direction = direction - eyePos;
                direction.Normalize();

                float min = float.MaxValue;
                BaseProxy minProxy = null;
                foreach (BaseProxy proxy in Proxies)
                {
                    float distance = proxy.HitTest(eyePos, direction);

                    if (distance < 0.0f)
                        continue;

                    if (distance < min)
                    {
                        min = distance;
                        minProxy = proxy;
                    }
                }

                if (minProxy != null)
                {
                    KFreonLib.Debugging.DebugOutput.PrintLn("Picked proxy '" + minProxy.Name + "'.");
                }
                else
                {
                    KFreonLib.Debugging.DebugOutput.PrintLn("Picked nothing.");
                }

                if (Renderer.KeyShift)
                {
                    if (minProxy != null)
                        minProxy.IsSelected = !minProxy.IsSelected;
                }
                else
                {
                    foreach (BaseProxy proxy in Proxies)
                        proxy.IsSelected = proxy == minProxy;
                }
            }
        }

        private void LevelExplorer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Menu || e.Alt || e.KeyCode == Keys.Shift || e.Shift)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Renderer.InvokeKeyUp(e);
            }
        }

        private void LevelExplorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Menu || e.Alt || e.KeyCode == Keys.Shift || e.Shift)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Renderer.InvokeKeyDown(e);
            }
        }

        private void Renderer_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void SceneTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                BaseProxy proxy = e.Node.Tag as BaseProxy;
                if (proxy != null)
                {
                    proxy.IsSelected = e.Node.Checked;
                }
            }
        }

        private void UpdateTitleText()
        {
            Text = "Level Explorer: " + LevelEntry.ObjectName + " (" + pcc.FileName + ")";
        }

        private void RefreshSceneTree()
        {
            SceneTree.Nodes.Clear();
            foreach (BaseProxy proxy in Proxies)
                SceneTree.Nodes.Add(proxy.TreeNode);
        }

        private void openPCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelSelectDialog.LevelSelection selection = (new LevelSelectDialog()).ShowDialog();
            if (selection == null)
                return;

            pcc?.Release(null, this);
            pcc?.Dispose();

            LoadME3Package(selection.PCCFilename);
            LevelEntry = pcc.getExport(selection.ExportID);
            UpdateTitleText();

            LevelObject = new Level(pcc as ME3Package, LevelEntry.Index, true);
            foreach (BaseProxy proxy in Proxies)
                proxy.Dispose();
            Proxies.Clear();
            // Enumerate level objects
            //LevelObject.Deserialize(true);
            LoadProgressBar.Visible = true;
            LoadProgressBar.Value = 0;
            LoadProgressBar.Maximum = LevelObject.Objects.Count;
            foreach (int index in LevelObject.Objects)
            {
                System.Diagnostics.Debug.WriteLine("#" + index + ": " + pcc.getExport(index).ClassName + " '" + pcc.getExport(index).ObjectName + "'");
                BaseProxy proxy = BaseProxy.CreateProxy(pcc.getExport(index), this);
                if (proxy != null)
                {
                    Proxies.Add(proxy);
                    SceneTree.Nodes.Add(proxy.TreeNode);
                }
                LoadProgressBar.Value++;
            }
            LoadProgressBar.Visible = false;
            Renderer.Invalidate();
        }

        private void sceneRenderControl1_Render(object sender, EventArgs e)
        {
            Renderer.ImmediateContext.ClearRenderTargetView(Renderer.BackBufferView, new SharpDX.Color(0.3f, 0.3f, 0.3f, 1.0f));

            PositionColorEffect.PrepDraw(Renderer.ImmediateContext);
            Matrix gridTransform = Matrix.Translation((float)Math.Floor(Renderer.Camera.Position.X), 0, (float)Math.Floor(Renderer.Camera.Position.Z));
            PositionColorEffect.RenderObject(Renderer.ImmediateContext, new SceneRenderControl.WorldConstants(Matrix.Transpose(Renderer.Camera.ProjectionMatrix), Matrix.Transpose(Renderer.Camera.ViewMatrix), Matrix.Transpose(gridTransform)), GridMesh);
            gridTransform = Matrix.Translation((float)Math.Floor(Renderer.Camera.Position.X / 100.0f) * 100.0f, 0, (float)Math.Floor(Renderer.Camera.Position.Z / 100.0f) * 100.0f);
            PositionColorEffect.RenderObject(Renderer.ImmediateContext, new SceneRenderControl.WorldConstants(Matrix.Transpose(Renderer.Camera.ProjectionMatrix), Matrix.Transpose(Renderer.Camera.ViewMatrix), Matrix.Transpose(gridTransform)), Grid100Mesh);

            foreach (BaseProxy proxy in Proxies)
            {
                proxy.Render();
            }
        }

        private void sceneRenderControl1_Update(object sender, float e)
        {
            foreach (BaseProxy proxy in Proxies)
                proxy.Update(e);

            CameraStatusLabel.Text = "Camera: " + (Renderer.Camera.FirstPerson ? "First" : "Third") + " Person at Unreal <" + Math.Round(Renderer.Camera.Position.X, 2) + ", " + Math.Round(-Renderer.Camera.Position.Z, 2) + ", " + Math.Round(Renderer.Camera.Position.Y, 2) + ">";
            //Text = Renderer.Camera.Position.ToString();
        }

        private void exportRawBinaryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.IO.File.WriteAllBytes("levelRaw.bin", pcc.getExport(LevelEntry.Index).getBinaryData());
        }

        private void SceneTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (SceneTree.SelectedNode != null)
            {
                propertyGrid1.SelectedObject = SceneTree.SelectedNode.Tag;
            }
        }

        private void LevelExplorer_Load(object sender, EventArgs e)
        {
            Renderer.LoadDirect3D();
            GridMesh = Mesh<PositionColorVertex>.CreateGrid(Renderer.Device, -100, 100, -100, 100, new Vector3(0.6f, 0.6f, 0.6f));
            Grid100Mesh = Mesh<PositionColorVertex>.CreateGrid(Renderer.Device, -100 * 100, 100 * 100, -100 * 100, 100 * 100, new Vector3(0.9f, 0.9f, 0.9f), 100, 100);
            PositionColorEffect = new Effect<SceneRenderControl.WorldConstants, PositionColorVertex>(Renderer.Device, Properties.Resources.ColorShader);
            SelectionEffect = new Effect<SceneRenderControl.WorldConstants, WorldVertex>(Renderer.Device, Properties.Resources.SelectionShader);
        }

        private void LevelExplorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            pcc?.Dispose();
            GridMesh.Dispose();
            Grid100Mesh.Dispose();
            PositionColorEffect.Dispose();
            SelectionEffect.Dispose();
            Renderer.UnloadDirect3D();
            foreach (BaseProxy proxy in Proxies)
                proxy.Dispose();
        }

        private void firstPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool old = Renderer.Camera.FirstPerson;
            Renderer.Camera.FirstPerson = firstPersonToolStripMenuItem.Checked;
            // Adjust view position so the camera doesn't teleport
            if (!old && Renderer.Camera.FirstPerson)
            {
                Renderer.Camera.Position += -Renderer.Camera.CameraForward * Renderer.Camera.FocusDepth;
            }
            else if (old && !Renderer.Camera.FirstPerson)
            {
                Renderer.Camera.Position += Renderer.Camera.CameraForward * Renderer.Camera.FocusDepth;
            }
            Renderer.Invalidate();
        }

        private void SceneUpdateTimer_Tick(object sender, EventArgs e)
        {
            Renderer.UpdateScene();
            Renderer.RenderScene();
        }

        private void SceneTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BaseProxy proxy = e.Node.Tag as BaseProxy;
            proxy?.NodeDoubleClicked(sender, e);
        }
    }
}
