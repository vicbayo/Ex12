using Ex12.Entities.Interfaces;
using Ex12.RepositoryEFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.RepositoryEFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly Ex12Context _ctx;

        public UnitOfWork(Ex12Context ctx)
        {
            _ctx = ctx;
        }
        public Task<int> SaveChangesAsync()
        {
            return _ctx.SaveChangesAsync();
        }
    }
}
