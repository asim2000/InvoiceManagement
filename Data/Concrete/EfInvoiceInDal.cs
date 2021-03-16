using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Concrete
{
    public class EfInvoiceInDal:EfEntityRepositoryBase<InvoiceIn,OfficeContext>,IInvoiceInDal
    {
        public void Update(InvoiceIn entity)
        {
            using (var context=new OfficeContext())
            {
                var invoiceIn = context.T_InvoiceIn.SingleOrDefault(i=>i.InvoiceInId==entity.InvoiceInId);
                invoiceIn.InvoiceInNo = entity.InvoiceInNo;
                invoiceIn.UserId = entity.UserId;
                invoiceIn.FirmId = entity.FirmId;
                invoiceIn.InvoiceInDate = entity.InvoiceInDate;
                invoiceIn.InvoiceInStatus = entity.InvoiceInStatus;
                context.SaveChanges();
            }
        }
    }
}
