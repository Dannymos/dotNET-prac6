﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ShopLibrary;

namespace ShopHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ShopService)))
            {
                host.Open();
                Console.WriteLine("Service ready");
                Console.ReadKey();
            }
        }

    }
}
