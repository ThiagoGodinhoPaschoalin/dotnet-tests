using LibApiSampleAbstraction.Services;
using LibApiSampleAbstraction.Services.Dtos;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LibApiSampleEfImplementation.Services
{
    public class CreateNewOccurrence : ICreateNewOccurrence
    {
        private readonly ILogger<CreateNewOccurrence> logger;

        public CreateNewOccurrence(ILogger<CreateNewOccurrence> logger)
        {
            this.logger = logger;
        }

        public Task ExecuteAsync(NewOccurrenceRequest request)
        {
            logger.LogInformation("Toda regra de negócio para criar uma nova ocorrência está aqui!");
            return Task.CompletedTask;
        }
    }
}