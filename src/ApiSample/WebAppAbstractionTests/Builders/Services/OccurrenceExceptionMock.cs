using LibApiSampleAbstraction.Exceptions;
using LibApiSampleAbstraction.Services;
using LibApiSampleAbstraction.Services.Dtos;
using System.Threading.Tasks;

namespace WebAppAbstractionTests.Builders.Services
{
    public class OccurrenceExceptionMock : ICreateNewOccurrence
    {
        public Task ExecuteAsync(NewOccurrenceRequest request)
            => throw new BusinessException("Ocorrencia falhou!");
    }
}