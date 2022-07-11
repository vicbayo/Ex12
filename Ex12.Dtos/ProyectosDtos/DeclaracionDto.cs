using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Dtos.ProyectosDtos
{
    public class DeclaracionDto
    {
        public Guid Id { get; set; }

        public string Descripcion { get; set; }

        public DateTime? FechaDeclaracion { get; set; }

        public string Ley { get; set; }

        public DateTime? FechaLey { get; set; }

        public int? Articulo { get; set; }

        public int? NumeroBOE { get; set; }

        public DateTime? FechaBOE { get; set; }

        public string ReferenciaBOE { get; set; }
    }
}
