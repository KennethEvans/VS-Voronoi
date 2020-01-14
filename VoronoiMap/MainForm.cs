﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

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
            _bitmap = new Bitmap(splitPanel.Panel2.ClientSize.Width, splitPanel.Panel2.ClientSize.Height);
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
            var start = Stopwatch.GetTimestamp();
            var rand = new Random((int)nudSeed.Value);
            var w = splitPanel.Panel2.ClientSize.Width;
            var h = splitPanel.Panel2.ClientSize.Height;
            var numSites = (int)nudNumRegions.Value;
            var sites = new List<BasicSite>();
            for (int i = 0; i < numSites; i++) {
                var color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                var site = new BasicSite(rand.Next(w), rand.Next(h), color);
                sites.Add(site);
            }
            if (nudRelax.Value > 0) {
                sites = RelaxPoints((int)nudRelax.Value, sites);
            }
            _graph = VoronoiGraph.ComputeVoronoiGraph(sites, w, h, chDebug.Checked);
            var elapsed = new TimeSpan(Stopwatch.GetTimestamp() - start);
            Console.WriteLine("Voronois done!");
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            PaintDiagram(g);
        }

        private void PaintDiagram(Graphics g, bool full = true) {

            using (var g1 = Graphics.FromImage(_bitmap)) {
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
            if (_graph != null) {
                g.Clear(BackColor);

                var item = cbCircles.SelectedIndex;

                var gp = new GraphicsPath();
                var gp2 = new GraphicsPath();
                var gp3 = new GraphicsPath();
                // Color the regions
                foreach (var site in _graph.Sites) {
                    var gp4 = new GraphicsPath();
                    var visibleClipBounds = g.VisibleClipBounds;
                    var points = site.Region(visibleClipBounds).Where(p => p != null).Select(p => (PointF)p).ToArray();
                    if (points.Count() >= 3) {
                        gp4.AddPolygon(points);
                    }
                    var region = new Region(gp4);
                    var brush = new SolidBrush(site.Color);
                    g.FillRegion(brush, region);
                    brush.Dispose();
                }
                // Do the rest
                foreach (var site in _graph.Sites) {
                    var r = new RectangleF(site.X - 2, site.Y - 2, 4, 4);
                    if (chkShowSites.Checked && chkShowNumbers.Checked) {
                        gp.AddEllipse(r);
                        g.DrawString(site.NumString(), _textFont, _siteBrush, site.X, site.Y);
                    }
                    foreach (var edge in site.Edges) {
                        var start = edge.RightSite;
                        var end = edge.LeftSite;
                        if (item == 2) {
                            gp2.AddLine(start, end);
                            gp2.CloseFigure();
                        }
                    }
                    if (chkShowEdges.Checked) {
                        var visibleClipBounds = g.VisibleClipBounds;
                        var points = site.Region(visibleClipBounds).Where(p => p != null).Select(p => (PointF)p).ToArray();
                        if (points.Count() >= 3) {
                            gp3.AddPolygon(points);
                        }
                    }
                }
                g.DrawPath(_circlePen, gp2);
                g.DrawPath(_edgePen, gp3);
                g.FillPath(_siteBrush, gp);
            }
        }

        private HashSet<Site> _sitesToIgnore = new HashSet<Site>();
        private void PaintDiagramIncremental(Graphics g) {
            if (_graph != null) {

                g.Clear(BackColor);

                g.DrawLine(_sweepPen, splitPanel.Panel2.ClientRectangle.Left, _graph.SweepLine, splitPanel.Panel2.ClientRectangle.Right, _graph.SweepLine);

                var item = cbCircles.SelectedIndex;

                if (item == 1) {
                    var gp = new GraphicsPath();
                    foreach (var triangle in _graph.Triangles) {
                        var circle = new Circle(triangle.V1, triangle.V2, triangle.V3);
                        if (triangle.New) {
                            g.DrawEllipse(_newCirclePen, circle.GetRect());
                        } else {
                            gp.AddEllipse(circle.GetRect());
                        }
                    }
                    g.DrawPath(_circlePen, gp);
                } else if (item == 2) {
                    var gp = new GraphicsPath();
                    foreach (var triangle in _graph.Triangles) {
                        if (triangle.New) {
                            g.DrawPolygon(_newCirclePen, new[] { (PointF)triangle.V1, triangle.V2, triangle.V3 });
                        } else {
                            gp.AddPolygon(new[] { (PointF)triangle.V1, triangle.V2, triangle.V3 });
                        }
                    }
                    g.DrawPath(_circlePen, gp);
                }

                if (chkShowEdges.Checked) {
                    var gp = new GraphicsPath();

                    foreach (var segment in _graph.Segments) {
                        var start = segment.P1;
                        var end = segment.P2;
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

                    var gp = new GraphicsPath();
                    var beachLine = new Dictionary<int, float>();

                    foreach (var point in _graph.Sites.Except(_sitesToIgnore.ToList())) {
                        var drop = true;
                        for (int x = 0; x < g.VisibleClipBounds.Width; x++) {
                            var y = ParabolaY(point, _graph.SweepLine, x);
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
                            _sitesToIgnore.Add(point);
                        }
                    }

                    for (int x = 0; x < beachLine.Count - 1; x++) {
                        gp.AddLine(x, beachLine[x], x + 1, beachLine[x + 1]);
                    }

                    g.DrawPath(_beachPen, gp);
                }


                if (chkShowVertices.Checked) {
                    var gp = new GraphicsPath();
                    foreach (var vertex in _graph.Vertices) {
                        var r = vertex.New ?
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
                    var gp = new GraphicsPath();
                    foreach (var point in _graph.Sites) {
                        var r = point.New ? new RectangleF(point.X - 4, point.Y - 4, 8, 8) : new RectangleF(point.X - 2, point.Y - 2, 4, 4);
                        if (point.New) {
                            g.FillEllipse(_newSiteBrush, r);
                        } else {
                            gp.AddEllipse(r);
                        }
                    }
                    g.FillPath(_siteBrush, gp);
                }
            }
        }

        private float ParabolaY(Site site, float sweepLineY, int x) {
            try {
                var a = site.X;
                var b = site.Y;
                var c = sweepLineY;

                var y = ((x - a) * (x - a) + b * b - c * c) / (2 * (b - c + 1e-10f));
                return y;
            } catch (Exception) {
                return -1;
            }
        }

        private void btnRegen_Click(object sender, EventArgs e) {
            GenerateGraph();
            splitPanel.Panel2.Invalidate();
        }

        private void chkShowEdges_CheckedChanged(object sender, EventArgs e) {
            splitPanel.Panel2.Invalidate();
        }

        private void btnStepVoronoi_Click(object sender, EventArgs e) {
            using (var graphics = splitPanel.Panel2.CreateGraphics()) {
                _graph = _voronoi.StepVoronoi();
                nudStepTo.Value++;
                PaintDiagram(graphics, false);
            }
        }

        private void btnInitialize_Click(object sender, EventArgs e) {
            InitializeVoronoi();
            using (var graphics = splitPanel.Panel2.CreateGraphics()) {
                PaintDiagramIncremental(graphics);
            }
        }

        private void InitializeVoronoi() {
            _sitesToIgnore = new HashSet<Site>();
            Console.Clear();
            nudStepTo.Value = 0;
            Edge.EdgeCount = 0;

            var rand = new Random((int)nudSeed.Value);
            var w = splitPanel.Panel2.ClientSize.Width;
            var h = splitPanel.Panel2.ClientSize.Height;
            Console.WriteLine("Initialize: Width=" + w + " Height=" + h);
            var numSites = (int)nudNumRegions.Value;
            var sites = new List<BasicSite>();
            for (int i = 0; i < numSites; i++) {
                var color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                var site = new BasicSite(rand.Next(w), rand.Next(h), color);
                sites.Add(site);
            }
            if (nudRelax.Value > 0) {
                sites = RelaxPoints((int)nudRelax.Value, sites);
            }
            _voronoi = new Voronoi(sites, w, h, chDebug.Checked);
            _graph = _voronoi.Initialize();

        }

        private List<BasicSite> RelaxPoints(int times, List<BasicSite> sites) {
            var ret = new List<BasicSite>();
            var w = splitPanel.Panel2.ClientSize.Width;
            var h = splitPanel.Panel2.ClientSize.Height;
            var tempPoints = sites;
            for (int i = 0; i < times; i++) {
                var voronoi = VoronoiGraph.ComputeVoronoiGraph(tempPoints, w, h);
                tempPoints.Clear();
                foreach (var site in voronoi.Sites) {
                    var region = site.Region(splitPanel.Panel2.ClientRectangle);
                    var newSite = new BasicSite(0, 0, site.Color, site.Height);
                    foreach (var q in region) {
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

        private void btnStepTo_Click(object sender, EventArgs e) {
            Animate((int)nudStepTo.Value);
        }

        private void Animate(int toStep = int.MaxValue) {
            Cursor = Cursors.WaitCursor;
            var lastStep = _voronoi.StepNumber;
            using (var graphics = splitPanel.Panel2.CreateGraphics()) {
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
        }

        private void btnAnimate_Click(object sender, EventArgs e) {
            if (_voronoi == null) {
                InitializeVoronoi();
            }
            var startStep = nudStepTo.Value;
            Animate();
            if (nudStepTo.Value == startStep) {
                _voronoi = null;

                btnAnimate_Click(sender, e);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e) {
            if (_bitmap != null) _bitmap.Dispose();
            _bitmap = new Bitmap(splitPanel.Panel2.ClientSize.Width, splitPanel.Panel2.ClientSize.Height);
            btnRegen_Click(null, null);
        }

        private void cbCircles_SelectedIndexChanged(object sender, EventArgs e) {
            splitPanel.Panel2.Invalidate();
        }

        private void file_OpenInput_click(object sender, EventArgs e) {

        }

        private void file_Exit_click(object sender, EventArgs e) {
            Close();
        }

        private void help_About_click(object sender, EventArgs e) {
            AboutBox dlg = new AboutBox();
            dlg.ShowDialog();
        }
    }
}
