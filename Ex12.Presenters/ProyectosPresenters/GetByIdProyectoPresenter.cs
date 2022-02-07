using Ex12.Dtos.ProyectosDtos;
using Ex12.UseCasesPort.ProyectosPort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Presenters.ProyectosPresenters
{
    public class GetByIdProyectoPresenter : IGetByIdProyectoOutputPort, IPresenter<ProyectoDto>
    {
        public ProyectoDto Content {get; private set;}

        public Task Handle(ProyectoDto proyectoDto)
        {
            Content = proyectoDto;
            return Task.CompletedTask;
        }
    }
}
