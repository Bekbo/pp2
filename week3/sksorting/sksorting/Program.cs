using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sksorting
{
    class FarManager
    {
        public int cursor = 0;
        public int size;

        public FarManager()
        {
            cursor = 0;
        }

        public void Color(FileSystemInfo fs, int index)
        {
            if (index == cursor)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
        }

        public void Show(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fileSystemInfos = directory.GetFileSystemInfos();
            FileSystemInfo[] folders = directory.GetDirectories();
            FileSystemInfo[] files = directory.GetFiles();
            size = fileSystemInfos.Length;
            int index = 0;
            foreach (FileSystemInfo fs in folders)
            {
                Color(fs, index);
                Console.WriteLine(index + 1 + ". " + fs.Name + " " + cursor + " " + index);
                index++;
            }
            foreach (FileSystemInfo fs in files)
            {
                Color(fs, index);
                Console.WriteLine(index + 1 + ". " + fs.Name + " " + cursor + " " + index);
                index++;
            }
        }

        public void Start(string path)
        {
            Show(path);
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fileSystemInfos = directory.GetFileSystemInfos();
            FileSystemInfo[] folders = directory.GetDirectories();
            FileSystemInfo[] files = directory.GetFiles();
            ConsoleKeyInfo cnskey = Console.ReadKey();
            FileSystemInfo fs = null;
            size = fileSystemInfos.Length;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Show(path);
                cnskey = Console.ReadKey();
                if (cnskey.Key == ConsoleKey.Escape)
                {
                    cursor = 0;
                    directory = directory.Parent;
                    path = directory.FullName;
                }
                if (cnskey.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                    {
                        cursor = size - 1;
                    }
                }
                if (cnskey.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == size)
                    {
                        cursor = 0;
                    }
                }
                if (cnskey.Key == ConsoleKey.F2)
                {
                    fs = directory.GetDirectories()[cursor];
                    Console.WriteLine("New name for {0} :", fs.Name);
                    string name = Console.ReadLine();
                    fs = directory.GetDirectories()[cursor];
                    DirectoryInfo dir = new DirectoryInfo(directory.Parent + "");
                    Directory.Move(fs.FullName, Path.GetDirectoryName(fs.FullName) + "/" + name);
                }
                if (cnskey.Key == ConsoleKey.F3) {
                    fs = directory.GetFiles()[cursor];
                    Console.WriteLine("New name for {0} :", fs.Name);
                    string name = Console.ReadLine();
                    string ext = Path.GetExtension(fs.FullName);
                    File.Copy(fs.FullName, Path.GetDirectoryName(fs.FullName) + "/" + name + ext);
                    File.Delete(fs.FullName);
                    cursor = 0;
                }
                if (cnskey.Key == ConsoleKey.Delete)
                {
                    fs = directory.GetFileSystemInfos()[cursor];
                    if (fs.GetType() == typeof(DirectoryInfo))
                        Directory.Delete(fs.FullName, true);
                    else
                        File.Delete(fs.FullName);
                    cursor = 0;
                }
                if (cnskey.Key == ConsoleKey.Enter)
                {
                    fs = directory.GetDirectories()[cursor];
                    cursor = 0;
                    directory = new DirectoryInfo(fs.FullName);
                    path = fs.FullName;
                }
                if (cnskey.Key == ConsoleKey.O) {
                    fs = directory.GetFiles()[cursor];
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    using (StreamReader reader = File.OpenText(fs.FullName))
                    {
                        string line = null;
                        do
                        {
                            line = reader.ReadLine();
                            Console.WriteLine(line);
                        } while (line != null);
                    }
                    Console.ReadKey();
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FarManager farmanager = new FarManager();
            farmanager.Start("C:/Users/User/Desktop/Univer/pp2");
        }
    }
}
