using Dapper;
using DapperSharedStandard.Configurations;
using SharedDomain.Configurations;
using SharedDomain.Models;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DapperTest31.ReadingTests
{
    public class QueryFirstOrDefaultTests
    {
        private readonly IDbConnection dbConnection;

        public QueryFirstOrDefaultTests()
        {
            dbConnection = GetNewConnections.SqlServer();
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarSomenteUmRegistro_Sucesso()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var @Param = new { Names = new[] { "Thiago", "ALUNO" } };

            var resultado = await dbConnection.QueryFirstOrDefaultAsync<AccountModel>(sql, @Param);

            Assert.Equal(SeedData.Thiago.Id, resultado.Id);
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarNenhumRegistro_RetornaNulo()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var @Param = new { Names = new[] { "Xpto", "ALUNO" } };

            var resultado = await dbConnection.QueryFirstOrDefaultAsync<AccountModel>(sql, @Param);
            
            Assert.Null(resultado);
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarMaisDoQueUmResultado_ObterPrimeiroOrdenadoPeloSql()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var names = SeedData.GetAccounts().OrderBy(x => x.FirstName).Select(x => x.FirstName);
            var namesOrderById = SeedData.GetAccounts().OrderBy(x => x.Id).Select(x => x.FirstName);
            var @Param = new { Names = names };

            var resultado = await dbConnection.QueryFirstOrDefaultAsync<AccountModel>(sql, @Param);

            Assert.NotEqual(names.First(), resultado.FirstName);
            Assert.NotEqual(namesOrderById.First(), resultado.FirstName);
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarMaisDoQueUmResultado_ObterPrimeiroOrdenadoPeloNome()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names ORDER BY [FirstName]; ";
            var names = SeedData.GetAccounts().OrderBy(x => x.FirstName).Select(x => x.FirstName);
            var @Param = new { Names = names };

            var resultado = await dbConnection.QueryFirstOrDefaultAsync<AccountModel>(sql, @Param);

            Assert.Equal(names.First(), resultado.FirstName);
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_ColocarStringAoInvesDoModelo_ExcecaoConversaoDeDados()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var names = SeedData.GetAccounts().Select(x => x.FirstName);
            var @Param = new { Names = names };

            await Assert.ThrowsAsync<DataException>(()
                => dbConnection.QueryFirstOrDefaultAsync<string>(sql, @Param));
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_ColocarParametroChaveErrada_ExcecaoSql()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var xpto = SeedData.GetAccounts().Select(x => x.FirstName);
            var @Param = new { xpto };

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(()
                => dbConnection.QueryFirstOrDefaultAsync<AccountModel>(sql, @Param));
        }
    }
}