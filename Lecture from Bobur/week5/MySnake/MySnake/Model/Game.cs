using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake.Model
{
    public class Game
    {
        public static bool GameOver = false;
        public static Snake snake;
        public static Food food;
        public static Wall wall;

        public static void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 35);

            List<Point> snake_body = new List<Point>();
            snake_body.Add(new Point(10, 10));
            snake_body.Add(new Point(9, 10));
            snake = new Snake(ConsoleColor.Yellow, 'o', snake_body);

            List<Point> food_body = new List<Point>();
            food_body.Add(new Point(0, 0));
            food = new Food(ConsoleColor.Green, '$', food_body);


            List<Point> wall_body = new List<Point>();
            wall = new Wall(ConsoleColor.Red, '#', wall_body);
        }

        public static void Draw()
        {
            Console.Clear();
            snake.Draw();
            food.Draw();
            wall.Draw();
        }



    }
}
