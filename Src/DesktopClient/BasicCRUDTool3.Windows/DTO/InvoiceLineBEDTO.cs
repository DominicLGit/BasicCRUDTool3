using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BasicCRUDTool3.Windows.DTO
{
    public class InvoiceLineBEDTO
    {
        #region Public Properties
        public int Id { get; set; }
        public int? InvoiceId { get; set; }
        public int? TrackId { get; set; }
        public int Quantity { get; set; }
        [Range(0, 9999999999)]
        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$")]
        public decimal UnitPrice { get; set; }
        public string TrackName { get; set; }
        #endregion
    }
}
