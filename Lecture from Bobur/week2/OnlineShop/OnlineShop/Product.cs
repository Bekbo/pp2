using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    class Product
    {
        public string name;
        public float price;


        public Product() { }

        public Product(string name, float price)
        {
            this.name = name;
            this.price = price;
        }

        public override string ToString()
        {
            return name + " costs " + price + "$";
        }
 
    }
}
