using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class InvoiceInInvoiceInLineModel
    {
        public List<InvoiceInLineModel> InvoiceInLine { get; set; }
        public InvoiceInModel InvoiceIn { get; set; }
    }
}
