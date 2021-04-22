//using LibApiSampleAbstraction.Contexts;
//using LibApiSampleAbstraction.Repositories;
//using SharedDomain.Configurations;
//using SharedDomain.Models;
//using SharedDomain.Models.Enums;
//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using WebAppAbstractionTests.Builders;
//using WebAppAbstractionTests.Builders.Contexts;
//using WebAppAbstractionTests.Builders.Repositories;
//using Xunit;

//namespace WebAppAbstractionTests
//{
//    public class AccountRepositoryTests
//    {
//        private IRepositoryContextMock Repository { get; }
//        private IBusinessContext Business { get; }
//        private IAccountRepository Account { get; }

//        public AccountRepositoryTests()
//        {
//            Repository = Build.RepositoryContext();
//            Business = Build.BusinessContext(Repository);
//            Account = new AccountRepMock(Repository);

//            Build.SeedData(Repository.Context);
//        }

//        [Fact]
//        public async Task NovaConta_UsuarioAindaNaoExiste_DeveCadastrarComSucesso()
//        {
//            var newAccount = new AccountModel("Assane", "Diop", GenderType.Male, "LUPIN", "diop@lupin.fr");

//            await Account.AddAsync(newAccount);
//            await Business.CommitTransactionAsync();

//            Assert.Equal(Build.GetAccounts.Count() + 1, Repository.Context.Accounts.Count());
//        }

//        [Fact]
//        public async Task ObterConta_UsuarioQueJaExiste_DeveObterComSucesso()
//        {
//            var existingAccount = Build.GetAccounts.First();
//            var getAccount = await Account.GetAsync(existingAccount.Id);

//            Assert.Equal(existingAccount.Document, getAccount.Document);
//        }

//        [Fact]
//        public async Task ObterConta_UsuarioQueNaoExiste_DeveRetornarNulo()
//        {
//            var getAccount = await Account.GetAsync(Guid.NewGuid());

//            Assert.Null(getAccount);
//        }

//        [Fact]
//        public async Task ObterTodasConta_RecuperarTodasAsContasDoBanco_DeveRetornarTodos()
//        {
//            var getAccount = await Account.GetAllAsync();

//            Assert.Equal(Build.GetAccounts.Count(), getAccount.Count());
//        }

//        [Fact]
//        public async Task ObterAlgumasConta_PesquisarPeloNomeDaConta_DeveRetornarAListaRequerida()
//        {
//            var names = new[] { SeedData.Andre.FirstName, SeedData.Debora.FirstName };

//            var getAccount = await Account.GetManyAsync(x => names.Contains(x.FirstName));
            
//            Assert.Equal(2, getAccount.Count());
//            Assert.Contains(getAccount, x => names.Contains(x.FirstName));
//        }
//    }
//}