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
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game game = new Game();
            Console.WriteLine("Press L to Load Saved game or N to Start New Game");
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            if (consoleKey.Key == ConsoleKey.L)
            {
                FileStream fs = new FileStream("savednake.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer xs = new XmlSerializer(typeof(Snake));
                Snake snake = xs.Deserialize(fs) as Snake;
                fs.Close();

                FileStream fs3 = new FileStream("savedwall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer xs3 = new XmlSerializer(typeof(Wall));
                Wall wall = xs3.Deserialize(fs3) as Wall;
                fs3.Close();

                FileStream fs2 = new FileStream("savedfood.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer xs2 = new XmlSerializer(typeof(Food));
                Food food = xs2.Deserialize(fs2) as Food;
                fs2.Close();

                Game newgame = new Game();
                newgame.snake = snake;
                newgame.wall = wall;
                newgame.food = food;
                newgame.Start();
            }
            else if (consoleKey.Key == ConsoleKey.N)
            {
                game.Start();
            }
        }
    }
}
