using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Example2
{
    public class PurchaseOrder
    {
        [XmlIgnore]
        public Address address;

        public string OrderDate;

        [XmlArray("Items")]
        public List<OrderItem> OrderItems;

        public PurchaseOrder()
        {
            OrderItems = new List<OrderItem>();
        }
        public PurchaseOrder(Address address, string OrderDate)
        {
            this.address = address;
            this.OrderDate = OrderDate;
            OrderItems = new List<OrderItem>();
        }
    }

    public class Address
    {
        public string Name;
        public string City;
        public string State;
        public string Zip;

        public Address() { }
        public Address(string Name, string City, string State, string Zip)
        {
            this.Name = Name;
            this.City = City;
            this.State = State;
            this.Zip = Zip;
        }
        public override string ToString()
        {
            return Name + " " + City;
        }
    }

    public class OrderItem
    {
        public string ItemName;
        public string Description;
        public int UnitPrice;
        public int Quantity;
        public int Total;

        public OrderItem() { }
        public OrderItem(string ItemName, string Description, int UnitPrice, int Quantity)
        {
            this.ItemName = ItemName;
            this.Description = Description;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
            this.Total = UnitPrice * Quantity;
        }
    }
    class Program
    {
        public static void F1()
        {
            PurchaseOrder order = new PurchaseOrder();

            Address address = new Address();
            address.Name = "Askar Akshabayev";
            address.City = "Almaty";
            address.State = "Alatau";
            address.Zip = "050000";

            Console.WriteLine(address);

            order.address = address;

            OrderItem item1 = new OrderItem("Item1", "Description 1", 100, 3);
            OrderItem item2 = new OrderItem("Item2", "Description 2", 123, 4);
            order.OrderItems.Add(item1);
            order.OrderItems.Add(item2);

            order.OrderDate = "23.02.2019";

            //StreamWriter sw = new StreamWriter("order.txt");
            //sw.WriteLine(address.Name);
            //sw.WriteLine(address.City);
            //sw.WriteLine(address.State);
            //sw.WriteLine(address.Zip);

            //sw.WriteLine(order.OrderDate);

            //foreach(OrderItem orderItem in order.OrderItems)
            //{
            //    sw.WriteLine(orderItem.ItemName);
            //    sw.WriteLine(orderItem.Description);
            //    sw.WriteLine(orderItem.UnitPrice);
            //    sw.WriteLine(orderItem.Quantity);
            //    sw.WriteLine(orderItem.Total);
            //}

            //sw.Close();
            FileStream fs = new FileStream("order.xml", FileMode.Truncate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(PurchaseOrder));
            xs.Serialize(fs, order);
            fs.Close();
        }
        public static void F2()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("order.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer xs = new XmlSerializer(typeof(PurchaseOrder));
                PurchaseOrder order = xs.Deserialize(fs) as PurchaseOrder;

                Console.WriteLine(order.OrderItems[0].ItemName);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        static void Main(string[] args)
        {
            F1();
            F2();
        }
    }
}