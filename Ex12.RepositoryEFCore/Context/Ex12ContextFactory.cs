using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.RepositoryEFCore.Context
{
    //Esta fabrica sólo la utiliza las migraciones, no necesita ser publica, solo se ejecuta en tiempo de diseño para las migraciones
    //Necesario para las tools de entityframework para las migraciones
    public class Ex12ContextFactory : IDesignTimeDbContextFactory<Ex12Context>
    {
        public Ex12Context CreateDbContext(string[] args)
        {
            //Esto sólo vive en tiempo de diseño, en tiempo de ejecución no se utiliza
            //Permite que las migraciones creen y actualicen la base de datos
            var OptionBuilder = new DbContextOptionsBuilder<Ex12Context>();
            OptionBuilder.UseSqlServer("Data Source=DESKTOP-0KSP0VB;Initial Catalog=Ex12;User ID=sa;Password=@reinos$;Connect Timeout=30");
            return new Ex12Context(OptionBuilder.Options);
        }
    }
}
