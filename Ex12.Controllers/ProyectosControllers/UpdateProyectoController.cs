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
    public class UpdateProyectoController
    {
        readonly IUpdateProyectoInputPort _inputPort;
        readonly IUpdateProyectoOutputPort _outputPort;

        public UpdateProyectoController(IUpdateProyectoInputPort inputPort, IUpdateProyectoOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateProyecto( UpdateProyectoDto updateProyectoDto)
        {            
            await _inputPort.Handle(updateProyectoDto);
            var presenter = _outputPort as UpdateProyectoPresenter;
            return presenter.Content;
        }
    }
}
