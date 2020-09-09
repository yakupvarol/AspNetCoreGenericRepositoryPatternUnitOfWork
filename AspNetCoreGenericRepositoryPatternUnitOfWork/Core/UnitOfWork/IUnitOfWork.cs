using Eco.Persistence.Connection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Core.UnitOfWork
{
    public interface IUnitOfWork<TContext> :  IDisposable where TContext : DbContext
    {
        TContext Context { get; }
        int Save();
        Task<int> SaveAsync();
        bool Commit();
        Task<bool> CommitAsync();
    }
}
