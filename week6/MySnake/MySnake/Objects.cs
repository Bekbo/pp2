using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MySnake
{
    public class Objects
    {
        public List<Point> objects;
        public char sign;
        public int lvlindex;

        public Objects(int x, int y, char sign)
        {
            objects = new List<Point>
            {
                new Point(x, y)
            };
            this.sign = sign;
        }

        public void Draw()
        {
            foreach (Point p in objects)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
        
        public bool IsColl(Objects obj)
        {
            foreach(Point p in obj.objects)
            {
                if (objects[0].x == p.x && objects[0].y == p.y)
                    return true;
            }
            return false;
        }

        public bool IsCollitself(Objects obj)
        {
            for (int i = 1; i < obj.objects.Count; i++)
            {
                if (obj.objects[i].x == obj.objects[0].x && obj.objects[i].y == obj.objects[0].y)
                    return true;
            }
            return false;
        }
    }
}
