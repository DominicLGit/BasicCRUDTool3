using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicCRUDTool3.Data.Models
{
    public partial class InvoiceLine
    {
        [Key]
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        [Column(TypeName = "numeric(10,2)")]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty("InvoiceLine")]
        public virtual Invoice Invoice { get; set; }
        [ForeignKey(nameof(TrackId))]
        [InverseProperty("InvoiceLine")]
        public virtual Track Track { get; set; }
    }
}
