using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Entities.Specifications
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;

        public NotSpecification(Specification<T> left)
        {
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();

            ParameterExpression paramExpr = Expression.Parameter(typeof(T));
            UnaryExpression unaryExpression = Expression.Not( leftExpression.Body);
            unaryExpression = (UnaryExpression)new ParameterReplacer(paramExpr).Visit(unaryExpression);

            var finalExpr = Expression.Lambda<Func<T, bool>> (unaryExpression, paramExpr);

            return finalExpr;
        }

        public override List<Expression<Func<T, object>>> ToIncludes()
        {
            throw new NotImplementedException();
        }
    }

}
