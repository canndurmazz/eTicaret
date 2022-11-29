using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class Address
    {
       
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public AddressType Type { get; set; }
        public Address()
        {
            Type = AddressType.Business;
        }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int PostalCode { get; set; }
        public string Directions { get; set; }
        public Customer Customer { get; set; }
    }
}
