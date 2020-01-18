#define dumpSites
#define traceFlow

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using KEUtils;


namespace VoronoiMap {
    public sealed partial class MainForm : Form {
        private VoronoiGraph _graph;
        private Voronoi _voronoi;
        // Drawing stuff
        private readonly Pen _sweepPen;
        private readonly Pen _circlePen;
        private readonly Pen _newCirclePen;
        private readonly Pen _edgePen;
        private readonly Pen _newEdgePen;
        private readonly Pen _beachPen;
        private readonly SolidBrush _vertBrush;
        private readonly SolidBrush _newVertBrush;
        private readonly SolidBrush _siteBrush;
        private readonly SolidBrush _newSiteBrush;

        private readonly Font _textFont = new System.Drawing.Font("Arial", 10);

        private Bitmap _bitmap;
        private bool bitMapDrawn = false;
        private bool doFull = true;
        private MapData mapData;
        private MapData mapDataFromFile;
        private string mapDataFileName;

        public MainForm() {
            InitializeComponent();
            loadSettings();

            _sweepPen = new Pen(Color.Magenta);
            _circlePen = new Pen(Color.Lime);
            _newCirclePen = new Pen(Color.Gold) { Width = 2 };
            _edgePen = new Pen(Color.Black);
            _newEdgePen = new Pen(Color.White) { Width = 2 };
            _beachPen = new Pen(Color.Orange);
            _vertBrush = new SolidBrush(Color.Firebrick);
            _newVertBrush = new SolidBrush(Color.Red);
            _siteBrush = new SolidBrush(Color.Black);
            _newSiteBrush = new SolidBrush(Color.Black);
        }

        private void loadSettings() {
            nudSeed.Value = Properties.Settings.Default.Seed;
            nudNumRegions.Value = Properties.Settings.Default.NumRegions;
            nudRelax.Value = Properties.Settings.Default.Relax;
            chkShowSites.Checked = Properties.Settings.Default.ShowSites;
            chkShowVertices.Checked = Properties.Settings.Default.ShowVertices;
            chkShowEdges.Checked = Properties.Settings.Default.ShowEdges;
            chkUseFile.Checked = Properties.Settings.Default.UseFile;
            chkDebug.Checked = Properties.Settings.Default.Debug;
            chkBeachline.Checked = Properties.Settings.Default.ShowBeachLine;
            chkShowSites.Checked = Properties.Settings.Default.ShowSites;
            cbCircles.SelectedIndex = Properties.Settings.Default.ShowCircleEvents;
            mapDataFileName = Properties.Settings.Default.LastFileName;
            fileNameTextBox.Text = mapDataFileName;
            fileNameTextBox.SelectionStart = fileNameTextBox.Text.Length;
            fileNameTextBox.SelectionLength = 0;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            //GenerateGraph();
            //InitializeVoronoi();
            _bitmap = new Bitmap(splitPanel.Panel2.ClientSize.Width,
                splitPanel.Panel2.ClientSize.Height);
            bitMapDrawn = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.Seed = nudSeed.Value;
            Properties.Settings.Default.NumRegions = nudNumRegions.Value;
            Properties.Settings.Default.Relax = nudRelax.Value;
            Properties.Settings.Default.ShowSites = chkShowSites.Checked;
            Properties.Settings.Default.ShowVertices = chkShowVertices.Checked;
            Properties.Settings.Default.ShowEdges = chkShowEdges.Checked;
            Properties.Settings.Default.UseFile = chkUseFile.Checked;
            Properties.Settings.Default.Debug = chkDebug.Checked;
            Properties.Settings.Default.ShowBeachLine = chkBeachline.Checked;
            Properties.Settings.Default.ShowSites = chkShowSites.Checked;
            Properties.Settings.Default.ShowCircleEvents = cbCircles.SelectedIndex;
            Properties.Settings.Default.LastFileName = mapDataFileName;

            Properties.Settings.Default.Save();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            _circlePen.Dispose();
            _edgePen.Dispose();
            _newCirclePen.Dispose();
            _newEdgePen.Dispose();
            _beachPen.Dispose();
            _newSiteBrush.Dispose();
            _newVertBrush.Dispose();
            _vertBrush.Dispose();
            _siteBrush.Dispose();
            _sweepPen.Dispose();
            _bitmap.Dispose();
        }

