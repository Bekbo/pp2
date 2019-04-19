using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SaveData
{
    class Program
    {
        static void Main(string[] args)
        {
            f2();
        }


        static void f1()
        {
            FileStream fs = new FileStream(@"data.ser", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            Snake s = new Snake('+', ConsoleColor.Green);

            try
            {
                bf.Serialize(fs, s);
            }
            catch
            {
                Console.Write("error");
            }
            finally
            {
                fs.Close();
            }
        }


        static void f2()
        {
            FileStream fs = new FileStream(@"data.ser", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            Snake s;
            try
            {
                s = bf.Deserialize(fs) as Snake;
                //s = (Snake)bf.Deserialize(fs);
                Console.Write(s);
                Console.ReadKey();
            }
            catch
            {
                Console.Write("error");
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
