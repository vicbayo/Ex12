using Ex12.RepositoryEFCore;
using Ex12.RepositoryEFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Ex12.Test.Entities
{
    [TestClass]
    public class ProyectosTest
    {
        ServiceProvider ServiceProvider;
        IServiceCollection Services;
        IConfiguration Configuration;

        public ProyectosTest()
        {
            Services = new ServiceCollection();
            Configuration = new ConfigurationBuilder()
                                    //.AddInMemoryCollection(myConfiguration)
                                    .AddJsonFile("appsettings.json", optional: true)
                                    .Build();

            Services.AddRepositoriesServices(Configuration);

            ServiceProvider = Services.BuildServiceProvider();
        }

        [TestInitialize]
        public void Init()
        {

        }

        [TestCleanup]
        public void End()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            var r1 = Configuration.GetConnectionString("Ex12");

            var c = ServiceProvider.GetRequiredService<Ex12Context>();
            var r = c.Proyectos.Include(x=> x.ResponsablesDemarcacion).Include(x=> x.Declaracion).ToList();
        }

        //public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        //{
        //    return new ConfigurationBuilder()
        //        .SetBasePath(outputPath)
        //        .AddJsonFile("appsettings.json", optional: true)
        //        .AddUserSecrets("e3dfcccf-0cb3-423a-b302-e3e92e95c128")
        //        .AddEnvironmentVariables()
        //        .Build();
        //}
    }
}
