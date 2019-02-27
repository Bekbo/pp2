using System;
using System.Collections.Generic;
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

}