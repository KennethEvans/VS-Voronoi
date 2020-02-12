#undef dumpSites
#undef traceFlow

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using KEUtils;


namespace VoronoiMap {
    public sealed partial class MainForm : Form {
        public readonly String NL = Environment.NewLine;
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
        private HashSet<Site> _sitesToIgnore = new HashSet<Site>();

        private Bitmap _bitmap;
        private bool bitMapDrawn = false;
        private bool doFull = true;
        private bool paintError = false;
        private MapData mapData;
        private MapData mapDataFromRandom;
        private MapData mapDataFromFile;
        private string mapDataFileName;
        private CreateFileFromImageDialog createFileFromImageDlg;

        enum CurrentOpertion { NONE, GENERATE, STEP }
        CurrentOpertion currentOperation = CurrentOpertion.NONE;

        public MainForm() {
            InitializeComponent();
            loadSettings();

            _sweepPen = new Pen(Color.Magenta);
            _circlePen = new Pen(Color.Green);
            _newCirclePen = new Pen(Color.LightGreen) { Width = 2 };
            _edgePen = new Pen(Color.Black);
            _newEdgePen = new Pen(Color.White) { Width = 2 };
            _beachPen = new Pen(Color.Orange);
            _vertBrush = new SolidBrush(Color.Firebrick);
            _newVertBrush = new SolidBrush(Color.Red);
            _siteBrush = new SolidBrush(Color.Black);
            _newSiteBrush = new SolidBrush(Color.Black);

            writeInfo("Voronoi "
                + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            writeInfo("To get started:");
            writeInfo("    Regenerate Graph generates the graph.");
            writeInfo("    Initialize followed by Step Graph or Animate shows the steps.");
        }

        /// <summary>
        /// Appends the input plus a NL to the textBoxInfo.
        /// </summary>
        /// <param name="line"></param>
        public void writeInfo(string line) {
            textBoxInfo.AppendText(line + NL);
        }

        private void loadSettings() {
            nudSeed.Value = Properties.Settings.Default.Seed;
            nudNumRegions.Value = Properties.Settings.Default.NumRegions;
            nudRelax.Value = Properties.Settings.Default.Relax;
            chkShowSites.Checked = Properties.Settings.Default.ShowSites;
            chkShowVertices.Checked = Properties.Settings.Default.ShowVertices;
            chkShowEdges.Checked = Properties.Settings.Default.ShowEdges;
            chkShowNumbers.Checked = Properties.Settings.Default.ShowNumbers;
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
            _bitmap = new Bitmap(panelDiagram.ClientSize.Width,
                panelDiagram.ClientSize.Height);
            bitMapDrawn = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.Seed = nudSeed.Value;
            Properties.Settings.Default.NumRegions = nudNumRegions.Value;
            Properties.Settings.Default.Relax = nudRelax.Value;
            Properties.Settings.Default.ShowSites = chkShowSites.Checked;
            Properties.Settings.Default.ShowVertices = chkShowVertices.Checked;
            Properties.Settings.Default.ShowEdges = chkShowEdges.Checked;
            Properties.Settings.Default.ShowNumbers = chkShowNumbers.Checked;
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
                    // Check if there is a file name specified
                    if (String.IsNullOrEmpty(mapDataFileName)) {
                        mapDataFileName = fileNameTextBox.Text;
                        if (String.IsNullOrEmpty(mapDataFileName)) {
                            Utils.errMsg("Use File is checked but there is no map " +
                                "data or file name");
                            return null;
                        }
                    }
                    try {
                        mapDataFromFile = new MapData(mapDataFileName);
                        fileNameTextBox.Text = mapDataFileName;
                        fileNameTextBox.SelectionStart = fileNameTextBox.Text.Length;
                        fileNameTextBox.SelectionLength = 0;
                        scaleMapData(mapDataFromFile);
                        mapData = mapDataFromFile;
                    } catch (Exception ex) {
                        Utils.excMsg("Unable to load " + mapDataFileName, ex);
                        return null;
                    }
                }
                mapData = mapDataFromFile;
            } else {
                if (mapDataFromRandom == null) {
                    mapDataFromRandom = makeMapDataFromRandom();
                }
                mapData = mapDataFromRandom;
            }
            return mapData;
        }

