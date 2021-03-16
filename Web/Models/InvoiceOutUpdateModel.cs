using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class InvoiceOutUpdateModel
    {
        public InvoiceOut InvoiceOut { get; set; }
        public InvoiceOutLine InvoiceOutLine { get; set; }
    }
}
