using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Conctrats
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public AddressTypeDto Type { get; set; }
        public AddressDto()
        {
            Type = AddressTypeDto.Business;
        }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int PostalCode { get; set; }
        public string Directions { get; set; }
    }
}
