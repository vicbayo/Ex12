using Ex12.Dtos.ProyectosDtos;
using Ex12.Presenters;
using Ex12.Presenters.ProyectosPresenters;
using Ex12.UseCases.ProyectosUseCases.CrearProyecto;
using Ex12.UseCasesPort.ProyectosPort;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Controllers.ProyectosControllers
{
    [Route("api/[controller]")]
    [ApiController] //para swagger nos vea
    public class CrearProyectoController
    {
        readonly ICrearProyectoInputPort _inputPort;
        readonly ICrearProyectoOutputPort _outputPort;

        public CrearProyectoController(ICrearProyectoInputPort inputPort, ICrearProyectoOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CrearProyecto( CrearProyectoDto crearproyectoDto)
        {
            
            await _inputPort.Handle(crearproyectoDto);
            var presenter = _outputPort as CrearProyectoPresenter;
            return presenter.Content;
        }
    }
}
