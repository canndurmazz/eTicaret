using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Conctrats
{
    public class BusinessAddressDto
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int PostalCode { get; set; }
        public string Directions { get; set; }
    }
}
