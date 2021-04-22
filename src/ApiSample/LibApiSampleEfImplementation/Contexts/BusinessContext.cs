using LibApiSampleAbstraction.Contexts;
using System;
using System.Threading.Tasks;

namespace LibApiSampleEfImplementation.Contexts
{
    public class BusinessContext : IBusinessContext
    {
        private readonly IAppDbContext application;

        public BusinessContext(IAppDbContext application)
        {
            this.application = application;
        }

        public async Task BeginTransactionAsync()
        {
            if(application.Context.Database.CurrentTransaction is null)
                await application.Context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (application.Context.Database.CurrentTransaction != null)
            {
                await application.Context.Database.CommitTransactionAsync();
            }
            else
            {
                await application.Context.SaveChangesAsync();
            }
        }

        public async Task RoolbackTransactionAsync()
        {
            if (application.Context.Database.CurrentTransaction != null)
                await application.Context.Database.RollbackTransactionAsync();
        }

        #region disposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
                application.Context?.Dispose();
        }
        ~BusinessContext()
        {
            Dispose(false);
        }
        #endregion
    }
}