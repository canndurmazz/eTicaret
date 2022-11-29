using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Conctrats
{
    public class ProductDto
    {

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ProductDto()
        {
            CreatedTime = DateTime.UtcNow;
        }
        public DateTime CreatedTime { get; set; }
        public StockDto Stock { get; set; }
        public ProductInformationDto ProductInformation { get; set; }

    }
}
