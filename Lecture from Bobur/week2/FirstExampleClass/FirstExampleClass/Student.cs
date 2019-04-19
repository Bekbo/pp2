using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstExampleClass
{
    class Student
    {
        private string fname;
        private string lname;
        private int age;
        private float gpa;

        public Student() { }

        public Student(string fname)
        {
            this.fname = fname;
        }

        public Student(string fname, string lname, int age, float gpa)
        {
            this.fname = fname;
            this.lname = lname;
            this.age = age;
            this.gpa = gpa;   
        }

        public string getFname()
        {
            return fname;
        }

        public void setFname(string fname)
        {
            this.fname = fname;
        }

        






        public override string ToString()
        {
            return fname + " " + lname + " " + age + " " + gpa;
            //return string.Format("Student\nfname: {0}\nlname: {1}\nage: {2}\ngpa: {3}", fname, lname, age, gpa);
        }
    }
}
