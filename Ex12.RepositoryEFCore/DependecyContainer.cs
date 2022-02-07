using Ex12.Entities.Interfaces;
using Ex12.Entities.Interfaces.Repository.ProyectoRepository;
using Ex12.RepositoryEFCore.Context;
using Ex12.RepositoryEFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.RepositoryEFCore
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddRepositoriesServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Devuelve siempre el mismo contexto por cada peticion
            services.AddDbContext<Ex12Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Ex12")), ServiceLifetime.Scoped);
            services.AddScoped<IProyectoRepo, ProyectoRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
