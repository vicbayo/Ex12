using Ex12.Entities.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Entities.Entities
{
    public class Proyecto : IEntity, IEntityIsDeleted, IEntityNotes, IEntityIsActive, IEntityAudit
    {        
        public Guid Id { get; set; }
        public string Clave { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Deleted { get; set; }
        public string Notes { get; set; }
        public byte[] RowVersion { get; set; }
        public string Creador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Modificador { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool IsActive { get; set; }
        public virtual ResponsablesDemarcacion ResponsablesDemarcacion { get; set; }
        public virtual Declaracion Declaracion { get; set; }
    }
}
