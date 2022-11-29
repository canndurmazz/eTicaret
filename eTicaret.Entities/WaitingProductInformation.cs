using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class WaitingProductInformation
    {
        public int WaitingProductInformationId { get; set; }
        public int WaitingProductId { get; set; }
        public string Information { get; set; }
        public WaitingProduct Product { get; set; }
    }
}
