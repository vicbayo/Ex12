using Ex12.Dtos.ProyectosDtos;
using Ex12.UseCasesPort.ProyectosPort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Presenters.ProyectosPresenters
{
    public class GetAllProyectosPresenter : IGetAllProyectosOutputPort, IPresenter<IEnumerable<GetAllProyectosDto>>
    {
        public IEnumerable<GetAllProyectosDto> Content {get; private set;}

        public Task Handle(IEnumerable<GetAllProyectosDto> proyectosDto)
        {
            Content = proyectosDto;
            return Task.CompletedTask;
        }
    }
}
