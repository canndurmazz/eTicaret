using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class CompanyEarning
    {
        public int CompanyEarningId { get; set; }
        public int CompanyId { get; set; }
        public int TotalEarning { get; set; }
        public Company Company { get; set; }
    }
}
