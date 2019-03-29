using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace NewSnake
{
    public class Menu
    {
        public int cursor = 0;
        public string[] menu =
        {
            "Continue",
            "New Game",
            "Exit"
        };

        public Menu() { }

        public void ShowMenu()
        {
            Console.Clear();
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("W E L C O M E !");
            int x = 32, y = 12;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Green;
                if (cursor == i)
                    Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(menu[i] + " " + cursor + " " + i);
                Console.ForegroundColor = ConsoleColor.Green;
                y += 2;
            }
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                if (cursor == 0)
                {
                    Game contgame = LoadGame();
                    contgame.Start();
                }
                if (cursor == 1)
                {
                    Game newgame = new Game();
                    newgame.reg();
                }
                if (cursor == 2)
                {
                    Environment.Exit(0);
                }
            }
            if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            Movecursor(key);
            ShowMenu();
        }

        public Game LoadGame()
        {
            FileStream fs = new FileStream("loader.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Game));
            Game gameloader = xs.Deserialize(fs) as Game;
            fs.Close();
            return gameloader;
        }

        public void Movecursor(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.DownArrow)
            {
                cursor++;
                if (cursor > 2)
                    cursor = 0;
            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                cursor--;
                if (cursor < 0)
                    cursor = 2;
            }
        }
    }
}
