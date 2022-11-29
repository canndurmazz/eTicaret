using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public long Tc { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Password { get; set; }    
        public string lastName { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; } = "customer";
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public Customer()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public Address Address { get; set; }
        public ICollection<Shopping> Shoppings { get; set; }
    }
}
