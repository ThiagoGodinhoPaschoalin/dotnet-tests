using Ef5Domain.Contexts;
using LibApiSampleAbstraction.Businesses;
using LibApiSampleAbstraction.Contexts;
using LibApiSampleAbstraction.Repositories;
using LibApiSampleAbstraction.Services;
using Microsoft.EntityFrameworkCore;
using WebAppAbstractionTests.Builders.Businesses;
using WebAppAbstractionTests.Builders.Contexts;
using WebAppAbstractionTests.Builders.Repositories;
using WebAppAbstractionTests.Builders.Services;

namespace WebAppAbstractionTests.Builders
{
    public class Build
    {
        public (IAccountRepository, IAccountBusiness) GetNewAccount()
        {
            IRepositoryContextMock repository = RepositoryContext();
            SeedData(repository.Context);
            IBusinessContext business = BusinessContext(repository);
            IAccountRepository AccountRepository = new AccountRepMock(repository);
            IProfileRepository profileRep = new ProfileRepMock(repository);
            ICreateNewOccurrence occurrence = new OccurrenceSuccessMock();
            ISendWelcomeEmail email = new SendMailSuccessMock();
            IAccountBusiness AccountBusiness = new AccountBsMock(business, AccountRepository, profileRep, occurrence, email);

            return (AccountRepository, AccountBusiness);
        }

        public (IAccountRepository, IBusinessContext) GetNewAccountRepository()
        {
            IRepositoryContextMock Repository = RepositoryContext();
            SeedData(Repository.Context);
            IBusinessContext Business = BusinessContext(Repository);
            IAccountRepository AccountRepository = new AccountRepMock(Repository);

            return (AccountRepository, Business);
        }

        private IRepositoryContextMock RepositoryContext(ApplicationDbContext context = null)
            => new RepositoryContextMock(context ?? InMemoryDatabase());

        private IBusinessContext BusinessContext(IRepositoryContextMock repository = null)
            => new BusinessContextMock(repository ?? RepositoryContext());

        private ApplicationDbContext InMemoryDatabase()
        {
            DbContextOptionsBuilder builder = new();
            builder.UseInMemoryDatabase(databaseName: "dotnet_tests");
            builder.EnableDetailedErrors();
            return new ApplicationDbContext(builder.Options);
        }

        private void SeedData(ApplicationDbContext context)
        {
            context.Accounts.RemoveRange(context.Accounts);
            context.Accounts.AddRange(SharedDomain.Configurations.SeedData.GetAccounts());

            context.Profiles.RemoveRange(context.Profiles);
            context.Profiles.AddRange(SharedDomain.Configurations.SeedData.GetProfiles());

            context.GetAssociativeAccountProfile.RemoveRange(context.GetAssociativeAccountProfile);
            context.GetAssociativeAccountProfile
                .AddRange(SharedDomain.Configurations.SeedData.GetAssociativeAccountProfiles());

            try
            {
                context.SaveChanges();
            }
            catch (System.ArgumentException ex)
            {
                ///Mais do que um teste sendo executado com SeedData no construtor;
                if(ex.Message.Contains("An item with the same key has already been added"))
                {
                    throw new System.Exception("A falha está no registro de instância do teste!");
                }

                throw;
            }
            catch(System.Exception)
            {
                throw;
            }
        }
    }
}