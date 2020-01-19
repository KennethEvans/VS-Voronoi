using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KEUtils;

namespace VoronoiMap {
    public partial class CreateFileFromImageDialog : Form {
        private static readonly string LF = Environment.NewLine;
        public CreateFileFromImageDialog() {
            InitializeComponent();

            textBoxMargin.Text = "0";
            textBoxXPoints.Text = "100";
            textBoxYPoints.Text = "100";
        }

        private Bitmap bitmap;

        private void OnInputFileBrowseButtonClick(object sender, System.EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                textBoxInputFile.Text = dlg.FileName;
            }
        }

        private void OnOutputFileBrowseButtonClick(object sender, System.EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Json Files|*.json";
            dlg.Title = "Select a Map Data File";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                textBoxOutputFile.Text = dlg.FileName;
            }
        }

        private void OnOpenButtonClick(object sender, MouseEventArgs e) {
            string fileName = textBoxInputFile.Text;
            if (String.IsNullOrEmpty(fileName)) {
                Utils.errMsg("There is no " +
                    "input file name defined");
                return;
            }
            if (!File.Exists(fileName)) {
                Utils.errMsg("Does not exist: " + fileName);
            }
            bitmap = new Bitmap(fileName);
            Utils.infoMsg("Opened: " + fileName + LF + "Width=" + bitmap.Width
                + " Height=" + bitmap.Height);
        }

        private void OnSaveButton_Click(object sender, System.EventArgs e) {
            string fileName = textBoxOutputFile.Text;
            if (String.IsNullOrEmpty(fileName)) {
                Utils.errMsg("There is no " +
                    "output file name defined");
                return;
            }
            try {
                float margin = float.Parse(textBoxMargin.Text);
                int nXPoints = int.Parse(textBoxXPoints.Text);
                int nYPoints = int.Parse(textBoxYPoints.Text);
                if (nXPoints <= 0) {
                    Utils.errMsg("Number of X Points must be greater than 0");
                    return;
                }
                if (nYPoints <= 0) {
                    Utils.errMsg("Number of Y Points must be greater than 0");
                    return;
                }
                if (bitmap.Width < 2 * (nXPoints + 1)) {
                    Utils.errMsg("Image Width=" + bitmap.Width
                        + " is too small for " + nXPoints + " points");
                    return;
                }
                if (bitmap.Height < 2 * (nYPoints + 1)) {
                    Utils.errMsg("Image Height=" + bitmap.Height
                        + " is too small for " + nXPoints + " points");
                    return;
                }
                List<BasicSite> basicSiteList = new List<BasicSite>();
                MapData mapData = new MapData(-margin, bitmap.Width + margin,
                    -margin, bitmap.Height + margin, basicSiteList);
                float deltaX = (float)bitmap.Width / (nXPoints + 1);
                float deltaY = (float)bitmap.Height / (nYPoints + 1);
                BasicSite basicSite = null;
                int pixelX, pixelY;
                Color color;
                for (int col = 0; col < nYPoints; col++) {
                    pixelY = (int)Math.Round(.5 + col * deltaY);
                    if (pixelY < 0) pixelY = 0;
                    if (pixelY > bitmap.Height - 1) pixelY = bitmap.Height - 1;
                    for (int row = 0; row < nXPoints; row++) {
                        pixelX = (int)Math.Round(.5 + row * deltaX);
                        if (pixelX < 0) pixelX = 0;
                        if (pixelX > bitmap.Width - 1) pixelY = bitmap.Height - 1;
                        color = bitmap.GetPixel(pixelX, pixelY);
                        basicSite = new BasicSite(pixelX, pixelY, color);
                        mapData.SiteList.Add(basicSite);
                    }
                }
                mapData.saveMapDataAsJson(fileName, true);
                Utils.infoMsg("Saved: " + fileName);
            } catch (Exception ex) {
                Utils.excMsg("Failed to save " + fileName, ex);
            }
        }

        private void OnQuitButtonClick(object sender, MouseEventArgs e) {
            Hide();
        }
    }
}
