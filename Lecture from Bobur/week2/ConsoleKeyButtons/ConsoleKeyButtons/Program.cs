using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKeyButtons
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ConsoleKeyInfo btn = Console.ReadKey();

                if(btn.Key == ConsoleKey.UpArrow)
                {
                    Console.WriteLine("Up");
                } else if (btn.Key == ConsoleKey.LeftArrow)
                {
                    Console.WriteLine("left");
                } else if(btn.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                }

            }
        }
    }
}
