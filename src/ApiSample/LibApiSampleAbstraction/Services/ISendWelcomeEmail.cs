using LibApiSampleAbstraction.Services.Dtos;
using System.Threading.Tasks;

namespace LibApiSampleAbstraction.Services
{
    public interface ISendWelcomeEmail
    {
        Task<bool> ToSendAsync(SendWelcomeEmailRequest request);
    }
}