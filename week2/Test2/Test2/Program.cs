using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Student    // new CLass Student
    {
        string name;  // arguments of the class Student, of type string
        string id;        // arguments of the class Student, of type string
        int year = 1;       // arguments of the class Student, of type int 

        public Student(string name, string id)     //   new parameter from 2 arguments
        {
            this.name = name;             //   argument name = name
            this.id = id;                 //    argument id = id
        }

        public void f1()        // function f1() for arguments of class Student
        {
            Console.WriteLine(name + ' ' + id + ' ' + year);   //Output the arguments
        }
        public void f2() // function f1() for arguments of class Student
        {
            year++;   // incrementing the year argument
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student("Bekbolat", "18BD145319");  // Insert values for st1 element of type of class Student
            st1.f1();  // do f1() function with st1 element
            st1.f2();  // do f2() function with st1 element
            st1.f1();  // do f1() function with st1 element
            Console.ReadKey();
        }
    }
}