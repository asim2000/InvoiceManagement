using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class InvoiceOutInvoiceOutLineModel
    {
        public List<InvoiceOutLineModel> InvoiceOutLines { get; set; }
        public InvoiceOutModel InvoiceOut { get; set; }
    }
}
