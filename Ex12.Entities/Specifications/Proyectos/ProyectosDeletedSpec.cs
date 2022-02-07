using Ex12.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Entities.Specifications.Proyectos
{
    public class ProyectosDeletedSpec : Specification<Proyecto>
    {
        public override Expression<Func<Proyecto, bool>> ToExpression()
        {
            return x => x.IsDeleted == true;
        }
    }
}