        /// <summary>
        /// Gets the appropriate MapData from a file or from random depending 
        /// on the Use File checkbox.
        /// </summary>
        /// <returns>The MapData or null on failure.</returns>
        private MapData getMapData() {
            if (chkUseFile.Checked) {
                if (mapDataFromFile == null) {
                    if (String.IsNullOrEmpty(mapDataFileName)) {
                        Utils.errMsg("Use File is checked but there is no map " +
                            "data available from a file");
                        return null;
                    } else {
                        try {
                            mapDataFromFile = new MapData(mapDataFileName);
                            fileNameTextBox.Text = mapDataFileName;
                            fileNameTextBox.SelectionStart = fileNameTextBox.Text.Length;
                            fileNameTextBox.SelectionLength = 0;
                        } catch (Exception ex) {
                            Utils.excMsg("Unable to load " + mapDataFileName, ex);
                            return null;
                        }
                    }
                }
                mapData = mapDataFromFile;
            } else {
                mapData = mapDataFromRandom();
            }
            return mapData;
        }

        /// <summary>
        /// Generates a MapData from random values with
        /// Left=0, Right = Panel2 width, Top = 0 Bottom = Panel2 Height.
        /// </summary>
        /// <returns>The MapData</returns>
        private MapData mapDataFromRandom() {
#if traceFlow
            Console.WriteLine("mapDataFromRandom doFull=" + doFull
                + " bitMapDrawn=" + bitMapDrawn);
#endif
            List<BasicSite> basicSites = new List<BasicSite>();
            int w = splitPanel.Panel2.ClientSize.Width;
            int h = splitPanel.Panel2.ClientSize.Height;
            Random rand = new Random((int)nudSeed.Value);
            int numSites = (int)nudNumRegions.Value;
            basicSites = new List<BasicSite>();
            for (int i = 0; i < numSites; i++) {
                Color color = Color.FromArgb(rand.Next(256), rand.Next(256),
                    rand.Next(256));
                BasicSite site = new BasicSite(rand.Next(w), rand.Next(h),
                    color);
                basicSites.Add(site);
            }
            // Generate the MapData
            return new MapData(0, w, 0, h, basicSites);
        }

        /// <summary>
        /// Generates a full Voroni graph non-interactively.
        /// Calculates mapData and _graph.
        /// </summary>
        private void GenerateGraph() {
#if traceFlow
            Console.WriteLine("GenerateGraph bitMapDrawn=" + bitMapDrawn
                + " chkUseFile.Checked=" + chkUseFile.Checked);
#endif
            long start = Stopwatch.GetTimestamp();
            List<BasicSite> basicSites = new List<BasicSite>();
            mapData = getMapData();
            if (mapData == null) {
                return;
            }
            if (nudRelax.Value > 0) {
                basicSites = RelaxPoints((int)nudRelax.Value, mapData.SiteList);
                mapData.SiteList = basicSites;
            }
            _graph =
            VoronoiGraph.ComputeVoronoiGraph(mapData.SiteList,
            mapData.Left, mapData.Top, mapData.Width, mapData.Height,
            chkDebug.Checked);
#if dumpSites
            dumpSites();
#endif            
            TimeSpan elapsed = new TimeSpan(Stopwatch.GetTimestamp() - start);
            Console.WriteLine("GenerateGraph done! " + " elapsed time " + elapsed);
        }

        /// <summary>
        /// Initializes for an interactive, incremental graph.
        /// Calculates mapData and _graph.
        /// </summary>
        private void InitializeVoronoi() {
#if traceFlow
            Console.WriteLine("InitializeVoronoi bitMapDrawn=" + bitMapDrawn
                + " chkUseFile.Checked=" + chkUseFile.Checked);
#endif
            _sitesToIgnore = new HashSet<Site>();
            //Console.Clear();
            nudStepTo.Value = 0;
            Edge.EdgeCount = 0;
            List<BasicSite> basicSites = new List<BasicSite>();
            mapData = getMapData();
            if (mapData == null) {
                return;
            }
            if (nudRelax.Value > 0) {
                basicSites = RelaxPoints((int)nudRelax.Value, mapData.SiteList);
                mapData.SiteList = basicSites;
            }
            if (nudRelax.Value > 0) {
                basicSites = RelaxPoints((int)nudRelax.Value, mapData.SiteList);
                mapData.SiteList = basicSites;
            }
            _voronoi = new Voronoi(mapData.SiteList, mapData.Left,
                mapData.Top, mapData.Width, mapData.Height, chkDebug.Checked);
            _graph = _voronoi.Initialize();
        }

