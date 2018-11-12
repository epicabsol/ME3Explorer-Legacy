﻿namespace ME3Explorer
{
    partial class PackageEditor
    {

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageEditor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogueEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faceFXEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meshplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathfindingEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wWiseBankEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInInterpreterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceWithBINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInCurveEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebuildStreamingLevelsListForBioWorldInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadTLKsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modjobsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createBinaryReplaceJobFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createBinaryReplaceJobFromObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getDumpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.findImportexportViaOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkIndexingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findExportsWithSerialSizeMismatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEBUGCallReadPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEBUGEnumerateAllClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEBUGOpenPackageEditorWPFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEBUGEnsureFolderOfPackageFilesHasANameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEBUGAddAPropertyToExportsMatchingCriteriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEBUGFindMateriaInstancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Button1 = new System.Windows.Forms.ToolStripButton();
            this.Button2 = new System.Windows.Forms.ToolStripButton();
            this.Button3 = new System.Windows.Forms.ToolStripButton();
            this.Button5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.combo1 = new System.Windows.Forms.ToolStripComboBox();
            this.findClassButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.searchBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.gotonumber = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.filenameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.nameContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.packageEditorTabPane = new System.Windows.Forms.TabControl();
            this.propertiesTab = new System.Windows.Forms.TabPage();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.interpreterTab = new System.Windows.Forms.TabPage();
            this.interpreterControl = new ME3Explorer.Interpreter();
            this.binaryEditorTab = new System.Windows.Forms.TabPage();
            this.binaryInterpreterControl = new ME3Explorer.BinaryInterpreter();
            this.bio2daEditorTab = new System.Windows.Forms.TabPage();
            this.bio2DAEditor1 = new ME3Explorer.Bio2DAEditor();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.infoExportDataBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.infoHeaderBox = new System.Windows.Forms.GroupBox();
            this.superclassTextBox = new System.Windows.Forms.TextBox();
            this.superclassLabel = new System.Windows.Forms.Label();
            this.flagsBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.archetypeBox = new System.Windows.Forms.TextBox();
            this.indexBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.headerSizeBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.packageNameBox = new System.Windows.Forms.TextBox();
            this.classNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.objectNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.metaDataPage = new System.Windows.Forms.TabPage();
            this.showFullPathsCheckbox = new System.Windows.Forms.CheckBox();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.indexLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.archetypeLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.archetypeComboBox = new System.Windows.Forms.ComboBox();
            this.linkComboBox = new System.Windows.Forms.ComboBox();
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.headerTab = new System.Windows.Forms.TabPage();
            this.headerRawHexBox = new Be.Windows.Forms.HexBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.saveHeaderHexChangesBtn = new System.Windows.Forms.ToolStripButton();
            this.scriptTab = new System.Windows.Forms.TabPage();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.nodeContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reindexClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllIndexesInThisTreeTo0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleformSWFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractSWFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceSWFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cloneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.compareWithAnotherVersionOfThisPccToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.nameContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.packageEditorTabPane.SuspendLayout();
            this.propertiesTab.SuspendLayout();
            this.interpreterTab.SuspendLayout();
            this.binaryEditorTab.SuspendLayout();
            this.bio2daEditorTab.SuspendLayout();
            this.infoTab.SuspendLayout();
            this.infoExportDataBox.SuspendLayout();
            this.infoHeaderBox.SuspendLayout();
            this.metaDataPage.SuspendLayout();
            this.headerTab.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.scriptTab.SuspendLayout();
            this.nodeContextMenuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.modjobsToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(958, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsMenuItem,
            this.openInToolStripMenuItem,
            this.toolStripMenuItem1,
            this.recentToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.ToolTipText = "Load an uncompressed or compressed PCC file";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.ToolTipText = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveAsMenuItem.Text = "Save As";
            this.saveAsMenuItem.ToolTipText = "Save As";
            this.saveAsMenuItem.Click += new System.EventHandler(this.appendSaveToolStripMenuItem_Click);
            // 
            // openInToolStripMenuItem
            // 
            this.openInToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dialogueEditorToolStripMenuItem,
            this.faceFXEditorToolStripMenuItem,
            this.meshplorerToolStripMenuItem,
            this.pathfindingEditorToolStripMenuItem,
            this.sequenceEditorToolStripMenuItem,
            this.wWiseBankEditorToolStripMenuItem});
            this.openInToolStripMenuItem.Name = "openInToolStripMenuItem";
            this.openInToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.openInToolStripMenuItem.Text = "Open in...";
            // 
            // dialogueEditorToolStripMenuItem
            // 
            this.dialogueEditorToolStripMenuItem.Name = "dialogueEditorToolStripMenuItem";
            this.dialogueEditorToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.dialogueEditorToolStripMenuItem.Text = "Dialogue Editor";
            this.dialogueEditorToolStripMenuItem.Click += new System.EventHandler(this.dialogueEditorToolStripMenuItem_Click);
            // 
            // faceFXEditorToolStripMenuItem
            // 
            this.faceFXEditorToolStripMenuItem.Name = "faceFXEditorToolStripMenuItem";
            this.faceFXEditorToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.faceFXEditorToolStripMenuItem.Text = "FaceFX Editor";
            this.faceFXEditorToolStripMenuItem.Click += new System.EventHandler(this.faceFXEditorToolStripMenuItem_Click);
            // 
            // meshplorerToolStripMenuItem
            // 
            this.meshplorerToolStripMenuItem.Name = "meshplorerToolStripMenuItem";
            this.meshplorerToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.meshplorerToolStripMenuItem.Text = "Meshplorer";
            this.meshplorerToolStripMenuItem.Click += new System.EventHandler(this.meshplorerToolStripMenuItem_Click);
            // 
            // pathfindingEditorToolStripMenuItem
            // 
            this.pathfindingEditorToolStripMenuItem.Name = "pathfindingEditorToolStripMenuItem";
            this.pathfindingEditorToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.pathfindingEditorToolStripMenuItem.Text = "Pathfinding Editor";
            this.pathfindingEditorToolStripMenuItem.Click += new System.EventHandler(this.pathfindingEditorToolstripMenuItem_Click);
            // 
            // sequenceEditorToolStripMenuItem
            // 
            this.sequenceEditorToolStripMenuItem.Name = "sequenceEditorToolStripMenuItem";
            this.sequenceEditorToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.sequenceEditorToolStripMenuItem.Text = "Sequence Editor";
            this.sequenceEditorToolStripMenuItem.Click += new System.EventHandler(this.sequenceEditorToolStripMenuItem_Click);
            // 
            // wWiseBankEditorToolStripMenuItem
            // 
            this.wWiseBankEditorToolStripMenuItem.Name = "wWiseBankEditorToolStripMenuItem";
            this.wWiseBankEditorToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.wWiseBankEditorToolStripMenuItem.Text = "WWiseBank Editor";
            this.wWiseBankEditorToolStripMenuItem.Click += new System.EventHandler(this.wWiseBankEditorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 6);
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.recentToolStripMenuItem.Text = "Recent";
            this.recentToolStripMenuItem.ToolTipText = "Open recently opened file";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hexConverterToolStripMenuItem,
            this.addNameToolStripMenuItem,
            this.editInInterpreterToolStripMenuItem,
            this.replaceWithBINToolStripMenuItem,
            this.editInCurveEditorToolStripMenuItem,
            this.rebuildStreamingLevelsListForBioWorldInfoToolStripMenuItem,
            this.reloadTLKsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // hexConverterToolStripMenuItem
            // 
            this.hexConverterToolStripMenuItem.AutoToolTip = true;
            this.hexConverterToolStripMenuItem.Name = "hexConverterToolStripMenuItem";
            this.hexConverterToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.hexConverterToolStripMenuItem.Text = "Hex Converter";
            this.hexConverterToolStripMenuItem.Click += new System.EventHandler(this.hexConverterToolStripMenuItem_Click);
            // 
            // addNameToolStripMenuItem
            // 
            this.addNameToolStripMenuItem.Name = "addNameToolStripMenuItem";
            this.addNameToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.addNameToolStripMenuItem.Text = "Add Name";
            this.addNameToolStripMenuItem.ToolTipText = "Add a name to the name table";
            this.addNameToolStripMenuItem.Click += new System.EventHandler(this.addNameToolStripMenuItem_Click);
            // 
            // editInInterpreterToolStripMenuItem
            // 
            this.editInInterpreterToolStripMenuItem.Name = "editInInterpreterToolStripMenuItem";
            this.editInInterpreterToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.editInInterpreterToolStripMenuItem.Text = "Edit in Interpreter";
            this.editInInterpreterToolStripMenuItem.ToolTipText = "Open this export in the interpreter";
            this.editInInterpreterToolStripMenuItem.Click += new System.EventHandler(this.editInInterpreterToolStripMenuItem_Click);
            // 
            // replaceWithBINToolStripMenuItem
            // 
            this.replaceWithBINToolStripMenuItem.Name = "replaceWithBINToolStripMenuItem";
            this.replaceWithBINToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.replaceWithBINToolStripMenuItem.Text = "Replace with BIN";
            this.replaceWithBINToolStripMenuItem.Click += new System.EventHandler(this.replaceWithBINToolStripMenuItem_Click);
            // 
            // editInCurveEditorToolStripMenuItem
            // 
            this.editInCurveEditorToolStripMenuItem.Name = "editInCurveEditorToolStripMenuItem";
            this.editInCurveEditorToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.editInCurveEditorToolStripMenuItem.Text = "Edit in Curve Editor";
            this.editInCurveEditorToolStripMenuItem.Click += new System.EventHandler(this.editInCurveEditorToolStripMenuItem_Click);
            // 
            // rebuildStreamingLevelsListForBioWorldInfoToolStripMenuItem
            // 
            this.rebuildStreamingLevelsListForBioWorldInfoToolStripMenuItem.Name = "rebuildStreamingLevelsListForBioWorldInfoToolStripMenuItem";
            this.rebuildStreamingLevelsListForBioWorldInfoToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.rebuildStreamingLevelsListForBioWorldInfoToolStripMenuItem.Text = "Rebuild StreamingLevels list for BioWorldInfo";
            this.rebuildStreamingLevelsListForBioWorldInfoToolStripMenuItem.Click += new System.EventHandler(this.rebuildStreamingLevelsListForBioWorldInfoToolStripMenuItem_Click);
            // 
            // reloadTLKsToolStripMenuItem
            // 
            this.reloadTLKsToolStripMenuItem.Name = "reloadTLKsToolStripMenuItem";
            this.reloadTLKsToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.reloadTLKsToolStripMenuItem.Text = "Reload TLKs";
            this.reloadTLKsToolStripMenuItem.ToolTipText = "Reloads the TLK files used by ME3Explorer for displaying StringRefProperty.";
            this.reloadTLKsToolStripMenuItem.Click += new System.EventHandler(this.reloadTLKsToolStripMenuItem_Click);
            // 
            // modjobsToolStripMenuItem
            // 
            this.modjobsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createBinaryReplaceJobFromFileToolStripMenuItem,
            this.createBinaryReplaceJobFromObjectToolStripMenuItem,
            this.compareWithAnotherVersionOfThisPccToolStripMenuItem});
            this.modjobsToolStripMenuItem.Name = "modjobsToolStripMenuItem";
            this.modjobsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.modjobsToolStripMenuItem.Text = "Modmaking";
            // 
            // createBinaryReplaceJobFromFileToolStripMenuItem
            // 
            this.createBinaryReplaceJobFromFileToolStripMenuItem.Name = "createBinaryReplaceJobFromFileToolStripMenuItem";
            this.createBinaryReplaceJobFromFileToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.createBinaryReplaceJobFromFileToolStripMenuItem.Text = "Create Binary Replace Job from File";
            this.createBinaryReplaceJobFromFileToolStripMenuItem.Click += new System.EventHandler(this.createBinaryReplaceJobFromFileToolStripMenuItem_Click);
            // 
            // createBinaryReplaceJobFromObjectToolStripMenuItem
            // 
            this.createBinaryReplaceJobFromObjectToolStripMenuItem.Name = "createBinaryReplaceJobFromObjectToolStripMenuItem";
            this.createBinaryReplaceJobFromObjectToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.createBinaryReplaceJobFromObjectToolStripMenuItem.Text = "Create Binary Replace Job from Object";
            this.createBinaryReplaceJobFromObjectToolStripMenuItem.Click += new System.EventHandler(this.createBinaryReplaceJobFromObjectToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getDumpToolStripMenuItem,
            this.getDumpToolStripMenuItem1,
            this.findImportexportViaOffsetToolStripMenuItem,
            this.checkIndexingToolStripMenuItem,
            this.findExportsWithSerialSizeMismatchToolStripMenuItem,
            this.dEBUGCallReadPropertiesToolStripMenuItem,
            this.dEBUGEnumerateAllClassesToolStripMenuItem,
            this.dEBUGOpenPackageEditorWPFToolStripMenuItem,
            this.dEBUGEnsureFolderOfPackageFilesHasANameToolStripMenuItem,
            this.dEBUGAddAPropertyToExportsMatchingCriteriaToolStripMenuItem,
            this.dEBUGFindMateriaInstancesToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.debugToolStripMenuItem.Text = "Debugging";
            // 
            // getDumpToolStripMenuItem
            // 
            this.getDumpToolStripMenuItem.Name = "getDumpToolStripMenuItem";
            this.getDumpToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.getDumpToolStripMenuItem.Text = "Dump Complete Export to Binary File";
            this.getDumpToolStripMenuItem.Click += new System.EventHandler(this.getDumpToolStripMenuItem_Click_1);
            // 
            // getDumpToolStripMenuItem1
            // 
            this.getDumpToolStripMenuItem1.Name = "getDumpToolStripMenuItem1";
            this.getDumpToolStripMenuItem1.Size = new System.Drawing.Size(358, 22);
            this.getDumpToolStripMenuItem1.Text = "Dump Binary Data of Export to Binary File";
            this.getDumpToolStripMenuItem1.Click += new System.EventHandler(this.getDumpToolStripMenuItem1_Click);
            // 
            // findImportexportViaOffsetToolStripMenuItem
            // 
            this.findImportexportViaOffsetToolStripMenuItem.Name = "findImportexportViaOffsetToolStripMenuItem";
            this.findImportexportViaOffsetToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.findImportexportViaOffsetToolStripMenuItem.Text = "Find Export via File Offset";
            this.findImportexportViaOffsetToolStripMenuItem.ToolTipText = "Finds an export containing the offset you specify.";
            this.findImportexportViaOffsetToolStripMenuItem.Click += new System.EventHandler(this.findImportexportViaOffsetToolStripMenuItem_Click);
            // 
            // checkIndexingToolStripMenuItem
            // 
            this.checkIndexingToolStripMenuItem.Name = "checkIndexingToolStripMenuItem";
            this.checkIndexingToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.checkIndexingToolStripMenuItem.Text = "Verify Indexing";
            this.checkIndexingToolStripMenuItem.Click += new System.EventHandler(this.checkIndexingToolStripMenuItem_Click);
            // 
            // findExportsWithSerialSizeMismatchToolStripMenuItem
            // 
            this.findExportsWithSerialSizeMismatchToolStripMenuItem.Name = "findExportsWithSerialSizeMismatchToolStripMenuItem";
            this.findExportsWithSerialSizeMismatchToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.findExportsWithSerialSizeMismatchToolStripMenuItem.Text = "Find Exports with Serial Size Mismatch";
            this.findExportsWithSerialSizeMismatchToolStripMenuItem.Click += new System.EventHandler(this.findExportsWithSerialSizeMismatchToolStripMenuItem_Click);
            // 
            // dEBUGCallReadPropertiesToolStripMenuItem
            // 
            this.dEBUGCallReadPropertiesToolStripMenuItem.Name = "dEBUGCallReadPropertiesToolStripMenuItem";
            this.dEBUGCallReadPropertiesToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.dEBUGCallReadPropertiesToolStripMenuItem.Text = "DEBUG: Call ReadProperties()";
            this.dEBUGCallReadPropertiesToolStripMenuItem.Visible = false;
            this.dEBUGCallReadPropertiesToolStripMenuItem.Click += new System.EventHandler(this.dEBUGCallReadPropertiesToolStripMenuItem_Click);
            // 
            // dEBUGEnumerateAllClassesToolStripMenuItem
            // 
            this.dEBUGEnumerateAllClassesToolStripMenuItem.Name = "dEBUGEnumerateAllClassesToolStripMenuItem";
            this.dEBUGEnumerateAllClassesToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.dEBUGEnumerateAllClassesToolStripMenuItem.Text = "DEBUG: BinaryInterpreter -Enumerate All Class Exports";
            this.dEBUGEnumerateAllClassesToolStripMenuItem.Visible = false;
            this.dEBUGEnumerateAllClassesToolStripMenuItem.Click += new System.EventHandler(this.dEBUGEnumerateAllClassesToolStripMenuItem_Click);
            // 
            // dEBUGOpenPackageEditorWPFToolStripMenuItem
            // 
            this.dEBUGOpenPackageEditorWPFToolStripMenuItem.Name = "dEBUGOpenPackageEditorWPFToolStripMenuItem";
            this.dEBUGOpenPackageEditorWPFToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.dEBUGOpenPackageEditorWPFToolStripMenuItem.Text = "DEBUG: Open Package Editor (WPF)";
            this.dEBUGOpenPackageEditorWPFToolStripMenuItem.Click += new System.EventHandler(this.dEBUGOpenPackageEditorWPFToolStripMenuItem_Click);
            // 
            // dEBUGEnsureFolderOfPackageFilesHasANameToolStripMenuItem
            // 
            this.dEBUGEnsureFolderOfPackageFilesHasANameToolStripMenuItem.Name = "dEBUGEnsureFolderOfPackageFilesHasANameToolStripMenuItem";
            this.dEBUGEnsureFolderOfPackageFilesHasANameToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.dEBUGEnsureFolderOfPackageFilesHasANameToolStripMenuItem.Text = "DEBUG: Ensure folder of package files has a name";
            this.dEBUGEnsureFolderOfPackageFilesHasANameToolStripMenuItem.Click += new System.EventHandler(this.dEBUGEnsureFolderOfPackageFilesHasANameToolStripMenuItem_Click);
            // 
            // dEBUGAddAPropertyToExportsMatchingCriteriaToolStripMenuItem
            // 
            this.dEBUGAddAPropertyToExportsMatchingCriteriaToolStripMenuItem.Name = "dEBUGAddAPropertyToExportsMatchingCriteriaToolStripMenuItem";
            this.dEBUGAddAPropertyToExportsMatchingCriteriaToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.dEBUGAddAPropertyToExportsMatchingCriteriaToolStripMenuItem.Text = "DEBUG: Add a property to exports matching criteria";
            this.dEBUGAddAPropertyToExportsMatchingCriteriaToolStripMenuItem.Click += new System.EventHandler(this.dEBUGAddAPropertyToExportsMatchingCriteriaToolStripMenuItem_Click);
            // 
            // dEBUGFindMateriaInstancesToolStripMenuItem
            // 
            this.dEBUGFindMateriaInstancesToolStripMenuItem.Name = "dEBUGFindMateriaInstancesToolStripMenuItem";
            this.dEBUGFindMateriaInstancesToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.dEBUGFindMateriaInstancesToolStripMenuItem.Text = "DEBUG: FindMateriaInstances";
            this.dEBUGFindMateriaInstancesToolStripMenuItem.Click += new System.EventHandler(this.dEBUGFindMateriaInstancesToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Button1,
            this.Button2,
            this.Button3,
            this.Button5,
            this.toolStripSeparator1,
            this.combo1,
            this.findClassButton,
            this.toolStripSeparator2,
            this.searchBox,
            this.toolStripButton2,
            this.toolStripSeparator4,
            this.gotonumber,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(958, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Button1
            // 
            this.Button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(48, 22);
            this.Button1.Text = "Names";
            this.Button1.Click += new System.EventHandler(this.NamesViewButton_Clicked);
            // 
            // Button2
            // 
            this.Button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button2.Image = ((System.Drawing.Image)(resources.GetObject("Button2.Image")));
            this.Button2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(52, 22);
            this.Button2.Text = "Imports";
            this.Button2.Click += new System.EventHandler(this.ImportsViewButton_Clicked);
            // 
            // Button3
            // 
            this.Button3.Checked = true;
            this.Button3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Button3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button3.Image = ((System.Drawing.Image)(resources.GetObject("Button3.Image")));
            this.Button3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(49, 22);
            this.Button3.Text = "Exports";
            this.Button3.Click += new System.EventHandler(this.ExportsViewButton_Clicked);
            // 
            // Button5
            // 
            this.Button5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button5.Image = ((System.Drawing.Image)(resources.GetObject("Button5.Image")));
            this.Button5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(61, 22);
            this.Button5.Text = "Tree View";
            this.Button5.Click += new System.EventHandler(this.TreeView_Button_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // combo1
            // 
            this.combo1.Name = "combo1";
            this.combo1.Size = new System.Drawing.Size(170, 25);
            this.combo1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.findClassComboBox_KeyPress);
            // 
            // findClassButton
            // 
            this.findClassButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.findClassButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.findClassButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findClassButton.Name = "findClassButton";
            this.findClassButton.Size = new System.Drawing.Size(34, 22);
            this.findClassButton.Text = "Find";
            this.findClassButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.findClassButton.Click += new System.EventHandler(this.findClassButtonClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // searchBox
            // 
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(100, 25);
            this.searchBox.Text = "search...";
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBar_KeyPressed);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(46, 22);
            this.toolStripButton2.Text = "Search";
            this.toolStripButton2.Click += new System.EventHandler(this.searchButton_Clicked);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // gotonumber
            // 
            this.gotonumber.Name = "gotonumber";
            this.gotonumber.Size = new System.Drawing.Size(60, 25);
            this.gotonumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gotonumber_KeyPress);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(47, 22);
            this.toolStripButton4.Text = "Goto #";
            this.toolStripButton4.Click += new System.EventHandler(this.gotoNumberButton_Clicked);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filenameLabel,
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(958, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // filenameLabel
            // 
            this.filenameLabel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filenameLabel.ForeColor = System.Drawing.Color.Blue;
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(10, 17);
            this.statusLabel.Text = " ";
            this.statusLabel.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // nameContextMenuStrip1
            // 
            this.nameContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.nameContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.editToolStripMenuItem1});
            this.nameContextMenuStrip1.Name = "contextMenuStrip1";
            this.nameContextMenuStrip1.Size = new System.Drawing.Size(103, 48);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.editToolStripMenuItem1.Text = "Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.packageEditorTabPane);
            this.splitContainer1.Size = new System.Drawing.Size(958, 445);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(314, 445);
            this.treeView1.TabIndex = 1;
            this.treeView1.Visible = false;
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(314, 445);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // packageEditorTabPane
            // 
            this.packageEditorTabPane.Controls.Add(this.propertiesTab);
            this.packageEditorTabPane.Controls.Add(this.interpreterTab);
            this.packageEditorTabPane.Controls.Add(this.binaryEditorTab);
            this.packageEditorTabPane.Controls.Add(this.bio2daEditorTab);
            this.packageEditorTabPane.Controls.Add(this.infoTab);
            this.packageEditorTabPane.Controls.Add(this.metaDataPage);
            this.packageEditorTabPane.Controls.Add(this.headerTab);
            this.packageEditorTabPane.Controls.Add(this.scriptTab);
            this.packageEditorTabPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packageEditorTabPane.Location = new System.Drawing.Point(0, 0);
            this.packageEditorTabPane.Name = "packageEditorTabPane";
            this.packageEditorTabPane.SelectedIndex = 0;
            this.packageEditorTabPane.Size = new System.Drawing.Size(640, 445);
            this.packageEditorTabPane.TabIndex = 4;
            this.packageEditorTabPane.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // propertiesTab
            // 
            this.propertiesTab.Controls.Add(this.propGrid);
            this.propertiesTab.Location = new System.Drawing.Point(4, 22);
            this.propertiesTab.Name = "propertiesTab";
            this.propertiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.propertiesTab.Size = new System.Drawing.Size(632, 419);
            this.propertiesTab.TabIndex = 1;
            this.propertiesTab.Text = "Properties";
            this.propertiesTab.ToolTipText = "Edit UProperties in a simple interface for this export";
            this.propertiesTab.UseVisualStyleBackColor = true;
            // 
            // propGrid
            // 
            this.propGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGrid.LineColor = System.Drawing.SystemColors.ControlDark;
            this.propGrid.Location = new System.Drawing.Point(3, 3);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(626, 413);
            this.propGrid.TabIndex = 0;
            this.propGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propGrid_PropertyValueChanged);
            // 
            // interpreterTab
            // 
            this.interpreterTab.Controls.Add(this.interpreterControl);
            this.interpreterTab.Location = new System.Drawing.Point(4, 22);
            this.interpreterTab.Name = "interpreterTab";
            this.interpreterTab.Padding = new System.Windows.Forms.Padding(3);
            this.interpreterTab.Size = new System.Drawing.Size(632, 419);
            this.interpreterTab.TabIndex = 6;
            this.interpreterTab.Text = "Interpreter / Hex Editor";
            this.interpreterTab.ToolTipText = "Edit UProperties for this export";
            this.interpreterTab.UseVisualStyleBackColor = true;
            // 
            // interpreterControl
            // 
            this.interpreterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interpreterControl.Location = new System.Drawing.Point(3, 3);
            this.interpreterControl.Name = "interpreterControl";
            this.interpreterControl.Pcc = null;
            this.interpreterControl.Size = new System.Drawing.Size(626, 413);
            this.interpreterControl.TabIndex = 0;
            // 
            // binaryEditorTab
            // 
            this.binaryEditorTab.Controls.Add(this.binaryInterpreterControl);
            this.binaryEditorTab.Location = new System.Drawing.Point(4, 22);
            this.binaryEditorTab.Name = "binaryEditorTab";
            this.binaryEditorTab.Padding = new System.Windows.Forms.Padding(3);
            this.binaryEditorTab.Size = new System.Drawing.Size(632, 419);
            this.binaryEditorTab.TabIndex = 7;
            this.binaryEditorTab.Text = "Binary Editor";
            this.binaryEditorTab.ToolTipText = "Edit parsable binary data for this export";
            this.binaryEditorTab.UseVisualStyleBackColor = true;
            // 
            // binaryInterpreterControl
            // 
            this.binaryInterpreterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.binaryInterpreterControl.Location = new System.Drawing.Point(3, 3);
            this.binaryInterpreterControl.Name = "binaryInterpreterControl";
            this.binaryInterpreterControl.Pcc = null;
            this.binaryInterpreterControl.Size = new System.Drawing.Size(626, 413);
            this.binaryInterpreterControl.TabIndex = 0;
            // 
            // bio2daEditorTab
            // 
            this.bio2daEditorTab.Controls.Add(this.bio2DAEditor1);
            this.bio2daEditorTab.Location = new System.Drawing.Point(4, 22);
            this.bio2daEditorTab.Name = "bio2daEditorTab";
            this.bio2daEditorTab.Padding = new System.Windows.Forms.Padding(3);
            this.bio2daEditorTab.Size = new System.Drawing.Size(632, 419);
            this.bio2daEditorTab.TabIndex = 8;
            this.bio2daEditorTab.Text = "Bio2DA Editor";
            this.bio2daEditorTab.ToolTipText = "Edit the binary Bio2DA data for this export";
            this.bio2daEditorTab.UseVisualStyleBackColor = true;
            // 
            // bio2DAEditor1
            // 
            this.bio2DAEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bio2DAEditor1.Location = new System.Drawing.Point(3, 3);
            this.bio2DAEditor1.Name = "bio2DAEditor1";
            this.bio2DAEditor1.Pcc = null;
            this.bio2DAEditor1.Size = new System.Drawing.Size(626, 413);
            this.bio2DAEditor1.TabIndex = 0;
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.infoExportDataBox);
            this.infoTab.Controls.Add(this.infoHeaderBox);
            this.infoTab.Location = new System.Drawing.Point(4, 22);
            this.infoTab.Name = "infoTab";
            this.infoTab.Size = new System.Drawing.Size(632, 419);
            this.infoTab.TabIndex = 3;
            this.infoTab.Text = "Info";
            this.infoTab.ToolTipText = "View information about this export";
            this.infoTab.UseVisualStyleBackColor = true;
            // 
            // infoExportDataBox
            // 
            this.infoExportDataBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoExportDataBox.Controls.Add(this.label10);
            this.infoExportDataBox.Controls.Add(this.label9);
            this.infoExportDataBox.Controls.Add(this.textBox9);
            this.infoExportDataBox.Controls.Add(this.label8);
            this.infoExportDataBox.Controls.Add(this.textBox8);
            this.infoExportDataBox.Controls.Add(this.textBox7);
            this.infoExportDataBox.Controls.Add(this.label7);
            this.infoExportDataBox.Location = new System.Drawing.Point(4, 240);
            this.infoExportDataBox.Name = "infoExportDataBox";
            this.infoExportDataBox.Size = new System.Drawing.Size(626, 219);
            this.infoExportDataBox.TabIndex = 1;
            this.infoExportDataBox.TabStop = false;
            this.infoExportDataBox.Text = "Export data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Dec:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(110, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Hex:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(318, 47);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(163, 20);
            this.textBox9.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Data offset:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(145, 47);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(131, 20);
            this.textBox8.TabIndex = 2;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(113, 20);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(368, 20);
            this.textBox7.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Data size:";
            // 
            // infoHeaderBox
            // 
            this.infoHeaderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoHeaderBox.Controls.Add(this.superclassTextBox);
            this.infoHeaderBox.Controls.Add(this.superclassLabel);
            this.infoHeaderBox.Controls.Add(this.flagsBox);
            this.infoHeaderBox.Controls.Add(this.label11);
            this.infoHeaderBox.Controls.Add(this.label6);
            this.infoHeaderBox.Controls.Add(this.archetypeBox);
            this.infoHeaderBox.Controls.Add(this.indexBox);
            this.infoHeaderBox.Controls.Add(this.label5);
            this.infoHeaderBox.Controls.Add(this.headerSizeBox);
            this.infoHeaderBox.Controls.Add(this.label4);
            this.infoHeaderBox.Controls.Add(this.label3);
            this.infoHeaderBox.Controls.Add(this.packageNameBox);
            this.infoHeaderBox.Controls.Add(this.classNameBox);
            this.infoHeaderBox.Controls.Add(this.label2);
            this.infoHeaderBox.Controls.Add(this.objectNameBox);
            this.infoHeaderBox.Controls.Add(this.label1);
            this.infoHeaderBox.Location = new System.Drawing.Point(4, 4);
            this.infoHeaderBox.Name = "infoHeaderBox";
            this.infoHeaderBox.Size = new System.Drawing.Size(626, 230);
            this.infoHeaderBox.TabIndex = 0;
            this.infoHeaderBox.TabStop = false;
            this.infoHeaderBox.Text = "Export header";
            // 
            // superclassTextBox
            // 
            this.superclassTextBox.Location = new System.Drawing.Point(113, 69);
            this.superclassTextBox.Name = "superclassTextBox";
            this.superclassTextBox.ReadOnly = true;
            this.superclassTextBox.Size = new System.Drawing.Size(368, 20);
            this.superclassTextBox.TabIndex = 15;
            // 
            // superclassLabel
            // 
            this.superclassLabel.AutoSize = true;
            this.superclassLabel.Location = new System.Drawing.Point(7, 72);
            this.superclassLabel.Name = "superclassLabel";
            this.superclassLabel.Size = new System.Drawing.Size(62, 13);
            this.superclassLabel.TabIndex = 14;
            this.superclassLabel.Text = "Superclass:";
            // 
            // flagsBox
            // 
            this.flagsBox.Location = new System.Drawing.Point(113, 200);
            this.flagsBox.Name = "flagsBox";
            this.flagsBox.ReadOnly = true;
            this.flagsBox.Size = new System.Drawing.Size(368, 20);
            this.flagsBox.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Flags:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Archetype name:";
            // 
            // archetypeBox
            // 
            this.archetypeBox.Location = new System.Drawing.Point(113, 147);
            this.archetypeBox.Name = "archetypeBox";
            this.archetypeBox.ReadOnly = true;
            this.archetypeBox.Size = new System.Drawing.Size(368, 20);
            this.archetypeBox.TabIndex = 10;
            // 
            // indexBox
            // 
            this.indexBox.Location = new System.Drawing.Point(113, 120);
            this.indexBox.Name = "indexBox";
            this.indexBox.ReadOnly = true;
            this.indexBox.Size = new System.Drawing.Size(368, 20);
            this.indexBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Index:";
            // 
            // headerSizeBox
            // 
            this.headerSizeBox.Location = new System.Drawing.Point(113, 173);
            this.headerSizeBox.Name = "headerSizeBox";
            this.headerSizeBox.ReadOnly = true;
            this.headerSizeBox.Size = new System.Drawing.Size(368, 20);
            this.headerSizeBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Header size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Package name:";
            // 
            // packageNameBox
            // 
            this.packageNameBox.Location = new System.Drawing.Point(113, 94);
            this.packageNameBox.Name = "packageNameBox";
            this.packageNameBox.ReadOnly = true;
            this.packageNameBox.Size = new System.Drawing.Size(368, 20);
            this.packageNameBox.TabIndex = 4;
            // 
            // classNameBox
            // 
            this.classNameBox.Location = new System.Drawing.Point(113, 43);
            this.classNameBox.Name = "classNameBox";
            this.classNameBox.ReadOnly = true;
            this.classNameBox.Size = new System.Drawing.Size(368, 20);
            this.classNameBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class:";
            // 
            // objectNameBox
            // 
            this.objectNameBox.Location = new System.Drawing.Point(113, 17);
            this.objectNameBox.Name = "objectNameBox";
            this.objectNameBox.ReadOnly = true;
            this.objectNameBox.Size = new System.Drawing.Size(368, 20);
            this.objectNameBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Object name:";
            // 
            // metaDataPage
            // 
            this.metaDataPage.Controls.Add(this.showFullPathsCheckbox);
            this.metaDataPage.Controls.Add(this.indexTextBox);
            this.metaDataPage.Controls.Add(this.indexLabel);
            this.metaDataPage.Controls.Add(this.button4);
            this.metaDataPage.Controls.Add(this.archetypeLabel);
            this.metaDataPage.Controls.Add(this.label14);
            this.metaDataPage.Controls.Add(this.archetypeComboBox);
            this.metaDataPage.Controls.Add(this.linkComboBox);
            this.metaDataPage.Controls.Add(this.classComboBox);
            this.metaDataPage.Controls.Add(this.nameComboBox);
            this.metaDataPage.Controls.Add(this.label13);
            this.metaDataPage.Controls.Add(this.label12);
            this.metaDataPage.Location = new System.Drawing.Point(4, 22);
            this.metaDataPage.Name = "metaDataPage";
            this.metaDataPage.Padding = new System.Windows.Forms.Padding(3);
            this.metaDataPage.Size = new System.Drawing.Size(632, 419);
            this.metaDataPage.TabIndex = 4;
            this.metaDataPage.Text = "Meta Data Editor";
            this.metaDataPage.ToolTipText = "Edit the metadata about this export";
            this.metaDataPage.UseVisualStyleBackColor = true;
            // 
            // showFullPathsCheckbox
            // 
            this.showFullPathsCheckbox.AutoSize = true;
            this.showFullPathsCheckbox.Checked = global::ME3Explorer.Properties.Settings.Default.UseMetadataFullPaths;
            this.showFullPathsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showFullPathsCheckbox.Location = new System.Drawing.Point(175, 129);
            this.showFullPathsCheckbox.Name = "showFullPathsCheckbox";
            this.showFullPathsCheckbox.Size = new System.Drawing.Size(143, 17);
            this.showFullPathsCheckbox.TabIndex = 12;
            this.showFullPathsCheckbox.Text = "Show full package paths";
            this.showFullPathsCheckbox.UseVisualStyleBackColor = true;
            this.showFullPathsCheckbox.CheckedChanged += new System.EventHandler(this.showFullPaths_CheckChanged);
            // 
            // indexTextBox
            // 
            this.indexTextBox.Location = new System.Drawing.Point(82, 126);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(87, 20);
            this.indexTextBox.TabIndex = 11;
            // 
            // indexLabel
            // 
            this.indexLabel.AutoSize = true;
            this.indexLabel.Location = new System.Drawing.Point(10, 126);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(33, 13);
            this.indexLabel.TabIndex = 10;
            this.indexLabel.Text = "Index";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(506, 126);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Save Changes";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // archetypeLabel
            // 
            this.archetypeLabel.AutoSize = true;
            this.archetypeLabel.Location = new System.Drawing.Point(10, 96);
            this.archetypeLabel.Name = "archetypeLabel";
            this.archetypeLabel.Size = new System.Drawing.Size(55, 13);
            this.archetypeLabel.TabIndex = 5;
            this.archetypeLabel.Text = "Archetype";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Link";
            // 
            // archetypeComboBox
            // 
            this.archetypeComboBox.FormattingEnabled = true;
            this.archetypeComboBox.Location = new System.Drawing.Point(82, 96);
            this.archetypeComboBox.Name = "archetypeComboBox";
            this.archetypeComboBox.Size = new System.Drawing.Size(527, 21);
            this.archetypeComboBox.TabIndex = 4;
            // 
            // linkComboBox
            // 
            this.linkComboBox.FormattingEnabled = true;
            this.linkComboBox.Location = new System.Drawing.Point(82, 66);
            this.linkComboBox.Name = "linkComboBox";
            this.linkComboBox.Size = new System.Drawing.Size(527, 21);
            this.linkComboBox.TabIndex = 4;
            // 
            // classComboBox
            // 
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(82, 38);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(527, 21);
            this.classComboBox.TabIndex = 3;
            // 
            // nameComboBox
            // 
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(82, 7);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(527, 21);
            this.nameComboBox.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Class";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Name";
            // 
            // headerTab
            // 
            this.headerTab.Controls.Add(this.headerRawHexBox);
            this.headerTab.Controls.Add(this.toolStrip2);
            this.headerTab.Location = new System.Drawing.Point(4, 22);
            this.headerTab.Name = "headerTab";
            this.headerTab.Padding = new System.Windows.Forms.Padding(3);
            this.headerTab.Size = new System.Drawing.Size(632, 419);
            this.headerTab.TabIndex = 5;
            this.headerTab.Text = "Header Raw";
            this.headerTab.ToolTipText = "Edit the header hex directly for this export";
            this.headerTab.UseVisualStyleBackColor = true;
            // 
            // headerRawHexBox
            // 
            this.headerRawHexBox.BoldFont = null;
            this.headerRawHexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerRawHexBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerRawHexBox.LineInfoForeColor = System.Drawing.Color.Empty;
            this.headerRawHexBox.LineInfoVisible = true;
            this.headerRawHexBox.Location = new System.Drawing.Point(3, 28);
            this.headerRawHexBox.MaxBytesPerLine = 100;
            this.headerRawHexBox.MinBytesPerLine = 16;
            this.headerRawHexBox.Name = "headerRawHexBox";
            this.headerRawHexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.headerRawHexBox.Size = new System.Drawing.Size(626, 388);
            this.headerRawHexBox.StringViewVisible = true;
            this.headerRawHexBox.TabIndex = 0;
            this.headerRawHexBox.UseFixedBytesPerLine = true;
            this.headerRawHexBox.VScrollBarVisible = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveHeaderHexChangesBtn});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(626, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // saveHeaderHexChangesBtn
            // 
            this.saveHeaderHexChangesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveHeaderHexChangesBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveHeaderHexChangesBtn.Image")));
            this.saveHeaderHexChangesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveHeaderHexChangesBtn.Name = "saveHeaderHexChangesBtn";
            this.saveHeaderHexChangesBtn.Size = new System.Drawing.Size(107, 22);
            this.saveHeaderHexChangesBtn.Text = "Save Hex Changes";
            this.saveHeaderHexChangesBtn.Click += new System.EventHandler(this.saveHeaderHexChangesBtn_Click);
            // 
            // scriptTab
            // 
            this.scriptTab.Controls.Add(this.rtb1);
            this.scriptTab.Location = new System.Drawing.Point(4, 22);
            this.scriptTab.Name = "scriptTab";
            this.scriptTab.Size = new System.Drawing.Size(632, 419);
            this.scriptTab.TabIndex = 2;
            this.scriptTab.Text = "Script";
            this.scriptTab.ToolTipText = "View a decompiled UnrealScript that this export represents.";
            this.scriptTab.UseVisualStyleBackColor = true;
            // 
            // rtb1
            // 
            this.rtb1.DetectUrls = false;
            this.rtb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb1.Location = new System.Drawing.Point(0, 0);
            this.rtb1.Name = "rtb1";
            this.rtb1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtb1.Size = new System.Drawing.Size(632, 419);
            this.rtb1.TabIndex = 2;
            this.rtb1.Text = "";
            this.rtb1.WordWrap = false;
            // 
            // nodeContextMenuStrip1
            // 
            this.nodeContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.nodeContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cloneToolStripMenuItem,
            this.cloneTreeToolStripMenuItem,
            this.reindexClassToolStripMenuItem,
            this.setAllIndexesInThisTreeTo0ToolStripMenuItem,
            this.scaleformSWFToolStripMenuItem});
            this.nodeContextMenuStrip1.Name = "nodeContextMenuStrip1";
            this.nodeContextMenuStrip1.Size = new System.Drawing.Size(238, 114);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.cloneToolStripMenuItem.Text = "Clone";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // cloneTreeToolStripMenuItem
            // 
            this.cloneTreeToolStripMenuItem.Name = "cloneTreeToolStripMenuItem";
            this.cloneTreeToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.cloneTreeToolStripMenuItem.Text = "Clone Tree";
            this.cloneTreeToolStripMenuItem.Click += new System.EventHandler(this.cloneTreeToolStripMenuItem_Click);
            // 
            // reindexClassToolStripMenuItem
            // 
            this.reindexClassToolStripMenuItem.Name = "reindexClassToolStripMenuItem";
            this.reindexClassToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.reindexClassToolStripMenuItem.Text = "Reindex objects with this name";
            this.reindexClassToolStripMenuItem.Click += new System.EventHandler(this.reindexClassToolStripMenuItem_Click);
            // 
            // setAllIndexesInThisTreeTo0ToolStripMenuItem
            // 
            this.setAllIndexesInThisTreeTo0ToolStripMenuItem.Name = "setAllIndexesInThisTreeTo0ToolStripMenuItem";
            this.setAllIndexesInThisTreeTo0ToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.setAllIndexesInThisTreeTo0ToolStripMenuItem.Text = "Set all indexes in this tree to 0";
            this.setAllIndexesInThisTreeTo0ToolStripMenuItem.Click += new System.EventHandler(this.setAllIndexesInThisTreeTo0ToolStripMenuItem_Click);
            // 
            // scaleformSWFToolStripMenuItem
            // 
            this.scaleformSWFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractSWFToolStripMenuItem,
            this.replaceSWFToolStripMenuItem});
            this.scaleformSWFToolStripMenuItem.Name = "scaleformSWFToolStripMenuItem";
            this.scaleformSWFToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.scaleformSWFToolStripMenuItem.Text = "Scaleform SWF";
            // 
            // extractSWFToolStripMenuItem
            // 
            this.extractSWFToolStripMenuItem.Name = "extractSWFToolStripMenuItem";
            this.extractSWFToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.extractSWFToolStripMenuItem.Text = "Extract SWF";
            this.extractSWFToolStripMenuItem.Click += new System.EventHandler(this.extractSWFToolStripMenuItem_Click);
            // 
            // replaceSWFToolStripMenuItem
            // 
            this.replaceSWFToolStripMenuItem.Name = "replaceSWFToolStripMenuItem";
            this.replaceSWFToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.replaceSWFToolStripMenuItem.Text = "Replace SWF";
            this.replaceSWFToolStripMenuItem.Click += new System.EventHandler(this.replaceSWFToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cloneToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 26);
            // 
            // cloneToolStripMenuItem1
            // 
            this.cloneToolStripMenuItem1.Name = "cloneToolStripMenuItem1";
            this.cloneToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.cloneToolStripMenuItem1.Text = "Clone";
            this.cloneToolStripMenuItem1.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // compareWithAnotherVersionOfThisPccToolStripMenuItem
            // 
            this.compareWithAnotherVersionOfThisPccToolStripMenuItem.Name = "compareWithAnotherVersionOfThisPccToolStripMenuItem";
            this.compareWithAnotherVersionOfThisPccToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.compareWithAnotherVersionOfThisPccToolStripMenuItem.Text = "Compare with another version of this pcc";
            this.compareWithAnotherVersionOfThisPccToolStripMenuItem.Click += new System.EventHandler(this.compareWithAnotherVersionOfThisPccToolStripMenuItem_Click);
            // 
            // PackageEditor
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 516);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PackageEditor";
            this.Text = "Package Editor";
            this.Activated += new System.EventHandler(this.PackageEditor_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PackageEditor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PackageEditor_FormClosed);
            this.Shown += new System.EventHandler(this.PackageEditor_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PackageEditor_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PackageEditor_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.nameContextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.packageEditorTabPane.ResumeLayout(false);
            this.propertiesTab.ResumeLayout(false);
            this.interpreterTab.ResumeLayout(false);
            this.binaryEditorTab.ResumeLayout(false);
            this.bio2daEditorTab.ResumeLayout(false);
            this.infoTab.ResumeLayout(false);
            this.infoExportDataBox.ResumeLayout(false);
            this.infoExportDataBox.PerformLayout();
            this.infoHeaderBox.ResumeLayout(false);
            this.infoHeaderBox.PerformLayout();
            this.metaDataPage.ResumeLayout(false);
            this.metaDataPage.PerformLayout();
            this.headerTab.ResumeLayout(false);
            this.headerTab.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.scriptTab.ResumeLayout(false);
            this.nodeContextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton Button1;
        public System.Windows.Forms.ToolStripButton Button2;
        public System.Windows.Forms.ToolStripButton Button3;
        public System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hexConverterToolStripMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileDialog;
        public System.Windows.Forms.ToolStripStatusLabel statusLabel;
        public System.Windows.Forms.ToolStripComboBox combo1;
        public System.Windows.Forms.ToolStripButton findClassButton;
        public System.Windows.Forms.ToolStripMenuItem addNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox searchBox;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getDumpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editInInterpreterToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox gotonumber;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        public System.Windows.Forms.ToolStripMenuItem getDumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceWithBINToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modjobsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBinaryReplaceJobFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBinaryReplaceJobFromObjectToolStripMenuItem;
        public System.Windows.Forms.PropertyGrid propGrid;
        public System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.TabControl packageEditorTabPane;
        private System.Windows.Forms.TabPage propertiesTab;
        private System.Windows.Forms.TabPage scriptTab;
        private System.Windows.Forms.TabPage infoTab;
        private System.Windows.Forms.GroupBox infoHeaderBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox packageNameBox;
        private System.Windows.Forms.TextBox classNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox objectNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox archetypeBox;
        private System.Windows.Forms.TextBox indexBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox headerSizeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox infoExportDataBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox flagsBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage metaDataPage;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox linkComboBox;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.ComboBox nameComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripStatusLabel filenameLabel;
        private System.Windows.Forms.TabPage headerTab;
        private System.Windows.Forms.ToolStripButton Button5;
        private System.Windows.Forms.TreeView treeView1;
        public System.Windows.Forms.ListBox listBox1;
        private Be.Windows.Forms.HexBox headerRawHexBox;
        private System.Windows.Forms.TextBox superclassTextBox;
        private System.Windows.Forms.Label superclassLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TextBox indexTextBox;
        private System.Windows.Forms.Label indexLabel;
        private System.Windows.Forms.Label archetypeLabel;
        private System.Windows.Forms.ComboBox archetypeComboBox;
        private System.Windows.Forms.ContextMenuStrip nameContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.TabPage interpreterTab;
        private Interpreter interpreterControl;
        private BinaryInterpreter binaryInterpreterControl;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton saveHeaderHexChangesBtn;
        private System.Windows.Forms.ContextMenuStrip nodeContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneTreeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editInCurveEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reindexClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAllIndexesInThisTreeTo0ToolStripMenuItem;
        private System.Windows.Forms.TabPage binaryEditorTab;
        private System.Windows.Forms.CheckBox showFullPathsCheckbox;
        private System.Windows.Forms.ToolStripMenuItem findImportexportViaOffsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkIndexingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEBUGCallReadPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pathfindingEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenceEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faceFXEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wWiseBankEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadTLKsToolStripMenuItem;
        private System.Windows.Forms.TabPage bio2daEditorTab;
        private Bio2DAEditor bio2DAEditor1;
        private System.Windows.Forms.ToolStripMenuItem findExportsWithSerialSizeMismatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEBUGEnumerateAllClassesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dialogueEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEBUGOpenPackageEditorWPFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleformSWFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractSWFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceSWFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEBUGEnsureFolderOfPackageFilesHasANameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebuildStreamingLevelsListForBioWorldInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meshplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEBUGAddAPropertyToExportsMatchingCriteriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEBUGFindMateriaInstancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareWithAnotherVersionOfThisPccToolStripMenuItem;
    }
}