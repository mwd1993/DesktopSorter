using System;
using System.Collections.Generic;

namespace DesktopSorter
{
    public static class DesktopSorterVariables
    {
        public static string desktopName = "DesktopSorter";
        public static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string desktopPublicPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
        public static string desktopAccessDeniedPublicDesktopPath = DesktopSorterVariables.desktopPath + "/" + DesktopSorterVariables.desktopName + "/_PublicDesktop/";
        public static List<string> ignoreExtensions = new List<string>();
        public static string desktopFoldersCompressionName = "_DesktopSorterFolders";
        public static string[] foldersToBig = new string[]{ 
            "gb","tb",
            "pb","eb"
        };
        public static string[] fileSizeSuffixes = {
            "B", "KB", "MB",
            "GB", "TB", "PB",
            "EB"
        };
        public static List<string> ignoreFolders = new List<string>()
        {
            DesktopSorterVariables.desktopName,
            "DesktopSorter",
            "_PublicFolder"
        };
        public static List<string> ignoreFiles = new List<string>()
        {
            "desktopsorter.exe",
            "desktop.ini",
            "desktopSorterWF.exe"
        };
        public static List<string> errorAccessDenied = new List<string>()
        {
            "############################################################################################\\n",
            "You should run CMD as admin, as there are some files\nthat are in the Public Desktop location, which requires admin rights to move it back.\n",
            "The files have been moved to a Folder on your Desktop named,\n\"_PublicDesktop\", since they are essentially stuck in limbo.\n",
            "############################################################################################\\n"
        };
    }
}