        /// <summary>
        /// Generates a MapData from random values with
        /// Left=0, Right = panelDiagram width, Top = 0 Bottom = panelDiagram Height.f
        /// </summary>
        /// <returns>The MapData</returns>
        private MapData makeMapDataFromRandom() {
#if traceFlow
            writeInfo("makeMapDataFromRandom doFull=" + doFull
                + " bitMapDrawn=" + bitMapDrawn);
#endif
            List<BasicSite> basicSites = new List<BasicSite>();
            int w = panelDiagram.ClientSize.Width;
            int h = panelDiagram.ClientSize.Height;
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
            writeInfo("GenerateGraph bitMapDrawn=" + bitMapDrawn
                + " chkUseFile.Checked=" + chkUseFile.Checked);
#endif
            long start = Stopwatch.GetTimestamp();
            List<BasicSite> basicSites = new List<BasicSite>();
            mapData = getMapData();
            //printMapData("GenerateGraph mapdata=", mapData);
            if (mapData == null) {
                return;
            }
            if (nudRelax.Value > 0) {
                basicSites = RelaxPoints((int)nudRelax.Value, mapData.SiteList);
                mapData.SiteList = basicSites;
            }
            _graph = VoronoiGraph.ComputeVoronoiGraph(mapData.SiteList,
                mapData.Left, mapData.Top, mapData.Width, mapData.Height,
                chkDebug.Checked);
#if dumpSites
            dumpSites();
#endif            
            TimeSpan elapsed = new TimeSpan(Stopwatch.GetTimestamp() - start);
            writeInfo("GenerateGraph done, elapsed time=" + elapsed);
        }

