using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class Stock
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }       
        public int StockProduct { get; set; }    
        public int SoldProduct { get; set; }
        public Product Product { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
