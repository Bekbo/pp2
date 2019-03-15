using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace MySnake
{
    public class Game
    {
        List<Objects> objects;
        public bool alive;
        public Snake snake;
        string name;
        public Food food;
        public Wall wall;
        public int timer = 1500;
        public int score = 1;
        public int lvlindex = 1;

        public Game()
        {
            objects = new List<Objects>();
            snake = new Snake(20, 10, '*');
            food = new Food(2, 2, 'O');
            wall = new Wall('#');
            wall.LoadLevel(lvlindex);
            alive = true;
            objects.Add(snake);
            objects.Add(food);
            objects.Add(wall);
        }
        public void Dead()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("SNAKE GAME BY - - - Author : BAKE");
            Console.WriteLine();
            Console.WriteLine("Level - " + lvlindex + " ~~ " + "GAME OVER, {0}!!! Your score is : {1}", name, score);
            Console.WriteLine();
            Console.WriteLine("Press R to Reset Game or ESC to quit game");
            ConsoleKeyInfo console = Console.ReadKey();
        }

        public void Start()
        {
            Console.Clear();
            Console.Write("Please, Enter Your Name : ");
            name = Console.ReadLine();
            ConsoleKeyInfo key = Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Green;
            while (alive || key.Key != ConsoleKey.Q)
            {
                Thread thread = new Thread(preDRAW);
                thread.Start();
                if (snake.IsColl(wall) || snake.IsCollitself(snake))
                {
                    alive = false;
                    break;
                }
                if (snake.IsColl(food))
                {
                    snake.objects.Add(new Point(0, 0));
                    score += 1;
                    while (food.IsColl(snake) || food.IsColl(wall))
                        food.Generate();
                    if (score % 3 ==0)
                    {
                        wall.NextLevel();
                    }
                }
                if (alive && key.Key == ConsoleKey.Escape)
                {
                    Save(food, snake, wall);
                }
                Console.Write("Score : " + score);
                key = Console.ReadKey();
                snake.ChangeDirection(key);
            }
            Dead();
            Game game = new Game();
            if (key.Key == ConsoleKey.R)
                game.Start();
            if (key.Key == ConsoleKey.Escape)
                Environment.Exit(0);
        }
        public void preDRAW()
        {
            while (alive)
            {
                Console.Clear();
                snake.Move();
                Draw();
                if (snake.IsColl(wall) || snake.IsCollitself(snake))
                {
                    alive = false;
                    break;
                }
                if (snake.IsColl(food))
                {
                    snake.objects.Add(new Point(0, 0));
                    score += 1;
                    while (food.IsColl(snake) || food.IsColl(wall))
                        food.Generate();
                    if (score % 3 == 0)
                    {
                        wall.NextLevel();
                    }
                }
                if (alive)
                {
                    Save(food, snake, wall);
                }
                Console.Write("Score : " + score);
                Thread.Sleep(timer);
            }
            Dead();
        }
        public void Draw()
        {
            Console.Clear();
            foreach (Objects g in objects)
                g.Draw();
        }
        public void Save(Objects food, Objects snake, Objects wall)
        {

        }
    }
}
