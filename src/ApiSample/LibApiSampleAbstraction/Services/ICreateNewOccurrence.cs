using LibApiSampleAbstraction.Services.Dtos;
using System.Threading.Tasks;

namespace LibApiSampleAbstraction.Services
{
    public interface ICreateNewOccurrence
    {
        Task ExecuteAsync(NewOccurrenceRequest request);
    }
}