using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Xml
{
    class Program
    {
        static void Main(string[] args)
        {
            f2();
        }

        static void f1()
        {
            FileStream fs = new FileStream(@"snake.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Snake));

            Snake s = new Snake('o', ConsoleColor.Green);

            try
            {
                xs.Serialize(fs, s);
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
            FileStream fs = new FileStream(@"snake.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Snake));

            Snake s;
            try
            {
                s = xs.Deserialize(fs) as Snake;

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
