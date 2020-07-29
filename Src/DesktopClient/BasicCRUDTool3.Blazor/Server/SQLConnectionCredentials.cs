using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCRUDTool3.Blazor.Server
{
    public class SQLConnectionCredentials : ISQLConnectionCredentials
    {
        #region Public Properties
        public string Password { get; set; } = "Password12!";
        public string UserID { get; set; } = "postgres";
        public string Database { get; set; } = "CRUDTestDB";
        public string Host { get; set; } = "localhost";
        #endregion
    }
}