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
    /// QuerySingle; 
    /// QuerySingleAsync; 
    /// </summary>
    public class QuerySingleTests
    {
        private readonly IDbConnection dbConnection;

        public QuerySingleTests()
        {
            dbConnection = GetNewConnections.SqlServer();
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarSomenteUmRegistro_Sucesso()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var @Param = new { Names = new[] { "Thiago", "ALUNO" } };

            var resultado = await dbConnection.QuerySingleAsync<AccountModel>(sql, @Param);

            Assert.Equal(SeedData.Thiago.Id, resultado.Id);
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarNenhumRegistro_DeveDarExcecaoPorNaoTerRegistro()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var @Param = new { Names = new[] { "Xpto", "ALUNO" } };

            await Assert.ThrowsAsync<InvalidOperationException>(()
                => dbConnection.QuerySingleAsync<AccountModel>(sql, @Param));
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarMaisDoQueUmResultado_DeveDarExcecaoQuantidade()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var names = SeedData.GetAccounts().Select(x => x.FirstName);
            var @Param = new { Names = names };

            await Assert.ThrowsAsync<InvalidOperationException>(() 
                => dbConnection.QuerySingleAsync<AccountModel>(sql, @Param));
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_ColocarStringAoInvesDoModelo_ExcecaoConversaoDeDados()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var names = SeedData.GetAccounts().Select(x => x.FirstName);
            var @Param = new { Names = names };

            await Assert.ThrowsAsync<DataException>(() 
                => dbConnection.QuerySingleAsync<string>(sql, @Param));
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_ColocarParametroChaveErrada_ExcecaoSql()
        {
            var sql = "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; ";
            var xpto = SeedData.GetAccounts().Select(x => x.FirstName);
            var @Param = new { xpto };

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(()
                => dbConnection.QuerySingleAsync<AccountModel>(sql, @Param));
        }
    }
}