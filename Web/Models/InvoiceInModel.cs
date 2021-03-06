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
        public int FirmId { get; set; }
        public Firm Firm { get; set; }
        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public bool Status { get; set; }

    }
}
