﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using KFreonLib.MEDirectories;
using ME1Explorer.Unreal;
using ME2Explorer.Unreal;
using ME3Explorer.Packages;
using ME3Explorer.Unreal;

namespace ME3Explorer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string AppDataFolder { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ME3Explorer\"; } }

        public static readonly string FileFilter = "*.pcc;*.u;*.upk;*sfm|*.pcc;*.u;*.upk;*sfm|All Files (*.*)|*.*";

        public static string Version { get { return GetVersion(); } }

        public static string GetVersion()
        {
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            return "v" + ver.Major + "." + ver.Minor + "." + ver.Build + "." + ver.Revision;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Winforms interop
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Integration.WindowsFormsHost.EnableWindowsFormsInterop();

            //set up AppData Folder
            if (!Directory.Exists(AppDataFolder))
            {
                Directory.CreateDirectory(AppDataFolder);
            }

            //load in data files
            ME3TalkFiles.LoadSavedTlkList();
            ME2Explorer.ME2TalkFiles.LoadSavedTlkList();
            ME1UnrealObjectInfo.loadfromJSON();
            ME2UnrealObjectInfo.loadfromJSON();
            ME3UnrealObjectInfo.loadfromJSON();

            //static class setup
            Tools.Initialize();
            MEPackageHandler.Initialize();

            //load kismet font
            SequenceObjects.SText.LoadFont();

            splashScreen.Close(TimeSpan.FromMilliseconds(1));
            if (HandleCommandLineJumplistCall(Environment.GetCommandLineArgs(), out int exitCode) != 1)
            {
                Shutdown(exitCode);
            }
            else
            {
                this.Dispatcher.UnhandledException += OnDispatcherUnhandledException; //only start handling them after bootup
                (new MainWindow()).Show();
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            ME3Explorer.Properties.Settings.Default.Save();
        }

        private int HandleCommandLineJumplistCall(string[] args, out int exitCode)
        {
            if (args.Length < 2)
            {
                exitCode = 0;
                return 1;
            }

            string arg = args[1];
            if (arg == "JUMPLIST_PACKAGE_EDITOR")
            {
                PackageEditor editor = new PackageEditor();
                editor.BringToFront();
                editor.Show();
                exitCode = 0;
                return 0;
            }
            if (arg == "JUMPLIST_SEQUENCE_EDITOR")
            {
                SequenceEditor editor = new SequenceEditor();
                editor.BringToFront();
                editor.Show();
                exitCode = 0;
                return 0;
            }
            if (arg == "JUMPLIST_PATHFINDING_EDITOR")
            {
                PathfindingEditor editor = new PathfindingEditor();
                editor.BringToFront();
                editor.Show();
                exitCode = 0;
                return 0;
            }

            string ending = Path.GetExtension(args[1]).ToLower();
            switch (ending)
            {
                case ".pcc":
                    PackageEditor editor = new PackageEditor();
                    editor.Show();
                    editor.LoadFile(args[1]);
                    exitCode = 0;
                    return 1;
            }
            exitCode = 0;
            return 1;
        }

        /// <summary>
        /// Called when an unhandled exception occurs. This method can only be invoked after startup has completed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Exception to process</param>
        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            SharedUI.ExceptionHandlerDialogWPF eh = new SharedUI.ExceptionHandlerDialogWPF(e.Exception);
            Window wpfActiveWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            eh.Owner = wpfActiveWindow;
            eh.ShowDialog();
#if DEBUG
            e.Handled = eh.Handled;
#endif
        }
    }
}
