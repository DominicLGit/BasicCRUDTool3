using BasicCRUDTool3.Data.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data.SqlClient;
using System.Security;

namespace BasicCRUDTool3.Windows
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
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                InitialCatalog = sQLConnectionCredentials.Database,
                DataSource = sQLConnectionCredentials.Host,
                Password = sQLConnectionCredentials.Password,
                UserID = sQLConnectionCredentials.UserID
            };


            var option = new DbContextOptionsBuilder<CRUDTestDBContext>()
                .UseNpgsql(new NpgsqlConnection(builder.ConnectionString))
                .UseLazyLoadingProxies();

            return new CRUDTestDBContext(option.Options);
        }
    }
}
