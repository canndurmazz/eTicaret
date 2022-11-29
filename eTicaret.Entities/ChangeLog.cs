using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Entities
{
    public class ChangeLog
    {
        public int Id { get; set; }
        public int PrimaryKey { get; set; }
        public string EntityName { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime DataChanged { get; set; }
        public ChangeLog()
        {
            DataChanged = DateTime.UtcNow; 
        }
      
    }
}
