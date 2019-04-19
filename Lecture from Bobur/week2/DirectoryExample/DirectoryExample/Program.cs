using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryExample
{
    class Program
    {

        static void f1()
        {
            DirectoryInfo dir = new DirectoryInfo(@"c:\test");

            FileInfo[] files = dir.GetFiles();

            foreach(FileInfo f in files)
            {
                Console.WriteLine(f.Name);
            }
            
            Console.ReadKey();
        }


        static void f2()
        {
            DirectoryInfo dir = new DirectoryInfo(@"c:\test");

            DirectoryInfo[] dirs = dir.GetDirectories();

            foreach(DirectoryInfo d in dirs)
            {
                Console.WriteLine(d.Name);
            }

            Console.ReadKey();
        }

        static void f3(string path, int depth)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            DirectoryInfo[] dirs = dir.GetDirectories();

            foreach(FileInfo f in files)
            {
                for (int i = 0; i < depth; i++) Console.Write(" ");
                Console.WriteLine(f.Name);
            }

            foreach(DirectoryInfo d in dirs)
            {
                for (int i = 0; i < depth; i++) Console.Write(" ");
                Console.WriteLine(d.Name);
                f3(d.FullName, depth + 5);
            }

        }
        static void Main(string[] args)
        {
            f3(@"c:\test", 0);

            Console.ReadKey();
        }
    }
}
