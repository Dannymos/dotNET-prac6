using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public List<Product> ownedProducts { get; }
        [DataMember]
        public double balance { get; set; }

        public User(string username, string password, double balance)
        {
            this.username = username;
            this.password = password;
            this.balance = balance;
        }

        //TODO: ADD PERSISTENCY
        public static bool addProduct(int productid, int amount)
        {
            return true;
        }

        public static bool register(User user)
        {
            return true;
        }

        public static List<Product> getOwnedProducts(int id)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(2, "Fiets", 13.37, 8));
            return products;
        }

        public static bool isUsernameUnique(string username)
        {
            return true;
        }

        public static double getBalance(int id)
        {
            return 1000.00;
        }

    }
}
