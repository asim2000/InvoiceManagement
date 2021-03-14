using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete
{
    public class EfInvoiceOutDal:EfEntityRepositoryBase<InvoiceOut,OfficeContext>,IInvoiceOutDal
    {
    }
}
