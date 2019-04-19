using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            f2();
        }

        static void f2()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            FileStream fs = new FileStream("test.xml", FileMode.Open, FileAccess.Read);

            try
            {
                Student s = xs.Deserialize(fs) as Student;
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

        static void f1()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate, FileAccess.Write);

            Student s = new Student();
            s.setInfo();

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
    }
}
