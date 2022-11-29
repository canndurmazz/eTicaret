using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Conctrats
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Origin { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "company";
        public string ManagerPhone { get; set; }
        public long TaxNo { get; set; }
        public CompanyEarningDto CompanyEarning { get; set; }
        public CompanyProductDto CompanyProduct { get; set; }
        public DateTime CreatedDate { get; set; }
        public CompanyDto()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
