using Ex12.Dtos.ProyectosDtos;
using Ex12.UseCases.Common.Validators;
using Ex12.UseCases.ProyectosUseCases.CrearProyecto;
using Ex12.UseCases.ProyectosUseCases.GetAllProyectos;
using Ex12.UseCases.ProyectosUseCases.GetByIdProyecto;
using Ex12.UseCases.ProyectosUseCases.UpdateProyecto;
using Ex12.UseCasesPort.ProyectosPort;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUsesCasesServices(this IServiceCollection services)
        {
            //services.AddMediatR(typeof(CrearProyectoInteractor));

            //services.AddMediatR(typeof(GetAllProyectosInteractor));
            //services.AddMediatR(typeof(GetByIdProyectoInteractor));


            services.AddValidatorsFromAssembly(typeof(CrearProyectoValidator).Assembly);
            services.AddScoped<ICrearProyectoInputPort, CrearProyectoInteractor>();
            services.AddScoped<IGetAllProyectosInputPort, GetAllProyectosInteractor>();
            services.AddScoped<IGetByIdProyectoInputPort, GetByIdProyectoInteractor>();
            services.AddScoped<IUpdateProyectoInputPort, UpdateProyectoInteractor>();

            return services;
        }
    }
}
