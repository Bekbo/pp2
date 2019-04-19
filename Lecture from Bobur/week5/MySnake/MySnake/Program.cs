using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySnake.Model;

namespace MySnake
{
    class Program
    {

        static void Main(string[] args)
        {
            Game.Init();

            while (!Game.GameOver)
            {
                Game.Draw();

                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.snake.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        Game.snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.snake.Move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        Game.GameOver = true;
                        break;
                }
                // TODO: remove following expressions
                if (Game.snake.CanEat(Game.food))
                {
                    Game.food.SetRandomPosition();
                }
                if(Game.snake.body.Count == 4)
                {
                    Game.wall.LoadLevel(2);
                }
            }

        }
    }
}
