﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ME3Explorer.Commands
{
    public static class PackageEditorWPFCommands
    {
        public static RoutedUICommand FindCommand { get; } = new RoutedUICommand("Find", "FindCommand", typeof(PackageEditorWPF));
        public static RoutedUICommand GotoCommand { get; } = new RoutedUICommand("Goto", "GotoEntryCommand", typeof(PackageEditorWPF));
        public static RoutedUICommand NextTabCommand { get; } = new RoutedUICommand("NextTab", "NextTabCommand", typeof(PackageEditorWPF));
        public static RoutedUICommand PreviousTabCommand { get; } = new RoutedUICommand("PreviousTab", "PreviousTabCommand", typeof(PackageEditorWPF));

        public static RoutedUICommand ComparePackageCommand { get; } = new RoutedUICommand("ComparePackage", "ComparePackageCommand", typeof(PackageEditorWPF));

        public static RoutedUICommand CustCommand1 { get; } = new RoutedUICommand("CMD", "CMDCMD", typeof(PackageEditorWPF));

    }
}
