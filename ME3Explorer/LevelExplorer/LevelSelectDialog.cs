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

namespace ME3Explorer.LevelExplorer
{
    public partial class LevelSelectDialog : WinFormsBase
    {
        public class LevelSelection
        {
            public string PCCFilename;
            public int ExportID;
        }

        /// <summary>
        /// Class for showing levels in a ListBox.
        /// </summary>
        private class LevelListItem
        {
            public string Name;
            public int ExportID;
            public string Type;

            public LevelListItem(string name, int exportID, string type)
            {
                Name = name;
                ExportID = exportID;
                Type = type;
            }

            public override string ToString()
            {
                return ExportID + " " + Type + " '" + Name + "'";
            }
        }

        private LevelSelection Selection { get; } = new LevelSelection();

        public LevelSelectDialog()
        {
            InitializeComponent();
        }

        private void LevelSelectDialog_Load(object sender, EventArgs e)
        {

        }

        public new LevelSelection ShowDialog()
        {
            if (base.ShowDialog() == DialogResult.OK)
                return Selection;
            else
                return null;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Unreal 3 Package (*.pcc)|*.pcc";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LevelList.Items.Clear();
                PCCPathLabel.Text = dialog.FileName;
                Selection.PCCFilename = dialog.FileName;

                // Populate list box
                LoadME3Package(dialog.FileName);

                foreach (IExportEntry export in pcc.Exports)
                {
                    if (export.ClassName == "Level")
                    {
                        LevelListItem item = new LevelListItem(export.ObjectName, export.Index, export.ClassName);
                        LevelList.Items.Add(item);
                    }
                }

                pcc.Release(null, this);
                pcc.Dispose();
                pcc = null;
            }
        }

        private void LevelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LevelList.SelectedIndex >= 0)
            {
                OKButton.Enabled = true;
                Selection.ExportID = (LevelList.SelectedItem as LevelListItem).ExportID;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LevelList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (LevelList.SelectedIndex >= 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
