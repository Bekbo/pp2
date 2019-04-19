using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySnake.Model;
using System.Threading;

namespace MySnake
{
    class Program
    {
        public static int d = 0;

        static void MoveSnake()
        {
            // magic code :)
        }

        static void Main(string[] args)
        {
            Game.Init();

            Thread t = new Thread(MoveSnake);
            t.Start();

            while (!Game.GameOver)
            {
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    // change variable "d" for four direction
                    case ConsoleKey.Escape:
                        Game.GameOver = true;
                        break;
                }
            }

        }
    }
}
