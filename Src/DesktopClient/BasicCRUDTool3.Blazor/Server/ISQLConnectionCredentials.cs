using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCRUDTool3.Blazor.Server
{
    public interface ISQLConnectionCredentials
    {
        #region Public Properties
        public string Password { get; set; }
        public string UserID { get; set; }
        public string Database { get; set; }
        public string Host { get; set; }
        #endregion
    }
}
