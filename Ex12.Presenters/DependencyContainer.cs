using Ex12.Presenters.ProyectosPresenters;
using Ex12.UseCasesPort.ProyectosPort;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Presenters
{
    public static class DependencyContainer
    {        
        public static IServiceCollection AddPresentersServices( this IServiceCollection services)
        {
            services.AddScoped<ICrearProyectoOutputPort, CrearProyectoPresenter>();
            services.AddScoped<IGetAllProyectosOutputPort, GetAllProyectosPresenter>();
            services.AddScoped<IGetByIdProyectoOutputPort, GetByIdProyectoPresenter>();
            services.AddScoped<IUpdateProyectoOutputPort, UpdateProyectoPresenter>();
            return services;
        }
    }
}
