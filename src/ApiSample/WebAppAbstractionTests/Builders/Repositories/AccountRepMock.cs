using LibApiSampleAbstraction.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAppAbstractionTests.Builders.Contexts;

namespace WebAppAbstractionTests.Builders.Repositories
{
    public class AccountRepMock : IAccountRepository
    {
        private readonly IRepositoryContextMock repository;

        public AccountRepMock(IRepositoryContextMock repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync(AccountModel model)
        {
            await repository.Context.Accounts.AddAsync(model);
        }

        public void Delete(AccountModel model)
        {
            repository.Context.Accounts.Remove(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            var model = await repository.Context.Accounts.FindAsync(id);
            if (model != null)
                repository.Context.Accounts.Remove(model);
        }

        public async Task<IEnumerable<AccountModel>> GetAllAsync()
            => await repository.Context.Accounts.ToListAsync();

        public async Task<AccountModel> GetAsync(Guid id)
            => await repository.Context.Accounts.FindAsync(id);

        public async Task<bool> ExistsAsync(Expression<Func<AccountModel, bool>> expression)
            => await repository.Context.Accounts.Where(expression).AnyAsync();

        public async Task<IEnumerable<AccountModel>> GetManyAsync(Expression<Func<AccountModel, bool>> expression)
            => await repository.Context.Accounts.Where(expression).ToListAsync();

        public async Task<AccountModel> GetWithAggregateAsync(Guid id)
            => await repository.Context.Accounts
            .Include(x => x.Profiles).ThenInclude(x => x.Profile)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}