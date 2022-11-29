using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class CompanyProduct
    {
        public int CompanyProductId { get; set; }
        public int CompanyId { get; set; }
        public int ProductCount { get; set; }
        public Company Company { get; set; }
       public ICollection<Product> Products { get; set; }
    }
}
