using Ex12.Dtos.ProyectosDtos;
using Ex12.UseCasesPort.ProyectosPort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Presenters.ProyectosPresenters
{
    /// <summary>
    /// Devuelve el dato a mostrar
    /// </summary>
    public class CrearProyectoPresenter : ICrearProyectoOutputPort, IPresenter<Guid>
    {
        public Guid Content { get; private set;}

        public Task Handle(Guid id)
        {
            Content = id;
            return Task.CompletedTask;
        }
    }
}
