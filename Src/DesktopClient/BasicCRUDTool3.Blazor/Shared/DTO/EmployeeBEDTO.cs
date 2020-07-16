using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Blazor.Shared.DTO
{
    public class EmployeeBEDTO
    {
        #region Public Properties
        public int Id { get; set; }
        public string CustomerFirstName { get;  set; }
        public string CustomerLastName { get;  set; }
        public int? CustomerID { get;  set; }
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public decimal Total { get; set; }
        public int InvoiceLineCount { get;  set; }
        #endregion
    }
}
