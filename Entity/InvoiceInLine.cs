using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class InvoiceInLine
    {
        [Key]
        public int InvoiceInLineId { get; set; }
        public int InvoiceInId { get; set; }
        public InvoiceIn InvoiceIn { get; set; }
        public int ExpenceId { get; set; }
        public Expence Expence { get; set; }
        public int InvoiceInLineQuantity { get; set; }
        public decimal InvoiceInLinePrice { get; set; }
        public decimal InvoiceInLineTotal { get; set; }
        public bool InvoiceInLineStatus { get; set; }
    }
}
