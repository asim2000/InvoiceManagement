using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Concrete
{
    public class EfInvoiceOutDal:EfEntityRepositoryBase<InvoiceOut,OfficeContext>,IInvoiceOutDal
    {
        public void Update(InvoiceOut entity)
        {
            using (var context = new OfficeContext())
            {
                var invoiceOut = context.T_InvoiceOut.SingleOrDefault(i => i.InvoiceOutId == entity.InvoiceOutId);
                invoiceOut.InvoiceOutNo = entity.InvoiceOutNo;
                invoiceOut.UserId = entity.UserId;
                invoiceOut.FirmId = entity.FirmId;
                invoiceOut.InvoiceOutDate = entity.InvoiceOutDate;
                invoiceOut.InvoiceOutStatus = entity.InvoiceOutStatus;
                context.SaveChanges();
            }
        }
    }
}
