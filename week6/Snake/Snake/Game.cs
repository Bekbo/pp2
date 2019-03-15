using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        List<GameObject> gameObjects;
        public Snake snake;
        public Food food;
        public Wall wall;
        public bool IsAlive;
        public int points=0;

        public Game()
        {
            gameObjects = new List<GameObject>();
            snake = new Snake(20, 10, '*', ConsoleColor.White);
            food = new Food(3, 3, 'o', ConsoleColor.Cyan);
            wall = new Wall('#', ConsoleColor.Green);

            IsAlive = true;
            gameObjects.Add(snake);
            gameObjects.Add(food);
            gameObjects.Add(wall);
        }

        public void Start()
        {
            ConsoleKeyInfo cnskey = Console.ReadKey();
            while (IsAlive && cnskey.Key != ConsoleKey.Escape)
            {
                Draw();
                cnskey = Console.ReadKey();
                if (snake.IsColl(food))
                {
                    snake.body.Add(new Point(0, 0));
                    points += 50;
                    while (food.IsColl(snake) || food.IsColl(wall))
                        food.Generate();
                }
                if (snake.body.Count % 3 == 0)
                    wall.NextLevel();
                if (snake.IsColl(wall))
                {
                    IsAlive = false;
                }
                Console.WriteLine(snake.body[0].x);
                snake.Move(cnskey);
            }
            //DEAD or END
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("GAME OVER!!! Your score is: {0} ", points);
            Console.ReadKey();
        }

        public void Draw()
        {
            Console.Clear();
            wall.LoadLevel();
            foreach(GameObject g in gameObjects)
            {
                g.Draw();
            }
        }
    }
}
