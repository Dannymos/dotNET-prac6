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
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public double price { get; set; }
        [DataMember]
        public int stock { get; set; }
    }
}
