using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class ProductInformation
    {
        public int ProductInformationId { get; set; }
        public int ProductId { get; set; }
        public string Information { get; set; }
        public Product Product { get; set; }
    }
}
