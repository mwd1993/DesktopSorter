using System;
using System.Collections.Generic;
using System.IO;

namespace DesktopSorter
{
    class Sorter
    {
        public static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static void Main(string[] args)
        {
            if(args.Length >= 1)
            {
                switch(args[0].ToLower())
                {
                    case "compress":
                        Sorter.compressFiles();
                        break;
                    case "decompress":
                        Sorter.decompressFiles();
                        break;
                }
            }
        }

        public static List<string> decompressFiles()
        {
            string[] directories = Directory.GetDirectories(Sorter.desktopPath + "/DesktopSorter/");
            List<string> filesDecompressed = new List<string>(){ };
            foreach(var dir in directories)
            {
                string[] files = Directory.GetFiles(dir + "/");
                foreach(var f in files)
                {
                    File.Move(f, Sorter.desktopPath + "/" + Path.GetFileName(f));
                    filesDecompressed.Add(f);
                }
            }
            Directory.Delete(Sorter.desktopPath + "/DesktopSorter/",true);
            return filesDecompressed;
        }

        public static List<string> compressFiles()
        {
            Directory.CreateDirectory(Sorter.desktopPath + "/DesktopSorter");
            string[] files = Directory.GetFiles(Sorter.desktopPath);
            List<string> folders = new List<string>();
            foreach(var f in files)
            {
                string ext = Path.GetExtension(f).Replace(".", "").Trim();
                if (!folders.Contains(ext))
                    folders.Add(ext);
            }
            foreach(var f in folders)
            {
                Directory.CreateDirectory(Sorter.desktopPath + "/DesktopSorter/" + f);
            }
            foreach(var f in files)
            {
                foreach(var _f in folders)
                {
                    if(Path.GetExtension(f).Replace(".", "").Trim() == _f)
                    {
                        File.Move(f, Sorter.desktopPath + "/DesktopSorter/" + _f + "/" + Path.GetFileName(f));
                        break;
                    }
                }
            }
            return new List<string>(files);
        }
    }
}
