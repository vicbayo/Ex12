using Ex12.Dtos.ProyectosDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Dtos.ModelView
{
    public class CrearProyectoMvDto
    {
        public ProyectoDto ProyectoDto { get; set; }

        public CrearResponsablesDemarcacionDto ResponsablesDto { get; set; }

        public DeclaracionDto DeclaracionDto { get; set; }

        public CrearProyectoMvDto()
        {
            ProyectoDto = new ProyectoDto();
            ResponsablesDto = new CrearResponsablesDemarcacionDto();
            DeclaracionDto = new DeclaracionDto();
        }

    }
}
