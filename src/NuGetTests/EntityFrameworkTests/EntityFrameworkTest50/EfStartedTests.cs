using Ef5Domain.Contexts;
using EntityFrameworkTest50.Builder;
using Microsoft.EntityFrameworkCore;
using SharedDomain.Configurations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkTest50
{
    public class EfStartedTests
    {
        private readonly ApplicationDbContext context;

        public EfStartedTests()
        {
            context = Builders.GetNewInMemoryContext();
        }

        [Fact]
        public void ContextoDoEntityFrameworkFoiInstaciadoCorretamente() {
            Assert.NotNull(context);
        }

        [Fact]
        public async Task SemearContextoComDadosEstaticos() {
            Builders.SeedData(context);
            var contas = await context.Accounts.ToListAsync();
            var perfis = await context.Profiles.ToListAsync();
            var agregado = await context .GetAssociativeAccountProfile.ToListAsync();

            Assert.Equal(SeedData.GetAccounts().Count(), contas.Count);
            Assert.Equal(SeedData.GetProfiles().Count(), perfis.Count);
            Assert.Equal(SeedData.GetAssociativeAccountProfiles().Count(), agregado.Count);
        }

        [Fact]
        public async Task CadaMetodoEstaNoSeuMundo() {
            var contas = await context.Accounts.ToListAsync();
            var perfis = await context.Profiles.ToListAsync();
            var agregado = await context.GetAssociativeAccountProfile.ToListAsync();

            Assert.Empty(contas);
            Assert.Empty(perfis);
            Assert.Empty(agregado);
        }
    }
}