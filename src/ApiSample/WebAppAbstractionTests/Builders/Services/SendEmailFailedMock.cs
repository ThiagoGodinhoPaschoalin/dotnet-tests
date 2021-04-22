using LibApiSampleAbstraction.Services;
using LibApiSampleAbstraction.Services.Dtos;
using System.Threading.Tasks;

namespace WebAppAbstractionTests.Builders.Services
{
    public class SendEmailFailedMock : ISendWelcomeEmail
    {
        public Task<bool> ToSendAsync(SendWelcomeEmailRequest request)
            => Task.FromResult(false);
    }
}