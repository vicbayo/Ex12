using Ex12.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Entities.Specifications.Proyectos
{
    public class ProyectosIsActiveSpec : Specification<Proyecto>
    {
        public override Expression<Func<Proyecto, bool>> ToExpression()
        {
            return x => x.IsActive == true;
        }

        public override List<Expression<Func<Proyecto, object>>> ToIncludes()
        {
            List<Expression<Func<Proyecto, object>>> includes = new List<Expression<Func<Proyecto, object>>>();
            includes.Add(x => x.ResponsablesDemarcacion);
            return includes;
        }

        public override Expression<Func<Proyecto, object>> ToOrderBy()
        {
            return x => x.FechaCreacion;
        }
    }
}
