using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Abstract
{
    public interface IInvoiceOutDal:IEntityRepository<InvoiceOut>
    {
        void Update(InvoiceOut entity);
    }
}