        /// <summary>
        /// Container method for painting.  Calls either PaintDiagramFull or
        /// PaintDiagramIncremental, depending on the value of full.  Does 
        /// nothing if bitMapCalulated = false, to avoid repainting when the
        /// Form is moved.
        /// </summary>
        /// <param name="g The graphics."></param>
        /// <param name="full Whether to use PaintDiagramFull or
        /// PaintDiagramIncremental."></param>
        private void PaintDiagram(Graphics g) {
            if (_graph == null) {
                return;
            }
            // g1 is used to paint the _bitmap.
            // g draws the _bitmap to the Control (Panel2).
            using (Graphics g1 = Graphics.FromImage(_bitmap)) {
                g1.SmoothingMode = SmoothingMode.AntiAlias;
                if (doFull) {
                    PaintDiagramFull(g1);
                } else {
                    PaintDiagramIncremental(g1);
                }
                g.DrawImage(_bitmap, new PointF());
            }
        }

        private void PaintDiagramFull(Graphics g) {
#if traceFlow
            Console.WriteLine("PaintDiagramFull doFull=" + doFull
                + " bitMapDrawn=" + bitMapDrawn);
#endif
            if (bitMapDrawn) return;
            if (mapData == null) return;
            g.Clear(BackColor);
            Matrix m = MapData.getMatrixToFitRectInRect(mapData.Bounds,
                g.VisibleClipBounds);
            g.Transform = m;
            // DEBUG
            Console.WriteLine("PaintDiagramFull Matrix:");
            Console.WriteLine("  mapData.Bounds=" + mapData.Bounds);
            Console.WriteLine("  g.VisibleClipBounds=" + g.VisibleClipBounds);
            string stringVal = "  ";
            foreach (float val in m.Elements) {
                stringVal += " " + val;
            }
            Console.WriteLine("m=" + stringVal);

            int item = cbCircles.SelectedIndex;
            GraphicsPath gp = new GraphicsPath();
            GraphicsPath gp2 = new GraphicsPath();
            GraphicsPath gp3 = new GraphicsPath();
            if (chkShowSites.Checked) {
                // Color the regions
                foreach (Site site in _graph.Sites) {
                    GraphicsPath gp4 = new GraphicsPath();
                    RectangleF visibleClipBounds = g.VisibleClipBounds;
                    //Console.WriteLine("ClipBounds " + visibleClipBounds);
                    PointF[] points = site.Region(visibleClipBounds).
                        Where(site1 => site1 != null).
                        Select(site1 => (PointF)site1).ToArray();
                    if (points.Count() >= 3) {
                        gp4.AddPolygon(points);
                    }
                    Region region = new Region(gp4);
                    SolidBrush brush = new SolidBrush(site.Color);
                    g.FillRegion(brush, region);
                    brush.Dispose();
                }
            }
            // Do the rest
            foreach (Site site in _graph.Sites) {
                RectangleF r = new RectangleF(site.X - 2, site.Y - 2, 4, 4);
                if (chkShowNumbers.Checked) {
                    gp.AddEllipse(r);
                    g.DrawString(site.NumString(), _textFont, _siteBrush,
                        site.X, site.Y);
                }
                foreach (Edge edge in site.Edges) {
                    Site start = edge.RightSite;
                    Site end = edge.LeftSite;
                    if (item == 2) {
                        gp2.AddLine(start, end);
                        gp2.CloseFigure();
                    }
                }
                if (chkShowEdges.Checked) {
                    RectangleF visibleClipBounds = g.VisibleClipBounds;
                    PointF[] points = site.Region(visibleClipBounds).
                        Where(site1 => site1 != null).
                        Select(site1 => (PointF)site1).ToArray();
                    if (points.Count() >= 3) {
                        gp3.AddPolygon(points);
                    }
                }
            }
            g.DrawPath(_circlePen, gp2);
            g.DrawPath(_edgePen, gp3);
            g.FillPath(_siteBrush, gp);
            // Draw mapData Bounds
            g.DrawRectangle(_edgePen, mapData.Left, mapData.Top, mapData.Width - 1, mapData.Height - 1);

            bitMapDrawn = true;
        }

        private HashSet<Site> _sitesToIgnore = new HashSet<Site>();

