using LibApiSampleAbstraction.Interfaces;
using SharedDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibApiSampleAbstraction.Repositories
{
    public interface IProfileRepository : IRepository<ProfileModel>
    {
        Task<IEnumerable<Guid>> GetIdsAsync(Expression<Func<ProfileModel, bool>> expression);
    }
}