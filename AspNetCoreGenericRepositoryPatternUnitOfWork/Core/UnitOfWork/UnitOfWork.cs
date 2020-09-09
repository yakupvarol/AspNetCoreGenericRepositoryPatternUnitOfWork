using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Core.UnitOfWork
{
    public class UnitOfWork<Tcontext> : IUnitOfWork<Tcontext> where Tcontext : DbContext
    {
        public Tcontext Context { get; }

        public UnitOfWork(Tcontext context) => Context = context;

        public int Save() => Context.SaveChanges();
        public async Task<int> SaveAsync() => await Context.SaveChangesAsync();

        public bool Commit()
        {
            bool returnValue = true;
            BeginTransaction();
            try
            {
                Context.SaveChanges();
                CommitTransaction();
            }
            catch (Exception ex)
            {
                //Log Exception Handling message (ex, ex.InnerException.Message, ex.Message)    
                returnValue = false;
                RollbackTransaction();
            }

            return returnValue;
        }
        public async Task<bool> CommitAsync()
        {
            bool returnValue = true;
            BeginTransaction();
            try
            {
                await Context.SaveChangesAsync();
                CommitTransaction();
            }
            catch
            {
                //Log Exception Handling message (ex, ex.InnerException.Message, ex.Message)    
                returnValue = false;
                RollbackTransaction();
            }
            return returnValue;
        }
        public void BeginTransaction() => Context.Database.BeginTransaction();
        public void CommitTransaction() => Context.Database.CommitTransaction();
        public void RollbackTransaction() => Context.Database.RollbackTransaction();
        public void DisposeTransaction() => Context.Database.CurrentTransaction.Dispose();
        public void Dispose() => Context.Dispose();

        
        /*
        
        public void Rollback()
        {
            Context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        */
    }
}
