using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class Shopping
    {
        public int ShoppingId { get; set; } 
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public PaymentType Type { get; set; }
        public Shopping()
        {
            Type = PaymentType.Card;
        }
        public int Piece { get; set; }
        public double Earning { get; set; }
        public double SitesEarning { get; set; }
        public double Share { get; set; }
        public double Count { get; set; }
        public DateTime Created { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
