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
    public class ProfileRepMock : IProfileRepository
    {
        private readonly IRepositoryContextMock repository;

        public ProfileRepMock(IRepositoryContextMock repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync(ProfileModel model)
        {
            await repository.Context.Profiles.AddAsync(model);
        }

        public void Delete(ProfileModel model)
        {
            repository.Context.Profiles.Remove(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            var model = await repository.Context.Profiles.FindAsync(id);
            if (model != null)
                repository.Context.Profiles.Remove(model);
        }

        public async Task<IEnumerable<ProfileModel>> GetAllAsync()
            => await repository.Context.Profiles.ToListAsync();

        public async Task<ProfileModel> GetAsync(Guid id)
            => await repository.Context.Profiles.FindAsync(id);

        public async Task<bool> ExistsAsync(Expression<Func<ProfileModel, bool>> expression)
            => await repository.Context.Profiles.AnyAsync(expression);

        public async Task<IEnumerable<ProfileModel>> GetManyAsync(Expression<Func<ProfileModel, bool>> expression)
            => await repository.Context.Profiles.Where(expression).ToListAsync();

        public async Task<ProfileModel> GetWithAggregateAsync(Guid id)
            => await repository.Context.Profiles
            .Include(x => x.Accounts).ThenInclude(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Guid>> GetIdsAsync(Expression<Func<ProfileModel, bool>> expression)
            => await repository.Context.Profiles.Where(expression).Select(x => x.Id).ToListAsync();
    }
}