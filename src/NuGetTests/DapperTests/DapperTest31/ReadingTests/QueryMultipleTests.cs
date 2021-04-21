using Dapper;
using DapperSharedStandard.Configurations;
using SharedDomain.Models;
using System.Data;
using System.Threading.Tasks;
using Xunit;

namespace DapperTest31.ReadingTests
{
    public class QueryMultipleTests
    {
        private readonly IDbConnection dbConnection;

        public QueryMultipleTests()
        {
            dbConnection = GetNewConnections.SqlServer();
        }

        [Fact]
        public async Task BuscarUmaListaDePessoas_RetornarNenhumRegistro_ObterListaVazia()
        {
            var sql = "" +
                "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; " +
                "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names; " +
                "SELECT * FROM [dbo].[account] WHERE [FirstName] IN @Names;";

            var @Param = new { Names = new[] { "Xpto", "ALUNO" } };

            var resultado = await dbConnection.QueryMultipleAsync(sql, @Param);

            int quantidadeDeResultados = 0;

            while (!resultado.IsConsumed) {
                var queryAsync = await resultado.ReadAsync<AccountModel>();
                quantidadeDeResultados++;
                
                Assert.Empty(queryAsync);
            }

            Assert.Equal(3, quantidadeDeResultados);
        }
    }
}