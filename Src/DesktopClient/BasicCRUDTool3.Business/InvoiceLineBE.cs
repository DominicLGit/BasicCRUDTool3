using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class InvoiceLineBE : BusinessEntity<InvoiceLine, int>,
        IAssignToBusinessEntity<TrackBE>
    {
        #region Public Properties
        public int Quantity { get; set; }
        public string TrackName { get; private set; }
        #endregion
        #region Constructors
        public InvoiceLineBE(ICRUDTestDBContextProvider contextProvider) : base(contextProvider)
        {
        }
        #endregion
        #region Public Methods
        public void AssignTo(TrackBE trackBE)
        {
            Entity.TrackId = trackBE.Id;
        }
        public override void Load(int id)
        {

            base.Load(id);

            Quantity = Entity.Quantity;
        }

        public override void Save()
        {
            base.Save();

            if (Id == default)
            {
                Id = Entity.InvoiceLineId;
            }
        }

        public override string ToString()
        {
            return $"Track Name: {TrackName} Quantity: {Quantity}";
        }

        
        #endregion


    }
}
