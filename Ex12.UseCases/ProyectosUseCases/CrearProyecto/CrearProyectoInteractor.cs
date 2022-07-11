using Ex12.Dtos.ProyectosDtos;
using Ex12.Entities.Entities;
using Ex12.Entities.Exceptions;
using Ex12.Entities.Interfaces;
using Ex12.Entities.Interfaces.Repository.ProyectoRepository;
using Ex12.UseCases.Common.Validators;
using Ex12.UseCasesPort.ProyectosPort;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex12.UseCases.ProyectosUseCases.CrearProyecto
{
    //debe implemetar el imput port, que recibe del controlador
    public class CrearProyectoInteractor : ICrearProyectoInputPort
    {
        readonly IProyectoRepo _repository;
        readonly IUnitOfWork _unitOfWork;
        readonly ICrearProyectoOutputPort _outputPort;
        readonly IEnumerable<IValidator<CrearProyectoDto>> _validators;

        public CrearProyectoInteractor(IProyectoRepo repository, IUnitOfWork unitOfWork, 
            ICrearProyectoOutputPort outputPort, IEnumerable<IValidator<CrearProyectoDto>> validators)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
            _validators = validators;
        }

        public async Task Handle(CrearProyectoDto proyectoDto)
        {
            await Validator<CrearProyectoDto>.Validate(proyectoDto, _validators);

            ResponsablesDemarcacion NuevoResponsablesDemarcacion = new ResponsablesDemarcacion
            {
                Id = Guid.NewGuid(),
                JefeDemarcacion = proyectoDto.CrearResponsablesDemarcacionDto.JefeDemarcacion,
                IngenerioCircumbalacion = proyectoDto.CrearResponsablesDemarcacionDto.IngenieroCircumbalacion,
                PeritoDemarcacion = proyectoDto.CrearResponsablesDemarcacionDto.PeritoDemarcacion,
                RepresentanteDemarcacion = proyectoDto.CrearResponsablesDemarcacionDto.RepresentanteDemarcacion,
                IngenieroJefeArea = proyectoDto.CrearResponsablesDemarcacionDto.IngenieroJefeArea,
                IngenieroJefe = proyectoDto.CrearResponsablesDemarcacionDto.IngenieroJefe,
                Pagador = proyectoDto.CrearResponsablesDemarcacionDto.Pagador
            };

            Declaracion NuevaDeclaracion = new Declaracion();

            if(proyectoDto.CrearDeclaracionDto != null)
            {
                NuevaDeclaracion.Id = NuevoResponsablesDemarcacion.Id;
                NuevaDeclaracion.Descripcion = proyectoDto.CrearDeclaracionDto.Descripcion;
                NuevaDeclaracion.FechaDeclaracion = proyectoDto.CrearDeclaracionDto.FechaDeclaracion;
                NuevaDeclaracion.Ley = proyectoDto.CrearDeclaracionDto.Ley;
                NuevaDeclaracion.FechaLey = proyectoDto.CrearDeclaracionDto.FechaLey;
                NuevaDeclaracion.Articulo = proyectoDto.CrearDeclaracionDto.Articulo;
                NuevaDeclaracion.NumeroBOE = proyectoDto.CrearDeclaracionDto.NumeroBOE;
                NuevaDeclaracion.FechaBOE = proyectoDto.CrearDeclaracionDto.FechaBOE;
                NuevaDeclaracion.ReferenciaBOE = proyectoDto.CrearDeclaracionDto.ReferenciaBOE;
            }


            Proyecto NuevoProyecto = new Proyecto
            {
                Id = NuevoResponsablesDemarcacion.Id, //Guid.NewGuid(),
                Clave = proyectoDto.Clave,
                FechaAprobacion = proyectoDto.FechaAprobacion,
                Titulo = proyectoDto.Titulo,
                IsDeleted = false,
                Deleted = null,
                Notes = proyectoDto.Notes,
                Creador = "CrearProyectoInteractor",
                FechaCreacion = DateTime.Now,
                ResponsablesDemarcacion = NuevoResponsablesDemarcacion,
                Declaracion = NuevaDeclaracion
            };

            _repository.CrearProyecto(NuevoProyecto);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new GeneralException("Error al crear el proyecto");
            }

            await _outputPort.Handle(NuevoProyecto.Id);
        }

    }
}
