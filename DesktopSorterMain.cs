using DesktopSorter;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace DesktopSorterWF
{
    static class DesktopSorterMain
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create a thread to keep our list views up to date
            // with our desktop and the sorted directory folder names
            Thread thread = new Thread(new ThreadStart(delegate ()
            {
                while (true)
                {
                    if(Interface.lvLoadTimeout)
                    {
                        long currTimeMS = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                        // MessageBox.Show(currTimeMS + " - " + Interface.lvLoadLastTimeoutValue + " > " + Interface.lvLoadTimeoutValue + "?");
                        if (currTimeMS - Interface.lvLoadLastTimeoutValue > Interface.lvLoadTimeoutValue)
                        {
                            Interface.lvLoadTimeout = false;
                            Interface.lvLoadLastTimeoutValue = currTimeMS;
                            Interface.enableListViews();
                        }
                        else
                            continue;
                    }
                    string dp = DesktopSorterVariables.desktopPath;
                    string[] files = Directory.GetFiles(DesktopSorterVariables.desktopPath);
                    string[] desktopSorterDirectories = new string[] { };
                    if (Directory.Exists(DesktopSorterVariables.desktopPath + "\\DesktopSorter"))
                        desktopSorterDirectories = Directory.GetDirectories(DesktopSorterVariables.desktopPath + "\\DesktopSorter");

                    if (Interface.lv1 != null)
                    {
                        Thread.Sleep(Interface.lvRefreshSleepTime);
                        // Try to modify the list views, if we fail, it's because
                        // the graphical interface has been closed, so we catch
                        // the exception, and simply exit, closing our thread aswell
                        try
                        {
                            Interface.lv1.Invoke((MethodInvoker)(() =>
                            {
                                if (files.Length != Interface.filesDetected.Count)
                                {
                                    Interface.lv1.Clear();
                                    Interface.filesDetected.Clear();
                                }
                                foreach (var f in files)
                                {
                                    var fn = Path.GetFileName(f);
                                    if (DesktopSorterWF.Interface.filesDetected.Contains(fn))
                                        continue;
                                    var listViewItem = new ListViewItem(new string[] { fn });
                                    Interface.lv1.Items.Add(listViewItem);
                                    Interface.filesDetected.Add(fn);
                                    // Interface.lv1L.Text = "Size: " + DesktopSorterUtilities.directorySize(DesktopSorterVariables.desktopPath);
                                    Thread getSizeOfDirectory = new Thread(new ThreadStart(delegate ()
                                    {
                                        var sizeOf = DesktopSorterUtilities.desktopSize();
                                        var sizeOfFinal = DesktopSorterUtilities.bytesToString((long)sizeOf);
                                        Interface.lv1L.Invoke((MethodInvoker)(() =>
                                        {
                                            Interface.lv1L.Text = "Size: " + sizeOfFinal + " (Folders Exluded)";
                                        }));

                                    }));
                                    getSizeOfDirectory.Start();
                                }
                            }));

                            // If user has ran the sorter, we can proceed to
                            // modify the sorted directories' list view
                            if (desktopSorterDirectories.Length > 0)
                            {
                                Interface.lv2.Invoke((MethodInvoker)(() =>
                                {
                                    // Something changed, so we can proceed to update the list view
                                    if (desktopSorterDirectories.Length != Interface.desktopSorterDirsDetected.Count)
                                    {
                                        Interface.lv2.Clear();
                                        Interface.desktopSorterDirsDetected.Clear();
                                    }
                                    foreach (var d in desktopSorterDirectories)
                                    {
                                        var dn = Path.GetFileName(d);
                                        if (Interface.desktopSorterDirsDetected.Contains(dn))
                                            continue;
                                        var listViewItem = new ListViewItem(new string[] { dn });
                                        Interface.lv2.Items.Add(listViewItem);
                                        Interface.desktopSorterDirsDetected.Add(dn);

                                        Thread getSizeOfDirectory = new Thread(new ThreadStart(delegate ()
                                        {
                                            var sizeOf = Double.Parse(DesktopSorterUtilities.directorySize(DesktopSorterVariables.desktopPath + "\\DesktopSorter").ToString(), System.Globalization.NumberStyles.Float);
                                            var sizeOfFinal = DesktopSorterUtilities.bytesToString((long)sizeOf);
                                            Interface.lv2L.Invoke((MethodInvoker)(() =>
                                            {
                                                Interface.lv2L.Text = "Size: " + sizeOfFinal;
                                            }));
                                            
                                        }));
                                        getSizeOfDirectory.Start();

                                    }
                                }));
                            }
                            else
                            {
                                Interface.lv2.Invoke((MethodInvoker)(() =>
                                {
                                    Interface.lv2.Items.Clear();
                                }));
                            }
                        }
                        catch
                        {
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                        }
                    }
                }

            }));

            // Start our thread
            thread.Start();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Interface());

        }

    }
}
