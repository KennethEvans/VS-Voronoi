using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace VoronoiMap {
    public class MapData {
        public float Left { get; set; }
        public float Right { get; set; }
        public float Top { get; set; }
        public float Bottom { get; set; }
        public List<BasicSite> SiteList { get; set; } = new List<BasicSite>();

        public float Width { get { return (Right - Left); } }
        public float Height { get { return (Bottom - Top); } }

        public MapData(float left, float right, float top, float bottom, List<BasicSite> siteList) {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
            SiteList = siteList;
        }

        public MapData(string fileName) {
            string json = File.ReadAllText(fileName);
            MapData newMapData = JsonConvert.DeserializeObject<MapData>(json);
            Left = newMapData.Left;
            Right = newMapData.Right;
            Top = newMapData.Top;
            BasicSite newBasicSite;
            foreach (BasicSite basicSite in newMapData.SiteList) {
                newBasicSite = new BasicSite(basicSite.X, basicSite.Y,
                    basicSite.Color, basicSite.Height);
                SiteList.Add(newBasicSite);
            }
        }

        public void saveMapDataAsJson(string fileName, bool indented = false) {
            string json;
            if (indented) {
                json = JsonConvert.SerializeObject(this, Formatting.Indented);
            } else {
                json = JsonConvert.SerializeObject(this);
            }
            File.WriteAllText(fileName, json);
        }

        public static MapData openFile() {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Json Files|*.json";
            dlg.Title = "Select a Map Data File";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                MapData mapData = new MapData(dlg.FileName);
                return mapData;
            }
            return null;
        }

        public void saveFile(bool indented = false) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Json Files|*.json";
            dlg.Title = "Select a Map Data File";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                saveMapDataAsJson(dlg.FileName, indented);
            }
        }
    }
}
