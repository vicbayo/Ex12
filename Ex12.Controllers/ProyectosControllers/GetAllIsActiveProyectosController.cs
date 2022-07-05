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
    public class GetAllIsActiveProyectosController
    {
        readonly IGetAllProyectosInputPort _inputPort;
        readonly IGetAllProyectosOutputPort _outputPort;

        public GetAllIsActiveProyectosController(IGetAllProyectosInputPort inputPort, IGetAllProyectosOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        [HttpGet("Get")]
        public async Task<IEnumerable<GetAllProyectosDto>> Get()
        {
            //Specification<Proyecto> specification = new ProyectosIsActiveSpec();
            //Specification<Proyecto> specification2 = new ProyectosDeletedSpec();
            //Specification<Proyecto> specification3 = new ProyectosNotDeletedSpec();

            //var r = specification.Or(specification2);
            //var r1 = specification.Or(specification2).Not(specification3).ToExpression();

            //await _inputPort.Handle(specification.Or(specification2).Not(specification3));

            Specification<Proyecto> specification = new ProyectosIsActiveSpec();
            Specification<Proyecto> specification3 = new ProyectosNotDeletedSpec();

            await _inputPort.Handle(specification.And(specification3));
            var presenter = _outputPort as GetAllProyectosPresenter;
            return presenter.Content;
        }

    }
}
