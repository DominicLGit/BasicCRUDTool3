using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class InvoiceLineBE : BusinessEntity<InvoiceLine, int>
    {
        #region Public Properties
        public string TrackName { get; private set; }
        #endregion
        #region Constructors
        public InvoiceLineBE(ICRUDTestDBContextProvider contextProvider) : base(contextProvider)
        {
        }
        #endregion


    }
}
