using Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class InvoiceInUpdateModel
    {
        public InvoiceIn InvoiceIn { get; set; }
        public InvoiceInLine InvoiceInLine { get; set; }
    }
}
