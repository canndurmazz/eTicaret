using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Conctrats
{
    public class ChangeLogDto
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string PropertyName { get; set; }    
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime DataChanged { get; set; }
        public ChangeLogDto()
        {
            DataChanged = DateTime.UtcNow;
        }

    }
}
