using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class InvoiceOut
    {
        [Key]
        public int InvoiceOutId { get; set; }
        public string InvoiceOutNo { get; set; }
        public DateTime InvoiceOutDate { get; set; }
        public int FirmId { get; set; }
        public Firm Firm { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public bool InvoiceOutStatus { get; set; }
        public List<InvoiceOutLine> InvoiceOutLines { get; set; }
    }
}
