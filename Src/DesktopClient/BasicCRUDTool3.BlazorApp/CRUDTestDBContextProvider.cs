using BasicCRUDTool3.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace BasicCRUDTool3.BlazorApp
{
    public class CRUDTestDBContextProvider //: ICRUDTestDBContextProvider
    {
        #region Public Properties
        public SecureString SecurePassword { private get; set; }
        public string UserID { get; set; }
        public string Database { get; set; }
        public string Host { get; set; }
        #endregion

        //TODO: Modify for Blazor


        //public CRUDTestDBContext GetContext()
        //{
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            //{
            //    InitialCatalog = Database,
            //    DataSource = Host
            //};


            ///var option = new DbContextOptionsBuilder<CRUDTestDBContext>()
            ///    .UseNpgsql(new SqlConnection(builder.ConnectionString, new SqlCredential(UserID, SecurePassword)))
            ///    .UseLazyLoadingProxies();
///
            ///return new CRUDTestDBContext(option.Options);
        //}
    }
}
