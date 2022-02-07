using Ex12.Dtos.ProyectosDtos;
using Ex12.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Mappers
{
    public static class ProyectoMap
    {
        /// <summary>
        /// Transforma proyecto a proyectoDto
        /// </summary>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        public static ProyectoDto ToProyectoDto( Proyecto proyecto)
        {
            ResponsablesDemarcacionDto rd = new ResponsablesDemarcacionDto 
            {
                Id = proyecto.ResponsablesDemarcacion.Id,
                JefeDemarcacion = proyecto.ResponsablesDemarcacion.JefeDemarcacion,
                IngenieroCircumbalacion = proyecto.ResponsablesDemarcacion.IngenerioCircumbalacion,
                PeritoDemarcacion = proyecto.ResponsablesDemarcacion.PeritoDemarcacion,
                RepresentanteDemarcacion = proyecto.ResponsablesDemarcacion.RepresentanteDemarcacion,
                IngenieroJefeArea = proyecto.ResponsablesDemarcacion.IngenieroJefeArea,
                IngenieroJefe = proyecto.ResponsablesDemarcacion.IngenieroJefe,
                Pagador = proyecto.ResponsablesDemarcacion.Pagador,
            };

            ProyectoDto proyectoDto = new ProyectoDto
            {
                Id = proyecto.Id,
                Clave = proyecto.Clave,
                FechaAprobacion = proyecto.FechaAprobacion,
                Titulo = proyecto.Titulo,
                IsDeleted = proyecto.IsDeleted,
                Deleted = proyecto.Deleted,
                Notes = proyecto.Notes,
                RowVersion = proyecto.RowVersion,
                Creador = proyecto.Creador,
                FechaCreacion = proyecto.FechaCreacion,
                Modificador = proyecto.Modificador,
                FechaModificacion = proyecto.FechaModificacion,
                IsActive = proyecto.IsActive,
                ResponsablesDemarcacionDto = rd
            };
            return proyectoDto;
        }

        /// <summary>
        /// Transforma ResponsablesDemarcacion a ResponsablesDemarcacionDto
        /// </summary>
        /// <param name="responsablesDemarcacion"></param>
        /// <returns></returns>
        public static ResponsablesDemarcacionDto ToResponsablesDemarcacionDto(ResponsablesDemarcacion responsablesDemarcacion)
        {
            if (responsablesDemarcacion == null) return null;

            ResponsablesDemarcacionDto rd = new ResponsablesDemarcacionDto
            {
                Id = responsablesDemarcacion.Id,
                JefeDemarcacion = responsablesDemarcacion.JefeDemarcacion,
                IngenieroCircumbalacion = responsablesDemarcacion.IngenerioCircumbalacion,
                PeritoDemarcacion = responsablesDemarcacion.PeritoDemarcacion,
                RepresentanteDemarcacion = responsablesDemarcacion.RepresentanteDemarcacion,
                IngenieroJefeArea = responsablesDemarcacion.IngenieroJefeArea,
                IngenieroJefe = responsablesDemarcacion.IngenieroJefe,
                Pagador = responsablesDemarcacion.Pagador,
            };
            return rd;
        }

        /// <summary>
        /// Transforma ResponsablesDemarcacionDto a ResponsablesDemarcacion
        /// </summary>
        /// <param name="responsablesDemarcacion"></param>
        /// <returns></returns>
        public static ResponsablesDemarcacion ToResponsablesDemarcacion(ResponsablesDemarcacionDto responsablesDemarcacionDto)
        {
            if (responsablesDemarcacionDto == null) return null;

            ResponsablesDemarcacion rd = new ResponsablesDemarcacion
            {
                Id = responsablesDemarcacionDto.Id,
                JefeDemarcacion = responsablesDemarcacionDto.JefeDemarcacion,
                IngenerioCircumbalacion = responsablesDemarcacionDto.IngenieroCircumbalacion,
                PeritoDemarcacion = responsablesDemarcacionDto.PeritoDemarcacion,
                RepresentanteDemarcacion = responsablesDemarcacionDto.RepresentanteDemarcacion,
                IngenieroJefeArea = responsablesDemarcacionDto.IngenieroJefeArea,
                IngenieroJefe = responsablesDemarcacionDto.IngenieroJefe,
                Pagador = responsablesDemarcacionDto.Pagador,
            };
            return rd;
        }

        /// <summary>
        /// Transforma proyectoDto a proyecto
        /// </summary>
        /// <param name="proyectoDto"></param>
        /// <returns></returns>
        public static Proyecto ToProyecto(ProyectoDto proyectoDto)
        {
            ResponsablesDemarcacion rd = new ResponsablesDemarcacion
            {
                Id = proyectoDto.ResponsablesDemarcacionDto.Id,
                JefeDemarcacion = proyectoDto.ResponsablesDemarcacionDto.JefeDemarcacion,
                IngenerioCircumbalacion = proyectoDto.ResponsablesDemarcacionDto.IngenieroCircumbalacion,
                PeritoDemarcacion = proyectoDto.ResponsablesDemarcacionDto.PeritoDemarcacion,
                RepresentanteDemarcacion = proyectoDto.ResponsablesDemarcacionDto.RepresentanteDemarcacion,
                IngenieroJefeArea = proyectoDto.ResponsablesDemarcacionDto.IngenieroJefeArea,
                IngenieroJefe = proyectoDto.ResponsablesDemarcacionDto.IngenieroJefe,
                Pagador = proyectoDto.ResponsablesDemarcacionDto.Pagador,
            };

            Proyecto proyecto = new Proyecto
            {
                Id = proyectoDto.Id,
                Clave = proyectoDto.Clave,
                FechaAprobacion = proyectoDto.FechaAprobacion,
                Titulo = proyectoDto.Titulo,
                IsDeleted = proyectoDto.IsDeleted,
                Deleted = proyectoDto.Deleted,
                Notes = proyectoDto.Notes,
                RowVersion = proyectoDto.RowVersion,
                Creador = proyectoDto.Creador,
                FechaCreacion = proyectoDto.FechaCreacion,
                Modificador = proyectoDto.Modificador,
                FechaModificacion = proyectoDto.FechaModificacion,
                IsActive = proyectoDto.IsActive,
                ResponsablesDemarcacion = rd
            };
            return proyecto;
        }

        /// <summary>
        /// Transforma una lista de proyecto en una de proyectoDto
        /// </summary>
        /// <param name="proyectos"></param>
        /// <returns></returns>
        public static IEnumerable<ProyectoDto> ToProyectoDtos(IEnumerable<Proyecto> proyectos)
        {
            List<ProyectoDto> proyectoDtos = new List<ProyectoDto>();
            foreach (var item in proyectos)
            {
                proyectoDtos.Add(ToProyectoDto(item));
            }
            return proyectoDtos;
        }

        /// <summary>
        /// Transforma una lista de proyectoDto en una de proyecto
        /// </summary>
        /// <param name="proyectos"></param>
        /// <returns></returns>
        public static IEnumerable<Proyecto> ToProyectos(IEnumerable<ProyectoDto> proyectoDtos)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            foreach (var item in proyectoDtos)
            {
                proyectos.Add(ToProyecto(item));
            }
            return proyectos;
        }
    }
}
