using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        public static int x = 10,y=10;
        static void Main(string[] args)
        {
            Console.SetCursorPosition(x,y);
            Console.Write('*');
            Thread t1 = new Thread(go);
            t1.Start();
        }

        public static void go()
        {
            string dir = "RU";
            while (true)
            {
                if (dir == "RU")
                {
                    while (dir == "RU")
                    {
                        if (x + 1 == Console.WindowWidth-1)
                        {
                            dir = "LU";break;
                        }
                        if (y - 1 == -1)
                        {
                            dir = "RD";break;
                        }
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        x++; y--;
                        Console.SetCursorPosition(x, y);
                        Console.Write('*');
                        Thread.Sleep(50);
                    }
                }
                if (dir == "RD")
                {
                    while (dir == "RD")
                    {
                        if (x + 1 == Console.WindowWidth)
                        {
                            dir = "LD";break;
                        }
                        if (y + 1 == Console.WindowHeight)
                        {
                            dir = "RU";break;
                        }
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        x++; y++;
                        Console.SetCursorPosition(x, y);
                        Console.Write('*');
                        Thread.Sleep(50);
                    }
                }
                if (dir == "LD")
                {
                    while (dir == "LD")
                    {
                        if (x == 0)
                        {
                            dir = "RD"; break;
                        }
                        if (y + 1 == Console.WindowHeight)
                        {
                            dir = "LU"; break;
                        }
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        x--; y++;
                        Console.SetCursorPosition(x, y);
                        Console.Write('*');
                        Thread.Sleep(50);
                    }
                }
                if (dir == "LU")
                {
                    while (dir == "LU")
                    {
                        if (x==0)
                        {
                            dir = "RU"; break;
                        }
                        if (y==0)
                        {
                            dir = "LD"; break;
                        }
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        x--; y--;
                        Console.SetCursorPosition(x, y);
                        Console.Write('*');
                        Thread.Sleep(50);
                    }
                }

            }
        }
    }
}
