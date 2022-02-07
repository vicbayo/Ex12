using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Entities.Specifications
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();  // { get; }

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> ExpresionDelegate = ToExpression().Compile();
            return ExpresionDelegate(entity);
        }

        public virtual List<Expression<Func<T, object>>> ToIncludes()
        {
            return null;
        }

        public virtual Expression<Func<T, object>> ToOrderBy()
        {
            return null;
        }

        public virtual Expression<Func<T, object>> ToOrderByDescending()
        {
            return null;
        }

        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }
        public Specification<T> Not(Specification<T> specification)
        {
            return new NotSpecification<T>(this);
        }
    }
}
