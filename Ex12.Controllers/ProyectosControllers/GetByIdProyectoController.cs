using Ex12.Dtos.ProyectosDtos;
using Ex12.Presenters;
using Ex12.Presenters.ProyectosPresenters;
using Ex12.UseCases.ProyectosUseCases.GetByIdProyecto;
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
    public class GetByIdProyectoController
    {
        readonly IGetByIdProyectoInputPort _inputPort;
        readonly IGetByIdProyectoOutputPort _outputPort;

        public GetByIdProyectoController(IGetByIdProyectoInputPort inputPort, IGetByIdProyectoOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        [HttpGet]
        public async Task<ProyectoDto> GetById(Guid id)
        {
            await _inputPort.Handle(id);
            var presenter = _outputPort as GetByIdProyectoPresenter;
            return presenter.Content;
        }
    }
}
