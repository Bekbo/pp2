using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace NewSnake
{
    public class Game : Program
    {
        public bool IsAlive;
        public Snake snake;
        public Wall wall;
        public Food food;
        public int timer = 300;
        public Menu menu = new Menu();
        public string name;

        public Game()
        {
            IsAlive = true;
            name = "";
            snake = new Snake(5, 5, 'o', ConsoleColor.White);
            food = new Food(2, 2, '@', ConsoleColor.DarkRed);
            wall = new Wall('#', ConsoleColor.Green);
            while (food.IsColl(snake) || food.IsColl(wall))
                food.Generate();
            wall.LoadLevel(1);
        }

        public Game(Snake snake, Wall wall, Food food, String name)
        {
            IsAlive = true;
            this.name = name;
            this.snake = snake;
            this.food = food;
            this.wall = wall;
            while (food.IsColl(snake) && food.IsColl(wall))
                food.Generate();
            wall.LoadLevel(1);
        }
        public void reg()
        {
            Console.SetCursorPosition(30, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Please, write your name : ");
            name = Console.ReadLine();
            Console.Clear();
            Start();
        }

        bool save = false;
        public void Start()
        {
            IsAlive = true;
            Thread thread = new Thread(Cont);
            thread.Start();
            while (IsAlive)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.Escape && IsAlive)
                {
                    Game savegame = new Game(snake, wall, food, name);
                    savegame.Save(savegame);
                    Console.Clear();
                    save = true;
                    Bye();
                }
                else
                    snake.Goo(key);
            }
            if (IsAlive == false)
                Dead();
        }

        public void Save(Game game)
        {
            if (File.Exists("loader.xml"))
                File.Delete("loader.xml");
            FileStream fs = new FileStream("loader.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Game));
            xs.Serialize(fs, game);
            fs.Close();
        }

        public void Bye()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("SNAKE GAME BY - - - Author : BAKE");
            Console.WriteLine();
            Console.WriteLine("The Game is Saved");
        }

        public void Dead()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("SNAKE GAME BY - - - Author : BAKE");
            Console.WriteLine();
            Console.WriteLine("GAME OVER, {0}!!! Your score is : {1}", name, snake.body.Count);
            Console.WriteLine();
            Console.WriteLine("Game Over ! Press R to Reset Game or ESC to quit game");
            ConsoleKeyInfo keyy = Console.ReadKey();
            if (keyy.Key == ConsoleKey.R)
            {
                System.Diagnostics.Process.Start(@"C:\Users\User\Desktop\Univer\pp2\week6\NewSnake\NewSnake\bin\Debug\NewSnake.exe");
                Environment.Exit(0);
            }
        }

        public void Cont()
        {
            while (IsAlive)
            {
                if (save)
                {
                    Thread.Sleep(1000);
                    break;
                }
                snake.Clear();
                snake.Move();
                if (snake.IsColl(food))
                {
                    while (food.IsColl(snake) || food.IsColl(wall))
                        food.Generate();
                    snake.body.Add(new Point(0, 0));
                    if (snake.body.Count % 5 == 0)
                    {
                        wall.Clear();
                        wall.NextLevel();
                    }
                }
                if (snake.IsCollitself(snake) || snake.IsColl(wall))
                {
                    IsAlive = false;
                    break;
                }
                snake.Draw();
                wall.Draw();
                food.Draw();
                Console.SetCursorPosition(30, 23);
                Console.WriteLine(name + " Score : " + snake.body.Count);
                Thread.Sleep(timer);
            }
            Environment.Exit(0);
        }

    }
}
