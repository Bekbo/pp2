using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    public class Employee
    {
        public string id;
        private string ID
        {
            get
            {
                return id;
            }
            set
            {
                ID = id;
            }
        }
        public string name;
        private string Name
        {
            get
            {
                return name;
            }
            set
            {
                Name = name;
            }
        }
        public int salary;
        private int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                Salary = salary;
            }
        }
        public Employee() { }
        public Employee(string id, string name ,int salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary + 50000;
        }

    }
    class Program
    {
        public static int x,y;
        static void Main(string[] args)
        {
             Thread t1 = new Thread(tt1);
            Thread t2 = new Thread(tt2);
            t1.Start(); t2.Start();
            ConsoleKeyInfo cns = Console.ReadKey();
            if (cns.Key == ConsoleKey.Spacebar)
            {
                Console.WriteLine("Position at " + x + " " + y);
                t1.Abort(); t2.Abort();
                Console.Read();
            }

            /*Employee emp = new Employee("18BD", "Bekbolat",500);
            FileStream fs = new FileStream("emp.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Employee));
            xs.Serialize(fs,emp);
            fs.Close();

            FileStream fs2 = new FileStream("emp.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xss = new XmlSerializer(typeof(Employee));
            Employee emp2 = xss.Deserialize(fs2) as Employee;
            fs2.Close();

            Console.WriteLine(emp2.id + " " + emp2.name + " " + emp2.salary );
            Console.ReadKey();*/

            /*
            //Binary
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, emp);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            */
            //Deser Binary
            /*FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            */



        }

        public static void tt1()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('-');
                Thread.Sleep(500);
                x = i;
                y = 0;
            }
        }

        public static void tt2()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write('-');
                Thread.Sleep(225);
                x = i;
                y = 1;
            }
        }
    }
}
