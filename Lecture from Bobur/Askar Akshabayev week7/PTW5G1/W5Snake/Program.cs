using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Init();

            while (!Game.GameOver)
            {
                Game.Draw();

                ConsoleKeyInfo pressed = Console.ReadKey();
                if (pressed.Key == ConsoleKey.UpArrow)
                    Game.snake.Move(0, -1);
                if (pressed.Key == ConsoleKey.DownArrow)
                    Game.snake.Move(0, 1);
                if (pressed.Key == ConsoleKey.LeftArrow)
                    Game.snake.Move(-1, 0);
                if (pressed.Key == ConsoleKey.RightArrow)
                    Game.snake.Move(1, 0);
                if (pressed.Key == ConsoleKey.F2)
                    Game.Save();
                if (pressed.Key == ConsoleKey.F3)
                    Game.Resume();
                if (pressed.Key == ConsoleKey.Escape)
                    Game.GameOver = true;
            }
        }
    }
}
