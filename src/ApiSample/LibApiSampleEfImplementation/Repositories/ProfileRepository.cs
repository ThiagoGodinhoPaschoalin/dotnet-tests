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
    public class ProfileRepository : IProfileRepository
    {
        private readonly IAppDbContext app;

        public ProfileRepository(IAppDbContext app)
        {
            this.app = app;
        }

        public async Task AddAsync(ProfileModel model)
        {
            await app.Context.Profiles.AddAsync(model);
        }

        public void Delete(ProfileModel model)
        {
            app.Context.Profiles.Remove(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            var model = await app.Context.Profiles.FindAsync(id);
            if (model != null)
                app.Context.Profiles.Remove(model);
        }

        public async Task<IEnumerable<ProfileModel>> GetAllAsync()
            => await app.Context.Profiles.ToListAsync();

        public async Task<ProfileModel> GetAsync(Guid id)
            => await app.Context.Profiles.FindAsync(id);

        public async Task<bool> ExistsAsync(Expression<Func<ProfileModel, bool>> expression)
            => await app.Context.Profiles.AnyAsync(expression);

        public async Task<IEnumerable<ProfileModel>> GetManyAsync(Expression<Func<ProfileModel, bool>> expression)
            => await app.Context.Profiles.Where(expression).ToListAsync();

        public async Task<ProfileModel> GetWithAggregateAsync(Guid id)
            => await app.Context.Profiles
            .Include(x => x.Accounts).ThenInclude(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Guid>> GetIdsAsync(Expression<Func<ProfileModel, bool>> expression)
            => await app.Context.Profiles.Where(expression).Select(x => x.Id).ToListAsync();
    }
}