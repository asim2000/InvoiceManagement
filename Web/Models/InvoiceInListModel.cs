using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class InvoiceInListModel
    {
        public InvoiceInModel InvoiceInModel { get; set; }
        public List<InvoiceInLineModel> InvoiceInLineModels { get; set; }

    }
}
