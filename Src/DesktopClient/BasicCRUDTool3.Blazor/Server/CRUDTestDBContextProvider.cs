using BasicCRUDTool3.Data.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data.SqlClient;
using System.Security;

namespace BasicCRUDTool3.Blazor.Server
{
    public class CRUDTestDBContextProvider : ICRUDTestDBContextProvider
    {
        private readonly ISQLConnectionCredentials sQLConnectionCredentials;
        public CRUDTestDBContextProvider(ISQLConnectionCredentials sQLConnectionCredentials)
        {
            this.sQLConnectionCredentials = sQLConnectionCredentials;
        }
        public CRUDTestDBContext GetContext()
        {
            NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder
            {
                Database = sQLConnectionCredentials.Database,
                Host = sQLConnectionCredentials.Host,
                Password = sQLConnectionCredentials.Password,
                Username = sQLConnectionCredentials.UserID
            };




            var option = new DbContextOptionsBuilder<CRUDTestDBContext>()
                .UseNpgsql(new NpgsqlConnection(builder.ConnectionString))
                .UseLazyLoadingProxies();

            return new CRUDTestDBContext(option.Options);
        }
    }
}
