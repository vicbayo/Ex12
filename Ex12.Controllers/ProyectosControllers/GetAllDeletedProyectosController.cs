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
    public class GetAllDeletedProyectosController
    {
        readonly IGetAllProyectosInputPort _inputPort;
        readonly IGetAllProyectosOutputPort _outputPort;

        public GetAllDeletedProyectosController(IGetAllProyectosInputPort inputPort, IGetAllProyectosOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        [HttpGet("GetAllDeleted")]
        public async Task<IEnumerable<GetAllProyectosDto>> GetAllDeleted()
        {
            Specification<Proyecto> specification = new ProyectosDeletedSpec();

            await _inputPort.Handle(specification);
            var presenter = _outputPort as GetAllProyectosPresenter;
            return presenter.Content;
        }

    }
}
