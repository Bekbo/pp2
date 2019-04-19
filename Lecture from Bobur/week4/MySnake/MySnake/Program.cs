using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    class Program
    {
        static bool GameOver = false;
        static Model.Snake snake = new Model.Snake();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            while (!GameOver)
            {
                snake.draw();
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        GameOver = true;
                        break;
                }
            }


        }
    }
}
