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
        public static int n;
        static void Main(string[] args)
        {
            Thread th1 = new Thread(fact);
            Thread th2 = new Thread(sumi);
            //n = Convert.ToInt32(Console.ReadLine());
            //th1.Start();
            //th2.Start();
            Thread th3 = new Thread(red);
            Thread th4 = new Thread(orange);
            Thread th5 = new Thread(green);
            //th3.Start();
            //th4.Start();
            //th5.Start();
            Thread th7 = new Thread(shoot);
            th7.Start();
            Console.ReadKey();
        }

        public static void shoot()
        {
            ConsoleKeyInfo k;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("######");
                Console.WriteLine("#.#");
                Console.WriteLine("##");
                Console.WriteLine("#");
                Thread.Sleep(500);
            while (true)
            {
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.Spacebar)
                {
                    Thread th6 = new Thread(bullet);
                    th6.Start();
                }
            }
        }

        public static void bullet()
        {
            for (int i = 6; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('$');
                Thread.Sleep(500);
                Console.SetCursorPosition(i, 0);
                Console.Write(' ');
            }
            Thread.CurrentThread.Abort();
        }

        public static void red()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0,1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("****");
                Console.WriteLine("****");
                Console.Write("****");
                Thread.Sleep(3000);
            }
        }

        public static void orange()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.SetCursorPosition(0, 4);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("****");
                Console.WriteLine("****");
                Console.Write("****");
                Thread.Sleep(2000);
            }
        }

        public static void green()
        {
            while (true)
            {
                Thread.Sleep(2000);
                Console.Clear();
                Console.SetCursorPosition(0, 7);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("****");
                Console.WriteLine("****");
                Console.Write("****");
                Thread.Sleep(1000);
            }
        }

        public static void fact()
        {
            int sum = 1;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Facrotial" + sum + " " + i);
                sum = sum * i;
            }
            Console.WriteLine("Factorial: " + sum);
        }
        public static void sumi()
        {
            int sum = 0;
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("Sumi");
                sum += i;
            }
            Console.WriteLine("Sum is: " + sum);
        }
    }
}
