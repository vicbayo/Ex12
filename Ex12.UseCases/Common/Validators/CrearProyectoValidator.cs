using Ex12.Dtos.ProyectosDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.UseCases.Common.Validators
{
    public class CrearProyectoValidator : AbstractValidator<CrearProyectoDto>
    {
        public CrearProyectoValidator()
        {
            RuleFor(p => p.Clave).NotEmpty().WithMessage("Debe introducir la clave del proyecto");
            RuleFor(p => p.Titulo).NotEmpty().WithMessage("Debe introducir un título");
            RuleFor(p => p.Clave).NotEmpty().MaximumLength(10).WithMessage("Longitud máxima de la clave es de 10 caracteres");
            //RuleFor(p.ReponsablesDemarcacion).Must( r=> r != null && r.Any)).WithMessage("Debe expecificarse lo que sea.....");

        }
    }
}
