using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class InvoiceOutLineModel
    {
        public int Id { get; set; }
        public int ExpenceId { get; set; }
        public Expence Expence { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public bool Status { get; set; }
    }
}
