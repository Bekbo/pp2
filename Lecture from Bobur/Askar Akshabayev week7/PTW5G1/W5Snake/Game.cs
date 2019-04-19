using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5Snake
{
    class Game
    {
        public static bool GameOver = false;
        public static Snake snake = new Snake();
        public static Wall wall = new Wall();
        public static Food food = new Food();

        public static void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 40);
        }

        public static void Draw()
        {
            Console.Clear();
            snake.Draw();
            wall.Draw();
            food.Draw();
        }

        public static void Save()
        {
            // serialize all objects
        }

        public static void Resume()
        {
            // deserialize all objects
        }
    }
}
