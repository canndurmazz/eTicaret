using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Conctrats
{
    public class WaitingProductDto
    {
        public int WaitingProductId { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public WaitingProductDto()
        {
            CreatedTime = DateTime.UtcNow;
        }
        public DateTime CreatedTime { get; set; }
        public WaitingStockDto Stock { get; set; }
        public WaitingProductInformationDto ProductInformation { get; set; }
    }
}
