using Ef5Domain;
using LibApiSampleAbstraction.Contexts;
using LibApiSampleAbstraction.Repositories;
using LibApiSampleAbstraction.Services;
using LibApiSampleEfImplementation.Contexts;
using LibApiSampleEfImplementation.Repositories;
using LibApiSampleEfImplementation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibApiSampleEfImplementation
{
    public static class DiServices
    {
        public static void AddEfImplementation(this IServiceCollection services)
        {
            services.AddEf5DomainContextInMemory();

            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IBusinessContext, BusinessContext>();

            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddSingleton<ICreateNewOccurrence, CreateNewOccurrence>();
            services.AddSingleton<ISendWelcomeEmail, SendWelcomeEmail>();
        }
    }
}