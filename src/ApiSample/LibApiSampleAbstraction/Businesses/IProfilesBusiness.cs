using LibApiSampleAbstraction.Businesses.ProfileDtos;
using LibApiSampleAbstraction.Contexts;
using LibApiSampleAbstraction.Interfaces;
using LibApiSampleAbstraction.Repositories;
using LibApiSampleAbstraction.Services;
using System;
using System.Threading.Tasks;

namespace LibApiSampleAbstraction.Businesses
{
    public interface IProfilesBusiness
        : IBusiness<CreateNewRequest, UpdateRequest, DeleteRequest, GetRequest, GetResponse>
    { }

    public abstract class ProfileBusinessAbstract : IProfilesBusiness
    {
        private readonly IBusinessContext businessContext;
        private readonly IAccountRepository account;
        private readonly ICreateNewOccurrence occurrence;
        private readonly ISendWelcomeEmail email;

        protected ProfileBusinessAbstract(IBusinessContext businessContext
            , IAccountRepository account
            , ICreateNewOccurrence occurrence
            , ISendWelcomeEmail email)
        {
            this.businessContext = businessContext;
            this.account = account;
            this.occurrence = occurrence;
            this.email = email;
        }

        public abstract Task<Guid> CreateNewAsync(CreateNewRequest request);
        public abstract Task<Guid> DeleteAsync(DeleteRequest request);
        public abstract Task<GetResponse> GetAsync(GetRequest request);
        public abstract Task<Guid> UpdateAsync(UpdateRequest request);
    }
}