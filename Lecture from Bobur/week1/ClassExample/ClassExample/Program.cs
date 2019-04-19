using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Person p1 = new Person();
             * p1.setName("Person 1"); // set value using setter
            */

            Person p2 = new Person("Person 1", 18); // send values to constructor
            Console.Write(p2.ToString());

            Console.ReadKey();
        }
    }
}
