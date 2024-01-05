using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded + product.ProductName);
        }

        public IDataResult<List<Product>> GetAll()
        {
            // İş kodları
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<Product>>(Messages.Maintancetime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryID)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=> p.CategoryID == categoryID));
        }

        public IDataResult<Product> GetByID(int productID)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productID));
        }

        public IDataResult<List<Product>> GetByPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.Price >= min && p.Price <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour > 22)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.Maintancetime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
