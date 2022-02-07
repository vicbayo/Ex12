using Ex12.Dtos.ProyectosDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.UseCasesPort.ProyectosPort
{
    //Con este interface se reciben los datos que nos envia el controlador
    //Datos de entrada del caso de uso
    public interface ICrearProyectoInputPort
    {
        Task Handle(CrearProyectoDto proyectoDto);
    }
}
