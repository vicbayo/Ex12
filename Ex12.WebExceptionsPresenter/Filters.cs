using Ex12.Entities.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.WebExceptionsPresenter
{
    public static class Filters
    {
        /// <summary>
        /// Registra las excepciones
        /// </summary>
        /// <param name="options"></param>
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new ApiExceptionFilterAttribute( new Dictionary<Type, IExceptionHandler>
                {
                    { typeof(GeneralException), new GeneralExceptionHandler()},
                    { typeof(ValidationException), new ValidationExceptionHandler()}
                }
            ));
        }
    }
}
