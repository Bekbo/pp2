using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Write("Enter user name : ");
            string name = Console.ReadLine();
            Game game = new Game();
            game.Start();
        }
    }
}
