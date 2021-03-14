using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete
{
    public class EfExpenceDal:EfEntityRepositoryBase<Expence,OfficeContext>,IExpenceDal
    {
    }
}
