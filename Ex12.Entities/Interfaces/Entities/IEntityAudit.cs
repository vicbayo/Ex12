using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Entities.Interfaces.Entities
{
    public interface IEntityAudit
    {
        string Creador { get; set; }
        DateTime FechaCreacion { get; set; }
        string Modificador { get; set; }
        DateTime? FechaModificacion { get; set; }
    }
}
