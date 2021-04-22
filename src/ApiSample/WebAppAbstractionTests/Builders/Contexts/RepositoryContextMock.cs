using Ef5Domain.Contexts;
using LibApiSampleAbstraction.Contexts;

namespace WebAppAbstractionTests.Builders.Contexts
{
    public interface IRepositoryContextMock : IRepositoryBaseContext<ApplicationDbContext>
    { }

    public class RepositoryContextMock : IRepositoryContextMock
    {
        private readonly ApplicationDbContext context;

        public RepositoryContextMock(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ApplicationDbContext Context => this.context;
    }
}