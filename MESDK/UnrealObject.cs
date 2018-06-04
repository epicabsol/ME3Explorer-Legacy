using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ME3Explorer.Packages;
using ME3Explorer.Unreal;

namespace MESDK
{
    public class UnrealObject
    {
        public IExportEntry Export { get; } = null;

        public UnrealObject(IExportEntry export)
        {
            Export = export;
        }
    }
}
