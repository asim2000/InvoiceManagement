using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class InvoiceIn
    {
        [Key]
        public int InvoiceInId { get; set; }
        public string InvoiceInNo { get; set; }
        public DateTime InvoiceInDate { get; set; }
        public int FirmId{ get; set; }
        public Firm Firm { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public bool InvoiceInStatus { get; set; }
        public List<InvoiceInLine> InvoiceInLines { get; set; }
    }
}
