using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThread
{
    class Program
    {
        static void doIt()
        {
            for (int i = 0; i < 5; i++)
                Console.WriteLine("thread 2 is working: " + i);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("main thread start");

            for (int i = 0; i < 5; i++)
                Console.WriteLine("main thread is working: " + i);

            Thread t = new Thread(doIt);
            t.Start();

            //t.Join();

            Console.WriteLine("main thread end");
            Console.ReadKey();
        }
    }
}
