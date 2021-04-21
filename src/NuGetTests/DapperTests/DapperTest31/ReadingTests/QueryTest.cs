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
    public class QueryTest
    {
        private readonly IDbConnection dbConnection;

        public QueryTest()
        {
            dbConnection = GetNewConnections.SqlServer();
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarNenhumRegistro_ObterListaVazia()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var @Param = new { Names = new[] { "Xpto", "ALUNO" } };

            var resultado = await dbConnection.QueryAsync<AccountModel>(sql, @Param);

            Assert.Empty(resultado);
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarSomenteUmRegistro_ObterListaComUmResultado()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var @Param = new { Names = new[] { "Thiago", "ALUNO" } };

            var resultado = await dbConnection.QueryAsync<AccountModel>(sql, @Param);

            Assert.Single(resultado);
            Assert.Equal(SeedData.Thiago.Id, resultado.First().Id);
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarMaisDoQueUmResultado_ObterListaDeResultados()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var names = SeedData.GetAccounts().OrderBy(x => x.FirstName).Select(x => x.FirstName);
            var @Param = new { Names = names };

            var resultado = await dbConnection.QueryAsync<AccountModel>(sql, @Param);

            Assert.Equal(names.Count(), resultado.Count());
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_ColocarParametroIgnorandoMaiusculos_ObterListaDeResultados()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var names = SeedData.GetAccounts().Select(x => x.FirstName);
            var @Param = new { names };

            var resultado = await dbConnection.QueryAsync<AccountModel>(sql, @Param);

            Assert.Equal(names.Count(), resultado.Count());
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_ColocarStringAoInvesDoModelo_ExcecaoConversaoDeDados()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var names = SeedData.GetAccounts().Select(x => x.FirstName);
            var @Param = new { Names = names };

            await Assert.ThrowsAsync<DataException>(()
                => dbConnection.QueryAsync<string>(sql, @Param));
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_ColocarParametroChaveErrada_ExcecaoSql()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var xpto = SeedData.GetAccounts().Select(x => x.FirstName);
            var @Param = new { xpto };

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(()
                => dbConnection.QueryAsync<AccountModel>(sql, @Param));
        }
    }
}