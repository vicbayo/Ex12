using Ex12.Entities.Entities;
using Ex12.Entities.Exceptions;
using Ex12.Entities.Interfaces.Repository.ProyectoRepository;
using Ex12.Entities.Specifications;
using Ex12.RepositoryEFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.RepositoryEFCore.Repositories
{
    public class ProyectoRepo : IProyectoRepo
    {
        readonly Ex12Context _ctx;

        public ProyectoRepo(Ex12Context ctx)
        {
            _ctx = ctx;
        }

        public void CrearProyecto(Proyecto proyecto)
        {
            _ctx.Add(proyecto.ResponsablesDemarcacion);
            _ctx.Add(proyecto.Declaracion);
            _ctx.Add(proyecto);
        }

        /// <summary>
        /// Use AsNoTracking
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        public IEnumerable<Proyecto> GetAll( Specification<Proyecto> specification = null)
        {
            if(specification == null ) return _ctx.Proyectos.AsNoTracking();
            return ProjectSpecification(specification);
        }

        public async Task<Proyecto> GetById(Guid Id)
        {
            return await _ctx.Proyectos.FindAsync(Id);
        }

        public void Update(Proyecto proyectoUpdate)
        {
            _ctx.Entry(proyectoUpdate.ResponsablesDemarcacion).State = EntityState.Modified;
            _ctx.ResponsablesDemarcacion.Update(proyectoUpdate.ResponsablesDemarcacion);

            _ctx.Entry(proyectoUpdate).State = EntityState.Modified;
            _ctx.Proyectos.Update(proyectoUpdate);
        }

        public IEnumerable<Proyecto> GetBySpecification(Specification<Proyecto> specification)
        {
            //var expresionDelegate = specification.ToExpression().Compile();
            //return _ctx.Proyectos.Where(expresionDelegate);
            if (specification == null) new GeneralException("No se especificó ninguna especificación");
            return ProjectSpecification(specification);
        }

        private IEnumerable<Proyecto> ProjectSpecification(Specification<Proyecto> specification)
        {
            var includes = specification.ToIncludes();

            if (includes == null) return _ctx.Proyectos.AsNoTracking().Where(specification.ToExpression());

            IQueryable<Proyecto> query = _ctx.Set<Proyecto>().AsQueryable();

            foreach (var include in includes) { query = query.Include(include); }

            if (specification.ToOrderBy() == null && specification.ToOrderByDescending() == null)
                return query.Where(specification.ToExpression()).AsNoTracking();

            if (specification.ToOrderByDescending() != null)
                return query.Where(specification.ToExpression()).OrderByDescending(specification.ToOrderByDescending()).AsNoTracking();

            return query.Where(specification.ToExpression()).OrderBy(specification.ToOrderBy()).AsNoTracking();
        }
    }
}
