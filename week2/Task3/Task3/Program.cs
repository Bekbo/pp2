using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        public static void p(int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write("   "); //invervals between folders
        }
        public static void f(DirectoryInfo dir, int level)
        {
            foreach (DirectoryInfo d in dir.GetDirectories()) // for folders in the directory
            {
                p(level); // put interval
                Console.WriteLine(d.Name); // write folder name
                f(d, level + 1); // recursion for the folder in initial folder, increment the interval
            }
            foreach (FileInfo f in dir.GetFiles())
            {
                p(level); // put interval
                Console.WriteLine(f.Name); // write file name
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("/Users/User/Desktop/Univer/pp2"); // initial path
            f(dir,0); // start function with main path and 0 integer (level)
            Console.ReadKey();
        }
    }
}