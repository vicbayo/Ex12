using Ex12.Dtos.ProyectosDtos;
using Ex12.Entities.Entities;
using Ex12.Entities.Interfaces;
using Ex12.Entities.Interfaces.Repository.ProyectoRepository;
using Ex12.Entities.Specifications;
using Ex12.Entities.Specifications.Proyectos;
using Ex12.UseCasesPort.ProyectosPort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex12.UseCases.ProyectosUseCases.GetAllProyectos
{
    //debe implemetar el imput port, que recibe del controlador
    public class GetAllProyectosInteractor : IGetAllProyectosInputPort
    {
        readonly IProyectoRepo _repository;
        readonly IGetAllProyectosOutputPort _outputPort;

        public GetAllProyectosInteractor(IProyectoRepo repository, IGetAllProyectosOutputPort outputPort)
        {
            _repository = repository;
            _outputPort = outputPort;
        }

        public async Task Handle(Specification<Proyecto> specification)
        {
            IEnumerable<GetAllProyectosDto> proyectosDto = _repository.GetAll(specification).Select(x => new GetAllProyectosDto
            {
                Id = x.Id,
                Clave = x.Clave,
                FechaAprobacion = x.FechaAprobacion,
                Titulo = x.Titulo,
                IsDeleted = x.IsDeleted,
                Deleted = x.Deleted,
                Notes = x.Notes,
                RowVersion = x.RowVersion,
                Creador = x.Creador,
                FechaCreacion = x.FechaCreacion,
                Modificador = x.Modificador,
                FechaModificacion = x.FechaModificacion,
                IsActive = x.IsActive,
                ResponsablesDemarcacionDto = Mappers.ProyectoMap.ToResponsablesDemarcacionDto(x.ResponsablesDemarcacion)
            }); //.OrderBy(x => x.FechaCreacion);

            await _outputPort.Handle(proyectosDto);
        }

    }
}
