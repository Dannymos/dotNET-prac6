using ShopLibrary;
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
            DAO dao = new DAO();
            return dao.readProducts();
        }

        public string register(string username)
        {
            //reverse username as password
            char[] passwordArray = username.ToArray();
            Array.Reverse(passwordArray);
            string password = new string(passwordArray);
            User user = new User
            {
                username = username,
                password = password,
                balance = 500.00
            };
            DAO dao = new DAO();
            dao.saveUser(user);
            return "User registered! you password is: " + password;
        }

        public User login(String username, String password)
        {
            DAO dao = new DAO();
            List<User> users = dao.readUsers();

            if((from user in users where user.username == username && user.password == password select user).Any())
            {
                User user = users.Find(x => x.username == username && x.password == password);
                return user;
            }
            else
            {
                return null;
            }
            
        }

        public string buyProduct(int prodid, int userid, int amount)
        {
            DAO dao = new DAO();
            List<Product> ownedproducts = dao.readInventory(userid);
            List<Product> products = dao.readProducts();
            List<User> users = dao.readUsers();
            Product product = products.Find(x => x.id == prodid);
            User user = users.Find(x => x.id == userid);
            if(getBalance(user.id) >= product.price)
            {
                if(product.stock >= 1)
                {
                    if ((from x in ownedproducts where x.id == product.id select x).Any())
                    {
                        int indexp = ownedproducts.FindIndex(x => x.id == product.id);
                        ownedproducts[indexp].stock += amount;
                        dao.overwriteInventory(ownedproducts, user.id);
                    }
                    else
                    {
                        dao.saveInventory(product, user, 1);

                    }
                    //update user balance
                    int index = users.FindIndex(x => x.id == user.id);
                    users[index].balance -= product.price;
                    dao.UpdateUser(users);
                    //update shop stock amount of bought product
                    int indexShop = products.FindIndex(x => x.id == product.id);
                    products[indexShop].stock -= amount;
                    dao.UpdateProduct(products);
                    return "bought product: " + product.name + " For : $" + product.price + " for user: " + user.username;
                }
                else
                {
                    return "Product no longer in stock!";
                }
            }
            else
            {
                return "Not enough balance!";
            }
        }

        public List<Product> getUserOwnedProducts(int userid)
        {
            DAO dao = new DAO();
            List<Product> inventory = dao.readInventory(userid);
            return inventory;
        }

        public double getBalance(int userid)
        {
            DAO dao = new DAO();
            List<User> users = dao.readUsers();

            if ((from user in users where user.id == userid select user).Any())
            {
                User user = users.Find(x => x.id == userid);
                return user.balance;
            }
            else
            {
                return 0.00;
            }
        }

        public string test()
        {
            return "succes!";
        }

        public bool isUsernameUnique(string username)
        {
            DAO dao = new DAO();
            List<User> users = dao.readUsers();

            if ((from user in users where user.username == username select user).Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
