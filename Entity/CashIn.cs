using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class CashIn
    {
        [Key]
        [Required]
        public int CashInId { get; set; }
        [Required]
        public string CashInNo { get; set; }
        [Required]
        public DateTime CashInDate { get; set; }
        [Required]
        public int Firm_Id { get; set; }
        public Firm Firm { get; set; }
        [Required]
        public int InvoiceOutId { get; set; }
        public InvoiceOut InvoiceOut { get; set; }
        [Required]
        public decimal CshInTotal { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public bool CashInStatus { get; set; }
    }
}