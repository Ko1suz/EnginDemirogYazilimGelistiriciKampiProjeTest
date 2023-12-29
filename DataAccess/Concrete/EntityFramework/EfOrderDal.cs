using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntitiyRepositoryBase<Order, NorthwindContext>, IOrderDal
    {

    }
}
