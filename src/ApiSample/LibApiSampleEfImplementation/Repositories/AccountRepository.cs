using LibApiSampleAbstraction.Repositories;
using LibApiSampleEfImplementation.Contexts;
using Microsoft.EntityFrameworkCore;
using SharedDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibApiSampleEfImplementation.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAppDbContext app;

        public AccountRepository(IAppDbContext app)
        {
            this.app = app;
        }

        public async Task AddAsync(AccountModel model)
        {
            await app.Context.Accounts.AddAsync(model);
        }

        public void Delete(AccountModel model)
        {
            app.Context.Accounts.Remove(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            var model = await app.Context.Accounts.FindAsync(id);
            if(model != null)
                app.Context.Accounts.Remove(model);
        }

        public async Task<IEnumerable<AccountModel>> GetAllAsync()
            => await app.Context.Accounts.ToListAsync();

        public async Task<AccountModel> GetAsync(Guid id)
            => await app.Context.Accounts.FindAsync(id);

        public async Task<bool> ExistsAsync(Expression<Func<AccountModel, bool>> expression)
            => await app.Context.Accounts.AnyAsync(expression);

        public async Task<IEnumerable<AccountModel>> GetManyAsync(Expression<Func<AccountModel, bool>> expression)
            => await app.Context.Accounts.Where(expression).ToListAsync();

        public async Task<AccountModel> GetWithAggregateAsync(Guid id)
            => await app.Context.Accounts
            .Include(x => x.Profiles).ThenInclude(x => x.Profile)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}