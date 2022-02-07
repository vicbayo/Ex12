using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Entities.Entities.Audit
{
    public class AuditLog
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }  //Create, Update, Delete
        public string TableName { get; set; }
        public DateTime DateTime { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string AffectedColumns { get; set; }
        public string PrimaryKey { get; set; }
    }
}
