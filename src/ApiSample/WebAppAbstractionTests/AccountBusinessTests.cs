using LibApiSampleAbstraction.Exceptions;
using SharedDomain.Configurations;
using SharedDomain.Models.Enums;
using System.Threading.Tasks;
using WebAppAbstractionTests.Builders;
using Xunit;

namespace WebAppAbstractionTests
{
    public class AccountBusinessTests
    {
        [Fact]
        public async Task CriarNovaConta_UsuarioAindaNaoExiste_DeveCadastrarComSucesso()
        {
            var (AccountRepository, AccountBusiness) = new Build().GetNewAccount();

            var request = new LibApiSampleAbstraction.Businesses.AccountDtos.CreateNewRequest
            {
                FirstName = "Assane",
                LastName = "Diop",
                Gender = GenderType.Male,
                Document = "L.U.P.I.N",
                Email = "master@lupin.fr",
                ProfileNames = new[] { SeedData.Professor.Name, SeedData.Gestor.Name }
            };

            var result = await AccountBusiness.CreateNewAsync(request);

            var getNewAccountByRepository = await AccountRepository.GetAsync(result);
            Assert.Equal(getNewAccountByRepository.FirstName, request.FirstName);
        }

        [Fact]
        public async Task CriarNovaConta_UsuarioJaExiste_DeveDarExcecao()
        {
            var (AccountRepository, AccountBusiness) = new Build().GetNewAccount();

            var request = new LibApiSampleAbstraction.Businesses.AccountDtos.CreateNewRequest
            {
                FirstName = SeedData.Thiago.FirstName,
                LastName = SeedData.Thiago.LastName,
                Gender = SeedData.Thiago.Gender,
                Document = SeedData.Thiago.Document,
                Email = SeedData.Thiago.Email,
                ProfileNames = new[] { SeedData.Professor.Name, SeedData.Gestor.Name }
            };

            await Assert.ThrowsAsync<BusinessException>(() => AccountBusiness.CreateNewAsync(request));
        }
    }
}