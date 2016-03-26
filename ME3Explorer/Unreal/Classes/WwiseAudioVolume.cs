﻿//This class was generated by ME3Explorer
//Author: Warranty Voider
//URL: http://sourceforge.net/projects/me3explorer/
//URL: http://me3explorer.freeforums.org/
//URL: http://www.facebook.com/pages/Creating-new-end-for-Mass-Effect-3/145902408865659
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ME3Explorer.Unreal;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using KFreonLib.Debugging;
using ModJob = KFreonLib.Scripting.ModMaker.ModJob;

namespace ME3Explorer.Unreal.Classes
{
    public class WwiseAudioVolume
    {
        #region Unreal Props

        //Bool Properties

        public bool bAutoPlay = false;
        public bool bLockLocation = false;
        //Name Properties

        public int Tag;
        public int UniqueTag;
        //Object Properties

        public int Brush;
        public int BrushComponent;
        public int CollisionComponent;
        public int AudioComponent;
        //Vector3 Properties

        public Vector3 location;

        #endregion

        public int MyIndex;
        public PCCObject pcc;
        public byte[] data;
        public List<PropertyReader.Property> Props;
        public BrushComponent brush;
        public Matrix MyMatrix;
        public bool isEdited = false;


        public WwiseAudioVolume(PCCObject Pcc, int Index)
        {
            pcc = Pcc;
            MyIndex = Index;
            if (pcc.isExport(Index))
                data = pcc.Exports[Index].Data;
            Props = PropertyReader.getPropList(pcc, pcc.Exports[Index]);
            BitConverter.IsLittleEndian = true;
            foreach (PropertyReader.Property p in Props)
                switch (pcc.getNameEntry(p.Name))
                {

                    case "bAutoPlay":
                        if (p.raw[p.raw.Length - 1] == 1)
                            bAutoPlay = true;
                        break;
                    case "bLockLocation":
                        if (p.raw[p.raw.Length - 1] == 1)
                            bLockLocation = true;
                        break;
                    case "Tag":
                        Tag = p.Value.IntValue;
                        break;
                    case "UniqueTag":
                        UniqueTag = p.Value.IntValue;
                        break;
                    case "Brush":
                        Brush = p.Value.IntValue;
                        break;
                    case "BrushComponent":
                        BrushComponent = p.Value.IntValue;
                        if (pcc.isExport(BrushComponent - 1) && pcc.Exports[BrushComponent - 1].ClassName == "BrushComponent")
                            brush = new BrushComponent(pcc, BrushComponent - 1);
                        break;
                    case "CollisionComponent":
                        CollisionComponent = p.Value.IntValue;
                        break;
                    case "AudioComponent":
                        AudioComponent = p.Value.IntValue;
                        break;
                    case "location":
                        location.X = BitConverter.ToSingle(p.raw, p.raw.Length - 12);
                        location.Y = BitConverter.ToSingle(p.raw, p.raw.Length - 8);
                        location.Z = BitConverter.ToSingle(p.raw, p.raw.Length - 4);
                        break;
                }
            MyMatrix = Matrix.Translation(location);
        }

        public void ProcessTreeClick(int[] path, bool AutoFocus)
        {
            if (brush != null)
                brush.SetSelection(true);
        }

        public void SetSelection(bool Selected)
        {
            if (brush != null)
                brush.SetSelection(Selected);
        }

        public void ApplyTransform(Matrix m)
        {
            if (brush != null && brush.isSelected)
            {
                isEdited = true;
                MyMatrix *= m;
            }
        }

        public void SaveChanges()
        {
            if (isEdited)
            {
                Matrix m = MyMatrix;
                Vector3 loc = new Vector3(m.M41, m.M42, m.M43);
                byte[] buff = Vector3ToBuff(loc);
                int f = -1;
                for (int i = 0; i < Props.Count; i++)
                    if (pcc.getNameEntry(Props[i].Name) == "location")
                    {
                        f = i;
                        break;
                    };
                if (f != -1)//has prop
                {
                    int off = Props[f].offend - 12;
                    for (int i = 0; i < 12; i++)
                        data[off + i] = buff[i];
                }
                else//have to add prop
                {
                    DebugOutput.PrintLn(MyIndex + " : cant find location property");
                }
                pcc.Exports[MyIndex].Data = data;
            }
        }

        public void CreateModJobs()
        {
            if (isEdited)
            {
                Matrix m = MyMatrix;
                Vector3 loc = new Vector3(m.M41, m.M42, m.M43);
                byte[] buff = Vector3ToBuff(loc);
                int f = -1;
                for (int i = 0; i < Props.Count; i++)
                    if (pcc.getNameEntry(Props[i].Name) == "location")
                    {
                        f = i;
                        break;
                    };
                if (f != -1)//has prop
                {
                    int off = Props[f].offend - 12;
                    for (int i = 0; i < 12; i++)
                        data[off + i] = buff[i];
                }
                else//have to add prop
                {
                    DebugOutput.PrintLn(MyIndex + " : cant find location property");
                }
                ModJob mj = new ModJob();
                string currfile = Path.GetFileName(pcc.pccFileName);
                mj.data = data;
                mj.Name = "Binary Replacement for file \"" + currfile + "\" in Object #" + MyIndex + " with " + data.Length + " bytes of data";
                string lc = Path.GetDirectoryName(Application.ExecutablePath);
                string template = System.IO.File.ReadAllText(lc + "\\exec\\JobTemplate_Binary2.txt");
                template = template.Replace("**m1**", MyIndex.ToString());
                template = template.Replace("**m2**", currfile);
                mj.Script = template;
                KFreonLib.Scripting.ModMaker.JobList.Add(mj);
                DebugOutput.PrintLn("Created Mod job : " + mj.Name);
            }
        }

        public byte[] Vector3ToBuff(Vector3 v)
        {
            MemoryStream m = new MemoryStream();
            BitConverter.IsLittleEndian = true;
            m.Write(BitConverter.GetBytes(v.X), 0, 4);
            m.Write(BitConverter.GetBytes(v.Y), 0, 4);
            m.Write(BitConverter.GetBytes(v.Z), 0, 4);
            return m.ToArray();
        }

        public void Render(Device device)
        {
            device.Transform.World = MyMatrix;
            if (brush != null)
                brush.Render(device);
        }

        public TreeNode ToTree()
        {
            TreeNode res = new TreeNode(pcc.Exports[MyIndex].ObjectName + "(#" + MyIndex + ")");
            res.Nodes.Add("bAutoPlay : " + bAutoPlay);
            res.Nodes.Add("bLockLocation : " + bLockLocation);
            res.Nodes.Add("Tag : " + pcc.getNameEntry(Tag));
            res.Nodes.Add("UniqueTag : " + pcc.getNameEntry(UniqueTag));
            res.Nodes.Add("Brush : " + Brush);
            res.Nodes.Add("BrushComponent : " + BrushComponent);
            res.Nodes.Add("CollisionComponent : " + CollisionComponent);
            res.Nodes.Add("AudioComponent : " + AudioComponent);
            if (brush != null)
                res.Nodes.Add(brush.ToTree());
            return res;
        }

    }
}