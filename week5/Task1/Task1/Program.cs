using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    public class Complex
    {
        public int im;
        public int real;

        public Complex() { }

        public Complex(int im, int real)
        {
            this.im = im;
            this.real = real;
        }

        public override string ToString()
        {
            return im + "i + " + real;
        }
    }
    class Program
    {
        public static void Ser(Complex complex)
        {
            FileStream fs = new FileStream("order.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            xs.Serialize(fs, complex);
            fs.Close();
        }
        public static void Des()
        {
            FileStream fs = new FileStream("order.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex complex = xs.Deserialize(fs) as Complex;
            Console.WriteLine(complex);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Complex complex = new Complex(3, 4);
            Ser(complex);
            Des();
        }
    }
}
