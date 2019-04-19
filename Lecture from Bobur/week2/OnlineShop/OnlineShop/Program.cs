using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("1 product", 10));
            products.Add(new Product("2 product", 20));
            products.Add(new Product("3 product", 30));

            Shop shop = new Shop("shop 1", "address 1", products);

            Product new_p = new Product("new product", 100);

            shop.addProduct(new_p);
            shop.removeProduct(new_p);

            Console.Write(shop);


            Console.ReadKey();

        }
    }
}
