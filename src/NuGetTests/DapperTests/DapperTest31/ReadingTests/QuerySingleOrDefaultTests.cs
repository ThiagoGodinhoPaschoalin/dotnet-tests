using Dapper;
using DapperSharedStandard.Configurations;
using SharedDomain.Configurations;
using SharedDomain.Models;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DapperTest31.ReadingTests
{
    /// <summary>
    /// QuerySingleOrDefault; 
    /// QuerySingleOrDefaultAsync;
    /// </summary>
    public class QuerySingleOrDefaultTests
    {
        private readonly IDbConnection dbConnection;

        public QuerySingleOrDefaultTests()
        {
            dbConnection = GetNewConnections.SqlServer();
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarSomenteUmRegistro_Sucesso()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var @Param = new { Names = new[] { "Thiago", "ALUNO" } };

            var resultado = await dbConnection.QuerySingleOrDefaultAsync<AccountModel>(sql, @Param);

            Assert.Equal(SeedData.Thiago.Id, resultado.Id);
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarNenhumRegistro_DeveRetornarNulo()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var @Param = new { Names = new[] { "Xpto", "ALUNO" } };

            var resultado = await dbConnection.QuerySingleOrDefaultAsync<AccountModel>(sql, @Param);

            Assert.Null(resultado);
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarMaisDoQueUmResultado_DeveDarExcecaoQuantidade()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var names = SeedData.GetAccounts().Select(x => x.FirstName);
            var @Param = new { Names = names };

            await Assert.ThrowsAsync<InvalidOperationException>(()
                => dbConnection.QuerySingleOrDefaultAsync<AccountModel>(sql, @Param));
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_ColocarStringAoInvesDoModelo_DeveDarExcecaoDeConversao()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var names = SeedData.GetAccounts().Select(x => x.FirstName);
            var @Param = new { Names = names };

            await Assert.ThrowsAsync<DataException>(()
                => dbConnection.QuerySingleOrDefaultAsync<string>(sql, @Param));
        }
    }
}