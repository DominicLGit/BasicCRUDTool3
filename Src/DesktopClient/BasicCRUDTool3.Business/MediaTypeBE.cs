using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class MediaTypeBE : BusinessEntity<MediaType, int>
    {
        #region Constructors
        public MediaTypeBE(ICRUDTestDBContextProvider contextProvider) : base(contextProvider)
        {
        }
        #endregion
    }
}
