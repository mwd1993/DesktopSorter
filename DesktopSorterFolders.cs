using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesktopSorter
{
    class DesktopSorterFolders
    {
        public static List<string> compressFolders()
        {
            if (DesktopSorterVariables.ignoreExtensions.Contains("folders"))
            {
                return new List<string>();
            }

            #region Variable Initializing
            List<string> foldersCompressed = new List<string>();
            List<string> foldersIgnored = new List<string>();
            List<string> foldersToIgnore = new List<string>() { "desktopsorter", "_publicdesktop" };
            string[] dirs = Directory.GetDirectories(DesktopSorterVariables.desktopPath);
            string[] foldersToBig = new string[] { "gb", "tb", "pb", "eb" };
            #endregion

            #region Folder Compression Logic
            // Loop through each directory
            // on our Desktop
            foreach (var d in dirs)
            {
                if (foldersToIgnore.Contains(Path.GetFileName(d).ToLower()))
                    continue;
                float size = DesktopSorterUtilities.directorySize(d);
                string sizeGB = DesktopSorterUtilities.bytesToString((long)size);
                bool folderToBig = false;
                // Check to see if the file
                // is over over a gigabyte in size
                foreach (var ftb in foldersToBig)
                {
                    if (sizeGB.ToLower().Contains(ftb))
                    {
                        folderToBig = true;
                        break;
                    }
                }
                if (folderToBig)
                {
                    foldersIgnored.Add(d);
                    continue;
                }
                foldersCompressed.Add(d);
            }

            if (foldersCompressed.Count > 0)
            {
                if (Directory.Exists(DesktopSorterVariables.desktopPath + "/DesktopSorter/"))
                {
                    if (!Directory.Exists(DesktopSorterVariables.desktopPath + "/DesktopSorter/_DesktopSorterFolders/"))
                        Directory.CreateDirectory(DesktopSorterVariables.desktopPath + "/DesktopSorter/_DesktopSorterFolders/");
                    // Moves each folder we stored
                    // to foldersCompressed, into
                    // out compression directory
                    foreach (var f in foldersCompressed)
                    {
                        Directory.Move(f, DesktopSorterVariables.desktopPath + "/DesktopSorter/_DesktopSorterFolders/" + Path.GetFileName(f));
                    }
                }
            }
            #endregion

            return foldersCompressed;
        }

        public static List<string> decompressFolders()
        {
            List<string> foldersDecompressed = new List<string>();
            string[] folders = Directory.GetDirectories(DesktopSorterVariables.desktopPath + "/DesktopSorter/_DesktopSorterFolders/");\
            // Loop through each directory
            // in our compression directory
            foreach (var f in folders)
            {
                // Move the file back to the desktop
                Directory.Move(f, DesktopSorterVariables.desktopPath + "/" + Path.GetFileName(f));
                foldersDecompressed.Add(f);
            }
            return foldersDecompressed;
        }
    }
}
