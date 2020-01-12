using System;
using System.Windows.Forms;

namespace VoronoiMap {
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            var form = new MainForm();
            

            Application.Run(form);
        }
    }
}
