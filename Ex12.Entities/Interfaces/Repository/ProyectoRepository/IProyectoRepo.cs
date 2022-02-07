using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex12.Entities.Entities;
using Ex12.Entities.Specifications;

namespace Ex12.Entities.Interfaces.Repository.ProyectoRepository
{
    public interface IProyectoRepo
    {
        void CrearProyecto(Proyecto proyecto);

        /// <summary>
        /// Use AsNoTracking
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        IEnumerable<Proyecto> GetAll(Specification<Proyecto> specification = null);
        Task<Proyecto> GetById(Guid Id);

        void Update(Proyecto proyectoUpdate);
        //IEnumerable<Proyecto> GetBySpecification(Specification<Proyecto> specification);
    }
}
