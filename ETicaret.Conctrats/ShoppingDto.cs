using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Conctrats
{
    public class ShoppingDto
    {
        public int ShoppingId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Piece { get; set; }
        public PaymentTypeDto Type { get; set; }
        public ShoppingDto()
        {
            Type = PaymentTypeDto.card;
            Created = DateTime.UtcNow;
        }
        public double Count { get; set; }
        public double Earning { get; set; }
        public double SitesEarning { get; set; }
        public DateTime Created { get; set; }

    }
}
