using Ex12.Dtos.ProyectosDtos;
using Ex12.Entities.Entities;
using Ex12.Entities.Interfaces;
using Ex12.Entities.Interfaces.Repository.ProyectoRepository;
using Ex12.UseCasesPort.ProyectosPort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex12.UseCases.ProyectosUseCases.GetByIdProyecto
{
    //debe implemetar el imput port, que recibe del controlador
    public class GetByIdProyectoInteractor : IGetByIdProyectoInputPort
    {
        readonly IProyectoRepo _repository;
        readonly IGetByIdProyectoOutputPort _outputPort;

        public GetByIdProyectoInteractor(IProyectoRepo repository, IGetByIdProyectoOutputPort outputPort)
        {
            _repository = repository;
            _outputPort = outputPort;
        }

        public async Task Handle(Guid id)
        {
            ProyectoDto proyectoDto = new ProyectoDto();
            Proyecto proyectoUpdate = await _repository.GetById(id);
            if (proyectoUpdate == null)
            {
                //TODO: El registro ha sido eliminado por otro usuario
            }
            else
            {
                proyectoDto.Id = proyectoUpdate.Id;
                proyectoDto.Clave = proyectoUpdate.Clave;
                proyectoDto.FechaAprobacion = proyectoUpdate.FechaAprobacion;
                proyectoDto.Titulo = proyectoUpdate.Titulo;
                proyectoDto.IsDeleted = proyectoUpdate.IsDeleted;
                proyectoDto.Deleted = proyectoUpdate.Deleted;
                proyectoDto.Notes = proyectoUpdate.Notes;
                proyectoDto.Creador = proyectoUpdate.Creador;
                proyectoDto.FechaCreacion = proyectoUpdate.FechaCreacion;
                proyectoDto.Modificador = proyectoUpdate.Modificador;
                proyectoDto.FechaModificacion = proyectoUpdate.FechaModificacion;
                proyectoDto.IsActive = proyectoUpdate.IsActive;
                proyectoDto.RowVersion = proyectoUpdate.RowVersion;
            }
            await _outputPort.Handle(proyectoDto);
        }
    }
}
