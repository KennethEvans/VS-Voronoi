namespace VoronoiMap {
    sealed partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInputFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeMapDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indentedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notIndentedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.resetSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileFromImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelControls = new System.Windows.Forms.TableLayoutPanel();
            this.seedLabel = new System.Windows.Forms.Label();
            this.nudSeed = new System.Windows.Forms.NumericUpDown();
            this.numRegionLabel = new System.Windows.Forms.Label();
            this.nudNumRegions = new System.Windows.Forms.NumericUpDown();
            this.relaxLabel = new System.Windows.Forms.Label();
            this.nudRelax = new System.Windows.Forms.NumericUpDown();
            this.chkShowSites = new System.Windows.Forms.CheckBox();
            this.chkShowVertices = new System.Windows.Forms.CheckBox();
            this.chkShowEdges = new System.Windows.Forms.CheckBox();
            this.chkShowNumbers = new System.Windows.Forms.CheckBox();
            this.chkUseFile = new System.Windows.Forms.CheckBox();
            this.circleLabel = new System.Windows.Forms.Label();
            this.cbCircles = new System.Windows.Forms.ComboBox();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.chkBeachline = new System.Windows.Forms.CheckBox();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnRegen = new System.Windows.Forms.Button();
            this.btnStepVoronoi = new System.Windows.Forms.Button();
            this.btnStepTo = new System.Windows.Forms.Button();
            this.stepLabel = new System.Windows.Forms.Label();
            this.nudStepTo = new System.Windows.Forms.NumericUpDown();
            this.btnAnimate = new System.Windows.Forms.Button();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.panelDiagram = new System.Windows.Forms.Panel();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainMenuStrip.SuspendLayout();
            this.tableLayoutPanelTop.SuspendLayout();
            this.tableLayoutPanelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumRegions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRelax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStepTo)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(10, 10);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1975, 49);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInputFileToolStripMenuItem,
            this.writeMapDataFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.resetSettingsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(75, 45);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openInputFileToolStripMenuItem
            // 
            this.openInputFileToolStripMenuItem.Name = "openInputFileToolStripMenuItem";
            this.openInputFileToolStripMenuItem.Size = new System.Drawing.Size(408, 46);
            this.openInputFileToolStripMenuItem.Text = "Open Input File...";
            this.openInputFileToolStripMenuItem.Click += new System.EventHandler(this.file_OpenInput_click);
            // 
            // writeMapDataFileToolStripMenuItem
            // 
            this.writeMapDataFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indentedToolStripMenuItem,
            this.notIndentedToolStripMenuItem});
            this.writeMapDataFileToolStripMenuItem.Name = "writeMapDataFileToolStripMenuItem";
            this.writeMapDataFileToolStripMenuItem.Size = new System.Drawing.Size(408, 46);
            this.writeMapDataFileToolStripMenuItem.Text = "Write Map Data file...";
            // 
            // indentedToolStripMenuItem
            // 
            this.indentedToolStripMenuItem.Name = "indentedToolStripMenuItem";
            this.indentedToolStripMenuItem.Size = new System.Drawing.Size(310, 46);
            this.indentedToolStripMenuItem.Text = "Indented";
            this.indentedToolStripMenuItem.Click += new System.EventHandler(this.file_SaveMapDataFileIndented_click);
            // 
            // notIndentedToolStripMenuItem
            // 
            this.notIndentedToolStripMenuItem.Name = "notIndentedToolStripMenuItem";
            this.notIndentedToolStripMenuItem.Size = new System.Drawing.Size(310, 46);
            this.notIndentedToolStripMenuItem.Text = "Not Indented";
            this.notIndentedToolStripMenuItem.Click += new System.EventHandler(this.file_SaveMapDataFileNotIndented_click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(405, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(405, 6);
            // 
            // resetSettingsToolStripMenuItem
            // 
            this.resetSettingsToolStripMenuItem.Name = "resetSettingsToolStripMenuItem";
            this.resetSettingsToolStripMenuItem.Size = new System.Drawing.Size(408, 46);
            this.resetSettingsToolStripMenuItem.Text = "Reset Settings";
            this.resetSettingsToolStripMenuItem.Click += new System.EventHandler(this.file_ResetSettings_click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(405, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(408, 46);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.file_Exit_click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFromImageToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(99, 45);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // fileFromImageToolStripMenuItem
            // 
            this.fileFromImageToolStripMenuItem.Name = "fileFromImageToolStripMenuItem";
            this.fileFromImageToolStripMenuItem.Size = new System.Drawing.Size(360, 46);
            this.fileFromImageToolStripMenuItem.Text = "File from Image...";
            this.fileFromImageToolStripMenuItem.Click += new System.EventHandler(this.tools_FileFromImage_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(92, 45);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(214, 46);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.help_About_click);
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.AutoSize = true;
            this.tableLayoutPanelTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTop.ColumnCount = 2;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTop.Controls.Add(this.tableLayoutPanelControls, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.panelDiagram, 1, 0);
            this.tableLayoutPanelTop.Controls.Add(this.textBoxInfo, 1, 1);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(10, 59);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 2;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1975, 1195);
            this.tableLayoutPanelTop.TabIndex = 2;
            // 
            // tableLayoutPanelControls
            // 
            this.tableLayoutPanelControls.AutoSize = true;
            this.tableLayoutPanelControls.ColumnCount = 2;
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelControls.Controls.Add(this.seedLabel, 0, 0);
            this.tableLayoutPanelControls.Controls.Add(this.nudSeed, 1, 0);
            this.tableLayoutPanelControls.Controls.Add(this.numRegionLabel, 0, 1);
            this.tableLayoutPanelControls.Controls.Add(this.nudNumRegions, 1, 1);
            this.tableLayoutPanelControls.Controls.Add(this.relaxLabel, 0, 2);
            this.tableLayoutPanelControls.Controls.Add(this.nudRelax, 1, 2);
            this.tableLayoutPanelControls.Controls.Add(this.chkShowSites, 1, 3);
            this.tableLayoutPanelControls.Controls.Add(this.chkShowVertices, 1, 4);
            this.tableLayoutPanelControls.Controls.Add(this.chkShowEdges, 1, 5);
            this.tableLayoutPanelControls.Controls.Add(this.chkShowNumbers, 1, 6);
            this.tableLayoutPanelControls.Controls.Add(this.chkUseFile, 1, 7);
            this.tableLayoutPanelControls.Controls.Add(this.circleLabel, 0, 8);
            this.tableLayoutPanelControls.Controls.Add(this.cbCircles, 1, 8);
            this.tableLayoutPanelControls.Controls.Add(this.chkDebug, 1, 9);
            this.tableLayoutPanelControls.Controls.Add(this.chkBeachline, 1, 10);
            this.tableLayoutPanelControls.Controls.Add(this.btnInitialize, 0, 12);
            this.tableLayoutPanelControls.Controls.Add(this.btnRegen, 1, 12);
            this.tableLayoutPanelControls.Controls.Add(this.btnStepVoronoi, 0, 13);
            this.tableLayoutPanelControls.Controls.Add(this.btnStepTo, 1, 13);
            this.tableLayoutPanelControls.Controls.Add(this.stepLabel, 0, 14);
            this.tableLayoutPanelControls.Controls.Add(this.nudStepTo, 1, 14);
            this.tableLayoutPanelControls.Controls.Add(this.btnAnimate, 1, 15);
            this.tableLayoutPanelControls.Controls.Add(this.fileNameLabel, 0, 16);
            this.tableLayoutPanelControls.Controls.Add(this.fileNameTextBox, 0, 17);
            this.tableLayoutPanelControls.Location = new System.Drawing.Point(8, 7);
            this.tableLayoutPanelControls.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tableLayoutPanelControls.Name = "tableLayoutPanelControls";
            this.tableLayoutPanelControls.RowCount = 15;
            this.tableLayoutPanelTop.SetRowSpan(this.tableLayoutPanelControls, 2);
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.Size = new System.Drawing.Size(580, 887);
            this.tableLayoutPanelControls.TabIndex = 19;
            // 
            // seedLabel
            // 
            this.seedLabel.AutoSize = true;
            this.seedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seedLabel.Location = new System.Drawing.Point(8, 0);
            this.seedLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.seedLabel.Name = "seedLabel";
            this.seedLabel.Size = new System.Drawing.Size(274, 52);
            this.seedLabel.TabIndex = 0;
            this.seedLabel.Text = "Seed:";
            this.seedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudSeed
            // 
            this.nudSeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudSeed.Location = new System.Drawing.Point(298, 7);
            this.nudSeed.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nudSeed.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudSeed.Name = "nudSeed";
            this.nudSeed.Size = new System.Drawing.Size(274, 38);
            this.nudSeed.TabIndex = 1;
            this.toolTip.SetToolTip(this.nudSeed, "Seed for random sites");
            // 
            // numRegionLabel
            // 
            this.numRegionLabel.AutoSize = true;
            this.numRegionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numRegionLabel.Location = new System.Drawing.Point(8, 52);
            this.numRegionLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.numRegionLabel.Name = "numRegionLabel";
            this.numRegionLabel.Size = new System.Drawing.Size(274, 52);
            this.numRegionLabel.TabIndex = 2;
            this.numRegionLabel.Text = "Number of Regions:";
            this.numRegionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudNumRegions
            // 
            this.nudNumRegions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudNumRegions.Location = new System.Drawing.Point(298, 59);
            this.nudNumRegions.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nudNumRegions.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudNumRegions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumRegions.Name = "nudNumRegions";
            this.nudNumRegions.Size = new System.Drawing.Size(274, 38);
            this.nudNumRegions.TabIndex = 3;
            this.toolTip.SetToolTip(this.nudNumRegions, "Number of random sites");
            this.nudNumRegions.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // relaxLabel
            // 
            this.relaxLabel.AutoSize = true;
            this.relaxLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.relaxLabel.Location = new System.Drawing.Point(8, 104);
            this.relaxLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.relaxLabel.Name = "relaxLabel";
            this.relaxLabel.Size = new System.Drawing.Size(274, 52);
            this.relaxLabel.TabIndex = 4;
            this.relaxLabel.Text = "Relax:";
            this.relaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudRelax
            // 
            this.nudRelax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudRelax.Location = new System.Drawing.Point(298, 111);
            this.nudRelax.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nudRelax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudRelax.Name = "nudRelax";
            this.nudRelax.Size = new System.Drawing.Size(274, 38);
            this.nudRelax.TabIndex = 5;
            // 
            // chkShowSites
            // 
            this.chkShowSites.AutoSize = true;
            this.chkShowSites.Checked = true;
            this.chkShowSites.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowSites.Location = new System.Drawing.Point(298, 163);
            this.chkShowSites.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkShowSites.Name = "chkShowSites";
            this.chkShowSites.Size = new System.Drawing.Size(274, 36);
            this.chkShowSites.TabIndex = 6;
            this.chkShowSites.Text = "Show Sites?";
            this.chkShowSites.UseVisualStyleBackColor = true;
            this.chkShowSites.CheckedChanged += new System.EventHandler(this.chkShowSites_CheckedChanged);
            // 
            // chkShowVertices
            // 
            this.chkShowVertices.AutoSize = true;
            this.chkShowVertices.Checked = true;
            this.chkShowVertices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowVertices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowVertices.Location = new System.Drawing.Point(298, 213);
            this.chkShowVertices.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkShowVertices.Name = "chkShowVertices";
            this.chkShowVertices.Size = new System.Drawing.Size(274, 36);
            this.chkShowVertices.TabIndex = 7;
            this.chkShowVertices.Text = "Show Vertices?";
            this.chkShowVertices.UseVisualStyleBackColor = true;
            this.chkShowVertices.CheckedChanged += new System.EventHandler(this.chkShowVertices_CheckedChanged);
            // 
            // chkShowEdges
            // 
            this.chkShowEdges.AutoSize = true;
            this.chkShowEdges.Checked = true;
            this.chkShowEdges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowEdges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowEdges.Location = new System.Drawing.Point(298, 263);
            this.chkShowEdges.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkShowEdges.Name = "chkShowEdges";
            this.chkShowEdges.Size = new System.Drawing.Size(274, 36);
            this.chkShowEdges.TabIndex = 8;
            this.chkShowEdges.Text = "Show Edges?";
            this.chkShowEdges.UseVisualStyleBackColor = true;
            this.chkShowEdges.CheckedChanged += new System.EventHandler(this.chkShowEdges_CheckedChanged);
            // 
            // chkShowNumbers
            // 
            this.chkShowNumbers.AutoSize = true;
            this.chkShowNumbers.Checked = true;
            this.chkShowNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowNumbers.Location = new System.Drawing.Point(298, 313);
            this.chkShowNumbers.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkShowNumbers.Name = "chkShowNumbers";
            this.chkShowNumbers.Size = new System.Drawing.Size(274, 36);
            this.chkShowNumbers.TabIndex = 9;
            this.chkShowNumbers.Text = "Show Numbers?";
            this.chkShowNumbers.UseVisualStyleBackColor = true;
            this.chkShowNumbers.CheckedChanged += new System.EventHandler(this.chkShowNumbers_Click);
            // 
            // chkUseFile
            // 
            this.chkUseFile.AutoSize = true;
            this.chkUseFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseFile.Location = new System.Drawing.Point(298, 363);
            this.chkUseFile.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkUseFile.Name = "chkUseFile";
            this.chkUseFile.Size = new System.Drawing.Size(274, 36);
            this.chkUseFile.TabIndex = 10;
            this.chkUseFile.Text = "Use File?";
            this.toolTip.SetToolTip(this.chkUseFile, "Use file or use JSON data");
            this.chkUseFile.UseVisualStyleBackColor = true;
            // 
            // circleLabel
            // 
            this.circleLabel.AutoSize = true;
            this.circleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circleLabel.Location = new System.Drawing.Point(8, 406);
            this.circleLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.circleLabel.Name = "circleLabel";
            this.circleLabel.Size = new System.Drawing.Size(274, 53);
            this.circleLabel.TabIndex = 11;
            this.circleLabel.Text = "Show Circle Events:";
            this.circleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbCircles
            // 
            this.cbCircles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCircles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCircles.FormattingEnabled = true;
            this.cbCircles.Items.AddRange(new object[] {
            "None",
            "Circles",
            "Triangles"});
            this.cbCircles.Location = new System.Drawing.Point(298, 413);
            this.cbCircles.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cbCircles.Name = "cbCircles";
            this.cbCircles.Size = new System.Drawing.Size(274, 39);
            this.cbCircles.TabIndex = 12;
            this.cbCircles.SelectedIndexChanged += new System.EventHandler(this.cbCircles_SelectedIndexChanged);
            // 
            // chkDebug
            // 
            this.chkDebug.AutoSize = true;
            this.chkDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkDebug.Location = new System.Drawing.Point(298, 466);
            this.chkDebug.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(274, 36);
            this.chkDebug.TabIndex = 13;
            this.chkDebug.Text = "Debug?";
            this.chkDebug.UseVisualStyleBackColor = true;
            // 
            // chkBeachline
            // 
            this.chkBeachline.AutoSize = true;
            this.chkBeachline.Checked = true;
            this.chkBeachline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBeachline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBeachline.Location = new System.Drawing.Point(298, 516);
            this.chkBeachline.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkBeachline.Name = "chkBeachline";
            this.chkBeachline.Size = new System.Drawing.Size(274, 36);
            this.chkBeachline.TabIndex = 14;
            this.chkBeachline.Text = "Show Beachline?";
            this.chkBeachline.UseVisualStyleBackColor = true;
            this.chkBeachline.CheckedChanged += new System.EventHandler(this.chkShowBeachLine_CheckChanged);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInitialize.Location = new System.Drawing.Point(8, 566);
            this.btnInitialize.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(274, 55);
            this.btnInitialize.TabIndex = 15;
            this.btnInitialize.Text = "Initialize";
            this.toolTip.SetToolTip(this.btnInitialize, "Initializes for stepping");
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnRegen
            // 
            this.btnRegen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegen.Location = new System.Drawing.Point(298, 566);
            this.btnRegen.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnRegen.Name = "btnRegen";
            this.btnRegen.Size = new System.Drawing.Size(274, 55);
            this.btnRegen.TabIndex = 16;
            this.btnRegen.Text = "Regenerate Graph";
            this.toolTip.SetToolTip(this.btnRegen, "Regenerates the entire diagram");
            this.btnRegen.UseVisualStyleBackColor = true;
            this.btnRegen.Click += new System.EventHandler(this.btnRegen_Click);
            // 
            // btnStepVoronoi
            // 
            this.btnStepVoronoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStepVoronoi.Location = new System.Drawing.Point(8, 635);
            this.btnStepVoronoi.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStepVoronoi.Name = "btnStepVoronoi";
            this.btnStepVoronoi.Size = new System.Drawing.Size(274, 55);
            this.btnStepVoronoi.TabIndex = 17;
            this.btnStepVoronoi.Text = "Step Graph";
            this.toolTip.SetToolTip(this.btnStepVoronoi, "Do next step");
            this.btnStepVoronoi.UseVisualStyleBackColor = true;
            this.btnStepVoronoi.Click += new System.EventHandler(this.btnStepVoronoi_Click);
            // 
            // btnStepTo
            // 
            this.btnStepTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStepTo.Location = new System.Drawing.Point(298, 635);
            this.btnStepTo.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStepTo.Name = "btnStepTo";
            this.btnStepTo.Size = new System.Drawing.Size(274, 55);
            this.btnStepTo.TabIndex = 18;
            this.btnStepTo.Text = "Step to:";
            this.toolTip.SetToolTip(this.btnStepTo, "Step to the step specified");
            this.btnStepTo.UseVisualStyleBackColor = true;
            this.btnStepTo.Click += new System.EventHandler(this.btnStepTo_Click);
            // 
            // stepLabel
            // 
            this.stepLabel.AutoSize = true;
            this.stepLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepLabel.Location = new System.Drawing.Point(8, 697);
            this.stepLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(274, 52);
            this.stepLabel.TabIndex = 19;
            this.stepLabel.Text = "Step:";
            this.stepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.stepLabel, "The current step");
            // 
            // nudStepTo
            // 
            this.nudStepTo.Location = new System.Drawing.Point(298, 704);
            this.nudStepTo.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nudStepTo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudStepTo.Name = "nudStepTo";
            this.nudStepTo.Size = new System.Drawing.Size(107, 38);
            this.nudStepTo.TabIndex = 20;
            this.toolTip.SetToolTip(this.nudStepTo, "The current step");
            // 
            // btnAnimate
            // 
            this.btnAnimate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnimate.Location = new System.Drawing.Point(298, 756);
            this.btnAnimate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(274, 55);
            this.btnAnimate.TabIndex = 21;
            this.btnAnimate.Text = "Animate";
            this.toolTip.SetToolTip(this.btnAnimate, "Animate, doing all the steps");
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.tableLayoutPanelControls.SetColumnSpan(this.fileNameLabel, 2);
            this.fileNameLabel.Location = new System.Drawing.Point(3, 818);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(152, 32);
            this.fileNameLabel.TabIndex = 22;
            this.fileNameLabel.Text = "File Name:";
            this.toolTip.SetToolTip(this.fileNameLabel, "Current JSON file");
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanelControls.SetColumnSpan(this.fileNameTextBox, 2);
            this.fileNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileNameTextBox.Location = new System.Drawing.Point(3, 853);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.ReadOnly = true;
            this.fileNameTextBox.Size = new System.Drawing.Size(574, 31);
            this.fileNameTextBox.TabIndex = 23;
            this.toolTip.SetToolTip(this.fileNameTextBox, "Current JSON file");
            // 
            // panelDiagram
            // 
            this.panelDiagram.AutoSize = true;
            this.panelDiagram.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelDiagram.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDiagram.Location = new System.Drawing.Point(599, 3);
            this.panelDiagram.Name = "panelDiagram";
            this.panelDiagram.Size = new System.Drawing.Size(1373, 890);
            this.panelDiagram.TabIndex = 0;
            this.panelDiagram.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPanelMainPaint);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInfo.Location = new System.Drawing.Point(599, 899);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxInfo.Size = new System.Drawing.Size(1373, 293);
            this.textBoxInfo.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBoxInfo, "Console messages area");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1995, 1264);
            this.Controls.Add(this.tableLayoutPanelTop);
            this.Controls.Add(this.mainMenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Voronoi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.OnMainFormResizeEnd);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelTop.PerformLayout();
            this.tableLayoutPanelControls.ResumeLayout(false);
            this.tableLayoutPanelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumRegions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRelax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStepTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInputFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeMapDataFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indentedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notIndentedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem resetSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileFromImageToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelControls;
        private System.Windows.Forms.Label seedLabel;
        private System.Windows.Forms.NumericUpDown nudSeed;
        private System.Windows.Forms.Label numRegionLabel;
        private System.Windows.Forms.NumericUpDown nudNumRegions;
        private System.Windows.Forms.Label relaxLabel;
        private System.Windows.Forms.NumericUpDown nudRelax;
        private System.Windows.Forms.CheckBox chkShowSites;
        private System.Windows.Forms.CheckBox chkShowVertices;
        private System.Windows.Forms.CheckBox chkShowEdges;
        private System.Windows.Forms.CheckBox chkShowNumbers;
        private System.Windows.Forms.CheckBox chkUseFile;
        private System.Windows.Forms.Label circleLabel;
        private System.Windows.Forms.ComboBox cbCircles;
        private System.Windows.Forms.CheckBox chkDebug;
        private System.Windows.Forms.CheckBox chkBeachline;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnRegen;
        private System.Windows.Forms.Button btnStepVoronoi;
        private System.Windows.Forms.Button btnStepTo;
        private System.Windows.Forms.Label stepLabel;
        private System.Windows.Forms.NumericUpDown nudStepTo;
        private System.Windows.Forms.Button btnAnimate;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Panel panelDiagram;
        private System.Windows.Forms.ToolTip toolTip;
    }
}