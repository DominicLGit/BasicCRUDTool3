using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BasicCRUDTool3.Business
{
    public class InvoiceBE : BusinessEntity<Invoice, int>,
        IAssignToBusinessEntity<CustomerBE>
    {
        #region Public Properties
        public string CustomerFirstName { get; private set; }
        public string CustomerLastName { get; private set; }
        public DateTime InvoiceDate { get; set; }
        [StringLength(70)]
        public string BillingAddress { get; set; }
        [StringLength(40)]
        public string BillingCity { get; set; }
        [StringLength(40)]
        public string BillingState { get; set; }
        [StringLength(40)]
        public string BillingCountry { get; set; }
        [StringLength(10)]
        public string BillingPostalCode { get; set; }
        [Range(0, 9999999999)]
        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal Total { get; set; }
        public int InvoiceLineCount { get; private set; }
        #endregion

        #region Constructors
        public InvoiceBE(ICRUDTestDBContextProvider contextProvider) : base(contextProvider)
        {
        }
        #endregion
        #region Public Methods
        public IEnumerable<InvoiceLineBE> GetInvoiceLines()
        {
            var ids = Context.InvoiceLine.Where(p => p.InvoiceId == Id).Select(p => p.InvoiceLineId);

            foreach (var id in ids)
            {
                var item = new InvoiceLineBE(CRUDTestDBContextProvider);
                item.Load(id);
                yield return item;
            }
        }
        public void AddToInvoiceLine(InvoiceLineBE invoiceLineBE)
        {
            invoiceLineBE.AssignTo(this);
        }

        public void AssignTo(CustomerBE customer)
        {
            Entity.CustomerId = customer.Id;
        }

        public override void Load(int id)
        {
            base.Load(id);
            InvoiceDate = Entity.InvoiceDate;
            BillingAddress = Entity.BillingAddress;
            BillingCity = Entity.BillingCity;
            BillingState = Entity.BillingState;
            BillingCountry = Entity.BillingCountry;
            BillingPostalCode = Entity.BillingPostalCode;
            Total = Entity.Total;
            InvoiceLineCount = Entity.InvoiceLine.Count;
            CustomerFirstName = Entity.Customer?.FirstName;
            CustomerLastName = Entity.Customer?.LastName;
        }

        public override void Save()
        {
            Entity.InvoiceDate = InvoiceDate;
            Entity.BillingAddress = BillingAddress;
            Entity.BillingCity = BillingCity;
            Entity.BillingState = BillingState;
            Entity.BillingCountry = BillingCountry;
            Entity.BillingPostalCode = BillingPostalCode;
            Entity.Total = Total;
            base.Save();

            if (Id == default)
            {
                Id = Entity.InvoiceId;
            }
        }

        public override string ToString()
        {
            return $"Invoice ID: {Id} Customer Name:{CustomerFirstName} {CustomerLastName} Date:{InvoiceDate.ToShortDateString()}";
        }
        #endregion
    }
}
