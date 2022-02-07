using Ex12.Dtos.ProyectosDtos;
using Ex12.Entities.Entities;
using Ex12.Entities.Interfaces;
using Ex12.Entities.Interfaces.Repository.ProyectoRepository;
using Ex12.UseCasesPort.ProyectosPort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.UseCases.ProyectosUseCases.UpdateProyecto
{
    //debe implemetar el imput port, que recibe del controlador
    public class UpdateProyectoInteractor : IUpdateProyectoInputPort
    {
        readonly IProyectoRepo _repository;
        readonly IUnitOfWork _unitOfWork;
        readonly IUpdateProyectoOutputPort _outputPort;

        public UpdateProyectoInteractor(IProyectoRepo repository, IUnitOfWork unitOfWork, IUpdateProyectoOutputPort outputPort)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
        }

        public async Task Handle(UpdateProyectoDto proyectoDto)
        {
            //TODO: Hay que hacer primero la acción del controlador para el GetById
            Proyecto proyectoDb = await _repository.GetById(proyectoDto.Id);  // hay que poner el AsNoTracking()
            if(proyectoDb == null)
            {
                //el proyecto no existe, o fue eliminado por otro usuario
                
            }
            else
            {
                proyectoDb.Id = proyectoDto.Id;
                proyectoDb.Clave = proyectoDto.Clave;
                proyectoDb.FechaAprobacion = proyectoDto.FechaAprobacion;
                proyectoDb.Titulo = proyectoDto.Titulo;
                proyectoDb.IsDeleted = proyectoDb.IsDeleted;
                proyectoDb.Deleted = proyectoDb.Deleted;
                proyectoDb.Notes = proyectoDto.Notes;
                proyectoDb.Creador = "UpdateProyectoInteractor";
                proyectoDb.FechaModificacion = DateTime.Now;
                proyectoDb.Modificador = "yo";
                proyectoDb.RowVersion = proyectoDto.RowVersion;
                proyectoDb.ResponsablesDemarcacion = Mappers.ProyectoMap.ToResponsablesDemarcacion( proyectoDto.ResponsablesDemarcacionDto);

                _repository.Update(proyectoDb);

                await _unitOfWork.SaveChangesAsync();

                await _outputPort.Handle(proyectoDb.Id);
            }
        }
    }
}
