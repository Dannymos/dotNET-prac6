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
        public List<Product> ownedProducts { get; set; }
        [DataMember]
        public double balance { get; set; }
    }
}
