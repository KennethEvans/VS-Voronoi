using KEUtils.Utils;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace VoronoiMap {
    /// <summary>
    /// Class that handles a complete VoronoiGraph, including geometry, Sites,
    /// Vertices, Segments, Triangles, Edges, and SweepLine.
    /// </summary>
    public class VoronoiGraph {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public bool Debug { get; set; }
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }

        public readonly List<Site> Sites = new List<Site>();
        public readonly List<Site> Vertices = new List<Site>();
        public readonly List<Segment> Segments = new List<Segment>();
        public readonly List<Triangle> Triangles = new List<Triangle>();
        public readonly List<Edge> Edges = new List<Edge>();
        public float SweepLine { get; set; }

        public VoronoiGraph(float x, float y, float w, float h) {
            X = x;
            Y = y;
            Width = w;
            Height = h;
            Debug = false;
        }

        public static VoronoiGraph ComputeVoronoiGraph(IEnumerable<BasicSite> basicSites,
            float x, float y, float w, float h, bool debug = false) {
            var sites = new SiteList(basicSites);
            if (debug) {
                sites.LogSites();
            }
            var graph = new VoronoiGraph(x, y, w, h) { Debug = debug };
            try {
                var edgeList = new EdgeList(sites);
                var eventQueue = new EventQueue();
                sites.BottomSite = sites.ExtractMin();
                graph.PlotSite(sites.BottomSite);

                var newSite = sites.ExtractMin();
                var newIntStar = new Site(Single.MaxValue, Single.MaxValue);

                while (true) {
                    if (!eventQueue.IsEmpty) {
                        newIntStar = eventQueue.Min();
                    }
                    if (newSite != null && (eventQueue.IsEmpty || newSite.CompareTo(newIntStar) < 0)) {
                        // new site is smallest
                        graph.PlotSite(newSite);
                        var lbnd = edgeList.LeftBound(newSite);
                        var rbnd = lbnd.Right;
                        var bot = edgeList.RightRegion(lbnd);
                        var e = Edge.CreateBisectingEdge(bot, newSite);
                        graph.PlotBisector(e);
                        var bisector = new HalfEdge(e, Side.Left);
                        EdgeList.Insert(lbnd, bisector);
                        var p = Site.CreateIntersectingSite(lbnd, bisector);
                        if (p != null) {
                            eventQueue.Delete(lbnd);
                            if (debug) {
                                Console.WriteLine("Inserting {0}", p);
                            }
                            eventQueue.Insert(lbnd, p, Site.Distance(p, newSite));
                        }
                        lbnd = bisector;
                        bisector = new HalfEdge(e, Side.Right);
                        EdgeList.Insert(lbnd, bisector);
                        p = Site.CreateIntersectingSite(bisector, rbnd);
                        if (p != null) {
                            if (debug) {
                                Console.WriteLine("Inserting {0}", p);
                            }
                            eventQueue.Insert(bisector, p, Site.Distance(p, newSite));
                        }
                        newSite = sites.ExtractMin();
                    } else if (!eventQueue.IsEmpty) {
                        // intersection is smallest
                        var lbnd = eventQueue.ExtractMin();
                        var llbnd = lbnd.Left;
                        var rbnd = lbnd.Right;
                        var rrbnd = rbnd.Right;
                        var bot = edgeList.LeftRegion(lbnd);
                        var top = edgeList.RightRegion(rbnd);
                        graph.PlotTriple(bot, top, edgeList.RightRegion(lbnd));
                        var v = lbnd.Vertex;
                        graph.PlotVertex(v);
                        graph.EndPoint(lbnd.Edge, lbnd.Side, v);
                        graph.EndPoint(rbnd.Edge, rbnd.Side, v);
                        EdgeList.Delete(lbnd);
                        eventQueue.Delete(rbnd);
                        EdgeList.Delete(rbnd);
                        var pm = Side.Left;
                        if (bot.Y > top.Y) {
                            var temp = bot;
                            bot = top;
                            top = temp;
                            pm = Side.Right;
                        }
                        var e = Edge.CreateBisectingEdge(bot, top);
                        graph.PlotBisector(e);
                        var bisector = new HalfEdge(e, pm);
                        EdgeList.Insert(llbnd, bisector);
                        graph.EndPoint(e, Side.Other(pm), v);
                        var p = Site.CreateIntersectingSite(llbnd, bisector);
                        if (p != null) {
                            eventQueue.Delete(llbnd);
                            if (debug) {
                                Console.WriteLine("Inserting {0}", p);
                            }
                            eventQueue.Insert(llbnd, p, Site.Distance(p, bot));
                        }
                        p = Site.CreateIntersectingSite(bisector, rrbnd);
                        if (p != null) {
                            if (debug) {
                                Console.WriteLine("Inserting {0}", p);
                            }
                            eventQueue.Insert(bisector, p, Site.Distance(p, bot));
                        }
                    } else {
                        break;
                    }
                }
                for (HalfEdge lbnd = edgeList.LeftEnd.Right; lbnd != edgeList.RightEnd; lbnd = lbnd.Right) {
                    Edge e = lbnd.Edge;
                    graph.PlotEndpoint(e);
                }
            } catch (Exception ex) {
                Utils.excMsg("Error creating VeronoiGraph", ex);
            }
            graph.SweepLine = graph.Height;
            graph.ResetNewItems();
            foreach (var edge in graph.Edges) {
                edge.ClipVertices(new RectangleF(x, y, w, h));
            }
            return graph;
        }

        public void PlotSite(Site site) {
            site.New = true;
            Sites.Add(site);
            if (Debug) {
                Console.WriteLine("site {0}", site);
                Log.InfoFormat("site {0}", site);
            }
            if (site.Y > SweepLine) {
                SweepLine = site.Y;
            }

        }


        public void PlotBisector(Edge e) {
            if (Debug) {
                Console.WriteLine("bisector {0} {1}", e.Region[Side.Left], e.Region[Side.Right]);
                Log.InfoFormat("bisector {0} {1}", e.Region[Side.Left], e.Region[Side.Right]);
            }
            Edges.Add(e);
        }

        public void PlotEndpoint(Edge e) {
            if (Debug) {
                Console.WriteLine("EP {0}", e);
                Log.InfoFormat("EP {0}", e);
            }
            ClipLine(e);
        }

        public void PlotVertex(Site s) {
            if (Debug) {
                Console.WriteLine("vertex {0},{1}", s.X, s.Y);
                Log.InfoFormat("vertex {0},{1}", s.X, s.Y);
            }
            s.New = true;
            Vertices.Add(s);
        }

        public void PlotTriple(Site s1, Site s2, Site s3) {
            if (Debug) {
                Console.WriteLine("triple {0} {1} {2}", s1, s2, s3);
            }
            var triangle = new Triangle(s1, s2, s3) { New = true };
            Triangles.Add(triangle);
        }

        public void ResetNewItems() {
            foreach (var site in Sites) {
                site.New = false;
            }
            foreach (var vertex in Vertices) {
                vertex.New = false;
            }
            foreach (var segment in Segments) {
                segment.New = false;
            }
            foreach (var triangle in Triangles) {
                triangle.New = false;
            }
        }


        /// <summary>
        /// Somewhat redundant line clipping routine.
        /// </summary>
        /// <param name="e"></param>
        private void ClipLine(Edge e) {
            var clipped = e.GetClippedEnds(new RectangleF(X, Y, Width, Height));
            if (clipped != null) {
                var site1 = new Site(clipped.Item1);
                var site2 = new Site(clipped.Item2);
                var s = new Segment(site1, site2) {
                    New = true
                };
                Segments.Add(s);
            }
        }

        public void EndPoint(Edge edge, Side side, Site site) {
            edge.Endpoint[side] = site;
            var opSide = side == Side.Left ? Side.Right : Side.Left;
            if (edge.Endpoint[opSide] == null) {
                return;
            }
            PlotEndpoint(edge);
        }
    }
}