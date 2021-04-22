using Ef5Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using SharedDomain.Models;
using SharedDomain.Models.Associative;
using System.Collections.Generic;

namespace EntityFrameworkTest50.Builder
{
    public static class Builders
    {
        public static ApplicationDbContext GetNewInMemoryContext()
        {
            DbContextOptionsBuilder builder = new();
            builder.UseInMemoryDatabase(databaseName: "dotnet_tests");
            builder.EnableDetailedErrors();
            return new ApplicationDbContext(builder.Options);
        }

        public static void SeedData(ApplicationDbContext context)
        {
            context.Accounts.AddRange(GetAccounts);
            context.Profiles.AddRange(GetProfiles);
            context.GetAssociativeAccountProfile.AddRange(GetAssociativeAccountProfiles);

            context.SaveChanges();
        }

        public static IEnumerable<AccountModel> GetAccounts 
            => SharedDomain.Configurations.SeedData.GetAccounts();

        public static IEnumerable<ProfileModel> GetProfiles
            => SharedDomain.Configurations.SeedData.GetProfiles();

        public static IEnumerable<AccountProfile> GetAssociativeAccountProfiles
            => SharedDomain.Configurations.SeedData.GetAssociativeAccountProfiles();
    }
}