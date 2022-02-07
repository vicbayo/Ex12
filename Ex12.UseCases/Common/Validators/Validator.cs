using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.UseCases.Common.Validators
{
    //Detiene el flujo cuando no pasa la validacion y devuelve una lista de errores de validación
    /// <summary>
    /// Valida un modelo con los validadores
    /// </summary>
    /// <typeparam name="Model"></typeparam>
    public static class Validator<Model>
    {
        public static Task<List<ValidationFailure>> Validate(Model model, IEnumerable<IValidator<Model>> validators, bool causesException = true)
        {
            var Failures = validators.Select(v => v.Validate(model)).SelectMany(r => r.Errors).Where(f => f != null).ToList();
            if (Failures.Any() && causesException)
            {
                //hay fallos
                throw new ValidationException(Failures);
            }
            return Task.FromResult(Failures);
        }
    }
}
