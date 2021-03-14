using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class InvoiceOutLine
    {
        [Key]
        [Required]
        public int InvoiceOutLineId { get; set; }
        [Required]
        public int InvoiceOutId { get; set; }
        public InvoiceOut InvoiceOut { get; set; }
        [Required]
        public int ExpenceId { get; set; }
        public Expence Expence { get; set; }
        [Required]
        public int InvoiceOutLineQuantity { get; set; }
        [Required]
        public decimal InvoiceOutLinePrice { get; set; }
        [Required]
        public decimal InvoiceOutLineTotal { get; set; }
        [Required]
        public bool InvoiceOutLineStatus { get; set; }
    }
}
