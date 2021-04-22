//using Ef5Domain.Contexts;
//using LibApiSampleAbstraction.Contexts;
//using Microsoft.EntityFrameworkCore;
//using SharedDomain.Models;
//using SharedDomain.Models.Associative;
//using System.Collections.Generic;
//using WebAppAbstractionTests.Builders.Contexts;

//namespace WebAppAbstractionTests.Builders
//{
//    public static class Build
//    {
//        public static IRepositoryContextMock RepositoryContext(ApplicationDbContext context = null)
//            => new RepositoryContextMock(context ?? InMemoryDatabase());

//        public static IBusinessContext BusinessContext(IRepositoryContextMock repository = null)
//            => new BusinessContextMock(repository ?? RepositoryContext());

//        private static ApplicationDbContext InMemoryDatabase()
//        {
//            DbContextOptionsBuilder builder = new();
//            builder.UseInMemoryDatabase(databaseName: "dotnet_tests");
//            builder.EnableDetailedErrors();
//            return new ApplicationDbContext(builder.Options);
//        }

//        public static void SeedData(ApplicationDbContext context)
//        {
//            context.Accounts.RemoveRange(context.Accounts);
//            context.Accounts.AddRange(GetAccounts);

//            context.Profiles.RemoveRange(context.Profiles);
//            context.Profiles.AddRange(GetProfiles);

//            context.GetAssociativeAccountProfile.RemoveRange(context.GetAssociativeAccountProfile);
//            context.GetAssociativeAccountProfile.AddRange(GetAssociativeAccountProfiles);

//            try
//            {
//                context.SaveChanges();
//            }
//            catch (System.ArgumentException ex)
//            {
//                ///Mais do que um teste sendo executado com SeedData no construtor;
//                if(!ex.Message.Contains("An item with the same key has already been added"))
//                {
//                    throw;
//                }
//            }
//            catch(System.Exception)
//            {
//                throw;
//            }
//        }

//        public static IEnumerable<AccountModel> GetAccounts
//            => SharedDomain.Configurations.SeedData.GetAccounts();

//        public static IEnumerable<ProfileModel> GetProfiles
//            => SharedDomain.Configurations.SeedData.GetProfiles();

//        public static IEnumerable<AccountProfile> GetAssociativeAccountProfiles
//            => SharedDomain.Configurations.SeedData.GetAssociativeAccountProfiles();
//    }
//}