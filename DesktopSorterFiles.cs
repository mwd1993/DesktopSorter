using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesktopSorter
{
    /// <summary>
    /// Class to handle the moving of files
    /// from and to the desktop directory
    /// </summary>
    class DesktopSorterFiles
    {
        /// <summary>
        /// Attempts to move the files from
        /// the desktopSorter directory
        /// </summary>
        /// <returns>List of files decompressed</returns>
        public static List<string> decompressFiles()
        {
            #region Public Desktop Decompression Logic
            bool publicAccessError = false;
            List<string> p_filesDecompressed = new List<string>() { };
            try
            {
                string[] p_directories = Directory.GetDirectories(DesktopSorterVariables.desktopPath + "/DesktopSorter/_PublicDesktop");
                // Loop through each directory inside of 
                // our DesktopSorter/_PublicDesktop Folder
                foreach (var dir in p_directories)
                {
                    string[] files = Directory.GetFiles(dir + "/");
                    // Loop through each file in
                    // the current indexed directory
                    foreach (var f in files)
                    {
                        if (DesktopSorterVariables.ignoreFiles.Contains(Path.GetFileName(f).ToLower()))
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
                            File.Move(f, DesktopSorterVariables.desktopPublicPath + "/" + Path.GetFileName(f));
                            p_filesDecompressed.Add(f);
                        }
                        catch
                        {
                            foreach(var errorline in DesktopSorterVariables.errorAccessDenied)
                                Console.WriteLine(errorline);
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
                string[] directories = Directory.GetDirectories(DesktopSorterVariables.desktopPath + "/DesktopSorter/");
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
                        File.Move(f, DesktopSorterVariables.desktopPath + "/" + Path.GetFileName(f));
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
                    Directory.Move(DesktopSorterVariables.desktopPath + "/DesktopSorter/_PublicDesktop/", DesktopSorterVariables.desktopPath + "/_PublicDesktop/");
                Directory.Delete(DesktopSorterVariables.desktopPath + "/DesktopSorter/", true);
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

        /// <summary>
        /// Attempts to move the files to
        /// the desktopSorter directory
        /// </summary>
        /// <returns>List of files compressed</returns>
        public static List<string> compressFiles()
        {
            Directory.CreateDirectory(DesktopSorterVariables.desktopPath + "/DesktopSorter");
            Directory.CreateDirectory(DesktopSorterVariables.desktopPath + "/DesktopSorter/_PublicDesktop");
            string[] files = Directory.GetFiles(DesktopSorterVariables.desktopPath);
            List<string> folders = new List<string>();

            #region User Desktop Compression Logic
            // Loop through all files on the Desktop
            // And append their extension to a list 
            // (if not on the list already)
            foreach (var f in files)
            {
                if (DesktopSorterVariables.ignoreFiles.Contains(Path.GetFileName(f).ToLower()) || DesktopSorterVariables.ignoreExtensions.Contains(Path.GetExtension(f).ToLower()))
                    continue;
                string ext = Path.GetExtension(f).Replace(".", "").Trim();
                if (!folders.Contains(ext))
                    folders.Add(ext);
            }
            // Create each extension directory 
            // inside of our DesktopSorter folder
            foreach (var f in folders)
            {
                Directory.CreateDirectory(DesktopSorterVariables.desktopPath + "/DesktopSorter/" + f);
            }
            // Loop through our files once more
            // then on our current indexed file
            // Loop through our created extensions to
            // check to see if the extension matches
            // with an extension directory, and move it there
            foreach (var f in files)
            {
                if (DesktopSorterVariables.ignoreFiles.Contains(Path.GetFileName(f).ToLower()) || DesktopSorterVariables.ignoreExtensions.Contains(Path.GetExtension(f).ToLower()))
                    continue;
                foreach (var _f in folders)
                {
                    if (Path.GetExtension(f).Replace(".", "").Trim() == _f)
                    {
                        try
                        {
                            File.Move(f, DesktopSorterVariables.desktopPath + "/DesktopSorter/" + _f + "/" + Path.GetFileName(f));
                        }
                        catch
                        {
                            // file in use by the user, so we can't move it
                        }
                        break;
                    }
                }
            }
            #endregion

            #region Public Desktop Compression Logic
            string[] files2 = Directory.GetFiles(DesktopSorterVariables.desktopPublicPath);
            // Loop through all of our files
            // in the Public Desktop Directory,
            // create directories and move
            // the file accordingly
            foreach (var f in files2)
            {
                if (DesktopSorterVariables.ignoreFiles.Contains(Path.GetFileName(f).ToLower()) || DesktopSorterVariables.ignoreExtensions.Contains(Path.GetExtension(f).ToLower()))
                    continue;
                string file_name = Path.GetFileName(f);
                string file_extension = Path.GetExtension(f).Replace(".", "").Trim();
                Directory.CreateDirectory(DesktopSorterVariables.desktopPath + "/DesktopSorter/_PublicDesktop/" + file_extension);
                try
                {
                    File.Move(f, DesktopSorterVariables.desktopPath + "/DesktopSorter/_PublicDesktop/" + file_extension + "/" + file_name);
                }
                catch
                {
                    // file in use by the user (in _PublicDesktop), so we cannot move it
                }
            }
            #endregion

            #region Public Desktop Access denied folder check
            if (Directory.Exists(DesktopSorterVariables.desktopPath + "/_PublicDesktop/"))
            {
                // Make sure the _PublicDesktop directory is valid
                if (Directory.Exists(DesktopSorterVariables.desktopPath + "/DesktopSorter/_PublicDesktop/"))
                {
                    string[] pd_folders = Directory.GetDirectories(DesktopSorterVariables.desktopPath + "/_PublicDesktop/");
                    bool pd_fail = false;
                    foreach (var pd_f in pd_folders)
                    {
                        try
                        {
                            Directory.Move(pd_f, DesktopSorterVariables.desktopPath + "/DesktopSorter/_PublicDesktop/" + Path.GetFileName(pd_f));
                        }
                        catch
                        {
                            pd_fail = true;
                            break;
                        }
                    }
                    if (!pd_fail && pd_folders.Length > 0)
                        Directory.Delete(DesktopSorterVariables.desktopPath + "/_PublicDesktop");
                }
            }
            #endregion

            List<string> files_return = new List<string>(files);
            files_return.AddRange(files2);
            return files_return;
        }
    }
}