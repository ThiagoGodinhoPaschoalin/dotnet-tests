using SharedDomain.Configurations;
using System.Data;
using System.Data.SqlClient;

namespace DapperSharedStandard.Configurations
{
    public static class GetNewConnections
    {
        public static IDbConnection SqlServer(string strintConnection = null)
            => new SqlConnection(strintConnection ?? GlobalConstants.STRING_CONNECTION);
    }
}