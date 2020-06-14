using BasicCRUDTool3.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security;
using System.Text;

namespace BasicCRUDTool3.WPFDesktop
{
    public class CRUDTestDBContextProvider : ICRUDTestDBContextProvider
    {
        #region Public Properties
        public SecureString SecurePassword { private get; set; }
        public string UserID { get; set; }
        public string Database { get; set; }
        public string Host { get; set; }
        #endregion

        //TODO: Move these to LoginViewModel


        public CRUDTestDBContext GetContext()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                InitialCatalog = Database,
                DataSource = Host
            };


            var option = new DbContextOptionsBuilder<CRUDTestDBContext>()
                .UseNpgsql(new SqlConnection(builder.ConnectionString, new SqlCredential(UserID, SecurePassword)));

            return new CRUDTestDBContext(option.Options);
        }
    }
}
