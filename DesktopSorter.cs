using System;
using System.Collections.Generic;
using System.IO;

namespace DesktopSorter
{
    public static class DesktopSorter
    {
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
                            // Nothing for now
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
