using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Entities.Specifications
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();

            ParameterExpression paramExpr = Expression.Parameter(typeof(T));
            BinaryExpression exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);

            var finalExpr = Expression.Lambda<Func<T, bool>> (exprBody, paramExpr);

            return finalExpr;
        }

        /// <summary>
        /// Suma los includes de las dos especificaciones. No añade includes iguales
        /// </summary>
        /// <returns></returns>
        public override List<Expression<Func<T, object>>> ToIncludes()
        {
            List<Expression<Func<T, object>>> result = new List<Expression<Func<T, object>>>();
            result.AddRange(_left.ToIncludes());
            foreach (var item in _right.ToIncludes())
            {
                bool find = false;

                foreach (var include in result)
                {
                    if (item.Body.ToString() == include.Body.ToString()) find = true;
                }
                if (find == false) result.Add(item);
            }
            return result;
        }

        /// <summary>
        /// Devuelve el OrderBy del elemento de la izquierda, no teniendo en cuenta el de la derecha
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<T, object>> ToOrderBy()
        {
            return _left.ToOrderBy();
        }

        /// <summary>
        /// Devuelve el OrderByDescending del elemento de la izquierda, no teniendo en cuenta el de la derecha
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<T, object>> ToOrderByDescending()
        {
            return _left.ToOrderByDescending();
        }

    }

}
