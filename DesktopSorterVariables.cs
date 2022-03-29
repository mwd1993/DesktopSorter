using System;
using System.Collections.Generic;

namespace DesktopSorter
{
    /// <summary>
    /// Class that contains all important
    /// DesktopSorter variables to be used
    /// </summary>
    public static class DesktopSorterVariables
    {
        public static string desktopName = "DesktopSorter";
        public static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string desktopPublicPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
        public static string desktopAccessDeniedPublicDesktopPath = DesktopSorterVariables.desktopPath + "/" + DesktopSorterVariables.desktopName + "/_PublicDesktop/";
        public static List<string> ignoreExtensions = new List<string>();
        public static string desktopFoldersCompressionName = "_DesktopSorterFolders";

        /// <summary>
        /// Folders to ignore in 
        /// our compression logic
        /// </summary>
        public static List<string> foldersToIgnore = new List<string>() { 
            "desktopsorter", 
            "_publicdesktop" 
        };

        /// <summary>
        /// Folders that the compression logic
        /// will ignore because they are too big
        /// </summary>
        public static string[] foldersTooBig = new string[]{ 
            "gb","tb",
            "pb","eb"
        };

        /// <summary>
        /// Suffixes for file sizes
        /// </summary>
        public static string[] fileSizeSuffixes = {
            "B", "KB", "MB",
            "GB", "TB", "PB",
            "EB"
        };

        /// <summary>
        /// Folders that the desktopSorter 
        /// compression/decompression logic will ignore
        /// </summary>
        public static List<string> ignoreFolders = new List<string>()
        {
            DesktopSorterVariables.desktopName,
            "DesktopSorter",
            "_PublicFolder"
        };

        /// <summary>
        /// Files that the desktopSorter
        /// compression/decompression logic will ignore
        /// </summary>
        public static List<string> ignoreFiles = new List<string>()
        {
            "desktopsorter.exe",
            "desktop.ini",
            "desktopsorterwf.exe"
        };

        /// <summary>
        /// Access denied error structured in
        /// list form to quickly loop and print it
        /// </summary>
        public static List<string> errorAccessDenied = new List<string>()
        {
            "############################################################################################\\n",
            "You should run CMD as admin, as there are some files\nthat are in the Public Desktop location, which requires admin rights to move it back.\n",
            "The files have been moved to a Folder on your Desktop named,\n\"_PublicDesktop\", since they are essentially stuck in limbo.\n",
            "############################################################################################\\n"
        };
    }
}
