using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        string name;
        string id;
        int year = 1;

        public Student(string name, string id)
        {
            this.name = name;
            this.id = id;
        }

        public void f1()
        {
            Console.WriteLine(name + ' ' + id + ' ' + year);
        }
        public void f2()
        {
            year++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student("Bekbolat", "18BD145319");
            st1.f1();
            st1.f2();
            Console.ReadKey();
        }
    }
}