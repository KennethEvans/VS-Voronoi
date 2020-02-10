namespace VoronoiMap {
    partial class CreateFileFromImageDialog {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateFileFromImageDialog));
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.buttonNewJson = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.tableLayoutPanelFiles = new System.Windows.Forms.TableLayoutPanel();
            this.labelInputFile = new System.Windows.Forms.Label();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.buttonFileInputFileBrowse = new System.Windows.Forms.Button();
            this.labelJsonFile = new System.Windows.Forms.Label();
            this.textBoxJsonFile = new System.Windows.Forms.TextBox();
            this.buttonJsonFileBrowse = new System.Windows.Forms.Button();
            this.labelOutputFile = new System.Windows.Forms.Label();
            this.textBoxOutputFile = new System.Windows.Forms.TextBox();
            this.buttonOutputFileBrowse = new System.Windows.Forms.Button();
            this.topTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBoxFiles = new System.Windows.Forms.GroupBox();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelOptions = new System.Windows.Forms.TableLayoutPanel();
            this.labelNPoints = new System.Windows.Forms.Label();
            this.textBoxNPoints = new System.Windows.Forms.TextBox();
            this.labelLeft = new System.Windows.Forms.Label();
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.labelRight = new System.Windows.Forms.Label();
            this.textBoxRight = new System.Windows.Forms.TextBox();
            this.labelTop = new System.Windows.Forms.Label();
            this.textBoxTop = new System.Windows.Forms.TextBox();
            this.labelBottom = new System.Windows.Forms.Label();
            this.textBoxBottom = new System.Windows.Forms.TextBox();
            this.labelMarginH = new System.Windows.Forms.Label();
            this.textBoxMarginH = new System.Windows.Forms.TextBox();
            this.labelMarginV = new System.Windows.Forms.Label();
            this.textBoxMarginV = new System.Windows.Forms.TextBox();
            this.checkBoxRandom = new System.Windows.Forms.CheckBox();
            this.checkBoxLatScaling = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanelButtons.SuspendLayout();
            this.tableLayoutPanelFiles.SuspendLayout();
            this.topTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBoxFiles.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.tableLayoutPanelOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelButtons.Controls.Add(this.buttonClear);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonRandom);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonNewJson);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonOpen);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonSave);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonQuit);
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(143, 1368);
            this.flowLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(1062, 57);
            this.flowLayoutPanelButtons.TabIndex = 4;
            this.flowLayoutPanelButtons.WrapContents = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonClear.AutoSize = true;
            this.buttonClear.Location = new System.Drawing.Point(6, 6);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(6);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(150, 45);
            this.buttonClear.TabIndex = 0;
            this.buttonClear.Text = "Clear";
            this.toolTip.SetToolTip(this.buttonClear, "Clear sites");
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.OnClearButtonClick);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRandom.AutoSize = true;
            this.buttonRandom.Location = new System.Drawing.Point(168, 6);
            this.buttonRandom.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(195, 45);
            this.buttonRandom.TabIndex = 1;
            this.buttonRandom.Text = "New Random";
            this.toolTip.SetToolTip(this.buttonRandom, "Generate random sites");
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.OnNewRandomButtonClick);
            // 
            // buttonNewJson
            // 
            this.buttonNewJson.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonNewJson.AutoSize = true;
            this.buttonNewJson.Location = new System.Drawing.Point(375, 6);
            this.buttonNewJson.Margin = new System.Windows.Forms.Padding(6);
            this.buttonNewJson.Name = "buttonNewJson";
            this.buttonNewJson.Size = new System.Drawing.Size(195, 45);
            this.buttonNewJson.TabIndex = 2;
            this.buttonNewJson.Text = "New JSON";
            this.toolTip.SetToolTip(this.buttonNewJson, "Open new JSON with sites");
            this.buttonNewJson.UseVisualStyleBackColor = true;
            this.buttonNewJson.Click += new System.EventHandler(this.OnJsonFileBrowse);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOpen.AutoSize = true;
            this.buttonOpen.Location = new System.Drawing.Point(582, 6);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(6);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(150, 45);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.Text = "Open";
            this.toolTip.SetToolTip(this.buttonOpen, "Open image file");
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnOpenButtonClick);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSave.AutoSize = true;
            this.buttonSave.Location = new System.Drawing.Point(744, 6);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 45);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.toolTip.SetToolTip(this.buttonSave, "Save JSON file");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.OnSaveButton_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonQuit.AutoSize = true;
            this.buttonQuit.Location = new System.Drawing.Point(906, 6);
            this.buttonQuit.Margin = new System.Windows.Forms.Padding(6);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(150, 45);
            this.buttonQuit.TabIndex = 5;
            this.buttonQuit.Text = "Quit";
            this.toolTip.SetToolTip(this.buttonQuit, "Exit this dialog");
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnQuitButtonClick);
            // 
            // tableLayoutPanelFiles
            // 
            this.tableLayoutPanelFiles.AutoSize = true;
            this.tableLayoutPanelFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelFiles.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanelFiles.ColumnCount = 3;
            this.tableLayoutPanelFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFiles.Controls.Add(this.labelInputFile, 0, 0);
            this.tableLayoutPanelFiles.Controls.Add(this.textBoxInputFile, 1, 0);
            this.tableLayoutPanelFiles.Controls.Add(this.buttonFileInputFileBrowse, 2, 0);
            this.tableLayoutPanelFiles.Controls.Add(this.labelJsonFile, 0, 1);
            this.tableLayoutPanelFiles.Controls.Add(this.textBoxJsonFile, 1, 1);
            this.tableLayoutPanelFiles.Controls.Add(this.buttonJsonFileBrowse, 2, 1);
            this.tableLayoutPanelFiles.Controls.Add(this.labelOutputFile, 0, 2);
            this.tableLayoutPanelFiles.Controls.Add(this.textBoxOutputFile, 1, 2);
            this.tableLayoutPanelFiles.Controls.Add(this.buttonOutputFileBrowse, 2, 2);
            this.tableLayoutPanelFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFiles.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanelFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanelFiles.Name = "tableLayoutPanelFiles";
            this.tableLayoutPanelFiles.RowCount = 3;
            this.tableLayoutPanelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelFiles.Size = new System.Drawing.Size(1336, 138);
            this.tableLayoutPanelFiles.TabIndex = 2;
            // 
            // labelInputFile
            // 
            this.labelInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInputFile.AutoSize = true;
            this.labelInputFile.BackColor = System.Drawing.SystemColors.Control;
            this.labelInputFile.Location = new System.Drawing.Point(3, 0);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.Size = new System.Drawing.Size(140, 46);
            this.labelInputFile.TabIndex = 0;
            this.labelInputFile.Text = "Input File:";
            this.labelInputFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInputFile.Location = new System.Drawing.Point(172, 2);
            this.textBoxInputFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.Size = new System.Drawing.Size(1036, 38);
            this.textBoxInputFile.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBoxInputFile, "Image file");
            // 
            // buttonFileInputFileBrowse
            // 
            this.buttonFileInputFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonFileInputFileBrowse.AutoSize = true;
            this.buttonFileInputFileBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonFileInputFileBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.buttonFileInputFileBrowse.Location = new System.Drawing.Point(1214, 2);
            this.buttonFileInputFileBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFileInputFileBrowse.Name = "buttonFileInputFileBrowse";
            this.buttonFileInputFileBrowse.Size = new System.Drawing.Size(119, 42);
            this.buttonFileInputFileBrowse.TabIndex = 2;
            this.buttonFileInputFileBrowse.Text = "Browse";
            this.buttonFileInputFileBrowse.UseVisualStyleBackColor = false;
            this.buttonFileInputFileBrowse.Click += new System.EventHandler(this.OnInputFileBrowseButtonClick);
            // 
            // labelJsonFile
            // 
            this.labelJsonFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelJsonFile.AutoSize = true;
            this.labelJsonFile.BackColor = System.Drawing.SystemColors.Control;
            this.labelJsonFile.Location = new System.Drawing.Point(3, 46);
            this.labelJsonFile.Name = "labelJsonFile";
            this.labelJsonFile.Size = new System.Drawing.Size(152, 46);
            this.labelJsonFile.TabIndex = 3;
            this.labelJsonFile.Text = "JSON File:";
            this.labelJsonFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxJsonFile
            // 
            this.textBoxJsonFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxJsonFile.Location = new System.Drawing.Point(172, 48);
            this.textBoxJsonFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxJsonFile.Name = "textBoxJsonFile";
            this.textBoxJsonFile.Size = new System.Drawing.Size(1036, 38);
            this.textBoxJsonFile.TabIndex = 4;
            this.toolTip.SetToolTip(this.textBoxJsonFile, "JSON file with sites");
            // 
            // buttonJsonFileBrowse
            // 
            this.buttonJsonFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonJsonFileBrowse.AutoSize = true;
            this.buttonJsonFileBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonJsonFileBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.buttonJsonFileBrowse.Location = new System.Drawing.Point(1214, 48);
            this.buttonJsonFileBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonJsonFileBrowse.Name = "buttonJsonFileBrowse";
            this.buttonJsonFileBrowse.Size = new System.Drawing.Size(119, 42);
            this.buttonJsonFileBrowse.TabIndex = 5;
            this.buttonJsonFileBrowse.Text = "Browse";
            this.buttonJsonFileBrowse.UseVisualStyleBackColor = false;
            this.buttonJsonFileBrowse.Click += new System.EventHandler(this.OnJsonFileBrowse);
            // 
            // labelOutputFile
            // 
            this.labelOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOutputFile.AutoSize = true;
            this.labelOutputFile.BackColor = System.Drawing.SystemColors.Control;
            this.labelOutputFile.Location = new System.Drawing.Point(3, 92);
            this.labelOutputFile.Name = "labelOutputFile";
            this.labelOutputFile.Size = new System.Drawing.Size(163, 46);
            this.labelOutputFile.TabIndex = 6;
            this.labelOutputFile.Text = "Output File:";
            this.labelOutputFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOutputFile
            // 
            this.textBoxOutputFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutputFile.Location = new System.Drawing.Point(172, 94);
            this.textBoxOutputFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxOutputFile.Name = "textBoxOutputFile";
            this.textBoxOutputFile.Size = new System.Drawing.Size(1036, 38);
            this.textBoxOutputFile.TabIndex = 7;
            this.toolTip.SetToolTip(this.textBoxOutputFile, "JSON output file");
            // 
            // buttonOutputFileBrowse
            // 
            this.buttonOutputFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonOutputFileBrowse.AutoSize = true;
            this.buttonOutputFileBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOutputFileBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOutputFileBrowse.Location = new System.Drawing.Point(1214, 94);
            this.buttonOutputFileBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOutputFileBrowse.Name = "buttonOutputFileBrowse";
            this.buttonOutputFileBrowse.Size = new System.Drawing.Size(119, 42);
            this.buttonOutputFileBrowse.TabIndex = 8;
            this.buttonOutputFileBrowse.Text = "Browse";
            this.buttonOutputFileBrowse.UseVisualStyleBackColor = false;
            this.buttonOutputFileBrowse.Click += new System.EventHandler(this.OnOutputFileBrowseButtonClick);
            // 
            // topTableLayoutPanel
            // 
            this.topTableLayoutPanel.AutoSize = true;
            this.topTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.topTableLayoutPanel.ColumnCount = 1;
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topTableLayoutPanel.Controls.Add(this.pictureBox, 0, 0);
            this.topTableLayoutPanel.Controls.Add(this.groupBoxFiles, 0, 1);
            this.topTableLayoutPanel.Controls.Add(this.groupBoxOptions, 0, 2);
            this.topTableLayoutPanel.Controls.Add(this.flowLayoutPanelButtons, 0, 3);
            this.topTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.topTableLayoutPanel.Margin = new System.Windows.Forms.Padding(6);
            this.topTableLayoutPanel.Name = "topTableLayoutPanel";
            this.topTableLayoutPanel.RowCount = 4;
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topTableLayoutPanel.Size = new System.Drawing.Size(1348, 1431);
            this.topTableLayoutPanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(10, 10);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1328, 876);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox, "Add: Click, Delete: Shift-Click, Move: Drag, Abort: Ctrl");
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // groupBoxFiles
            // 
            this.groupBoxFiles.AutoSize = true;
            this.groupBoxFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxFiles.Controls.Add(this.tableLayoutPanelFiles);
            this.groupBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFiles.Location = new System.Drawing.Point(3, 899);
            this.groupBoxFiles.Name = "groupBoxFiles";
            this.groupBoxFiles.Size = new System.Drawing.Size(1342, 175);
            this.groupBoxFiles.TabIndex = 2;
            this.groupBoxFiles.TabStop = false;
            this.groupBoxFiles.Text = "Files";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.AutoSize = true;
            this.groupBoxOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxOptions.Controls.Add(this.tableLayoutPanelOptions);
            this.groupBoxOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOptions.Location = new System.Drawing.Point(3, 1080);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(1342, 279);
            this.groupBoxOptions.TabIndex = 0;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // tableLayoutPanelOptions
            // 
            this.tableLayoutPanelOptions.AutoSize = true;
            this.tableLayoutPanelOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelOptions.ColumnCount = 4;
            this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOptions.Controls.Add(this.labelNPoints, 0, 0);
            this.tableLayoutPanelOptions.Controls.Add(this.textBoxNPoints, 1, 0);
            this.tableLayoutPanelOptions.Controls.Add(this.labelLeft, 0, 1);
            this.tableLayoutPanelOptions.Controls.Add(this.textBoxLeft, 1, 1);
            this.tableLayoutPanelOptions.Controls.Add(this.labelRight, 2, 1);
            this.tableLayoutPanelOptions.Controls.Add(this.textBoxRight, 3, 1);
            this.tableLayoutPanelOptions.Controls.Add(this.labelTop, 0, 2);
            this.tableLayoutPanelOptions.Controls.Add(this.textBoxTop, 1, 2);
            this.tableLayoutPanelOptions.Controls.Add(this.labelBottom, 2, 2);
            this.tableLayoutPanelOptions.Controls.Add(this.textBoxBottom, 3, 2);
            this.tableLayoutPanelOptions.Controls.Add(this.labelMarginH, 0, 3);
            this.tableLayoutPanelOptions.Controls.Add(this.textBoxMarginH, 1, 3);
            this.tableLayoutPanelOptions.Controls.Add(this.labelMarginV, 2, 3);
            this.tableLayoutPanelOptions.Controls.Add(this.textBoxMarginV, 3, 3);
            this.tableLayoutPanelOptions.Controls.Add(this.checkBoxRandom, 0, 4);
            this.tableLayoutPanelOptions.Controls.Add(this.checkBoxLatScaling, 1, 4);
            this.tableLayoutPanelOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOptions.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanelOptions.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanelOptions.Name = "tableLayoutPanelOptions";
            this.tableLayoutPanelOptions.RowCount = 5;
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.Size = new System.Drawing.Size(1336, 242);
            this.tableLayoutPanelOptions.TabIndex = 9;
            this.toolTip.SetToolTip(this.tableLayoutPanelOptions, "Number of random points");
            // 
            // labelNPoints
            // 
            this.labelNPoints.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNPoints.AutoSize = true;
            this.labelNPoints.Location = new System.Drawing.Point(6, 9);
            this.labelNPoints.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelNPoints.Name = "labelNPoints";
            this.labelNPoints.Size = new System.Drawing.Size(241, 32);
            this.labelNPoints.TabIndex = 0;
            this.labelNPoints.Text = "Number of Points:";
            // 
            // textBoxNPoints
            // 
            this.textBoxNPoints.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxNPoints.Location = new System.Drawing.Point(264, 6);
            this.textBoxNPoints.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxNPoints.Name = "textBoxNPoints";
            this.textBoxNPoints.Size = new System.Drawing.Size(200, 38);
            this.textBoxNPoints.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBoxNPoints, "Number of points for random");
            // 
            // labelLeft
            // 
            this.labelLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLeft.AutoSize = true;
            this.labelLeft.Location = new System.Drawing.Point(6, 59);
            this.labelLeft.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(71, 32);
            this.labelLeft.TabIndex = 2;
            this.labelLeft.Text = "Left:";
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxLeft.Location = new System.Drawing.Point(264, 56);
            this.textBoxLeft.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.Size = new System.Drawing.Size(200, 38);
            this.textBoxLeft.TabIndex = 3;
            this.toolTip.SetToolTip(this.textBoxLeft, "Left boundary for MapData");
            // 
            // labelRight
            // 
            this.labelRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelRight.AutoSize = true;
            this.labelRight.Location = new System.Drawing.Point(528, 59);
            this.labelRight.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRight.Name = "labelRight";
            this.labelRight.Size = new System.Drawing.Size(90, 32);
            this.labelRight.TabIndex = 4;
            this.labelRight.Text = "Right:";
            // 
            // textBoxRight
            // 
            this.textBoxRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxRight.Location = new System.Drawing.Point(753, 56);
            this.textBoxRight.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxRight.Name = "textBoxRight";
            this.textBoxRight.Size = new System.Drawing.Size(200, 38);
            this.textBoxRight.TabIndex = 5;
            this.toolTip.SetToolTip(this.textBoxRight, "Right boundary for MapData");
            // 
            // labelTop
            // 
            this.labelTop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTop.AutoSize = true;
            this.labelTop.Location = new System.Drawing.Point(6, 109);
            this.labelTop.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(72, 32);
            this.labelTop.TabIndex = 6;
            this.labelTop.Text = "Top:";
            // 
            // textBoxTop
            // 
            this.textBoxTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxTop.Location = new System.Drawing.Point(264, 106);
            this.textBoxTop.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxTop.Name = "textBoxTop";
            this.textBoxTop.Size = new System.Drawing.Size(200, 38);
            this.textBoxTop.TabIndex = 7;
            this.toolTip.SetToolTip(this.textBoxTop, "Top boundary for MapData");
            // 
            // labelBottom
            // 
            this.labelBottom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBottom.AutoSize = true;
            this.labelBottom.Location = new System.Drawing.Point(528, 109);
            this.labelBottom.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelBottom.Name = "labelBottom";
            this.labelBottom.Size = new System.Drawing.Size(113, 32);
            this.labelBottom.TabIndex = 8;
            this.labelBottom.Text = "Bottom:";
            // 
            // textBoxBottom
            // 
            this.textBoxBottom.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxBottom.Location = new System.Drawing.Point(753, 106);
            this.textBoxBottom.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxBottom.Name = "textBoxBottom";
            this.textBoxBottom.Size = new System.Drawing.Size(200, 38);
            this.textBoxBottom.TabIndex = 9;
            this.toolTip.SetToolTip(this.textBoxBottom, "Bottom boundary for MapData");
            // 
            // labelMarginH
            // 
            this.labelMarginH.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMarginH.AutoSize = true;
            this.labelMarginH.Location = new System.Drawing.Point(6, 159);
            this.labelMarginH.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelMarginH.Name = "labelMarginH";
            this.labelMarginH.Size = new System.Drawing.Size(246, 32);
            this.labelMarginH.TabIndex = 10;
            this.labelMarginH.Text = "Horizontal Margin:";
            // 
            // textBoxMarginH
            // 
            this.textBoxMarginH.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxMarginH.Location = new System.Drawing.Point(264, 156);
            this.textBoxMarginH.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxMarginH.Name = "textBoxMarginH";
            this.textBoxMarginH.Size = new System.Drawing.Size(200, 38);
            this.textBoxMarginH.TabIndex = 11;
            // 
            // labelMarginV
            // 
            this.labelMarginV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMarginV.AutoSize = true;
            this.labelMarginV.Location = new System.Drawing.Point(528, 159);
            this.labelMarginV.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelMarginV.Name = "labelMarginV";
            this.labelMarginV.Size = new System.Drawing.Size(213, 32);
            this.labelMarginV.TabIndex = 12;
            this.labelMarginV.Text = "Vertical Margin:";
            // 
            // textBoxMarginV
            // 
            this.textBoxMarginV.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxMarginV.Location = new System.Drawing.Point(753, 156);
            this.textBoxMarginV.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxMarginV.Name = "textBoxMarginV";
            this.textBoxMarginV.Size = new System.Drawing.Size(200, 38);
            this.textBoxMarginV.TabIndex = 13;
            // 
            // checkBoxRandom
            // 
            this.checkBoxRandom.AutoSize = true;
            this.checkBoxRandom.Location = new System.Drawing.Point(3, 203);
            this.checkBoxRandom.Name = "checkBoxRandom";
            this.checkBoxRandom.Size = new System.Drawing.Size(160, 36);
            this.checkBoxRandom.TabIndex = 14;
            this.checkBoxRandom.Text = "Random";
            this.toolTip.SetToolTip(this.checkBoxRandom, "Use random or use sites form JSON file");
            this.checkBoxRandom.UseVisualStyleBackColor = true;
            this.checkBoxRandom.CheckedChanged += new System.EventHandler(this.OnRandomCheckChanged);
            // 
            // checkBoxLatScaling
            // 
            this.checkBoxLatScaling.AutoSize = true;
            this.checkBoxLatScaling.Location = new System.Drawing.Point(261, 203);
            this.checkBoxLatScaling.Name = "checkBoxLatScaling";
            this.checkBoxLatScaling.Size = new System.Drawing.Size(258, 36);
            this.checkBoxLatScaling.TabIndex = 15;
            this.checkBoxLatScaling.Text = "Latitude Scaling";
            this.toolTip.SetToolTip(this.checkBoxLatScaling, "Reduce random sites by latitude");
            this.checkBoxLatScaling.UseVisualStyleBackColor = true;
            // 
            // CreateFileFromImageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1348, 1431);
            this.Controls.Add(this.topTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateFileFromImageDialog";
            this.Text = "Create File From Image";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelButtons.PerformLayout();
            this.tableLayoutPanelFiles.ResumeLayout(false);
            this.tableLayoutPanelFiles.PerformLayout();
            this.topTableLayoutPanel.ResumeLayout(false);
            this.topTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBoxFiles.ResumeLayout(false);
            this.groupBoxFiles.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.tableLayoutPanelOptions.ResumeLayout(false);
            this.tableLayoutPanelOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFiles;
        private System.Windows.Forms.TextBox textBoxInputFile;
        private System.Windows.Forms.TextBox textBoxOutputFile;
        private System.Windows.Forms.Button buttonFileInputFileBrowse;
        private System.Windows.Forms.Button buttonOutputFileBrowse;
        private System.Windows.Forms.Label labelInputFile;
        private System.Windows.Forms.Label labelOutputFile;
        private System.Windows.Forms.TableLayoutPanel topTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOptions;
        private System.Windows.Forms.Label labelNPoints;
        private System.Windows.Forms.TextBox textBoxNPoints;
        private System.Windows.Forms.Label labelMarginH;
        private System.Windows.Forms.TextBox textBoxMarginH;
        private System.Windows.Forms.GroupBox groupBoxFiles;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.Label labelMarginV;
        private System.Windows.Forms.TextBox textBoxMarginV;
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.Label labelRight;
        private System.Windows.Forms.TextBox textBoxRight;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.TextBox textBoxTop;
        private System.Windows.Forms.Label labelBottom;
        private System.Windows.Forms.TextBox textBoxBottom;
        private System.Windows.Forms.CheckBox checkBoxRandom;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelJsonFile;
        private System.Windows.Forms.TextBox textBoxJsonFile;
        private System.Windows.Forms.Button buttonJsonFileBrowse;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Button buttonNewJson;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox checkBoxLatScaling;
    }
}