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

namespace ME3Explorer.LevelExplorer
{
    public partial class LevelExplorer : WinFormsBase
    {
        public IExportEntry LevelEntry { get; private set; }
        public Level LevelObject { get; private set; }

        public List<BaseProxy> Proxies = new List<BaseProxy>();

        public LevelExplorer()
        {
            InitializeComponent();
            //Renderer.Camera.FirstPerson = true;
            Renderer.StrafeSpeed = 800.0f;
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
            Renderer.ImmediateContext.ClearRenderTargetView(Renderer.BackBufferView, new SharpDX.Color(1.0f, 1.0f, 1.0f, 1.0f));

            // TODO: Render grid

            foreach (BaseProxy proxy in Proxies)
            {
                proxy.Render();
            }
        }

        private void sceneRenderControl1_Update(object sender, float e)
        {
            foreach (BaseProxy proxy in Proxies)
                proxy.Update(e);

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
        }

        private void LevelExplorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            pcc.Dispose();
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
    }
}
