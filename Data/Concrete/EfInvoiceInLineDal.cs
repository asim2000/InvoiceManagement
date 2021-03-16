using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Concrete
{
    public class EfInvoiceInLineDal:EfEntityRepositoryBase<InvoiceInLine,OfficeContext>,IInvoiceInLineDal
    {
        public void Update(InvoiceInLine entity)
        {
            using (var context = new OfficeContext())
            {
                var invoiceInLine = context.T_InvoiceInLine.SingleOrDefault(i => i.InvoiceInLineId == entity.InvoiceInLineId);
                invoiceInLine.ExpenceId = entity.ExpenceId;
                invoiceInLine.InvoiceInLineQuantity = entity.InvoiceInLineQuantity;
                invoiceInLine.InvoiceInLinePrice = entity.InvoiceInLinePrice;
                invoiceInLine.InvoiceInLineTotal = entity.InvoiceInLineTotal;
                invoiceInLine.InvoiceInLineStatus = entity.InvoiceInLineStatus;
                context.SaveChanges();
            }
        }
    }
}
