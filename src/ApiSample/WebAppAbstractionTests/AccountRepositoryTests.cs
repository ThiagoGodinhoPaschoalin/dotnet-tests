using SharedDomain.Configurations;
using SharedDomain.Models;
using SharedDomain.Models.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebAppAbstractionTests.Builders;
using Xunit;

namespace WebAppAbstractionTests
{
    public class AccountRepositoryTests
    {
        [Fact]
        public async Task NovaConta_UsuarioAindaNaoExiste_DeveCadastrarComSucesso()
        {
            var (AccountRepository, BusinessContext) = new Build().GetNewAccountRepository();

            var newAccount = new AccountModel("Assane", "Diop", GenderType.Male, "LUPIN", "diop@lupin.fr");

            await AccountRepository.AddAsync(newAccount);
            await BusinessContext.CommitTransactionAsync();
            int countActual = (await AccountRepository.GetAllAsync()).Count();

            Assert.Equal(SeedData.GetAccounts().Count() + 1, countActual);
        }

        [Fact]
        public async Task ObterConta_UsuarioQueJaExiste_DeveObterComSucesso()
        {
            var (AccountRepository, BusinessContext) = new Build().GetNewAccountRepository();

            var existingAccount = SeedData.GetAccounts().First();
            var getAccount = await AccountRepository.GetAsync(existingAccount.Id);

            Assert.Equal(existingAccount.Document, getAccount.Document);
        }

        [Fact]
        public async Task ObterConta_UsuarioQueNaoExiste_DeveRetornarNulo()
        {
            var (AccountRepository, BusinessContext) = new Build().GetNewAccountRepository();

            var getAccount = await AccountRepository.GetAsync(Guid.NewGuid());

            Assert.Null(getAccount);
        }

        [Fact]
        public async Task ObterTodasConta_RecuperarTodasAsContasDoBanco_DeveRetornarTodos()
        {
            var (AccountRepository, BusinessContext) = new Build().GetNewAccountRepository();

            var getAccount = await AccountRepository.GetAllAsync();

            Assert.Equal(SeedData.GetAccounts().Count(), getAccount.Count());
        }

        [Fact]
        public async Task ObterAlgumasConta_PesquisarPeloNomeDaConta_DeveRetornarAListaRequerida()
        {
            var (AccountRepository, BusinessContext) = new Build().GetNewAccountRepository();
            var names = new[] { SeedData.Andre.FirstName, SeedData.Debora.FirstName };

            var getAccount = await AccountRepository.GetManyAsync(x => names.Contains(x.FirstName));
            
            Assert.Equal(2, getAccount.Count());
            Assert.Contains(getAccount, x => names.Contains(x.FirstName));
        }
    }
}