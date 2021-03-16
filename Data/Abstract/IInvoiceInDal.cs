﻿using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Abstract
{
    public interface IInvoiceInDal:IEntityRepository<InvoiceIn>
    {
        void Update(InvoiceIn entity);
    }
}
