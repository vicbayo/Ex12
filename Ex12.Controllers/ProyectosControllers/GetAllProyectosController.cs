using Ex12.Dtos.ProyectosDtos;
using Ex12.Entities.Entities;
using Ex12.Entities.Specifications;
using Ex12.Entities.Specifications.Proyectos;
using Ex12.Presenters;
using Ex12.Presenters.ProyectosPresenters;
using Ex12.UseCases.ProyectosUseCases.GetAllProyectos;
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
    public class GetAllProyectosController
    {
        readonly IGetAllProyectosInputPort _inputPort;
        readonly IGetAllProyectosOutputPort _outputPort;

        public GetAllProyectosController(IGetAllProyectosInputPort inputPort, IGetAllProyectosOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<GetAllProyectosDto>> GetAll()
        {
            await _inputPort.Handle();
            var presenter = _outputPort as GetAllProyectosPresenter;
            return presenter.Content;
        }
    }
}
