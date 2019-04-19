using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void showInfo(DirectoryInfo dir, int cursor)
        {
            Console.Clear();
            FileSystemInfo[] infos = dir.GetFileSystemInfos();
            for(int i = 0; i < infos.Length; i++)
            {
                /*
                if(i == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                } else {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                */
                Console.BackgroundColor = (i == cursor) ? ConsoleColor.Blue : ConsoleColor.Black;
                /*
                if (infos[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                } else {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                */
                Console.ForegroundColor = (infos[i].GetType() == typeof(DirectoryInfo)) ? ConsoleColor.Yellow : ConsoleColor.Magenta;

                Console.WriteLine(infos[i].Name);
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int cursor = 0;
            DirectoryInfo dir = new DirectoryInfo(@"c:\test");

            while (true)
            {
                showInfo(dir, cursor);
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursor > 0) cursor--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursor < dir.GetFileSystemInfos().Length - 1) cursor++;
                        break;
                    case ConsoleKey.Enter:
                        FileSystemInfo fs = dir.GetFileSystemInfos()[cursor];
                        if (fs.GetType() == typeof(DirectoryInfo))
                        {
                            dir = new DirectoryInfo(fs.FullName);
                        }
                        else
                        {
                            Process.Start(fs.FullName);
                        }
                        break;
                    case ConsoleKey.Escape:
                        dir = dir.Parent;
                        break;
                }

            }
        }

    }
}
