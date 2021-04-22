using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibApiSampleAbstraction.Interfaces
{
    public interface IRepository<TModel>
    {
        Task<TModel> GetAsync(Guid id);
        Task<TModel> GetWithAggregateAsync(Guid id);
        Task<bool> ExistsAsync(Expression<Func<TModel, bool>> expression);
        Task<IEnumerable<TModel>> GetManyAsync(Expression<Func<TModel, bool>> expression);
        Task<IEnumerable<TModel>> GetAllAsync();

        Task AddAsync(TModel model);
        void Delete(TModel model);
        Task DeleteAsync(Guid id);
    }
}