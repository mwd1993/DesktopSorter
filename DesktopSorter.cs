using System;
using System.Collections.Generic;
using System.IO;

namespace DesktopSorter
{
    class Sorter
    {
        public static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string desktopPublicPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
        public static List<string> ignoreExtensions = new List<string>();
        public static List<string> ignoreFiles = new List<string>()
        {
            "desktopsorter.exe",
            "desktop.ini"
        };
    
        public static void Main(string[] args)
        {
            if(args.Length >= 1)
            {
                // Extensions to ignore
                // were provided by the user
                if (args.Length >= 2)
                {
                    string ignoreExt = args[1];
                    // Split by the seperator "," and
                    // store each extension to a list
                    List<string> ignore = new List<string>(ignoreExt.Split(","));
                    Sorter.ignoreExtensions = ignore;
                }
                switch(args[0].ToLower())
                {
                    case "compress":
                        {
                            List<string> files = Sorter.compressFiles();
                            Console.WriteLine("Compressed " + files.Count + " files");
                            break;
                        }
                    case "decompress":
                        {
                            List<string> files = Sorter.decompressFiles();
                            Console.WriteLine("Decompressed " + files.Count + " files");
                            break;
                        }
                }
            }
        }

        public static List<string> decompressFiles()
        {
            #region Public Desktop Decompression Logic
            bool publicAccessError = false;
            List<string> p_filesDecompressed = new List<string>() { };
            try
            {
                string[] p_directories = Directory.GetDirectories(Sorter.desktopPath + "/DesktopSorter/_PublicDesktop");
                // Loop through each directory inside of 
                // our DesktopSorter/_PublicDesktop Folder
                foreach (var dir in p_directories)
                {
                    string[] files = Directory.GetFiles(dir + "/");
                    // Loop through each file in
                    // the current indexed directory
                    foreach (var f in files)
                    {
                        if (ignoreFiles.Contains(Path.GetFileName(f).ToLower()))
                            continue;

                        // This try attempt will fail if the user
                        // isn't running CMD as admin and then calling
                        // this program via the terminal. If they
                        // aren't running CMD as admin, we can not
                        // move Files 'back' to User/Public/Desktop <- protected
                        // but can move them 'from' that location with
                        // no problem, weirdly enough..
                        try
                        {
                            File.Move(f, Sorter.desktopPublicPath + "/" + Path.GetFileName(f));
                            p_filesDecompressed.Add(f);
                        }
                        catch
                        {
                            Console.WriteLine("############################################################################################\\n");
                            Console.WriteLine("You should run CMD as admin, as there are some files\nthat are in the Public Desktop location, which requires admin rights to move it back.\n");
                            Console.WriteLine("The files have been moved to a Folder on your Desktop named,\n\"_PublicDesktop\", since they are essentially stuck in limbo.\n");
                            Console.WriteLine("############################################################################################\\n");
                            publicAccessError = true;
                            break;
                        }
                        
                    }
                    if (publicAccessError)
                        break;
                }
            }
            catch
            {
                Console.WriteLine("No such directory for _PublicDesktop, ignoring execution logic.");
            }
            #endregion

            #region User Desktop Decompression Logic
            List<string> filesDecompressed = new List<string>() { };
            try
            {
                string[] directories = Directory.GetDirectories(Sorter.desktopPath + "/DesktopSorter/");
                // Loop through each directory inside of 
                // our DesktopSorter/_PublicDesktop Folder
                foreach (var dir in directories)
                {
                    string[] files = Directory.GetFiles(dir + "/");
                    // Loop through each file in
                    // the current indexed directory
                    foreach (var f in files)
                    {
                        if (Path.GetFileName(f).Contains("DesktopSorter"))
                            continue;
                        File.Move(f, Sorter.desktopPath + "/" + Path.GetFileName(f));
                        filesDecompressed.Add(f);
                    }
                }
                // If user isn't running CMD as admin
                // then we'll move files back to the 
                // normal desktop, in a folder named:
                // _PublicDesktop. These were files
                // stored on the users Public Desktop 
                // Directory, which requires Admin Access
                if (publicAccessError)
                    Directory.Move(Sorter.desktopPath + "/DesktopSorter/_PublicDesktop/", Sorter.desktopPath + "/_PublicDesktop/");
                Directory.Delete(Sorter.desktopPath + "/DesktopSorter/", true);
                filesDecompressed.AddRange(p_filesDecompressed);
            }
            catch
            {
                Console.WriteLine("No such directory for DesktopSorter, ignoring execution logic.");
            }
            #endregion

            filesDecompressed.AddRange(p_filesDecompressed);
            return filesDecompressed;
        }

        public static List<string> compressFiles()
        {
            Directory.CreateDirectory(Sorter.desktopPath + "/DesktopSorter");
            Directory.CreateDirectory(Sorter.desktopPath + "/DesktopSorter/_PublicDesktop");
            string[] files = Directory.GetFiles(Sorter.desktopPath);
            List<string> folders = new List<string>();

            #region User Desktop Compression Logic
            // Loop through all files on the Desktop
            // And append their extension to a list 
            // (if not on the list already)
            foreach (var f in files)
            {
                if (Sorter.ignoreFiles.Contains(Path.GetFileName(f).ToLower()) || Sorter.ignoreExtensions.Contains(Path.GetExtension(f).ToLower()))
                    continue;
                string ext = Path.GetExtension(f).Replace(".", "").Trim();
                if (!folders.Contains(ext))
                    folders.Add(ext);
            }
            // Create each extension directory 
            // inside of our DesktopSorter folder
            foreach(var f in folders)
            {
                Directory.CreateDirectory(Sorter.desktopPath + "/DesktopSorter/" + f);
            }
            // Loop through our files once more
            // then on our current indexed file
            // Loop through our created extensions to
            // check to see if the extension matches
            // with an extension directory, and move it there
            foreach(var f in files)
            {
                if (Sorter.ignoreFiles.Contains(Path.GetFileName(f).ToLower()) || Sorter.ignoreExtensions.Contains(Path.GetExtension(f).ToLower()))
                    continue;
                foreach (var _f in folders)
                {
                    if(Path.GetExtension(f).Replace(".", "").Trim() == _f)
                    {
                        File.Move(f, Sorter.desktopPath + "/DesktopSorter/" + _f + "/" + Path.GetFileName(f));
                        break;
                    }
                }
            }
            #endregion

            #region Public Desktop Compression Logic
            string[] files2 = Directory.GetFiles(Sorter.desktopPublicPath);
            // Loop through all of our files
            // in the Public Desktop Directory,
            // create directories and move
            // the file accordingly
            foreach(var f in files2)
            {
                if (Sorter.ignoreFiles.Contains(Path.GetFileName(f).ToLower()) || Sorter.ignoreExtensions.Contains(Path.GetExtension(f).ToLower()))
                    continue;
                string file_name = Path.GetFileName(f);
                string file_extension = Path.GetExtension(f).Replace(".", "").Trim();
                Directory.CreateDirectory(Sorter.desktopPath + "/DesktopSorter/_PublicDesktop/" + file_extension);
                File.Move(f, Sorter.desktopPath + "/DesktopSorter/_PublicDesktop/" + file_extension + "/" + file_name);
            }
            #endregion

            List<string> files_return = new List<string>(files);
            files_return.AddRange(files2);
            return files_return;
        }
    }
}
