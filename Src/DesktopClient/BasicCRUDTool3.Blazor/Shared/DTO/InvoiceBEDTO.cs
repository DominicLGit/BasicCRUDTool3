using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BasicCRUDTool3.Blazor.Shared.DTO
{
    public class InvoiceBEDTO
    {
        #region Public Properties
        public int Id { get; set; }
        public string CustomerFirstName { get;  set; }
        public string CustomerLastName { get;  set; }
        public int? CustomerID { get;  set; }
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
        public int InvoiceLineCount { get;  set; }
        #endregion
    }
}
