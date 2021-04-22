using LibApiSampleAbstraction.Services;
using LibApiSampleAbstraction.Services.Dtos;
using System.Threading.Tasks;

namespace WebAppAbstractionTests.Builders.Services
{
    public class SendMailSuccessMock : ISendWelcomeEmail
    {
        public Task<bool> ToSendAsync(SendWelcomeEmailRequest request)
            => Task.FromResult(true);
    }
}