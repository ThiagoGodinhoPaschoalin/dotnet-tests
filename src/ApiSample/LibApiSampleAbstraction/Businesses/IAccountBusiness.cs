using LibApiSampleAbstraction.Businesses.AccountDtos;
using LibApiSampleAbstraction.Contexts;
using LibApiSampleAbstraction.Interfaces;
using LibApiSampleAbstraction.Repositories;
using LibApiSampleAbstraction.Services;
using System;
using System.Threading.Tasks;

namespace LibApiSampleAbstraction.Businesses
{
    public interface IAccountBusiness 
        : IBusiness<CreateNewRequest, UpdateRequest, DeleteRequest, GetRequest, GetResponse>
    { }

    public abstract class AccountBusinessAbstract : IAccountBusiness
    {
        protected readonly IBusinessContext businessContext;
        protected readonly IAccountRepository account;
        protected readonly IProfileRepository profile;
        protected readonly ICreateNewOccurrence occurrence;
        protected readonly ISendWelcomeEmail email;

        protected AccountBusinessAbstract(IBusinessContext businessContext
            , IAccountRepository account
            , IProfileRepository profile
            , ICreateNewOccurrence occurrence
            , ISendWelcomeEmail email)
        {
            this.businessContext = businessContext;
            this.account = account;
            this.profile = profile;
            this.occurrence = occurrence;
            this.email = email;
        }

        public abstract Task<GetResponse> GetAsync(GetRequest request);
        public abstract Task<Guid> CreateNewAsync(CreateNewRequest request);
        public abstract Task<Guid> UpdateAsync(UpdateRequest request);
        public abstract Task<Guid> DeleteAsync(DeleteRequest request);
    }
}