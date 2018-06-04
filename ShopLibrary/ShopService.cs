using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShopLibrary
{
    //TODO: ADD PERSISTENCY
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShopServices" in both code and config file together.
    public class ShopService : IShopService
    {
        public List<Product> getAllProducts()
        {
            List<Product> products = Product.createProducts();
            return products;
        }

        public bool register(string username)
        {
            //reverse username as password
            char[] passwordArray = username.ToArray();
            Array.Reverse(passwordArray);
            string password = new string(passwordArray);
            User user = new User(username, password, 1000.00);
            if (User.register(user))
            {
                return true;
            }
            return false;
        }

        public User login(string username, string password)
        {
            if (username == "username" && password == "password")
            {
                User user = new User("username", "password", 1000.00);
                return user;
            }
            else
            {

            }
            return null;
        }

        public bool buyProduct(int prodid, int amount)
        {
            return true;
        }

        public List<Product> getUserOwnedProducts(int userid)
        {
            List<Product> ownedProducts = User.getOwnedProducts(userid);
            return ownedProducts;
        }

        public double getBalance(int userid)
        {
            return User.getBalance(userid);
        }

        public string test()
        {
            return "succes!";
        }

        public bool isUsernameUnique(string username)
        {
            return User.isUsernameUnique(username);
        }
    }
}
