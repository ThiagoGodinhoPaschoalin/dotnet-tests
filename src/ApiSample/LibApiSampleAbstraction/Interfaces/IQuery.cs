using System.Threading.Tasks;

namespace LibApiSampleAbstraction.Interfaces
{
    public interface IQueryOut<TResponse>
    {
        Task<TResponse> ExecuteAsync();
    }

    public interface IQueryIn<in TRequest>
    {
        Task ExecuteAsync(TRequest request);
    }

    public interface IQuery<in TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}