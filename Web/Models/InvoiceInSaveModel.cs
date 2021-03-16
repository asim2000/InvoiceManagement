using Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class InvoiceInSaveModel
    {
        public int InvoiceInId { get; set; }
        public string InvoiceInNo { get; set; }
        public DateTime InvoiceInDate { get; set; }
        public int FirmId { get; set; }
        public string UserId { get; set; }
        public bool InvoiceInStatus { get; set; }


        public int InvoiceInLineId { get; set; }
        public int ExpenceId { get; set; }
        public int InvoiceInLineQuantity { get; set; }
        public decimal InvoiceInLinePrice { get; set; }
        public decimal InvoiceInLineTotal { get; set; }
        public bool InvoiceInLineStatus { get; set; }
    }
}
