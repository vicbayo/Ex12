using Ex12.Presenters;
using Ex12.RepositoryEFCore;
using Ex12.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddEx12Services(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositoriesServices(configuration);
            services.AddUsesCasesServices();
            services.AddPresentersServices();
            return services;
        }
    }
}
