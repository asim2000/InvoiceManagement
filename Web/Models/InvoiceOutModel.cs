using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class InvoiceOutModel
    {
        public string InvoiceNo { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string FirmName { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
    }
}
