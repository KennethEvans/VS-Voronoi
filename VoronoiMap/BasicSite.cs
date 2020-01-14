using System.Drawing;

namespace VoronoiMap {
    public class BasicSite {
        public float X { get; set; }
        public float Y { get; set; }
        public Color Color { get; set; }
        public float Height { get; set; }

        public BasicSite(float x, float y, Color color, float height = 0) {
            X = x;
            Y = y;
            Color = color;
            Height = height;
        }
    }
}
