using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample
{
    class Person
    {
        private string name;
        private int age;

        // constructor 1
        public Person() { }

        // constructor 2
        public Person(string name)
        {
            this.name = name;
        }

        // constructor 3
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

    
        // getter for field: name
        public string getName()
        {
            return name;
        }

        // setter for field: name
        public void setName(string name)
        {
            this.name = name;
        }

        // override toString method for our Person class
        public override string ToString()
        {
            return "Name: " + name + "\nAge: " + age;
        }
    }
}
