using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class CashOut
    {

        [Key]
        [Required]
        public int CashOutId { get; set; }
        [Required]
        public string CashOutNo { get; set; }
        [Required]
        public DateTime CashOutDate { get; set; }
        [Required]
        public int Firm_Id { get; set; }
        public Firm Firm { get; set; }
        [Required]
        public int InvoiceInId { get; set; }
        public InvoiceIn InvoiceIn { get; set; }
        [Required]
        public decimal CashOutTotal { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public bool CashOutStatus { get; set; }
    }
}
