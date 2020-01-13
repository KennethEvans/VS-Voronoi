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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitPanel = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnimate = new System.Windows.Forms.Button();
            this.btnStepVoronoi = new System.Windows.Forms.Button();
            this.btnStepTo = new System.Windows.Forms.Button();
            this.nudStepTo = new System.Windows.Forms.NumericUpDown();
            this.nudRelax = new System.Windows.Forms.NumericUpDown();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.nudSeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudNumRegions = new System.Windows.Forms.NumericUpDown();
            this.chDebug = new System.Windows.Forms.CheckBox();
            this.btnRegen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.chkShowSites = new System.Windows.Forms.CheckBox();
            this.chkShowVertices = new System.Windows.Forms.CheckBox();
            this.chkShowEdges = new System.Windows.Forms.CheckBox();
            this.chkUseFile = new System.Windows.Forms.CheckBox();
            this.chkShowNumbers = new System.Windows.Forms.CheckBox();
            this.cbCircles = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkBeachline = new System.Windows.Forms.CheckBox();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInputFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel)).BeginInit();
            this.splitPanel.Panel1.SuspendLayout();
            this.splitPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStepTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRelax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumRegions)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitPanel
            // 
            this.splitPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitPanel.IsSplitterFixed = true;
            this.splitPanel.Location = new System.Drawing.Point(10, 59);
            this.splitPanel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.splitPanel.Name = "splitPanel";
            // 
            // splitPanel.Panel1
            // 
            this.splitPanel.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitPanel.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitPanel.Panel1MinSize = 250;
            // 
            // splitPanel.Panel2
            // 
            this.splitPanel.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitPanel.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitPanel.Size = new System.Drawing.Size(1448, 981);
            this.splitPanel.SplitterDistance = 250;
            this.splitPanel.SplitterWidth = 10;
            this.splitPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAnimate, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.btnStepVoronoi, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnStepTo, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.nudStepTo, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.nudRelax, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnInitialize, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.nudSeed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudNumRegions, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chDebug, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.btnRegen, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkShowSites, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkShowVertices, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkShowEdges, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkUseFile, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.chkShowNumbers, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbCircles, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.chkBeachline, 1, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(246, 977);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 52);
            this.label2.TabIndex = 13;
            this.label2.Text = "Seed:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAnimate
            // 
            this.btnAnimate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnimate.Location = new System.Drawing.Point(131, 907);
            this.btnAnimate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(107, 55);
            this.btnAnimate.TabIndex = 14;
            this.btnAnimate.Text = "Animate";
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            // 
            // btnStepVoronoi
            // 
            this.btnStepVoronoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStepVoronoi.Location = new System.Drawing.Point(8, 786);
            this.btnStepVoronoi.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStepVoronoi.Name = "btnStepVoronoi";
            this.btnStepVoronoi.Size = new System.Drawing.Size(107, 55);
            this.btnStepVoronoi.TabIndex = 7;
            this.btnStepVoronoi.Text = "Step Graph";
            this.btnStepVoronoi.UseVisualStyleBackColor = true;
            this.btnStepVoronoi.Click += new System.EventHandler(this.btnStepVoronoi_Click);
            // 
            // btnStepTo
            // 
            this.btnStepTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStepTo.Location = new System.Drawing.Point(131, 786);
            this.btnStepTo.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStepTo.Name = "btnStepTo";
            this.btnStepTo.Size = new System.Drawing.Size(107, 55);
            this.btnStepTo.TabIndex = 11;
            this.btnStepTo.Text = "Step to:";
            this.btnStepTo.UseVisualStyleBackColor = true;
            this.btnStepTo.Click += new System.EventHandler(this.btnStepTo_Click);
            // 
            // nudStepTo
            // 
            this.nudStepTo.Location = new System.Drawing.Point(131, 855);
            this.nudStepTo.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nudStepTo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudStepTo.Name = "nudStepTo";
            this.nudStepTo.Size = new System.Drawing.Size(107, 38);
            this.nudStepTo.TabIndex = 10;
            // 
            // nudRelax
            // 
            this.nudRelax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudRelax.Location = new System.Drawing.Point(131, 187);
            this.nudRelax.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nudRelax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudRelax.Name = "nudRelax";
            this.nudRelax.Size = new System.Drawing.Size(107, 38);
            this.nudRelax.TabIndex = 18;
            // 
            // btnInitialize
            // 
            this.btnInitialize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInitialize.Location = new System.Drawing.Point(8, 717);
            this.btnInitialize.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(107, 55);
            this.btnInitialize.TabIndex = 8;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // nudSeed
            // 
            this.nudSeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudSeed.Location = new System.Drawing.Point(131, 7);
            this.nudSeed.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nudSeed.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudSeed.Name = "nudSeed";
            this.nudSeed.Size = new System.Drawing.Size(107, 38);
            this.nudSeed.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 128);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Regions:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudNumRegions
            // 
            this.nudNumRegions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudNumRegions.Location = new System.Drawing.Point(131, 59);
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
            this.nudNumRegions.Size = new System.Drawing.Size(107, 38);
            this.nudNumRegions.TabIndex = 1;
            this.nudNumRegions.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // chDebug
            // 
            this.chDebug.AutoSize = true;
            this.chDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chDebug.Location = new System.Drawing.Point(131, 617);
            this.chDebug.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chDebug.Name = "chDebug";
            this.chDebug.Size = new System.Drawing.Size(107, 36);
            this.chDebug.TabIndex = 12;
            this.chDebug.Text = "Debug?";
            this.chDebug.UseVisualStyleBackColor = true;
            // 
            // btnRegen
            // 
            this.btnRegen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegen.Location = new System.Drawing.Point(131, 717);
            this.btnRegen.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnRegen.Name = "btnRegen";
            this.btnRegen.Size = new System.Drawing.Size(107, 55);
            this.btnRegen.TabIndex = 0;
            this.btnRegen.Text = "Regenerate Graph";
            this.btnRegen.UseVisualStyleBackColor = true;
            this.btnRegen.Click += new System.EventHandler(this.btnRegen_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(8, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 52);
            this.label4.TabIndex = 17;
            this.label4.Text = "Relax:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkShowSites
            // 
            this.chkShowSites.AutoSize = true;
            this.chkShowSites.Checked = true;
            this.chkShowSites.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowSites.Location = new System.Drawing.Point(131, 239);
            this.chkShowSites.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkShowSites.Name = "chkShowSites";
            this.chkShowSites.Size = new System.Drawing.Size(107, 36);
            this.chkShowSites.TabIndex = 3;
            this.chkShowSites.Text = "Show Sites?";
            this.chkShowSites.UseVisualStyleBackColor = true;
            this.chkShowSites.CheckedChanged += new System.EventHandler(this.chkShowEdges_CheckedChanged);
            // 
            // chkShowVertices
            // 
            this.chkShowVertices.AutoSize = true;
            this.chkShowVertices.Checked = true;
            this.chkShowVertices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowVertices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowVertices.Location = new System.Drawing.Point(131, 289);
            this.chkShowVertices.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkShowVertices.Name = "chkShowVertices";
            this.chkShowVertices.Size = new System.Drawing.Size(107, 36);
            this.chkShowVertices.TabIndex = 4;
            this.chkShowVertices.Text = "Show Vertices?";
            this.chkShowVertices.UseVisualStyleBackColor = true;
            this.chkShowVertices.CheckedChanged += new System.EventHandler(this.chkShowEdges_CheckedChanged);
            // 
            // chkShowEdges
            // 
            this.chkShowEdges.AutoSize = true;
            this.chkShowEdges.Checked = true;
            this.chkShowEdges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowEdges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowEdges.Location = new System.Drawing.Point(131, 339);
            this.chkShowEdges.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkShowEdges.Name = "chkShowEdges";
            this.chkShowEdges.Size = new System.Drawing.Size(107, 36);
            this.chkShowEdges.TabIndex = 5;
            this.chkShowEdges.Text = "Show Edges?";
            this.chkShowEdges.UseVisualStyleBackColor = true;
            this.chkShowEdges.CheckedChanged += new System.EventHandler(this.chkShowEdges_CheckedChanged);
            // 
            // chkUseFile
            // 
            this.chkUseFile.AutoSize = true;
            this.chkUseFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseFile.Location = new System.Drawing.Point(131, 439);
            this.chkUseFile.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkUseFile.Name = "chkUseFile";
            this.chkUseFile.Size = new System.Drawing.Size(107, 36);
            this.chkUseFile.TabIndex = 21;
            this.chkUseFile.Text = "Use File?";
            this.chkUseFile.UseVisualStyleBackColor = true;
            // 
            // chkShowNumbers
            // 
            this.chkShowNumbers.AutoSize = true;
            this.chkShowNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowNumbers.Location = new System.Drawing.Point(131, 389);
            this.chkShowNumbers.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkShowNumbers.Name = "chkShowNumbers";
            this.chkShowNumbers.Size = new System.Drawing.Size(107, 36);
            this.chkShowNumbers.TabIndex = 22;
            this.chkShowNumbers.Text = "Show Numbers?";
            this.chkShowNumbers.UseVisualStyleBackColor = true;
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
            this.cbCircles.Location = new System.Drawing.Point(131, 489);
            this.cbCircles.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cbCircles.Name = "cbCircles";
            this.cbCircles.Size = new System.Drawing.Size(107, 39);
            this.cbCircles.TabIndex = 15;
            this.cbCircles.SelectedIndexChanged += new System.EventHandler(this.cbCircles_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(8, 482);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 128);
            this.label5.TabIndex = 19;
            this.label5.Text = "Show Circle Events:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(8, 848);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 52);
            this.label3.TabIndex = 16;
            this.label3.Text = "Step:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkBeachline
            // 
            this.chkBeachline.AutoSize = true;
            this.chkBeachline.Checked = true;
            this.chkBeachline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBeachline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBeachline.Location = new System.Drawing.Point(131, 667);
            this.chkBeachline.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkBeachline.Name = "chkBeachline";
            this.chkBeachline.Size = new System.Drawing.Size(107, 36);
            this.chkBeachline.TabIndex = 20;
            this.chkBeachline.Text = "Show Beachline?";
            this.chkBeachline.UseVisualStyleBackColor = true;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(10, 10);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1448, 49);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInputFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(75, 45);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openInputFileToolStripMenuItem
            // 
            this.openInputFileToolStripMenuItem.Name = "openInputFileToolStripMenuItem";
            this.openInputFileToolStripMenuItem.Size = new System.Drawing.Size(358, 46);
            this.openInputFileToolStripMenuItem.Text = "Open Input File...";
            this.openInputFileToolStripMenuItem.Click += new System.EventHandler(this.file_OpenInput_click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(358, 46);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.file_Exit_click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1468, 1050);
            this.Controls.Add(this.splitPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Voronoi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.splitPanel.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel)).EndInit();
            this.splitPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStepTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRelax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumRegions)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitPanel;
        private System.Windows.Forms.CheckBox chkShowEdges;
        private System.Windows.Forms.CheckBox chkShowVertices;
        private System.Windows.Forms.CheckBox chkShowSites;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudNumRegions;
        private System.Windows.Forms.Button btnRegen;
        private System.Windows.Forms.NumericUpDown nudSeed;
        private System.Windows.Forms.Button btnStepVoronoi;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnStepTo;
        private System.Windows.Forms.NumericUpDown nudStepTo;
        private System.Windows.Forms.CheckBox chDebug;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnimate;
        private System.Windows.Forms.ComboBox cbCircles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudRelax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkBeachline;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInputFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkUseFile;
        private System.Windows.Forms.CheckBox chkShowNumbers;
    }
}