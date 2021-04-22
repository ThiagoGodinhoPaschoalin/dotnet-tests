using LibApiSampleAbstraction.Services;
using LibApiSampleAbstraction.Services.Dtos;
using System.Threading.Tasks;

namespace WebAppAbstractionTests.Builders.Services
{
    public class OccurrenceSuccessMock : ICreateNewOccurrence
    {
        public Task ExecuteAsync(NewOccurrenceRequest request)
            => Task.CompletedTask;
    }
}