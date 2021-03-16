using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Abstract
{
    public interface IInvoiceInLineDal:IEntityRepository<InvoiceInLine>
    {
        void Update(InvoiceInLine entity);
    }
}
