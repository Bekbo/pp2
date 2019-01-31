using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine(); // Read the first row , size of array of strings
            string[] s = Console.ReadLine().Split(); // declare array of string and read these strings
            Console.WriteLine(); // go to the next row
            for (int i = 0; i < int.Parse(s1); i++) // for which i < the given 1st row, the size of the array
            {
                Console.Write(s[i] + ' ' + s[i] + ' ');      // write instant string twice with free spaces
            }
            Console.ReadKey(); // wait for the next command( Don't close the command line
        }
    }
}
