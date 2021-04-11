using Ef5Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharedDomain.Configurations;
using System;

namespace Ef5Domain
{
    public static class DiServices
    {
        public static void UsarEf5DomainComMemoria(this IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationDbContext>( (provider, options) =>
            {
                options.UseInMemoryDatabase(databaseName: "dotnet_tests");
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
                options.UseLoggerFactory(provider.GetService<ILoggerFactory>());
            });
        }

        public static void UserEf5DomainComSqlServer(this IServiceCollection services, string stringConnection = null)
        {
            services.AddDbContextPool<ApplicationDbContext>((provider, options) =>
            {
                options.UseSqlServer(stringConnection ?? GlobalConstants.STRING_CONNECTION, opts => 
                {
                    opts.CommandTimeout(60);
                    opts.EnableRetryOnFailure(3);
                    ///opts.MigrationsHistoryTable("history", "migrations");
                });
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
                options.UseLoggerFactory(provider.GetService<ILoggerFactory>());
            });
        }
    }

    #region migrations

    abstract class FactoryForSql<T> : IDesignTimeDbContextFactory<T> where T : DbContext {
        public T CreateDbContext(string[] args) {
            var builder = new DbContextOptionsBuilder<T>();
            builder.UseSqlServer(GlobalConstants.STRING_CONNECTION, opt => opt.MigrationsAssembly(typeof(T).Assembly.GetName().Name));
            return (T)Activator.CreateInstance(typeof(T), builder.Options);
        }
    }

    class StartApplicationDbContext : FactoryForSql<ApplicationDbContext> { }

    #endregion
}