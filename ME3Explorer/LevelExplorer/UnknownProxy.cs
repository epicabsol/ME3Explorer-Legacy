using ME3Explorer.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME3Explorer.LevelExplorer
{
    public class UnknownProxy : BaseProxy
    {
        public UnknownProxy(IExportEntry export, LevelExplorer explorer) : base(export, explorer)
        {
            TreeNode.Text += " (Unknown)";
            TreeNode.ForeColor = System.Drawing.Color.Gray;
        }
    }
}
