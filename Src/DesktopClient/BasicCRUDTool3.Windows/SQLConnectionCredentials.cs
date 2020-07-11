using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCRUDTool3.Windows
{
    public class SQLConnectionCredentials : ISQLConnectionCredentials
    {
        #region Public Properties
        public string Password { get; set; }
        public string UserID { get; set; }
        public string Database { get; set; }
        public string Host { get; set; }
        #endregion
    }
}
}
