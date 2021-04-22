using LibApiSampleAbstraction.Services;
using LibApiSampleAbstraction.Services.Dtos;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LibApiSampleEfImplementation.Services
{
    public class SendWelcomeEmail : ISendWelcomeEmail
    {
        private readonly ILogger<SendWelcomeEmail> logger;

        public SendWelcomeEmail(ILogger<SendWelcomeEmail> logger)
        {
            this.logger = logger;
        }

        public Task<bool> ToSendAsync(SendWelcomeEmailRequest request)
        {
            logger.LogInformation("Envio de e-mail de boas-vindas!");
            return Task.FromResult(true);
        }
    }
}