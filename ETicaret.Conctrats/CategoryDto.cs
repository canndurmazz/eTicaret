using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ETicaret.Conctrats
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Share { get; set; }
        public CategoryDto()
        {
            CreatedTime = DateTime.UtcNow;
        }
        public DateTime CreatedTime { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}
