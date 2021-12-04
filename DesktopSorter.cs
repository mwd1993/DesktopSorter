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
            string[] directories = Directory.GetDirectories(Sorter.desktopPath + "/DesktopSorter/");
            List<string> filesDecompressed = new List<string>(){ };
            foreach(var dir in directories)
            {
                string[] files = Directory.GetFiles(dir + "/");
                foreach(var f in files)
                {
                    if (Path.GetFileName(f).Contains("DesktopSorter"))
                        continue;
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
                if (Path.GetFileName(f).Contains("DesktopSorter"))
                    continue;
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