        private void PaintDiagramIncremental(Graphics g) {
#if traceFlow
            Console.WriteLine("PaintDiagramIncremental doFull=" + doFull
                 + " bitMapDrawn=" + bitMapDrawn);
#endif
            if (_graph == null) {
                return;
            }
            if (bitMapDrawn) return;
            if (mapData == null) return;
            g.Clear(BackColor);
            Matrix m = MapData.getMatrixToFitRectInRect(mapData.Bounds,
                g.VisibleClipBounds);
            g.Transform = m;
            g.DrawLine(_sweepPen, splitPanel.Panel2.ClientRectangle.Left,
                _graph.SweepLine, splitPanel.Panel2.ClientRectangle.Right,
                _graph.SweepLine);
            int item = cbCircles.SelectedIndex;
            if (item == 1) {
                GraphicsPath gp = new GraphicsPath();
                foreach (Triangle triangle in _graph.Triangles) {
                    Circle circle = new Circle(triangle.V1, triangle.V2,
                        triangle.V3);
                    if (triangle.New) {
                        g.DrawEllipse(_newCirclePen, circle.GetRect());
                    } else {
                        gp.AddEllipse(circle.GetRect());
                    }
                }
                g.DrawPath(_circlePen, gp);
            } else if (item == 2) {
                GraphicsPath gp = new GraphicsPath();
                foreach (Triangle triangle in _graph.Triangles) {
                    if (triangle.New) {
                        g.DrawPolygon(_newCirclePen, new[] {
                            (PointF)triangle.V1, triangle.V2, triangle.V3 });
                    } else {
                        gp.AddPolygon(new[] { (PointF)triangle.V1, triangle.V2,
                            triangle.V3 });
                    }
                }
                g.DrawPath(_circlePen, gp);
            }
            if (chkShowEdges.Checked) {
                GraphicsPath gp = new GraphicsPath();
                foreach (Segment segment in _graph.Segments) {
                    Site start = segment.P1;
                    Site end = segment.P2;
                    if (segment.New) {
                        g.DrawLine(_newEdgePen, start, end);
                    } else {
                        gp.AddLine(start, end);
                        gp.CloseFigure();
                    }
                }
                g.DrawPath(_edgePen, gp);
            }
            if (chkBeachline.Checked) {
                GraphicsPath gp = new GraphicsPath();
                Dictionary<int, float> beachLine = new Dictionary<int, float>();
                foreach (Site site in
                    _graph.Sites.Except(_sitesToIgnore.ToList())) {
                    bool drop = true;
                    for (int x = 0; x < g.VisibleClipBounds.Width; x++) {
                        float y = ParabolaY(site, _graph.SweepLine, x);
                        if (y > g.VisibleClipBounds.Height) {
                            drop = false;
                            continue;
                        }
                        if (!beachLine.ContainsKey(x)) {
                            beachLine[x] = y;
                            drop = false;
                        } else if (beachLine[x] < y) {
                            beachLine[x] = y;
                            drop = false;
                        }
                    }
                    if (drop) {
                        _sitesToIgnore.Add(site);
                    }
                }
                for (int x = 0; x < beachLine.Count - 1; x++) {
                    gp.AddLine(x, beachLine[x], x + 1, beachLine[x + 1]);
                }
                g.DrawPath(_beachPen, gp);
            }
            if (chkShowVertices.Checked) {
                GraphicsPath gp = new GraphicsPath();
                foreach (Site vertex in _graph.Vertices) {
                    RectangleF r = vertex.New ?
                        new RectangleF(vertex.X - 4, vertex.Y - 4, 8, 8)
                        : new RectangleF(vertex.X - 2, vertex.Y - 2, 4, 4)
                        ;
                    if (vertex.New) {
                        g.FillEllipse(_newVertBrush, r);
                    } else {
                        gp.AddEllipse(r);
                    }
                }
                g.DrawPath(new Pen(Color.Red), gp);
            }
            foreach (Site site in _graph.Sites) {
                if (chkShowSites.Checked) {
                    GraphicsPath gp = new GraphicsPath();
                    RectangleF r = site.New ?
                        new RectangleF(site.X - 4, site.Y - 4, 8, 8)
                        : new RectangleF(site.X - 2, site.Y - 2, 4, 4);
                    if (site.New) {
                        g.FillEllipse(_newSiteBrush, r);
                    } else {
                        gp.AddEllipse(r);
                    }
                    g.FillPath(_siteBrush, gp);
                }
                if (chkShowNumbers.Checked) {
                    g.DrawString(site.NumString(), _textFont,
                        _siteBrush, site.X, site.Y);
                }
            }
            // Draw mapData Bounds
            g.DrawRectangle(_edgePen, mapData.Left, mapData.Top, mapData.Width - 1, mapData.Height - 1);
            bitMapDrawn = true;
        }