        /// <summary>
        /// Initializes for an interactive, incremental graph.
        /// Calculates mapData and _graph.
        /// </summary>
        private void InitializeVoronoi() {
#if traceFlow
            writeInfo("InitializeVoronoi bitMapDrawn=" + bitMapDrawn
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
#if traceFlow && false
            writeInfo("PaintDiagram");
            if (_graph == null) {
                return;
            }
#endif
            // g1 is used to paint the _bitmap.
            // g draws the _bitmap to the Control (panelDiagram).
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
            writeInfo("PaintDiagramFull doFull=" + doFull
                + " bitMapDrawn=" + bitMapDrawn);
            writeInfo("    panelDiagram.Size: "
                + panelDiagram.Size.Width
                + "," + panelDiagram.Size.Height);
            writeInfo("    panelDiagram.ClientSize: "
                + panelDiagram.ClientSize.Width
                + "," + panelDiagram.ClientSize.Height);
            writeInfo("    _bitmap: " + _bitmap.Width + "," + _bitmap.Height);
#endif
            if (bitMapDrawn) return;
            if (mapData == null) return;
            try {
                g.Clear(BackColor);
                Matrix m = MapData.getMatrixToFitRectInRect(mapData.Bounds,
                    g.VisibleClipBounds);
                g.Transform = m;
                //// DEBUG
                //WriteLine("PaintDiagramFull Matrix:");
                //WriteLine("  mapData.Bounds=" + mapData.Bounds);
                //WriteLine("  g.VisibleClipBounds=" + g.VisibleClipBounds);
                //string stringVal = "  ";
                //foreach (float val in m.Elements) {
                //    stringVal += " " + val;
                //}
                //WriteLine("m=" + stringVal);

                int item = cbCircles.SelectedIndex;
                GraphicsPath gp = new GraphicsPath();
                GraphicsPath gp2 = new GraphicsPath();
                GraphicsPath gp3 = new GraphicsPath();
                if (chkShowSites.Checked) {
                    // Color the regions
                    foreach (Site site in _graph.Sites) {
                        GraphicsPath gp4 = new GraphicsPath();
                        RectangleF visibleClipBounds = g.VisibleClipBounds;
                        //WriteLine("ClipBounds " + visibleClipBounds);
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
            } catch (Exception ex) {
                Utils.excMsg("Error drawing full diagram", ex);
                return;
            }
        }

        private void PaintDiagramIncremental(Graphics g) {
#if traceFlow
            writeInfo("PaintDiagramIncremental doFull=" + doFull
                 + " bitMapDrawn=" + bitMapDrawn);
#endif
            if (_graph == null) {
                return;
            }
            if (bitMapDrawn) return;
            g.Clear(BackColor);
            try {
                Matrix m = MapData.getMatrixToFitRectInRect(mapData.Bounds,
                    g.VisibleClipBounds);
                g.Transform = m;
                g.DrawLine(_sweepPen, panelDiagram.ClientRectangle.Left,
                    _graph.SweepLine, panelDiagram.ClientRectangle.Right,
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
            } catch (Exception ex) {
                Utils.excMsg("Error drawing incremental diagram", ex);
                paintError = true;
                return;
            }
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

        private void scaleMapData(MapData mapData) {
            if (mapData == null) return;
            //printMapData("scaleMapData: Before: ", mapData);
            //WriteLine("panelDiagram.ClientSize=" + panelDiagram.ClientSize);
            // Convert to pixel coordinates
            MapData oldMapData = new MapData(mapData);
            //printMapData("scaleMapData: Before: ", oldMapData);
            int w = panelDiagram.ClientSize.Width;
            int h = panelDiagram.ClientSize.Height;
            List<BasicSite> basicSiteList = new List<BasicSite>();
            PointF p1;
            BasicSite basicSite1;
            mapData.Left = 0;
            mapData.Right = w;
            mapData.Top = 0;
            mapData.Bottom = h;
            mapData.SiteList = basicSiteList;
            Transform trans = new Transform(panelDiagram.ClientSize, oldMapData);
            foreach (BasicSite basicSite in oldMapData.SiteList) {
                p1 = trans.tf(new PointF(basicSite.X, basicSite.Y));
                basicSite1 = new BasicSite(p1.X, p1.Y, basicSite.Color);
                basicSiteList.Add(basicSite1);
            }
            //printMapData("    After: ", mapData);
        }

        private void printMapData(string prefix, MapData mapData) {
            float xmin = float.MaxValue;
            float xmax = -float.MaxValue;
            float ymin = float.MaxValue;
            float ymax = -float.MaxValue;
            foreach (BasicSite site in mapData.SiteList) {
                if (site.X < xmin) xmin = site.X;
                if (site.X > xmax) xmax = site.X;
                if (site.Y < ymin) ymin = site.Y;
                if (site.Y > ymax) ymax = site.Y;
            }
            writeInfo(prefix + "mapData=" + mapData);
            writeInfo("xmin=" + xmin + " xmax=" + xmax
                + " ymin=" + ymin + " ymax=" + ymax);
        }

        private List<BasicSite> RelaxPoints(int times, List<BasicSite> sites) {
            List<BasicSite> ret = new List<BasicSite>();
            int w = panelDiagram.ClientSize.Width;
            int h = panelDiagram.ClientSize.Height;
            List<BasicSite> tempPoints = sites;
            for (int i = 0; i < times; i++) {
                VoronoiGraph voronoi =
                    VoronoiGraph.ComputeVoronoiGraph(tempPoints, mapData.Right, mapData.Top, mapData.Width, mapData.Height);
                tempPoints.Clear();
                foreach (Site site in voronoi.Sites) {
                    List<Site> region =
                        site.Region(panelDiagram.ClientRectangle);
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
            writeInfo("Site Dump");
            writeInfo("mapData: " + mapData);
            GraphicsUnit units = GraphicsUnit.Pixel;
            RectangleF visibleClipBounds = _bitmap.GetBounds(ref units);
            writeInfo("visibleClipBounds=" + visibleClipBounds);
            foreach (Site site in _graph.Sites) {
                PointF[] points = site.Region(visibleClipBounds).
                    Where(site1 => site1 != null).
                    Select(site1 => (PointF)site1).ToArray();
                writeInfo("Site " + site.ToString()
                    + " nPoints=" + points.Length
                    + " nEdges=" + site.Edges.Count);
                foreach (PointF point in points) {
                    writeInfo("  Point " + point.ToString());
                }
                foreach (Edge edge in site.Edges) {
                    writeInfo("  Edge " + edge.ToString());
                    writeInfo("    Visible " + edge.Visible);
                    writeInfo("    Endpoints " + edge.Endpoint[0] + "," + edge.Endpoint[1]);
                    writeInfo("    ClippedEndpoints " + edge.ClippedEndpoints[0] + "," + edge.ClippedEndpoints[1]);
                }
            }
        }

        private void btnRegen_Click(object sender, EventArgs e) {
            currentOperation = CurrentOpertion.GENERATE;
            doFull = true;
            bitMapDrawn = false;
            GenerateGraph();
            panelDiagram.Invalidate();
        }

        private void chkShowSites_CheckedChanged(object sender, EventArgs e) {
            bitMapDrawn = false;
            panelDiagram.Invalidate();
        }

        private void chkShowVertices_CheckedChanged(object sender, EventArgs e) {
            bitMapDrawn = false;
            panelDiagram.Invalidate();
        }

        private void chkShowEdges_CheckedChanged(object sender, EventArgs e) {
            bitMapDrawn = false;
            panelDiagram.Invalidate();
        }

        private void cbCircles_SelectedIndexChanged(object sender, EventArgs e) {
            bitMapDrawn = false;
            panelDiagram.Invalidate();
        }

        private void chkShowNumbers_Click(object sender, EventArgs e) {
            bitMapDrawn = false;
            panelDiagram.Invalidate();
        }


        private void chkShowBeachLine_CheckChanged(object sender, EventArgs e) {
            bitMapDrawn = false;
            panelDiagram.Invalidate();
        }

        private void btnStepVoronoi_Click(object sender, EventArgs e) {
#if traceFlow
            writeInfo("btnStepVoronoi_Click doFull=" + doFull
                + " bitMapDrawn=" + bitMapDrawn);
#endif
            if (_voronoi == null) {
                Utils.errMsg("Voronoi has not been initialized");
                return;
            }
            currentOperation = CurrentOpertion.STEP;
            doFull = false;
            bitMapDrawn = false;
            _graph = _voronoi.StepVoronoi();
            nudStepTo.Value++;
            panelDiagram.Invalidate();
        }

        private void btnInitialize_Click(object sender, EventArgs e) {
            doFull = false;
            bitMapDrawn = false;
            InitializeVoronoi();
            nudStepTo.Value++;
        }

        private void btnStepTo_Click(object sender, EventArgs e) {
#if traceFlow
            writeInfo("btnStepTo_Click doFull=" + doFull
               + " bitMapDrawn=" + bitMapDrawn);
#endif
            currentOperation = CurrentOpertion.STEP;
            doFull = false;
            bitMapDrawn = false;
            Animate((int)nudStepTo.Value);
        }

        private void Animate(int toStep = int.MaxValue) {
#if traceFlow
            writeInfo("Animate doFull=" + doFull
               + " bitMapDrawn=" + bitMapDrawn
               + " toStep=" + toStep);
#endif
            Cursor = Cursors.WaitCursor;
            doFull = false;
            int lastStep = _voronoi.StepNumber;
            using (Graphics g = panelDiagram.CreateGraphics()) {
                while (_voronoi.StepNumber < toStep) {
                    _voronoi.StepVoronoi();
                    bitMapDrawn = false;
                    paintError = false;
                    //WriteLine("Animate: step=" + _voronoi.StepNumber);
                    // This is the only place PaintDiagram is being called explicitly
                    PaintDiagram(g);
                    if (paintError) {
                        writeInfo("Animate: Paint Error: step="
                            + _voronoi.StepNumber);
                        break;
                    }
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
            writeInfo("btnAnimate_Click doFull=" + doFull
               + " bitMapDrawn=" + bitMapDrawn);
#endif
            currentOperation = CurrentOpertion.STEP;
            doFull = false;
            bitMapDrawn = false;
            if (_voronoi == null) {
                InitializeVoronoi();
            }
            decimal startStep = nudStepTo.Value;
            Animate();
            if (paintError) {
                paintError = false;
                return;
            }
            if (nudStepTo.Value == startStep) {
                _voronoi = null;
                btnAnimate_Click(sender, e);
            }
        }

        private void OnPanelMainPaint(object sender, PaintEventArgs e) {
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
                scaleMapData(mapDataFromFile);
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

        private void tools_FileFromImage_Click(object sender, EventArgs e) {
            if (createFileFromImageDlg == null) {
                createFileFromImageDlg = new CreateFileFromImageDialog(this);
            }
            createFileFromImageDlg.Show();
        }

        private void OnMainFormResizeEnd(object sender, EventArgs e) {
#if traceFlow
            // DEBUG
            writeInfo("OnMainFormResizeEnd: currentOperation=" + currentOperation);
#endif
            // Also happens when the Form is moved so only do if ClientSize changed
            if (_bitmap != null &&
                _bitmap.Width == panelDiagram.ClientSize.Width &&
                _bitmap.Height == panelDiagram.ClientSize.Height) {
                return;
            }

            if (_bitmap != null) _bitmap.Dispose();
            _bitmap = new Bitmap(panelDiagram.ClientSize.Width,
                panelDiagram.ClientSize.Height);
            if (mapDataFromFile != null) scaleMapData(mapDataFromFile);
            if (mapDataFromRandom != null) scaleMapData(mapDataFromRandom);
            getMapData();
#if traceFlow
            writeInfo("    _bitmap recreated: " + _bitmap.Width + "," + _bitmap.Height);
            writeInfo("    mapDataFromRandom: " + mapDataFromRandom);
            writeInfo("    mapDataFromFile: " + mapDataFromFile);
            writeInfo("    mapData: " + mapData);
#endif
            // Have to go through all the steps since they depend on ClientSize
            bitMapDrawn = false;
            if (currentOperation == CurrentOpertion.GENERATE) {
                btnRegen_Click(sender, e);
            } else if (currentOperation == CurrentOpertion.STEP) {
                decimal lastStep = nudStepTo.Value;
                // Is 0 only before InitializeVoronoi, which we do
                if (lastStep < 1) lastStep = 1;
                InitializeVoronoi();
                nudStepTo.Value = lastStep;
                // Go through all the steps
                btnStepTo_Click(sender, e);
            }
        }
    }
}
