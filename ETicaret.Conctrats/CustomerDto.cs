using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Conctrats
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public long Tc { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "customer";
        public string lastName { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }    
        public AddressDto Address { get; set; }
    }
}
