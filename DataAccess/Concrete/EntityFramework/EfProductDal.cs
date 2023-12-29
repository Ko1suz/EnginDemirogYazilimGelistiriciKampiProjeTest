using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : EfEntitiyRepositoryBase<Product,NorthwindContext>, IProductDal
    {
          
    }
}
