using Ef5Domain.Contexts;
using Microsoft.EntityFrameworkCore;

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
            context.Accounts
                .AddRange(SharedDomain.Configurations.SeedData.GetAccounts());

            context.Profiles
                .AddRange(SharedDomain.Configurations.SeedData.GetProfiles());

            context.GetAssociativeAccountProfile
                .AddRange(SharedDomain.Configurations.SeedData.GetAssociativeAccountProfiles());

            context.SaveChanges();
        }
    }
}