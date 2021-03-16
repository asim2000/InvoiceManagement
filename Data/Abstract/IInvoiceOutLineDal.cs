using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Abstract
{
    public interface IInvoiceOutLineDal:IEntityRepository<InvoiceOutLine>
    {
        void Update(InvoiceOutLine entity);
    }
}
