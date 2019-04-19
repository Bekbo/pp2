using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point();
            p.X = 222;

            int a = p.X;

            Console.Write(a);



            Console.ReadKey();
        }
    }
}
