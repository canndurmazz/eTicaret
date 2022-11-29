using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class WaitingProduct
    {
        public int WaitingProductId { get; set; }

        public int ShoppingId { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public WaitingProduct()
        {
            CreatedTime = DateTime.UtcNow;
        }
        public DateTime CreatedTime { get; set; }
        public Company Company { get; set; }
        public CompanyProduct CompanyProduct { get; set; }
        public Category Category { get; set; }
        public WaitingStock Stock { get; set; }
        public WaitingProductInformation ProductInformation { get; set; }

        public ICollection<Shopping> Shoppings { get; set; }

    }
}
