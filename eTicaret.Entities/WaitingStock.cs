using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class WaitingStock
    {
        public int WaitingStockId { get; set; }
        public int WaitingProductId { get; set; }
        public int StockProduct { get; set; }
        public int SoldProduct { get; set; }
        public WaitingProduct Product { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
