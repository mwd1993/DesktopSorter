using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSorterWF
{
    public partial class Interface : Form
    {
        public static ListView lv1;
        public static ListView lv2;
        public static Label lv1L;
        public static Label lv2L;
        public static ListView lv1Dis;
        public static ListView lv2Dis;
        public static List<string> filesDetected = new List<string>();
        public static List<string> desktopSorterDirsDetected = new List<string>();
        public static int lvRefreshSleepTime = 100;
        public static bool lvLoadTimeout = false;
        public static long lvLoadTimeoutValue = 2500;
        public static long lvLoadLastTimeoutValue = 0;
        public Interface()
        {
            InitializeComponent();
            Interface.lv1 = listView1;
            Interface.lv2 = listView2;
            Interface.lv1L = desktopfilesSizeText;
            Interface.lv2L = sortedDirectorySizeText;
            Interface.lv1.Scrollable = true;
            Interface.lv2.Scrollable = true;
            Interface.lv1Dis = lv1Disabled;
            Interface.lv2Dis = lv2Disabled;

            var lv1text = new ListViewItem(new string[] { "... Loading ..." });
            var lv2text = new ListViewItem(new string[] { "... Loading ..." });
            Interface.lv1Dis.Items.Add(lv1text);
            Interface.lv2Dis.Items.Add(lv2text);

        }

        public static void disableListViews()
        {
            Interface.lv1Dis.BringToFront();
            Interface.lv2Dis.BringToFront();
        }

        public static void enableListViews()
        {
            lv1.Invoke((MethodInvoker)(() =>
            {
                Interface.lv1.Items.Clear();
                Interface.filesDetected.Clear();
                Interface.desktopSorterDirsDetected.Clear();
            }));
            lv2.Invoke((MethodInvoker)(() =>
            {
                Interface.lv2.Items.Clear();
                Interface.filesDetected.Clear();
                Interface.desktopSorterDirsDetected.Clear();
            }));

            lv1Dis.Invoke((MethodInvoker)(() =>
            {
                lv1Dis.SendToBack();
            }));

            lv2Dis.Invoke((MethodInvoker)(() =>
            {
                lv2Dis.SendToBack();
            }));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string desktopDir = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + "\\DesktopSorter";
            if (Directory.Exists(desktopDir))
            {
                Process.Start("explorer.exe", "/open, " + desktopDir);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://github.com/mwd1993/DesktopSorter/releases");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Interface.lvLoadTimeout = true;
            Interface.lvLoadLastTimeoutValue = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            DesktopSorter.DesktopSorter.secondaryMain(new string[] {
                "compress", ignoreCompressionText.Text
            });
            Interface.lv1.Items.Clear();
            Interface.filesDetected.Clear();
            Interface.lv2.Items.Clear();
            Interface.desktopSorterDirsDetected.Clear();
            Interface.disableListViews();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Interface.lvLoadTimeout = true;
            Interface.lvLoadLastTimeoutValue = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            DesktopSorter.DesktopSorter.secondaryMain(new string[] {
                "decompress"
            });
            Interface.lv1.Items.Clear();
            Interface.filesDetected.Clear();
            Interface.lv2.Items.Clear();
            Interface.desktopSorterDirsDetected.Clear();
            Interface.disableListViews();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://www.buymeacoffee.com/mwd1993");
        }
    }
}
