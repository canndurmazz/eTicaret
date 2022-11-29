using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product()
        {
            CreatedTime = DateTime.UtcNow;
        }
        public DateTime CreatedTime { get; set; }
        public Company Company { get; set; }
        public CompanyProduct CompanyProduct { get; set; }
        public Category Category { get; set; }
        public Stock Stock { get; set; } 
        public ProductInformation ProductInformation { get; set; }
        public ICollection<Shopping> Shoppings { get; set; }

    }
}
