using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Conctrats
{
    public class AdminDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "admin";
    }
}
