using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesktopSorter
{
    /// <summary>
    /// Various misc. methods for 
    /// the desktopSorter
    /// </summary>
    class DesktopSorterUtilities
    {
        /// <summary>
        /// Gets the current desktop size in bytes
        /// </summary>
        /// <returns>float bytes</returns>
        public static float desktopSize()
        {
            string[] files = Directory.GetFiles(DesktopSorterVariables.desktopPath);
            float desktopSize = 0;
            foreach(var f in files)
            {
                FileInfo fileInfo = new FileInfo(f);
                desktopSize += fileInfo.Length;
            }
            return desktopSize;
        }

        /// <summary>
        /// Gets the current directory size
        /// provided, and returns the total bytes
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="inGigabytes"></param>
        /// <returns>float bytes</returns>
        public static float directorySize(string directory, bool inGigabytes = true)
        {
            try
            {
                float size = 0;
                DirectoryInfo d = new DirectoryInfo(directory);
                FileInfo[] fis = d.GetFiles();
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (FileInfo fi in fis)
                    size += fi.Length;
                foreach (DirectoryInfo di in dis)
                    size += directorySize(di.FullName, inGigabytes: false);
                return size;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Converts bytes to a human-readable form
        /// </summary>
        /// <param name="byteCount"></param>
        /// <returns>string representation</returns>
        public static String bytesToString(long byteCount)
        {
            string[] suffixes = {
                "B", "KB", "MB",
                "GB", "TB", "PB",
                "EB"
            };
            if (byteCount == 0)
                return "0" + suffixes[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suffixes[place];
        }
    }
}
