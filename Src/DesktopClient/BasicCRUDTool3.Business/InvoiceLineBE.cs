using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class InvoiceLineBE : BusinessEntity<InvoiceLine, int>,
        IAssignToBusinessEntity<TrackBE>,
        IAssignToBusinessEntity<InvoiceBE>
    {
        #region Public Properties
        public int Quantity { get; set; }
        [Range(0, 9999999999)]
        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal UnitPrice { get; set; }
        public string TrackName { get; private set; }
        #endregion
        #region Constructors
        public InvoiceLineBE(ICRUDTestDBContextProvider contextProvider) : base(contextProvider)
        {
        }
        #endregion
        #region Public Methods
        public void AssignTo(TrackBE track)
        {
            Entity.TrackId = track.Id;
        }

        public void AssignTo(InvoiceBE invoice)
        {
            Entity.InvoiceId = invoice.Id;
        }
        public override void Load(int id)
        {

            base.Load(id);

            Quantity = Entity.Quantity;
            UnitPrice = Entity.UnitPrice;
            TrackName = Entity.Track?.Name;
        }

        public override void Save()
        {
            Entity.Quantity = Quantity;
            Entity.UnitPrice = UnitPrice;
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
