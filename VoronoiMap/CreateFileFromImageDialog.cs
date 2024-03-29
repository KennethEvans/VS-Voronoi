﻿#undef debugMouse

using KEUtils.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VoronoiMap {
    public partial class CreateFileFromImageDialog : Form {
        private static readonly string LF = Environment.NewLine;
        private MainForm mainForm;
        private static readonly int pointRadius = 4;
        private MapData fileMapData;
        private MapData randomMapData;
        private MapData mapData;     // The current MapData, one of the above
        private Bitmap bitmap;
        private Bitmap curBitmap;
        private MouseStatus mouseStatus;

        public CreateFileFromImageDialog(MainForm mainForm) {
            this.mainForm = mainForm;
            InitializeComponent();

            textBoxInputFile.Text = Properties.ImageSettings.Default.ImageFileName;
            textBoxJsonFile.Text = Properties.ImageSettings.Default.JsonFileName;
            textBoxOutputFile.Text = Properties.ImageSettings.Default.OutputFileName;
            textBoxNPoints.Text = Properties.ImageSettings.Default.NPoints;
            textBoxLeft.Text = Properties.ImageSettings.Default.Left;
            textBoxRight.Text = Properties.ImageSettings.Default.Right;
            textBoxTop.Text = Properties.ImageSettings.Default.Top;
            textBoxBottom.Text = Properties.ImageSettings.Default.Bottom;
            textBoxMarginH.Text = Properties.ImageSettings.Default.MarginH;
            textBoxMarginV.Text = Properties.ImageSettings.Default.MarginV;
            checkBoxRandom.Checked = Properties.ImageSettings.Default.Random;
            checkBoxLatScaling.Checked = Properties.ImageSettings.Default.LatScaling;

            if (File.Exists(textBoxInputFile.Text)) {
                loadImage(textBoxInputFile.Text);
            }
            if (File.Exists(textBoxJsonFile.Text)) {
                loadJson(textBoxJsonFile.Text);
            }
        }

        private void loadImage(string fileName) {
            bitmap = new Bitmap(fileName);
            pictureBox.Image = bitmap;
        }

        private void loadJson(string fileName) {
            //mainForm.writeInfo("loadJson checkBoxRandom.Checked="
            //    + checkBoxRandom.Checked + " mapData=" + mapData);
            fileMapData = new MapData(fileName);
            if (!checkBoxRandom.Checked) {
                resetMapData(fileMapData);
            } else {
                checkBoxRandom.Checked = false;
            }
            if (textBoxRight.Text.Equals("0") && textBoxBottom.Text.Equals("0")) {
                textBoxLeft.Text = mapData.Left.ToString();
                textBoxRight.Text = mapData.Right.ToString();
                textBoxTop.Text = mapData.Top.ToString();
                textBoxBottom.Text = mapData.Bottom.ToString();
            }
        }

        void clearMapData() {
            //mainForm.writeInfo("clearMapData checkBoxRandom.Checked="
            //    + checkBoxRandom.Checked + " mapData=" + mapData);
            if (mapData == null) return;
            mapData.SiteList = new List<BasicSite>();
            plotMapData(mapData);
        }

        void plotMapData(MapData mapData) {
#if debugMouse
            mainForm.writeInfo("plotMapData checkBoxRandom.Checked="
                + checkBoxRandom.Checked);
            mainForm.writeInfo("   mapData=" + mapData);
#endif
            if (bitmap == null || mapData == null) {
                return;
            }
            if (curBitmap != null) {
                curBitmap.Dispose();
            }
            curBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            Transform trans = new Transform(bitmap.Size, mapData);
            PointF p0;
#if debugMouse && false
            mainForm.writeInfo("Transforming mapData to bitmap
            mainForm.writeInfo("bitmap.Width=" + bitmap.Width
                + " bitmap.Height=" + bitmap.Height
                + " bitmap.Size=" + bitmap.Size);
            p0 = new PointF(mapData.Left, mapData.Top);
            mainForm.writeInfo("left-top: " + p0 + "->" + trans.tf(p0));
            p0 = new PointF(mapData.Right, mapData.Top);
            mainForm.writeInfo("right-top: " + p0 + "->" + trans.tf(p0));
            p0 = new PointF(mapData.Right, mapData.Bottom);
            mainForm.writeInfo("right-bottom: " + p0 + "->" + trans.tf(p0));
            p0 = new PointF(mapData.Left, mapData.Bottom);
            mainForm.writeInfo("left-bottom: " + p0 + "->" + trans.tf(p0));
#endif
            using (Graphics gr = Graphics.FromImage(curBitmap)) {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gr.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
                RectangleF rect;
                using (Pen pen = new Pen(Color.Black, 4)) {
                    foreach (BasicSite basicSite in mapData.SiteList) {
                        p0 = trans.tf(new PointF(basicSite.X, basicSite.Y));
                        rect = new RectangleF(p0.X - pointRadius, p0.Y -
                            pointRadius, 2 * pointRadius, 2 * pointRadius);
                        gr.DrawEllipse(pen, rect);
                    }
                }
            }
            pictureBox.Image = curBitmap;
        }

        private void resetMapData(MapData newMapData) {
            mapData = new MapData(newMapData);
            plotMapData(mapData);
        }

        private MapData emptyMapData() {
            // Make a new one
            float marginH = float.Parse(textBoxMarginH.Text);
            float marginV = float.Parse(textBoxMarginV.Text);
            int nPoints = int.Parse(textBoxNPoints.Text);
            int left = int.Parse(textBoxLeft.Text);
            int right = int.Parse(textBoxRight.Text);
            int top = int.Parse(textBoxTop.Text);
            int bottom = int.Parse(textBoxBottom.Text);
            if (nPoints <= 0) {
                Utils.errMsg("emptyMapData failed: " +
                    "Number of X Points must be greater than 0");
                return null;
            }
            List<BasicSite> basicSiteList = new List<BasicSite>();
            return new MapData(left, right, top, bottom, basicSiteList);
        }

        private double distance(BasicSite basicSite, PointF p) {
            return (basicSite.X - p.X) * (basicSite.X - p.X) +
                (basicSite.Y - p.Y) * (basicSite.Y - p.Y);
        }

        /// <summary>
        /// Determines the normlized radius of a circle of constant latitude.
        /// </summary>
        /// <param name="lat">Latitude in degrees.</param>
        /// <returns></returns>
        private double latRatio(double lat) {
            return Math.Abs(Math.Cos(Math.PI * lat / 180.0));
        }

        private void OnInputFileBrowseButtonClick(object sender, System.EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select an Image File";
            string fileName = textBoxInputFile.Text;
            if (!String.IsNullOrEmpty(fileName)) {
                dlg.FileName = fileName;
                dlg.InitialDirectory = Directory.GetParent(fileName).FullName;
            }
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                textBoxInputFile.Text = dlg.FileName;
                loadImage(dlg.FileName);
            }
        }

        private void OnJsonFileBrowse(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Json Files|*.json";
            dlg.Title = "Select a JSON Input File";
            string fileName = textBoxJsonFile.Text;
            if (!String.IsNullOrEmpty(fileName)) {
                dlg.FileName = fileName;
                dlg.InitialDirectory = Directory.GetParent(fileName).FullName;
            }
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                textBoxJsonFile.Text = dlg.FileName;
                loadJson(dlg.FileName);
            }
        }

        private void OnOutputFileBrowseButtonClick(object sender, System.EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Json Files|*.json";
            dlg.Title = "Select a JSON Output File";
            string fileName = textBoxJsonFile.Text;
            if (!String.IsNullOrEmpty(fileName)) {
                dlg.FileName = fileName;
                dlg.InitialDirectory = Directory.GetParent(fileName).FullName;
            }
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                textBoxOutputFile.Text = dlg.FileName;
            }
        }

        private void OnRandomCheckChanged(object sender, EventArgs e) {
#if debugMouse
            mainForm.writeInfo("OnRandomCheckChanged checkBoxRandom.Checked="
                + checkBoxRandom.Checked + " mapData=" + mapData);
            mainForm.writeInfo("    randomMapData=" + randomMapData);
            mainForm.writeInfo("    fileMapData=" + fileMapData);
#endif
            if (mapData == null) return;
            clearMapData();
            if (checkBoxRandom.Checked) {
                if (randomMapData != null) {
                    resetMapData(randomMapData);
                } else {
                    randomMapData = emptyMapData();
                    resetMapData(randomMapData);
                }
            } else {
                if (fileMapData != null) {
                    resetMapData(fileMapData);
                } else {
                    // Make a new one
                    fileMapData = emptyMapData();
                    resetMapData(fileMapData);
                }
            }
        }

        private void OnClearButtonClick(object sender, EventArgs e) {
            clearMapData();
        }

        private void OnQuitButtonClick(object sender, MouseEventArgs e) {
            Properties.ImageSettings.Default.ImageFileName = textBoxInputFile.Text;
            Properties.ImageSettings.Default.JsonFileName = textBoxJsonFile.Text;
            Properties.ImageSettings.Default.OutputFileName = textBoxOutputFile.Text;
            Properties.ImageSettings.Default.NPoints = textBoxNPoints.Text;
            Properties.ImageSettings.Default.Left = textBoxLeft.Text;
            Properties.ImageSettings.Default.Right = textBoxRight.Text;
            Properties.ImageSettings.Default.Top = textBoxTop.Text;
            Properties.ImageSettings.Default.Bottom = textBoxBottom.Text;
            Properties.ImageSettings.Default.MarginH = textBoxMarginH.Text;
            Properties.ImageSettings.Default.MarginV = textBoxMarginV.Text;
            Properties.ImageSettings.Default.Random = checkBoxRandom.Checked;
            Properties.ImageSettings.Default.LatScaling = checkBoxLatScaling.Checked;
            Properties.ImageSettings.Default.Save();
            Hide();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e) {
            OnQuitButtonClick(null, null);
            if (bitmap != null) bitmap.Dispose();
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
            loadImage(fileName);
            Utils.infoMsg("Opened: " + fileName + LF + "Width=" + bitmap.Width
                + " Height=" + bitmap.Height);
        }

        private void OnNewRandomButtonClick(object sender, EventArgs e) {
            //mainForm.writeInfo("OnNewRandomButtonClick checkBoxRandom.Checked="
            //    + checkBoxRandom.Checked + " mapData=" + mapData);
            try {
                float marginH = float.Parse(textBoxMarginH.Text);
                float marginV = float.Parse(textBoxMarginV.Text);
                int nPoints = int.Parse(textBoxNPoints.Text);
                int left = int.Parse(textBoxLeft.Text);
                int right = int.Parse(textBoxRight.Text);
                int top = int.Parse(textBoxTop.Text);
                int bottom = int.Parse(textBoxBottom.Text);
                if (nPoints <= 0) {
                    Utils.errMsg("Number of X Points must be greater than 0");
                    return;
                }
                List<BasicSite> basicSiteList = new List<BasicSite>();
                randomMapData = new MapData(left, right, top, bottom, basicSiteList);
                Transform trans = new Transform(bitmap.Size, randomMapData);
                double x, y;
                int x1, y1;
                Point p1;
                Color color;
                BasicSite basicSite = null;
                Random rand = new Random();
                for (int i = 0; i < nPoints; i++) {
                    y = randomMapData.Top + rand.NextDouble() * randomMapData.Height;
                    if (checkBoxLatScaling.Checked) {
                        double ratio = latRatio(y);
                        if (rand.NextDouble() > ratio) {
                            i--;
                            continue;
                        }
                    }
                    x = randomMapData.Left + rand.NextDouble() * randomMapData.Width;
                    p1 = trans.tp(new PointF((float)x, (float)y));
                    x1 = p1.X;
                    y1 = p1.Y;
                    bool err = false;
                    if (x1 < 0 || x1 > bitmap.Width - 1) {
                        mainForm.writeInfo("Invalid x=" + x1 + " for bitmap.Width=" + bitmap.Width);
                        err = true;
                    }
                    if (11 < 0 || 11 > bitmap.Height - 1) {
                        mainForm.writeInfo("Invalid x=" + x1 + " for bitmap.Width=" + bitmap.Width);
                        err = true;
                    }
                    if (err) {
                        color = Color.Black;
                    } else {
                        color = bitmap.GetPixel(x1, y1);
                    }
                    basicSite = new BasicSite((float)x, (float)y, color);
                    randomMapData.SiteList.Add(basicSite);
                }
#if false

                float xmin = float.MaxValue;
                float xmax = -float.MaxValue;
                float ymin = float.MaxValue;
                float ymax = -float.MaxValue;
                foreach (BasicSite site in randomMapData.SiteList) {
                    if (site.X < xmin) xmin = site.X;
                    if (site.X > xmax) xmax = site.X;
                    if (site.Y < ymin) ymin = site.Y;
                    if (site.Y > ymax) ymax = site.Y;
                }
                mainForm.writeInfo("randomMapData=" + randomMapData);
                mainForm.writeInfo("xmin=" + xmin + " xmax=" + xmax
                    + " ymin=" + ymin + " ymax=" + ymax);
            }
#endif
                if (checkBoxRandom.Checked) {
                    resetMapData(randomMapData);
                } else {
                    checkBoxRandom.Checked = true;
                }
                //mainForm.writeInfo("    after checkBoxRandom.Checked="
                //    + checkBoxRandom.Checked + " mapData=" + mapData);
            } catch (Exception ex) {
                Utils.excMsg("Failed to generate random sites", ex);
            }
        }

        private void OnSaveButton_Click(object sender, System.EventArgs e) {
            if (mapData == null) {
                Utils.errMsg("There is no data to save");
                return;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Json Files|*.json";
            dlg.Title = "Select a JSON Outout File";
            string fileName = textBoxOutputFile.Text;
            if (!String.IsNullOrEmpty(fileName)) {
                dlg.FileName = fileName;
                dlg.InitialDirectory = Directory.GetParent(fileName).FullName;
            }
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                try {
                    mapData.saveMapDataAsJson(dlg.FileName, true);
                    Utils.infoMsg("Saved: " + dlg.FileName);
                } catch (Exception ex) {
                    Utils.excMsg("Failed to save " + dlg.FileName, ex);
                }
                textBoxOutputFile.Text = dlg.FileName;
            }
        }

        private void OnMouseDown(object sender, MouseEventArgs e) {
            mouseStatus = new MouseStatus(e.Location);
        }

        private void OnMouseMove(object sender, MouseEventArgs e) {
            if (mouseStatus == null) {
                endMouseOperations();
                return;
            }
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
                endMouseOperations();
                return;
            }
            mouseStatus.Moved = true;
            Cursor.Current = Cursors.Cross;
        }

        private void OnMouseUp(object sender, MouseEventArgs e) {
#if debugMouse
            mainForm.writeInfo("OnMouseUp checkBoxRandom.Checked="
                + checkBoxRandom.Checked);
            mainForm.writeInfo("    mapData=" + mapData);
#endif
            Cursor.Current = Cursors.Default;
            if (mouseStatus == null) {
                endMouseOperations();
                return;
            }
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
                endMouseOperations();
                return;
            }
            if (mapData == null) {
                Utils.errMsg("No MapData has been defined for Random="
                    + checkBoxRandom.Checked);
                endMouseOperations();
                return;
            }
            bool drag = (Control.ModifierKeys & Keys.Shift) == Keys.Shift;
            Transform t1, t2;
            PointF p0, p1;
            int x, y;
            if (!mouseStatus.Moved && !drag) {
                // Add a new point
                x = mouseStatus.Start.X;
                y = mouseStatus.Start.Y;
                p0 = new PointF(x, y);
                t1 = new Transform(mapData, pictureBox.Size);
                p1 = t1.tf(p0);
                t2 = new Transform(bitmap.Size, pictureBox.Size);
                Point p2 = t2.tp(p0);
                Color color = bitmap.GetPixel(p2.X, p2.Y);
#if debugMouse
                mainForm.writeInfo("    New Site");
                mainForm.writeInfo("    pictureBox.Size=" + pictureBox.Size + " bitmap.Size=" + bitmap.Size);
                mainForm.writeInfo("    p0=" + p0 + " p1=" + p1 + " p2=" + p2);
#endif
                mapData.SiteList.Add(new BasicSite(p1.X, p1.Y, color));
                endMouseOperations();
                plotMapData(mapData);
                return;
            }
            // Is  move or delete so find which site was closest
            int len = mapData.SiteList.Count;
            double max = Double.MaxValue;
            BasicSite basicSite;
            BasicSite basicSite0 = null;
            x = mouseStatus.Start.X;
            y = mouseStatus.Start.Y;
            p0 = new PointF(x, y);
            PointF pend = new PointF(e.Location.X, e.Location.Y);
            if (pend.X < 0 || pend.X >= pictureBox.ClientSize.Width
                || pend.Y < 0 || pend.Y >= pictureBox.ClientSize.Height) {
                mainForm.writeInfo("Mouse down out of bounds: X="
                    + pend.X + " Y=" + pend.Y);
                endMouseOperations();
                return;
            }
            t1 = new Transform(mapData, pictureBox.Size);
            p1 = t1.tf(p0);
            double distance;
            for (int i = 0; i < len; i++) {
                basicSite = mapData.SiteList[i];
                distance = this.distance(basicSite, p1);
                if (distance < max) {
                    max = distance;
                    basicSite0 = basicSite;
                }
            }
            if (basicSite0 == null) {
                mainForm.writeInfo("Did not find any closest site.");
                endMouseOperations();
                return;
            }
            if (drag) {
                mapData.SiteList.Remove(basicSite0);
            } else if (mouseStatus.Moved) {
                p1 = t1.tf(pend);
                basicSite0.X = p1.X;
                basicSite0.Y = p1.Y;
            }
            endMouseOperations();
            plotMapData(mapData);
        }

        private void endMouseOperations() {
            mouseStatus = null;
            Cursor.Current = Cursors.Default;
        }
    }

    /// <summary>
    /// Hold the information for a mouse event;
    /// </summary>
    class MouseStatus {
        public Point Start { get; set; }
        public bool Moved { get; set; } = false;

        public MouseStatus(Point pStart) {
            Start = pStart;
        }
    }

    /// <summary>
    /// Class to handle an arbitrary transform.  Sacrifices speed for clarity.
    /// Transform is from Object 0 to Object 1.
    /// </summary>
    class Transform {
        float a;
        float b;
        float c;
        float d;

        public Transform(MapData mapData1, MapData mapData0) {
            a = mapData1.Width / mapData0.Width;
            b = mapData1.Left - a * mapData0.Left;
            c = mapData1.Height / mapData0.Height;
            d = mapData1.Top - c * mapData0.Top;
        }

        public Transform(MapData mapData1, Size size0) {
            a = mapData1.Width / (size0.Width - 1);
            b = mapData1.Left;
            c = mapData1.Height / (size0.Height - 1);
            d = mapData1.Top;
        }

        public Transform(Size size1, MapData mapData0) {
            a = (size1.Width - 1) / mapData0.Width;
            b = -a * mapData0.Left;
            c = (size1.Height - 1) / mapData0.Height;
            d = -c * mapData0.Top;
        }

        public Transform(Size size1, Size size0) {
            a = (size1.Width - 1) / (size0.Width - 1);
            b = 0;
            c = (size1.Height - 1) / (size0.Height - 1);
            d = 0;
        }

        /// <summary>
        ///  Returns a PointF.
        /// </summary>
        /// <param name="p0"></param>
        /// <returns></returns>
        public PointF tf(PointF p0) {
            float x = a * p0.X + b;
            float y = c * p0.Y + d;
            return new PointF(x, y);
        }

        /// <summary>
        /// Returns a Point by rounding.
        /// </summary>
        /// <param name="p0"></param>
        /// <returns></returns>

        public Point tp(PointF p0) {
            PointF pf = tf(p0);
            return new Point((int)Math.Round(pf.X), (int)Math.Round(pf.Y));
        }
    }
}
