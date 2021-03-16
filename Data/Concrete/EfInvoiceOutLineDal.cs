using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Concrete
{
    public class EfInvoiceOutLineDal:EfEntityRepositoryBase<InvoiceOutLine,OfficeContext>,IInvoiceOutLineDal
    {
        public void Update(InvoiceOutLine entity)
        {
            using (var context = new OfficeContext())
            {
                var invoiceOutLine = context.T_InvoiceOutLine.SingleOrDefault(i => i.InvoiceOutLineId == entity.InvoiceOutLineId);
                invoiceOutLine.ExpenceId = entity.ExpenceId;
                invoiceOutLine.InvoiceOutLineQuantity = entity.InvoiceOutLineQuantity;
                invoiceOutLine.InvoiceOutLinePrice = entity.InvoiceOutLinePrice;
                invoiceOutLine.InvoiceOutLineTotal = entity.InvoiceOutLineTotal;
                invoiceOutLine.InvoiceOutLineStatus = entity.InvoiceOutLineStatus;
                context.SaveChanges();
            }
        }
    }
}
