using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWrite
{
    class Program
    {
        static void f1()
        {
            FileStream fs = new FileStream(@"c:\test\test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);

            sw.Write("hello");

            sw.Close();
            fs.Close();
        }

        static void f2()
        {
            FileStream fs = new FileStream(@"c:\test\test.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadLine(); // "1 2 3 4 5"
            string[] arr = s.Split(); // ["1", "2", "3", "4", "5"];

            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int tmp = int.Parse(arr[i]);
                sum += tmp;
            }

            /*
            foreach (string ss in arr)
            {
                sum += int.Parse(ss);
            }*/
            Console.Write(sum);
            //Console.Write(s);

            sr.Close();
            fs.Close();

            Console.ReadKey();
        }

        static void f3()
        {
            FileStream fs = new FileStream(@"c:\test\test.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine(); // "1-2-3-4-5"
            string[] arr = s.Split('-'); // ["1", "2", "3", "4", "5"];


            Console.Write(s);


            sr.Close();
            fs.Close();

            Console.ReadKey();
        }

        static void f4()
        {
            FileStream fs = new FileStream(@"c:\test\test.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadToEnd();
            string[] arr = s.Split('\n'); // ["hello", "world!", "1 2 3"];

            string[] arr2 = arr[2].Split(); // ["1", "2", "3"]


            foreach(string ss in arr)
            {
                Console.WriteLine(ss);
            }

            sr.Close();
            fs.Close();

            Console.ReadKey();
        }

    
        static void Main(string[] args)
        {
            f4();
        }


    }
}
