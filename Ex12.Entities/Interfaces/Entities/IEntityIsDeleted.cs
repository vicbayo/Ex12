using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Entities.Interfaces.Entities
{
    public interface IEntityIsDeleted
    {
        bool IsDeleted { get; set; }
        DateTime? Deleted { get; set; }
    }
}
