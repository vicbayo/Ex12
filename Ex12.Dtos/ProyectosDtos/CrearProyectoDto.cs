using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Dtos.ProyectosDtos
{
    public class CrearProyectoDto
    {
        //public Guid Id { get; set; }
        public string Clave { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaAprobacion { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime? Deleted { get; set; }
        public string Notes { get; set; }
        //public byte[] RowVersion { get; set; }
        public string Creador { get; set; }
        public DateTime FechaCreacion { get; set; }
        //public string Modificador { get; set; }
        //public DateTime? FechaModificacion { get; set; }
        public bool IsActive { get; set; }
        public CrearResponsablesDemarcacionDto CrearResponsablesDemarcacionDto { get; set; } = new CrearResponsablesDemarcacionDto();
        public CrearDeclaracionDto CrearDeclaracionDto { get; set; } = new CrearDeclaracionDto();
    }
}
