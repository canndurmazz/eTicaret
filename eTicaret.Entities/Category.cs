using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class Category
    {
        
        public int CategoryId { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }
        public decimal Share { get; set; }
        public Category()
        {
            CreatedTime = DateTime.UtcNow;
        }
        public DateTime CreatedTime { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
