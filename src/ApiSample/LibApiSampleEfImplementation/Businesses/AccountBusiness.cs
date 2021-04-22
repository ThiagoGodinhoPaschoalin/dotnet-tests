using LibApiSampleAbstraction.Businesses;
using LibApiSampleAbstraction.Businesses.AccountDtos;
using LibApiSampleAbstraction.Contexts;
using LibApiSampleAbstraction.Exceptions;
using LibApiSampleAbstraction.Repositories;
using LibApiSampleAbstraction.Services;
using LibApiSampleAbstraction.Services.Dtos;
using Microsoft.Extensions.Logging;
using SharedDomain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibApiSampleEfImplementation.Businesses
{
    public class AccountBusiness : AccountBusinessAbstract
    {
        private readonly ILogger<AccountBusiness> logger;

        public AccountBusiness(ILogger<AccountBusiness> logger
            , IBusinessContext businessContext
            , IAccountRepository account
            , IProfileRepository profile
            , ICreateNewOccurrence occurrence
            , ISendWelcomeEmail email) 
            : base(businessContext, account, profile, occurrence, email)
        {
            this.logger = logger;
        }

        public override async Task<Guid> CreateNewAsync(CreateNewRequest request)
        {
            if(await account.ExistsAsync(x => x.Document == request.Document))
            {
                throw new BusinessException("O documento já existe no sistema. Não é possível criar essa conta.");
            }

            var accountModel = new AccountModel(
                request.FirstName
                , request.LastName
                , request.Gender
                , request.Document
                , request.Email);

            if (request.ProfileNames.Any())
                accountModel.AddProfiles(await profile.GetIdsAsync(x => request.ProfileNames.Any(p => x.Name.Equals(p))));

            await account.AddAsync(accountModel);

            await occurrence.ExecuteAsync(new NewOccurrenceRequest("NewAccount", "Novo usuário foi criado."));

            await email.ToSendAsync(new SendWelcomeEmailRequest("http://xpto", "Bem-vindo", "thiago@godinho.com", request.Email));

            await businessContext.CommitTransactionAsync();

            return accountModel.Id;
        }

        public override Task<Guid> DeleteAsync(DeleteRequest request)
        {
            throw new NotImplementedException();
        }

        public override async Task<GetResponse> GetAsync(GetRequest request)
            => new GetResponse(await account.GetWithAggregateAsync(request.AccountId));

        public override Task<Guid> UpdateAsync(UpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}