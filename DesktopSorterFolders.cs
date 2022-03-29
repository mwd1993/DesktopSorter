using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DesktopSorter
{
    class DesktopSorterFolders
    {
        /// <summary>
        /// Tries to move folders from the active desktop
        /// to the sorting directory, ignoring folders
        /// that are over 1gig in size
        /// </summary>
        /// <returns>
        /// a List of strings of the directories that got moved
        /// </returns>
        public static List<string> compressFolders()
        {
            if (DesktopSorterVariables.ignoreExtensions.Contains("folders"))
            {
                return new List<string>();
            }

            #region Variable Initializing
            List<string> foldersCompressed = new List<string>();
            List<string> foldersIgnored = new List<string>();
            string[] dirs = Directory.GetDirectories(DesktopSorterVariables.desktopPath);
            #endregion

            #region Folder Compression Logic
            // Loop through each directory
            // on our Desktop
            foreach (var d in dirs)
            {
                if (DesktopSorterVariables.foldersToIgnore.Contains(Path.GetFileName(d).ToLower()))
                    continue;
                float size = DesktopSorterUtilities.directorySize(d);
                string sizeGB = DesktopSorterUtilities.bytesToString((long)size);
                bool folderTooBig = false;
                // Check to see if the file
                // is over over a gigabyte in size
                foreach (var ftb in DesktopSorterVariables.foldersTooBig)
                {
                    if (sizeGB.ToLower().Contains(ftb))
                    {
                        folderTooBig = true;
                        break;
                    }
                }
                if (folderTooBig)
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

        /// <summary>
        /// Tries to decompress the folders (containing files)
        /// back to the active desktop
        /// </summary>
        /// <returns>a List of strings of the directories that got moved</returns>
        public static List<string> decompressFolders()
        {
            List<string> foldersDecompressed = new List<string>();
            string[] folders = new string[] { };
            try
            {
                folders = Directory.GetDirectories(DesktopSorterVariables.desktopPath + "/DesktopSorter/_DesktopSorterFolders/");
            }
            catch
            {
                return foldersDecompressed;
            }
            // Loop through each directory
            // in our compression directory
            foreach (var f in folders)
            {
                // TODO: May need to wrap this try in a while loop
                try
                {
                    // Move the file back to the desktop
                    Directory.Move(f, DesktopSorterVariables.desktopPath + "/" + Path.GetFileName(f));
                }
                catch
                {
                    // folder has something in use by user, cannot move
                    MessageBox.Show("You have a program or file running, the application is paused until it has been closed.");
                }
                foldersDecompressed.Add(f);
            }
            return foldersDecompressed;
        }
    }
}
