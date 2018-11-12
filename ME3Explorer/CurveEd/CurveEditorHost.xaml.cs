﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gibbed.IO;
using ME3Explorer.Packages;
using ME3Explorer.Unreal;

namespace ME3Explorer.CurveEd
{
    /// <summary>
    /// Interaction logic for CurveEditorHost.xaml
    /// </summary>
    public partial class CurveEditorHost : WPFBase
    {
        IExportEntry exp;

        public CurveEditorHost()
        {
            InitializeComponent();
        }

        public CurveEditorHost(IExportEntry exp)
        {
            InitializeComponent();
            this.exp = exp;
            CurveEditor_SubModule.LoadExport(exp);
            Title = "Curve Editor | " + System.IO.Path.GetFileName(exp.FileRef.FileName) + " | " + exp.Index + ": " + exp.ClassName;
        }

        /*
        private void Load()
        {
            InterpCurveTracks = new List<InterpCurve>();
            
            var props = expEntry.GetProperties();
            foreach (var prop in props)
            {
                if (prop is StructProperty structProp)
                {
                    if (Enum.TryParse(structProp.StructType, out CurveType _))
                    {
                        InterpCurveTracks.Add(new InterpCurve(pcc, structProp));
                    }
                }
            }
            
            foreach (var interpCurve in InterpCurveTracks)
            {
                foreach (var curve in interpCurve.Curves)
                {
                    curve.SaveChanges = Commit;
                }
            }

            TrackList.ItemsSource = InterpCurveTracks;
            graph.Paint();
        }

        
        private void TrackList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is Curve)
            {
                graph.SelectedCurve = e.NewValue as Curve;
            }
            graph.Paint(true);
        }

        private void graph_SelectedPointChanged(object sender, RoutedPropertyChangedEventArgs<CurvePoint> e)
        {
            if (e.NewValue == null)
            {
                return;
            }
            switch (e.NewValue.InterpMode)
            {
                case CurveMode.CIM_Linear:
                    btnLinear.IsChecked = true;
                    break;
                case CurveMode.CIM_CurveAuto:
                    btnAuto.IsChecked = true;
                    break;
                case CurveMode.CIM_Constant:
                    btnConstant.IsChecked = true;
                    break;
                case CurveMode.CIM_CurveUser:
                    btnUser.IsChecked = true;
                    break;
                case CurveMode.CIM_CurveBreak:
                    btnBreak.IsChecked = true;
                    break;
                case CurveMode.CIM_CurveAutoClamped:
                    btnClamped.IsChecked = true;
                    break;
                default:
                    break;
            }
        }

        private void btnInterpMode_Click(object sender, RoutedEventArgs e)
        {
            CurvePoint selectedPoint = graph.SelectedPoint;
            switch ((sender as RadioButton).Name)
            {
                case "btnLinear":
                    selectedPoint.InterpMode = CurveMode.CIM_Linear;
                    break;
                case "btnAuto":
                    selectedPoint.InterpMode = CurveMode.CIM_CurveAuto;
                    break;
                case "btnConstant":
                    selectedPoint.InterpMode = CurveMode.CIM_Constant;
                    break;
                case "btnUser":
                    selectedPoint.InterpMode = CurveMode.CIM_CurveUser;
                    break;
                case "btnBreak":
                    selectedPoint.InterpMode = CurveMode.CIM_CurveBreak;
                    break;
                case "btnClamped":
                    selectedPoint.InterpMode = CurveMode.CIM_CurveAutoClamped;
                    break;
                default:
                    break;
            }
            graph.Paint();
            graph.SelectedPoint = selectedPoint;
        }*/

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // Commit();
        }

        /*
        private void Commit()
        {
            var props = expEntry.GetProperties();
            foreach (InterpCurve item in InterpCurveTracks)
            {
                props.AddOrReplaceProp(item.WriteProperties());
            }
            expEntry.WriteProperties(props);
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = InterpCurveTracks.Count > 0;
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Commit();
            pcc.save();
            MessageBox.Show("Done");
        }*/

        public override void handleUpdate(List<PackageUpdate> updates)
        {
            IEnumerable<PackageUpdate> relevantUpdates = updates.Where(x => x.change == PackageChange.ExportData);
            List<int> updatedExports = relevantUpdates.Select(x => x.index).ToList();
            if (updatedExports.Contains(exp.Index) && !this.IsForegroundWindow())
            {
                CurveEditor_SubModule.LoadExport(exp);
            }
        }
    }
}
