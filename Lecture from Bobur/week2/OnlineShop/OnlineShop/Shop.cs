using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    class Shop
    {
        public string name;
        public string address;
        public List<Product> products;

        public Shop() { }

        public Shop(string _name, string _address, List<Product> _products)
        {
            name = _name;
            address = _address;
            products = _products;
        }

        public void addProduct(Product p)
        {
            products.Add(p);
        }

        public void removeProduct(Product p)
        {
            products.Remove(p);
        }

        public override string ToString()
        {
            string res = "";
            res = name + " " + address + "\n";
            foreach(Product p in products)
            {
                res += p.ToString() + "\n";
            }
            return res;
        }
    }
}
