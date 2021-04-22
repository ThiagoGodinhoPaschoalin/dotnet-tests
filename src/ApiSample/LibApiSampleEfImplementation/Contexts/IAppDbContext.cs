using Ef5Domain.Contexts;
using LibApiSampleAbstraction.Contexts;

namespace LibApiSampleEfImplementation.Contexts
{
    public interface IAppDbContext : IRepositoryBaseContext<ApplicationDbContext>
    { }

    public class AppDbContext : IAppDbContext
    {
        private readonly ApplicationDbContext context;

        public AppDbContext(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ApplicationDbContext Context => context;
    }
}