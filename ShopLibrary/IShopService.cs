﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShopLibrary
{
    [ServiceContract]
    public interface IShopService
    {

        //PRODUCT FUNCTIONS
        [OperationContract]
        List<Product> getAllProducts();


        //USER FUNCTIONS
        [OperationContract]
        string register(string username);

        [OperationContract]
        double getBalance(int userid);

        [OperationContract]
        string test();

        [OperationContract]
        bool isUsernameUnique(string username);

        [OperationContract]
        User login(String username, String password);

        [OperationContract]
        string buyProduct(int prodid, int userid, int amount);

        [OperationContract]
        List<Product> getUserOwnedProducts(int userid);
    }
}
