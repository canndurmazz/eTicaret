using System;
using System.Collections.Generic;

namespace eTicaret.Entities
{
    public class Company 
    {           
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Origin { get; set; }
        public string ManagerPhone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "company";
        public long TaxNo { get; set; }
        public CompanyEarning CompanyEarning { get; set; }
        public CompanyProduct CompanyProduct { get; set; }
        public DateTime CreatedDate { get; set; }
        public Company()
        {
            CreatedDate=DateTime.UtcNow;
        }
        public ICollection<Product> Products { get; set; }
    }
}
