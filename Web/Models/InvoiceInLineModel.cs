using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class InvoiceInLineModel
    {
        public int InvoiceInLineId { get; set; }
        public string Expence { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public bool Status { get; set; }
    }
}
