using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadClass
{
    class Worker
    {
        public bool isWorking = true;

        public void work()
        {
            int i = 0;
            while (isWorking)
            {
                Console.WriteLine("work function thread is working: " + i++);
            }
        }

        public void stopWorking()
        {
            isWorking = false;
        }
    }
}
