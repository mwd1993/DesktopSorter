using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;


namespace DesktopSorterWF
{
    /// <summary>
    /// Our main entry point (the interface)
    /// and we can then handle button compression
    /// calls, and send to our secondary entry point
    /// via DesktopSorter class
    /// </summary>
    public partial class Interface : Form
    {
        public static ListView lv1;
        public static ListView lv2;
        public static Label lv1L;
        public static Label lv2L;
        public static ListView lv1Dis;
        public static ListView lv2Dis;
        public static Button b1, b2, b3, b4;
        public static List<string> filesDetected = new List<string>();
        public static List<string> desktopSorterDirsDetected = new List<string>();
        public static int lvRefreshSleepTime = 100;
        public static bool lvLoadTimeout = false;
        public static long lvLoadTimeoutValue = 2500;
        public static long lvLoadLastTimeoutValue = 0;

        /// <summary>
        /// Constructor method
        /// </summary>
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
            Interface.b1 = button1;
            Interface.b2 = button2;
            Interface.b3 = button3;
            ToolTip ignoreCompressionTextTT = new ToolTip();
            ignoreCompressionTextTT.SetToolTip(ignoreCompressionText, "Ignores extensions provided. Seperate each extension with a comma, don't use spaces.\nIE: .txt,.mp4,folders,.jpg");
        }

        /// <summary>
        /// Disables the buttons on the interface
        /// </summary>
        public static void disableButtons()
        {
            Interface.b1.Enabled = false;
            Interface.b2.Enabled = false;
            Interface.b3.Enabled = false;
        }

        /// <summary>
        /// Enables the buttons on the interface
        /// </summary>
        public static void enableButtons()
        {
            Interface.b1.Invoke((MethodInvoker)(() =>
            {
                Interface.b1.Enabled = true;
            }));
            Interface.b2.Invoke((MethodInvoker)(() =>
            {
                Interface.b2.Enabled = true;
            }));
            Interface.b3.Invoke((MethodInvoker)(() =>
            {
                Interface.b3.Enabled = true;
            }));
        }

        /// <summary>
        /// Disables the list views on the
        /// interface and the buttons
        /// </summary>
        public static void disableListViews()
        {
            Interface.lv1Dis.BringToFront();
            Interface.lv2Dis.BringToFront();
            Interface.disableButtons();
        }

        /// <summary>
        /// Enables the list views on the
        /// interface and the buttons
        /// </summary>
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
            Interface.enableButtons();
        }

        /// <summary>
        /// The view button click event
        /// on the interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string desktopDir = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + "\\DesktopSorter";
            if (Directory.Exists(desktopDir))
            {
                Process.Start("explorer.exe", "/open, " + desktopDir);
            }
        }

        /// <summary>
        /// The github button event on the
        /// interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://github.com/mwd1993/DesktopSorter/releases");
        }

        /// <summary>
        /// The compress button event on
        /// the interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// The decompress button event on
        /// the interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// The donation button event on
        /// the interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://www.buymeacoffee.com/mwd1993");
        }
    }
}
