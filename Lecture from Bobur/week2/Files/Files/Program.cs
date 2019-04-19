using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1; i <= 7; i++)
            {
                FileInfo file = new FileInfo(@"c:\test\1_newfolder\" + i + "_file");
                file.Create();
            }                        

            //Console.WriteLine(d.Name);
            //Console.WriteLine(d.FullName);


            Console.ReadKey();
        }

    }
}