        private float ParabolaY(Site site, float sweepLineY, int x) {
            try {
                float a = site.X;
                float b = site.Y;
                float c = sweepLineY;
                float y = ((x - a) * (x - a) + b * b - c * c) /
                    (2 * (b - c + 1e-10f));
                return y;
            } catch (Exception) {
                return -1;
            }
        }

        private List<BasicSite> RelaxPoints(int times, List<BasicSite> sites) {
            List<BasicSite> ret = new List<BasicSite>();
            int w = splitPanel.Panel2.ClientSize.Width;
            int h = splitPanel.Panel2.ClientSize.Height;
            List<BasicSite> tempPoints = sites;
            for (int i = 0; i < times; i++) {
                VoronoiGraph voronoi =
                    VoronoiGraph.ComputeVoronoiGraph(tempPoints, mapData.Right, mapData.Top, mapData.Width, mapData.Height);
                tempPoints.Clear();
                foreach (Site site in voronoi.Sites) {
                    List<Site> region =
                        site.Region(splitPanel.Panel2.ClientRectangle);
                    BasicSite newSite =
                        new BasicSite(0, 0, site.Color, site.Height);
                    foreach (Site q in region) {
                        newSite.X += q.X;
                        newSite.Y += q.Y;
                    }
                    newSite.X /= region.Count;
                    newSite.Y /= region.Count;
                    tempPoints.Add(newSite);
                }
                ret = tempPoints;
            }
            return ret;
        }

        public void dumpSites() {
            Console.WriteLine("Site Dump");
            Console.WriteLine("mapData: " + mapData);
            GraphicsUnit units = GraphicsUnit.Pixel;
            RectangleF visibleClipBounds = _bitmap.GetBounds(ref units);
            Console.WriteLine("visibleClipBounds=" + visibleClipBounds);
            foreach (Site site in _graph.Sites) {
                PointF[] points = site.Region(visibleClipBounds).
                    Where(site1 => site1 != null).
                    Select(site1 => (PointF)site1).ToArray();
                Console.WriteLine("Site " + site.ToString()
                    + " nPoints=" + points.Length
                    + " nEdges=" + site.Edges.Count);
                foreach (PointF point in points) {
                    Console.WriteLine("  Point " + point.ToString());
                }
                foreach (Edge edge in site.Edges) {
                    Console.WriteLine("  Edge " + edge.ToString());
                    Console.WriteLine("    Visible " + edge.Visible);
                    Console.WriteLine("    Endpoints " + edge.Endpoint[0] + "," + edge.Endpoint[1]);
                    Console.WriteLine("    ClippedEndpoints " + edge.ClippedEndpoints[0] + "," + edge.ClippedEndpoints[1]);
                }
            }
        }

        private void btnRegen_Click(object sender, EventArgs e) {
            doFull = true;
            bitMapDrawn = false;
            GenerateGraph();
            splitPanel.Panel2.Invalidate();
        }

        private void chkShowSites_CheckedChanged(object sender, EventArgs e) {
            bitMapDrawn = false;
            splitPanel.Panel2.Invalidate();
        }

        private void chkShowVertices_CheckedChanged(object sender, EventArgs e) {
            bitMapDrawn = false;
            splitPanel.Panel2.Invalidate();
        }

        private void chkShowEdges_CheckedChanged(object sender, EventArgs e) {
            bitMapDrawn = false;
            splitPanel.Panel2.Invalidate();
        }

        private void cbCircles_SelectedIndexChanged(object sender, EventArgs e) {
            bitMapDrawn = false;
            splitPanel.Panel2.Invalidate();
        }

        private void chkShowNumbers_Click(object sender, EventArgs e) {
            bitMapDrawn = false;
            splitPanel.Panel2.Invalidate();
        }


        private void chkShowBeachLine_CheckChanged(object sender, EventArgs e) {
            bitMapDrawn = false;
            splitPanel.Panel2.Invalidate();
        }

        private void btnStepVoronoi_Click(object sender, EventArgs e) {
#if traceFlow
            Console.WriteLine("btnStepVoronoi_Click doFull=" + doFull
                + " bitMapDrawn=" + bitMapDrawn);
#endif
            if (_voronoi == null) {
                Utils.errMsg("Voronoi has not been initialized");
                return;
            }
            doFull = false;
            bitMapDrawn = false;
            _graph = _voronoi.StepVoronoi();
            nudStepTo.Value++;
            splitPanel.Panel2.Invalidate();
        }

