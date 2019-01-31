using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine(); // Read the lenght of the square from Console
            int n = int.Parse(s); // convert s into int type number
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)   //where j <= i put the symbol
                {
                    Console.Write("[*]"); // the symbol [*]
                }
                Console.WriteLine(); // Go to the next row
            }
            Console.ReadKey();
        }
    }
}
