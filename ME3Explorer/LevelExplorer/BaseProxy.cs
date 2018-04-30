﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ME3Explorer.Packages;
using SharpDX;

namespace ME3Explorer.LevelExplorer
{
    /// <summary>
    /// The base class for a proxy representing an item in a Level.
    /// </summary>
    public abstract class BaseProxy : IDisposable
    {
        [Browsable(false)]
        public TreeNode TreeNode { get; private set; }
        [Category("Info")]
        public string Name { get; }
        [Category("Info")]
        public string Type { get; }
        [Browsable(false)]
        public IExportEntry Export { get; }

        [Browsable(false)]
        protected LevelExplorer Window { get; }
        private bool _isSelected = false;
        [Browsable(false)]
        public bool IsSelected
        {
            set
            {
                if (value != IsSelected)
                {
                    _isSelected = value;

                    if (TreeNode.Checked != value)
                        TreeNode.Checked = value;

                    if (IsSelected)
                    {
                        TreeNode.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
                        OnSelected(this, new EventArgs());
                        Selected?.Invoke(this, new EventArgs());
                    }
                    else
                    {
                        TreeNode.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                        OnDeselected(this, new EventArgs());
                        Deselected?.Invoke(this, new EventArgs());
                    }
                }
            }
            get
            {
                return _isSelected;
            }
        }

        public event EventHandler Selected;
        public event EventHandler Deselected;

        public BaseProxy(IExportEntry export, LevelExplorer window)
        {
            Name = export.ObjectName;
            Type = export.ClassName;
            Export = export;
            TreeNode = new TreeNode(Name + " (" + Type + ")");
            TreeNode.Tag = this;
            Window = window;

            foreach (Unreal.UProperty uprop in Export.GetProperties())
            {
                TreeNode node = new TreeNode(uprop.Name + " (" + uprop.PropType + ")");
                TreeNode.Nodes.Add(node);
            }
        }

        public virtual void Render()
        {

        }

        public virtual void Update(float timeStep)
        {

        }

        public virtual float HitTest(Vector3 rayOrigin, Vector3 rayDirection)
        {
            return -1.0f;
        }

        public virtual void NodeDoubleClicked(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        public virtual void Dispose()
        {

        }

        protected virtual void OnSelected(object sender, EventArgs e)
        {

        }

        protected virtual void OnDeselected(object sender, EventArgs e)
        {

        }

        /*
         * Static proxy registry
         */
        private static Dictionary<string, System.Reflection.ConstructorInfo> ProxyDatabase = null;

        public static BaseProxy CreateProxy(IExportEntry export, LevelExplorer window)
        {
            if (ProxyDatabase == null)
            {
                ProxyDatabase = new Dictionary<string, System.Reflection.ConstructorInfo>();
                foreach (var type in System.Reflection.Assembly.GetAssembly(typeof(BaseProxy)).DefinedTypes)
                {
                    foreach (Attribute a in type.GetCustomAttributes(false))
                        if (a is InstanceProxyAttribute proxyInfo)
                            ProxyDatabase.Add(proxyInfo.ClassName, type.GetConstructor(new System.Type[] { typeof(IExportEntry), typeof(LevelExplorer) }));
                }
            }

            if (ProxyDatabase.ContainsKey(export.ClassName))
                return ProxyDatabase[export.ClassName].Invoke(new object[] { export, window }) as BaseProxy;

            return null;
        }
    }

    public class InstanceProxyAttribute : Attribute
    {
        public string ClassName { get; }

        public InstanceProxyAttribute(string className)
        {
            ClassName = className;
        }
    }
}
