using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Example
{
    class Program
    {
        public static void Ex1()
        {
            FileInfo file = new FileInfo("/Users/askar/Desktop/ud1.jpg");
            Console.WriteLine(file.Name);
            Console.WriteLine(file.FullName);
            Console.WriteLine(file.Directory);
        }

        public static void Ex2()
        {
            DirectoryInfo directory = new DirectoryInfo("/Users/askar/Desktop/");
            Console.WriteLine(directory.Name);
            Console.WriteLine(directory.FullName);
            Console.WriteLine(directory.Parent);
        }

        public static void Ex3()
        {
            DirectoryInfo directory = new DirectoryInfo("/Users/askar/Desktop");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                Console.WriteLine(file.Name);
            }
        }

        public static void Ex4()
        {
            DirectoryInfo directory = new DirectoryInfo("/Users/askar/Desktop");
            DirectoryInfo[] directories = directory.GetDirectories();
            foreach (DirectoryInfo d in directories)
            {
                Console.WriteLine(d.Name);
            }
        }

        public static void PrintSpaces(int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write("     ");
        }

        public static void Ex5(DirectoryInfo dir, int level)
        {
            foreach (FileInfo f in dir.GetFiles())
            {
                PrintSpaces(level);
                Console.WriteLine(f.Name);
            }
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                PrintSpaces(level);
                Console.WriteLine(d.Name);
                Ex5(d, level + 1);
            }
        }

        public static void Ex6()
        {
            DirectoryInfo directory = new DirectoryInfo("/Users/askar/projects/PP2");
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            foreach (FileSystemInfo f in fs)
            {
                if (f.GetType() == typeof(FileInfo))
                {
                    Console.WriteLine("File: " + f.Name);
                }
                else
                {
                    Console.WriteLine("Directory: " + f.Name);
                }

            }
        }

        public static void Ex7()
        {
            StreamReader sr = new StreamReader("input.txt");
            String s = sr.ReadToEnd();
            String[] arr = s.Split();
            int sum = 0;
            foreach (String a in arr)
            {
                sum += int.Parse(a);
            }
            sr.Close();

            StreamWriter sw = new StreamWriter("output.txt");
            sw.WriteLine(sum);
            sw.Close();
        }

        public static void Ex8()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            ConsoleKeyInfo button = Console.ReadKey();
            while (button.Key != ConsoleKey.Escape)
            {
                if (button.Key == ConsoleKey.UpArrow)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("UpArrow");
                }
                if (button.Key == ConsoleKey.DownArrow)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("DownArrow");
                }
                button = Console.ReadKey();
            }

        }

        static void Main(string[] args)
        {
            //DirectoryInfo dir = new DirectoryInfo("/Users/askar/projects/PP2");
            //Ex5(dir, 0);
            Ex8();
        }
    }
}