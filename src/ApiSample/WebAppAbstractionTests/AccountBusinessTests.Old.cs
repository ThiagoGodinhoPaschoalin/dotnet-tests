//using LibApiSampleAbstraction.Businesses;
//using LibApiSampleAbstraction.Contexts;
//using LibApiSampleAbstraction.Repositories;
//using LibApiSampleAbstraction.Services;
//using SharedDomain.Configurations;
//using SharedDomain.Models.Enums;
//using System.Threading.Tasks;
//using WebAppAbstractionTests.Builders;
//using WebAppAbstractionTests.Builders.Businesses;
//using WebAppAbstractionTests.Builders.Contexts;
//using WebAppAbstractionTests.Builders.Repositories;
//using WebAppAbstractionTests.Builders.Services;
//using Xunit;

//namespace WebAppAbstractionTests
//{
//    public class AccountBusinessTests
//    {
//        private IAccountRepository AccountRepository { get; }
//        private IAccountBusiness AccountBusiness { get; }

//        public AccountBusinessTests()
//        {
//            IRepositoryContextMock repository = Build.RepositoryContext();
//            IBusinessContext business = Build.BusinessContext(repository);
//            AccountRepository = new AccountRepMock(repository);
//            IProfileRepository profileRep = new ProfileRepMock(repository);

//            ICreateNewOccurrence occurrence = new OccurrenceSuccessMock();
//            ISendWelcomeEmail email = new SendMailSuccessMock();

//            AccountBusiness = new AccountBsMock(business, AccountRepository, profileRep, occurrence, email);

//            Build.SeedData(repository.Context);
//        }

//        [Fact]
//        public async Task CriarNovaConta_UsuarioAindaNaoExiste_DeveCadastrarComSucesso()
//        {
//            var request = new LibApiSampleAbstraction.Businesses.AccountDtos.CreateNewRequest
//            {
//                FirstName = "Assane",
//                LastName = "Diop",
//                Gender = GenderType.Male,
//                Document = "L.U.P.I.N",
//                Email = "master@lupin.fr",
//                ProfileNames = new[] { SeedData.Professor.Name, SeedData.Gestor.Name }
//            };

//            var result = await AccountBusiness.CreateNewAsync(request);

//            var getNewAccountByRepository = await AccountRepository.GetAsync(result);
//            Assert.Equal(getNewAccountByRepository.FirstName, request.FirstName);
//        }

//        [Fact]
//        public async Task CriarNovaConta_UsuarioJaExiste_DeveDarExcecao()
//        {
//            var request = new LibApiSampleAbstraction.Businesses.AccountDtos.CreateNewRequest
//            {
//                FirstName = SeedData.Thiago.FirstName,
//                LastName = SeedData.Thiago.LastName,
//                Gender = SeedData.Thiago.Gender,
//                Document = SeedData.Thiago.Document,
//                Email = SeedData.Thiago.Email,
//                ProfileNames = new[] { SeedData.Professor.Name, SeedData.Gestor.Name }
//            };
//            ///throw new BusinessException("O documento já existe no sistema. Não é possível criar essa conta.");
//            var result = await AccountBusiness.CreateNewAsync(request);

//            var getNewAccountByRepository = await AccountRepository.GetAsync(result);
//            Assert.Equal(getNewAccountByRepository.FirstName, request.FirstName);
//        }
//    }
//}