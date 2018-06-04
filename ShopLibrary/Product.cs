using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    [DataContract]
    public class Product
    {

        public Product(int id, string name, double price, int stock)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.stock = stock;
        }

        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int typeid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public double price { get; set; }
        [DataMember]
        public int stock { get; set; }

        //TODO: REMOVE AND AND PERSISTENCY

        public List<Product> allProducts { get; set; }

        public static List<Product> createProducts()
        {
            Product product1 = new Product(1, "Auto", 4.20, 2);

            Product product2 = new Product(2, "Fiets", 13.37, 8);

            List<Product> products = new List<Product>();

            products.Add(product1);
            products.Add(product2);

            return products;
        }

        public bool isStockAvailable()
        {
            return true;
        }

        public override string ToString()
        {
            return name + ": " + price.ToString("#0.00") + " Stock: " + stock;  
        }

    }
}
