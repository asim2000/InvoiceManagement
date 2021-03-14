using Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class InvoiceInModel
    {
        public int InvoiceId { get; set; }
        [Required]
        public string InvoiceNo { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string FirmName { get; set; }
        [Required]
        public string UserName { get; set; }
        public bool Status { get; set; }

    }
}