        private void btnInitialize_Click(object sender, EventArgs e) {
            doFull = false;
            bitMapDrawn = false;
            InitializeVoronoi();
            nudStepTo.Value++;
        }

        private void btnStepTo_Click(object sender, EventArgs e) {
#if traceFlow
            Console.WriteLine("btnStepTo_Click doFull=" + doFull
               + " bitMapDrawn=" + bitMapDrawn);
#endif
            doFull = false;
            bitMapDrawn = false;
            Animate((int)nudStepTo.Value);
        }

        private void Animate(int toStep = int.MaxValue) {
#if traceFlow
            Console.WriteLine("Animate doFull=" + doFull
               + " bitMapDrawn=" + bitMapDrawn
               + " toStep=" + toStep);
#endif
            Cursor = Cursors.WaitCursor;
            doFull = false;
            int lastStep = _voronoi.StepNumber;
            using (Graphics g = splitPanel.Panel2.CreateGraphics()) {
                while (_voronoi.StepNumber < toStep) {
                    _voronoi.StepVoronoi();
                    bitMapDrawn = false;
                    PaintDiagram(g);
                    Thread.Sleep(10);
                    Application.DoEvents();
                    if (lastStep == _voronoi.StepNumber) {
                        break;
                    }
                    lastStep = _voronoi.StepNumber;
                    nudStepTo.Value = _voronoi.StepNumber;
                }
            }
            Cursor = Cursors.Default;
#if dumpSites
            dumpSites();
#endif            
        }

        private void btnAnimate_Click(object sender, EventArgs e) {
#if traceFlow
            Console.WriteLine("btnAnimate_Click doFull=" + doFull
               + " bitMapDrawn=" + bitMapDrawn);
#endif
            doFull = false;
            bitMapDrawn = false;
            if (_voronoi == null) {
                InitializeVoronoi();
            }
            decimal startStep = nudStepTo.Value;
            Animate();
            if (nudStepTo.Value == startStep) {
                _voronoi = null;
                btnAnimate_Click(sender, e);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e) {
#if traceFlow
            // DEBUG
            Console.WriteLine("MainForm_Resize");
            if (_bitmap != null) {
                Console.WriteLine("_bitmap: " + _bitmap.Width + "," + _bitmap.Height);
            } else {
                Console.WriteLine("_bitmap: null");
            }
            Console.WriteLine("Panel2.ClientSize: "
                + splitPanel.Panel2.ClientSize.Width
                + "," + splitPanel.Panel2.ClientSize.Width);
#endif
            // This event also occurs when the form moves, so check for a size change
            if (_bitmap != null) {
                if (_bitmap.Width == splitPanel.Panel2.ClientSize.Width &&
                    _bitmap.Height == splitPanel.Panel2.ClientSize.Width) {
                    return;
                }
                _bitmap.Dispose();
            }
            _bitmap = new Bitmap(splitPanel.Panel2.ClientSize.Width,
                splitPanel.Panel2.ClientSize.Height);
            bitMapDrawn = false;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            PaintDiagram(g);
        }

        private void file_OpenInput_click(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Json Files|*.json";
            dlg.Title = "Select a Map Data File";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                mapDataFileName = dlg.FileName;
                mapDataFromFile = new MapData(dlg.FileName);
                fileNameTextBox.Text = mapDataFileName;
                fileNameTextBox.SelectionStart = fileNameTextBox.Text.Length;
                fileNameTextBox.SelectionLength = 0;
                if (mapDataFromFile == null) {
                    Utils.warnMsg("Failed to open Map Data file");
                }
            }
        }

        private void file_Exit_click(object sender, EventArgs e) {
            Close();
        }

        private void help_About_click(object sender, EventArgs e) {
            AboutBox dlg = new AboutBox();
            dlg.ShowDialog();
        }

        private void file_SaveMapDataFileIndented_click(object sender,
            EventArgs e) {
            if (mapData == null) {
                Utils.errMsg("There is no map data to save.");
                return;
            }
            mapData.saveFile(true);
        }

        private void file_SaveMapDataFileNotIndented_click(object sender,
            EventArgs e) {
            if (mapData == null) {
                Utils.errMsg("There is no map data to save.");
                return;
            }
            mapData.saveFile(false);
        }

        private void file_ResetSettings_click(object sender, EventArgs e) {
            Properties.Settings.Default.Reset();
            loadSettings();
        }
    }
}
