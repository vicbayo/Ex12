using Ex12.Dtos.ProyectosDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.UseCasesPort.ProyectosPort
{
    // para devolver datos al presentador con el producto ya creado
    public interface ICrearProyectoOutputPort
    {
        Task Handle(Guid id);
    }
}
