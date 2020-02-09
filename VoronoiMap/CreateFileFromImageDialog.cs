﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KEUtils;

namespace VoronoiMap {
    public partial class CreateFileFromImageDialog : Form {
        private static readonly string LF = Environment.NewLine;
        private static readonly int pointRadius = 4;
        private MapData fileMapData;
        private MapData randomMapData;
        //private MapData manualMapData;
        private MapData mapData;
        private Bitmap bitmap;
        private Bitmap curBitmap;

        public CreateFileFromImageDialog() {
            InitializeComponent();

            textBoxInputFile.Text = Properties.ImageSettings.Default.ImageFileName;
            textBoxJsonFile.Text = Properties.ImageSettings.Default.JsonFileName;
            textBoxOutputFile.Text = Properties.ImageSettings.Default.OutputFileName;

            textBoxMarginH.Text = "0";
            textBoxMarginV.Text = "0";
            textBoxNPoints.Text = "1000";
            textBoxLeft.Text = "-180";
            textBoxRight.Text = "180";
            textBoxTop.Text = "90";
            textBoxBottom.Text = "-90";
            checkBoxRandom.Checked = false;

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
            //Console.WriteLine("loadJson checkBoxRandom.Checked="
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
            //Console.WriteLine("clearMapData checkBoxRandom.Checked="
            //    + checkBoxRandom.Checked + " mapData=" + mapData);
            if (mapData == null) return;
            mapData.SiteList = new List<BasicSite>();
            plotMapData(mapData);
        }

        void plotMapData(MapData mapData) {
            //Console.WriteLine("plotMapData checkBoxRandom.Checked="
            //    + checkBoxRandom.Checked + " mapData=" + mapData);
            if (bitmap == null || mapData == null) {
                return;
            }
            if (curBitmap != null) {
                curBitmap.Dispose();
            }
            curBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            Transform trans = new Transform(bitmap.Size, mapData);
            PointF p0;
            //Console.WriteLine("bitmap.Width=" + bitmap.Width
            //    + " bitmap.Height=" + bitmap.Height
            //    + " bitmap.Size=" + bitmap.Size);
            //p0 = new PointF(mapData.Left, mapData.Top);
            //Console.WriteLine("left-top: " + p0 + "->" + trans.tf(p0));
            //p0 = new PointF(mapData.Right, mapData.Top);
            //Console.WriteLine("right-top: " + p0 + "->" + trans.tf(p0));
            //p0 = new PointF(mapData.Right, mapData.Bottom);
            //Console.WriteLine("right-bottom: " + p0 + "->" + trans.tf(p0));
            //p0 = new PointF(mapData.Left, mapData.Bottom);
            //Console.WriteLine("left-bottom: " + p0 + "->" + trans.tf(p0));
            using (Graphics gr = Graphics.FromImage(curBitmap)) {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gr.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
                RectangleF rect;
                using (Pen pen = new Pen(Color.Black, 5)) {
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

        private void OnInputFileBrowseButtonClick(object sender, System.EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                textBoxInputFile.Text = dlg.FileName;
                loadImage(dlg.FileName);
            }
        }

        private void OnJsonFileBrowse(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                textBoxJsonFile.Text = dlg.FileName;
                loadJson(dlg.FileName);
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

        private void OnRandomCheckChanged(object sender, EventArgs e) {
            Console.WriteLine("OnRandomCheckChanged checkBoxRandom.Checked="
                + checkBoxRandom.Checked + " mapData=" + mapData);
            if (mapData == null) return;
            clearMapData();
            if (checkBoxRandom.Checked) {
                if (randomMapData != null) {
                    resetMapData(randomMapData);
                }
            } else {
                if (fileMapData != null) {
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
            Properties.ImageSettings.Default.Save();
            Hide();
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
            //Console.WriteLine("OnNewRandomButtonClick checkBoxRandom.Checked="
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
                    x = randomMapData.Left + rand.NextDouble() * randomMapData.Width;
                    y = randomMapData.Top + rand.NextDouble() * randomMapData.Height;
                    p1 = trans.tp(new PointF((float)x,(float)y));
                    x1 = p1.X;
                    y1 = p1.Y;
                    bool err = false;
                    if (x1 < 0 || x1 > bitmap.Width - 1) {
                        Console.WriteLine("Invalid x=" + x1 + " for bitmap.Width=" + bitmap.Width);
                        err = true;
                    }
                    if (11 < 0 || 11 > bitmap.Height - 1) {
                        Console.WriteLine("Invalid x=" + x1 + " for bitmap.Width=" + bitmap.Width);
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
                if (true) {
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
                    Console.WriteLine("randomMapData=" + randomMapData);
                    Console.WriteLine("xmin=" + xmin + " xmax=" + xmax
                        + " ymin=" + ymin + " ymax=" + ymax);
                }
                if (checkBoxRandom.Checked) {
                    resetMapData(randomMapData);
                } else {
                    checkBoxRandom.Checked = true;
                }
                Console.WriteLine("    after checkBoxRandom.Checked="
                    + checkBoxRandom.Checked + " mapData=" + mapData);
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
            dlg.Title = "Select a Map Data File";
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
    }

    /// <summary>
    /// Class to handle an arbitrary transform.  Sacrifices speed for clarity.
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
            a = mapData1.Width / (size0.Width -1);
            b = mapData1.Left;
            c = mapData1.Height / (size0.Height -1);
            d = -c * mapData1.Top;
        }

        public Transform(Size size1, MapData mapData0) {
            a = (size1.Width -1) / mapData0.Width;
            b = -a * mapData0.Left;
            c = (size1.Height -1) / mapData0.Height;
            d = -c * mapData0.Top;
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
