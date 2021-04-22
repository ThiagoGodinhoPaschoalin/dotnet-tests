using System;
using System.Threading.Tasks;

namespace LibApiSampleAbstraction.Contexts
{
    public interface IBusinessContext : IDisposable
    {
        Task BeginTransactionAsync();
        Task RoolbackTransactionAsync();
        Task CommitTransactionAsync();
    }
}