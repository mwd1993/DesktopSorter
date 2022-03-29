using System;
using System.Collections.Generic;
using System.IO;

namespace DesktopSorter
{
    /// <summary>
    /// DesktopSorter class that handles
    /// the logic of either compression or
    /// the decompression
    /// </summary>
    public static class DesktopSorter
    {
        /// <summary>
        /// This was our main entry point when the
        /// program was command line only. Since
        /// our main entry point changed to the interface
        /// we will call this, the secondary entry point
        /// </summary>
        /// <param name="args"></param>
        public static void secondaryMain(string[] args)
        {
            if (args.Length >= 1)
            {
                // Extensions to ignore
                // were provided by the user
                if (args.Length >= 2)
                {
                    string ignoreExt = args[1];
                    // Split by the seperator "," and
                    // store each extension to a list
                    List<string> ignore = new List<string>(ignoreExt.Split(","));
                    DesktopSorterVariables.ignoreExtensions = ignore;
                }

                #region Command Line Switch Logic
                switch (args[0].ToLower())
                {
                    case "test":
                        {
                            // Nothing for now, may be used
                            // to handle any testing we need to do.
                            break;
                        }
                    case "compress":
                        {
                            List<string> files = DesktopSorterFiles.compressFiles();
                            List<string> folders = DesktopSorterFolders.compressFolders();
                            Console.WriteLine("Compressed " + files.Count + " Files and " + folders.Count + " Folders");
                            break;
                        }
                    case "decompress":
                        {
                            List<string> folders = DesktopSorterFolders.decompressFolders();
                            List<string> files = DesktopSorterFiles.decompressFiles(); // method deletes DesktopSorter's Desktop Folder, so call it last
                            Console.WriteLine("Decompressed " + files.Count + " Files and " + folders.Count + " Folders");
                            break;
                        }
                }
                #endregion
            }
        }
    }
}
