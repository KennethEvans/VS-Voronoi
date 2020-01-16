﻿#undef dumpSites

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
        private MapData mapData;
        private Size plotSize;

        public MainForm() {
            InitializeComponent();
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

        private void MainForm_Load(object sender, EventArgs e) {
            //GenerateGraph();
            InitializeVoronoi();
            _bitmap = new Bitmap(splitPanel.Panel2.ClientSize.Width,
                splitPanel.Panel2.ClientSize.Height);
            cbCircles.SelectedIndex = 0;
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

        private void GenerateGraph() {
            long start = Stopwatch.GetTimestamp();
            List<BasicSite> basicSites = new List<BasicSite>();
            if (chkUseFile.Checked) {
                Utils.errMsg("GenerateGraph is not implemented for using a file");
                return;
            } else {
                Random rand = new Random((int)nudSeed.Value);
                int w = splitPanel.Panel2.ClientSize.Width;
                int h = splitPanel.Panel2.ClientSize.Height;
                plotSize = new Size(w, h);
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
                mapData = new MapData(0, w, 0, h, basicSites);
            }
            if (nudRelax.Value > 0) {
                basicSites = RelaxPoints((int)nudRelax.Value, basicSites);
                mapData.SiteList = basicSites;
            }
            _graph = VoronoiGraph.ComputeVoronoiGraph(basicSites,
                mapData.Width, mapData.Height, chDebug.Checked);
#if dumpSites
            dumpSites();
#endif            
            TimeSpan elapsed = new TimeSpan(Stopwatch.GetTimestamp() - start);
            Console.WriteLine("Voronois done!");
        }

        private void splitContainer1_Panel2_Paint(object sender,
            PaintEventArgs e) {
            Graphics g = e.Graphics;
            PaintDiagram(g);
        }

        private void PaintDiagram(Graphics g, bool full = true) {
            if (_graph == null) {
                Utils.errMsg("Graph is not defined");
                return;
            }
            using (Graphics g1 = Graphics.FromImage(_bitmap)) {
                g1.SmoothingMode = SmoothingMode.AntiAlias;
                if (full) {
                    PaintDiagramFull(g1);
                } else {
                    PaintDiagramIncremental(g1);
                }
                g.DrawImage(_bitmap, new PointF());
            }
        }

        private void PaintDiagramFull(Graphics g) {
            g.Clear(BackColor);
            int item = cbCircles.SelectedIndex;
            GraphicsPath gp = new GraphicsPath();
            GraphicsPath gp2 = new GraphicsPath();
            GraphicsPath gp3 = new GraphicsPath();
            // Color the regions
            foreach (Site site in _graph.Sites) {
                GraphicsPath gp4 = new GraphicsPath();
                RectangleF visibleClipBounds = g.VisibleClipBounds;
                //Console.WriteLine("visibleBounds " + visibleClipBounds);
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
            // Do the rest
            foreach (Site site in _graph.Sites) {
                RectangleF r = new RectangleF(site.X - 2, site.Y - 2, 4, 4);
                if (chkShowSites.Checked && chkShowNumbers.Checked) {
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
        }

        private HashSet<Site> _sitesToIgnore = new HashSet<Site>();
        private void PaintDiagramIncremental(Graphics g) {
            if (_graph == null) {
                Utils.errMsg("PaintDiagramIncremental: Graph is not defined");
                return;
            }
            g.Clear(BackColor);
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
                        if (y > g.ClipBounds.Height) {
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
            if (chkShowSites.Checked) {
                GraphicsPath gp = new GraphicsPath();
                foreach (Site site in _graph.Sites) {
                    RectangleF r = site.New ?
                        new RectangleF(site.X - 4, site.Y - 4, 8, 8)
                        : new RectangleF(site.X - 2, site.Y - 2, 4, 4);
                    if (site.New) {
                        g.FillEllipse(_newSiteBrush, r);
                    } else {
                        gp.AddEllipse(r);
                    }
                    if (chkShowNumbers.Checked) {
                        g.DrawString(site.NumString(), _textFont,
                            _siteBrush, site.X, site.Y);
                    }
                }
                g.FillPath(_siteBrush, gp);
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

        private void InitializeVoronoi() {
            _sitesToIgnore = new HashSet<Site>();
            Console.Clear();
            nudStepTo.Value = 0;
            Edge.EdgeCount = 0;
            Random rand = new Random((int)nudSeed.Value);
            int w = splitPanel.Panel2.ClientSize.Width;
            int h = splitPanel.Panel2.ClientSize.Height;
            Console.WriteLine("Initialize: Width=" + w + " Height=" + h);
            int numSites = (int)nudNumRegions.Value;
            List<BasicSite> sites = new List<BasicSite>();
            for (int i = 0; i < numSites; i++) {
                Color color = Color.FromArgb(rand.Next(256), rand.Next(256),
                    rand.Next(256));
                BasicSite site = new BasicSite(rand.Next(w), rand.Next(h), color);
                sites.Add(site);
            }
            if (nudRelax.Value > 0) {
                sites = RelaxPoints((int)nudRelax.Value, sites);
            }
            _voronoi = new Voronoi(sites, w, h, chDebug.Checked);
            _graph = _voronoi.Initialize();

        }

        private List<BasicSite> RelaxPoints(int times, List<BasicSite> sites) {
            List<BasicSite> ret = new List<BasicSite>();
            int w = splitPanel.Panel2.ClientSize.Width;
            int h = splitPanel.Panel2.ClientSize.Height;
            List<BasicSite> tempPoints = sites;
            for (int i = 0; i < times; i++) {
                VoronoiGraph voronoi =
                    VoronoiGraph.ComputeVoronoiGraph(tempPoints, w, h);
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
            GraphicsUnit units = GraphicsUnit.Pixel;
            RectangleF clipBounds = _bitmap.GetBounds(ref units);
            Console.WriteLine("clipBounds=" + clipBounds);
            foreach (Site site in _graph.Sites) {
                PointF[] points = site.Region(clipBounds).
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
            //Console.WriteLine("btnRegen_Click");
            GenerateGraph();
            splitPanel.Panel2.Invalidate();
        }

        private void chkShowEdges_CheckedChanged(object sender, EventArgs e) {
            splitPanel.Panel2.Invalidate();
        }

        private void btnStepVoronoi_Click(object sender, EventArgs e) {
            using (Graphics graphics = splitPanel.Panel2.CreateGraphics()) {
                _graph = _voronoi.StepVoronoi();
                nudStepTo.Value++;
                PaintDiagram(graphics, false);
            }
        }

        private void btnInitialize_Click(object sender, EventArgs e) {
            InitializeVoronoi();
            using (Graphics graphics = splitPanel.Panel2.CreateGraphics()) {
                PaintDiagramIncremental(graphics);
            }
        }

        private void btnStepTo_Click(object sender, EventArgs e) {
            Animate((int)nudStepTo.Value);
        }

        private void Animate(int toStep = int.MaxValue) {
            Cursor = Cursors.WaitCursor;
            int lastStep = _voronoi.StepNumber;
            using (Graphics graphics = splitPanel.Panel2.CreateGraphics()) {
                while (_voronoi.StepNumber < toStep) {
                    _voronoi.StepVoronoi();
                    PaintDiagram(graphics, false);
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
            if (_bitmap != null) _bitmap.Dispose();
            _bitmap = new Bitmap(splitPanel.Panel2.ClientSize.Width,
                splitPanel.Panel2.ClientSize.Height);
            btnRegen_Click(null, null);
        }

        private void cbCircles_SelectedIndexChanged(object sender, EventArgs e) {
            splitPanel.Panel2.Invalidate();
        }

        private void file_OpenInput_click(object sender, EventArgs e) {
            mapData = MapData.openFile();
            if (mapData == null) {
                Utils.warnMsg("Failed to open Map Data file");
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

        }

        private void file_SaveMapDataFileNotIndented_click(object sender,
            EventArgs e) {

        }
    }
}