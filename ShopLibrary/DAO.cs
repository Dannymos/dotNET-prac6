using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    class DAO
    {

        public void saveProduct(Product product)
        {
            var path = "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\Practicum6\\ShopLibrary\\product.csv";
            String[] csv = File.ReadAllLines(path);
            int id = csv.Length + 1;
            String newLine = string.Format("{0},{1},{2},{3}", id, product.name, product.price, product.stock);
            Array.Resize(ref csv, csv.Length + 1);
            csv[csv.Length - 1] = newLine;
            File.WriteAllLines(path, csv);
        }

        public void saveUser(User user)
        {
            var path = "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\Practicum6\\ShopLibrary\\user.csv";
            String[] csv = File.ReadAllLines(path);
            int id = csv.Length + 1;
            String newLine = string.Format("{0},{1},{2},{3}", id, user.balance, user.password, user.username);
            Array.Resize(ref csv, csv.Length + 1);
            csv[csv.Length - 1] = newLine;
            File.WriteAllLines(path, csv);
        }
        public void saveInventory(Product product, User user, int amount)
        {
            var path = "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\Practicum6\\ShopLibrary\\inventory.csv";
            String[] csv = File.ReadAllLines(path);
            int id = csv.Length + 1;
            String newLine = string.Format("{0},{1},{2},{3}", id, product.id, user.id, amount);
            Array.Resize(ref csv, csv.Length + 1);
            csv[csv.Length - 1] = newLine;
            File.WriteAllLines(path, csv);
        }

        public List<User> readUsers()
        {
            var path = "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\Practicum6\\ShopLibrary\\user.csv";
            String[] csv = File.ReadAllLines(path);
            List<User> users = new List<User>();
            foreach (string line in csv)
            {
                string[] userline = line.Split(',');

                User user = new User
                {

                    id = Int32.Parse(userline[0]),
                    balance = Double.Parse(userline[1]),
                    password = userline[2],
                    username = userline[3]

                };
                users.Add(user);



            }
            return users;
        }

        public List<Product> readProducts()
        {
            var path = "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\Practicum6\\ShopLibrary\\product.csv";
            String[] csv = File.ReadAllLines(path);
            List<Product> products = new List<Product>();
            foreach (string line in csv)
            {
                string[] productline = line.Split(',');

                Product newProduct = new Product
                {
                    id = Int32.Parse(productline[0]),
                    name = productline[1],
                    price = Double.Parse(productline[2]),
                    stock = Int32.Parse(productline[3])
                };
                products.Add(newProduct);

            }
            return products;
        }

        public List<Product> readInventory(int user)
        {
            var path = "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\Practicum6\\ShopLibrary\\inventory.csv";
            List<Product> products = readProducts();

            String[] csv = File.ReadAllLines(path);
            List<Product> results = new List<Product>();
            foreach (string line in csv)
            {
                string[] inventoryline = line.Split(',');
                //check if user
                if (Int32.Parse(inventoryline[2]) == user)
                {
                    Product item = (from product in products
                                    where product.id == Int32.Parse(inventoryline[1])
                                    select product).First();
                    results.Add(
                        new Product
                        {
                            stock = Int32.Parse(inventoryline[3]),
                            id = item.id,
                            name = item.name,
                            price = item.price
                        });
                }
            }
            return results;
        }


    }
}