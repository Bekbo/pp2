using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main thread start");

            for (int i = 0; i < 5; i++)
                Console.WriteLine("main thread is working: " + i);

            Worker w = new Worker();
            Thread t = new Thread(w.work);
            t.Start();

            Thread.Sleep(1);

            w.stopWorking();


            Console.WriteLine("main thread end");
            Console.ReadKey();
        }
    }
}
