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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateFileFromImageDialog));
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.tableLayoutPanelFiles = new System.Windows.Forms.TableLayoutPanel();
            this.labelOutputFile = new System.Windows.Forms.Label();
            this.labelInputFile = new System.Windows.Forms.Label();
            this.buttonOutputFileBrowse = new System.Windows.Forms.Button();
            this.buttonFileInputFileBrowse = new System.Windows.Forms.Button();
            this.textBoxOutputFile = new System.Windows.Forms.TextBox();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.topTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelOptions = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxXPoints = new System.Windows.Forms.TextBox();
            this.labelXPoints = new System.Windows.Forms.Label();
            this.labelYPoints = new System.Windows.Forms.Label();
            this.textBoxYPoints = new System.Windows.Forms.TextBox();
            this.textBoxMargin = new System.Windows.Forms.TextBox();
            this.labelMargin = new System.Windows.Forms.Label();
            this.groupBoxFiles = new System.Windows.Forms.GroupBox();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.tableLayoutPanelFiles.SuspendLayout();
            this.topTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanelOptions.SuspendLayout();
            this.groupBoxFiles.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelButtons.Controls.Add(this.buttonOpen);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonSave);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonQuit);
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(431, 334);
            this.flowLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(486, 57);
            this.flowLayoutPanelButtons.TabIndex = 4;
            this.flowLayoutPanelButtons.WrapContents = false;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonQuit.AutoSize = true;
            this.buttonQuit.Location = new System.Drawing.Point(330, 6);
            this.buttonQuit.Margin = new System.Windows.Forms.Padding(6);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(150, 45);
            this.buttonQuit.TabIndex = 2;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnQuitButtonClick);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSave.AutoSize = true;
            this.buttonSave.Location = new System.Drawing.Point(168, 6);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 45);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.OnSaveButton_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOpen.AutoSize = true;
            this.buttonOpen.Location = new System.Drawing.Point(6, 6);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(6);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(150, 45);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnOpenButtonClick);
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
            this.tableLayoutPanelFiles.Controls.Add(this.textBoxInputFile, 1, 0);
            this.tableLayoutPanelFiles.Controls.Add(this.textBoxOutputFile, 1, 1);
            this.tableLayoutPanelFiles.Controls.Add(this.buttonFileInputFileBrowse, 2, 0);
            this.tableLayoutPanelFiles.Controls.Add(this.buttonOutputFileBrowse, 2, 1);
            this.tableLayoutPanelFiles.Controls.Add(this.labelInputFile, 0, 0);
            this.tableLayoutPanelFiles.Controls.Add(this.labelOutputFile, 0, 1);
            this.tableLayoutPanelFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFiles.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanelFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanelFiles.Name = "tableLayoutPanelFiles";
            this.tableLayoutPanelFiles.RowCount = 3;
            this.tableLayoutPanelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFiles.Size = new System.Drawing.Size(1336, 92);
            this.tableLayoutPanelFiles.TabIndex = 2;
            // 
            // labelOutputFile
            // 
            this.labelOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOutputFile.AutoSize = true;
            this.labelOutputFile.BackColor = System.Drawing.SystemColors.Control;
            this.labelOutputFile.Location = new System.Drawing.Point(3, 46);
            this.labelOutputFile.Name = "labelOutputFile";
            this.labelOutputFile.Size = new System.Drawing.Size(163, 46);
            this.labelOutputFile.TabIndex = 3;
            this.labelOutputFile.Text = "Output File:";
            this.labelOutputFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // buttonOutputFileBrowse
            // 
            this.buttonOutputFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonOutputFileBrowse.AutoSize = true;
            this.buttonOutputFileBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOutputFileBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOutputFileBrowse.Location = new System.Drawing.Point(1214, 48);
            this.buttonOutputFileBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOutputFileBrowse.Name = "buttonOutputFileBrowse";
            this.buttonOutputFileBrowse.Size = new System.Drawing.Size(119, 42);
            this.buttonOutputFileBrowse.TabIndex = 5;
            this.buttonOutputFileBrowse.Text = "Browse";
            this.buttonOutputFileBrowse.UseVisualStyleBackColor = false;
            this.buttonOutputFileBrowse.Click += new System.EventHandler(this.OnOutputFileBrowseButtonClick);
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
            // textBoxOutputFile
            // 
            this.textBoxOutputFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutputFile.Location = new System.Drawing.Point(172, 48);
            this.textBoxOutputFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxOutputFile.Name = "textBoxOutputFile";
            this.textBoxOutputFile.Size = new System.Drawing.Size(1036, 38);
            this.textBoxOutputFile.TabIndex = 6;
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInputFile.Location = new System.Drawing.Point(172, 2);
            this.textBoxInputFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.Size = new System.Drawing.Size(1036, 38);
            this.textBoxInputFile.TabIndex = 1;
            // 
            // topTableLayoutPanel
            // 
            this.topTableLayoutPanel.AutoSize = true;
            this.topTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.topTableLayoutPanel.ColumnCount = 1;
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topTableLayoutPanel.Controls.Add(this.groupBoxFiles, 0, 0);
            this.topTableLayoutPanel.Controls.Add(this.groupBoxOptions, 0, 1);
            this.topTableLayoutPanel.Controls.Add(this.flowLayoutPanelButtons, 0, 5);
            this.topTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.topTableLayoutPanel.Margin = new System.Windows.Forms.Padding(6);
            this.topTableLayoutPanel.Name = "topTableLayoutPanel";
            this.topTableLayoutPanel.RowCount = 6;
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.topTableLayoutPanel.Size = new System.Drawing.Size(1348, 397);
            this.topTableLayoutPanel.TabIndex = 1;
            // 
            // tableLayoutPanelOptions
            // 
            this.tableLayoutPanelOptions.AutoSize = true;
            this.tableLayoutPanelOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelOptions.ColumnCount = 2;
            this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOptions.Controls.Add(this.labelXPoints, 0, 0);
            this.tableLayoutPanelOptions.Controls.Add(this.textBoxXPoints, 1, 0);
            this.tableLayoutPanelOptions.Controls.Add(this.labelYPoints, 0, 1);
            this.tableLayoutPanelOptions.Controls.Add(this.textBoxYPoints, 1, 1);
            this.tableLayoutPanelOptions.Controls.Add(this.labelMargin, 0, 2);
            this.tableLayoutPanelOptions.Controls.Add(this.textBoxMargin, 1, 2);
            this.tableLayoutPanelOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOptions.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanelOptions.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanelOptions.Name = "tableLayoutPanelOptions";
            this.tableLayoutPanelOptions.RowCount = 3;
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.Size = new System.Drawing.Size(1336, 150);
            this.tableLayoutPanelOptions.TabIndex = 9;
            // 
            // textBoxXPoints
            // 
            this.textBoxXPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxXPoints.Location = new System.Drawing.Point(285, 6);
            this.textBoxXPoints.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxXPoints.Name = "textBoxXPoints";
            this.textBoxXPoints.Size = new System.Drawing.Size(1045, 38);
            this.textBoxXPoints.TabIndex = 1;
            // 
            // labelXPoints
            // 
            this.labelXPoints.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelXPoints.AutoSize = true;
            this.labelXPoints.Location = new System.Drawing.Point(6, 9);
            this.labelXPoints.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelXPoints.Name = "labelXPoints";
            this.labelXPoints.Size = new System.Drawing.Size(267, 32);
            this.labelXPoints.TabIndex = 0;
            this.labelXPoints.Text = "Number of X Points:";
            // 
            // labelYPoints
            // 
            this.labelYPoints.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelYPoints.AutoSize = true;
            this.labelYPoints.Location = new System.Drawing.Point(6, 59);
            this.labelYPoints.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelYPoints.Name = "labelYPoints";
            this.labelYPoints.Size = new System.Drawing.Size(267, 32);
            this.labelYPoints.TabIndex = 0;
            this.labelYPoints.Text = "Number of Y Points:";
            // 
            // textBoxYPoints
            // 
            this.textBoxYPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxYPoints.Location = new System.Drawing.Point(285, 56);
            this.textBoxYPoints.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxYPoints.Name = "textBoxYPoints";
            this.textBoxYPoints.Size = new System.Drawing.Size(1045, 38);
            this.textBoxYPoints.TabIndex = 1;
            // 
            // textBoxMargin
            // 
            this.textBoxMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMargin.Location = new System.Drawing.Point(285, 106);
            this.textBoxMargin.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxMargin.Name = "textBoxMargin";
            this.textBoxMargin.Size = new System.Drawing.Size(1045, 38);
            this.textBoxMargin.TabIndex = 1;
            // 
            // labelMargin
            // 
            this.labelMargin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMargin.AutoSize = true;
            this.labelMargin.Location = new System.Drawing.Point(6, 109);
            this.labelMargin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelMargin.Name = "labelMargin";
            this.labelMargin.Size = new System.Drawing.Size(110, 32);
            this.labelMargin.TabIndex = 0;
            this.labelMargin.Text = "Margin:";
            // 
            // groupBoxFiles
            // 
            this.groupBoxFiles.AutoSize = true;
            this.groupBoxFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxFiles.Controls.Add(this.tableLayoutPanelFiles);
            this.groupBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFiles.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFiles.Name = "groupBoxFiles";
            this.groupBoxFiles.Size = new System.Drawing.Size(1342, 129);
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
            this.groupBoxOptions.Location = new System.Drawing.Point(3, 138);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(1342, 187);
            this.groupBoxOptions.TabIndex = 10;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // CreateFileFromImageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1348, 397);
            this.Controls.Add(this.topTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateFileFromImageDialog";
            this.Text = "Create File From Image";
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelButtons.PerformLayout();
            this.tableLayoutPanelFiles.ResumeLayout(false);
            this.tableLayoutPanelFiles.PerformLayout();
            this.topTableLayoutPanel.ResumeLayout(false);
            this.topTableLayoutPanel.PerformLayout();
            this.tableLayoutPanelOptions.ResumeLayout(false);
            this.tableLayoutPanelOptions.PerformLayout();
            this.groupBoxFiles.ResumeLayout(false);
            this.groupBoxFiles.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
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
        private System.Windows.Forms.Label labelXPoints;
        private System.Windows.Forms.TextBox textBoxXPoints;
        private System.Windows.Forms.Label labelYPoints;
        private System.Windows.Forms.TextBox textBoxYPoints;
        private System.Windows.Forms.Label labelMargin;
        private System.Windows.Forms.TextBox textBoxMargin;
        private System.Windows.Forms.GroupBox groupBoxFiles;
        private System.Windows.Forms.GroupBox groupBoxOptions;
    }
}