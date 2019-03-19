using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSnake
{
    public class Food : GameObjects
    {
        public Food() { }
        public Food(int x, int y, char sign, ConsoleColor color) : base(x, y, sign,color) { }
        public void Generate()
        {
            Random random = new Random();
            int x = random.Next(2, Console.WindowWidth-2);
            int y = random.Next(2, Console.WindowHeight-2);
            body[0].x = x;
            body[0].y = y;
        }
    }
}
