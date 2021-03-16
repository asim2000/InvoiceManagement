using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class InvoiceOutSaveModel
    {
        [Required]
        public int InvoiceOutId { get; set; }
        [Required]
        public string InvoiceOutNo { get; set; }
        [Required]
        public DateTime InvoiceOutDate { get; set; }
        [Required]
        public int FirmId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public bool InvoiceOutStatus { get; set; }

        public int InvoiceOutLineId { get; set; }
        [Required]
        public int ExpenceId { get; set; }
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
