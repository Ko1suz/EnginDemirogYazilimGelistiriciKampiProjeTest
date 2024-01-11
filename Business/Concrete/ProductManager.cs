using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.CrossCuttingConcernsTest;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Buisness;
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
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BuisnessRules.Run(
                CheckProductCount(product),
                CheckSameNameProducts(product),
                CheckCategoryCount(product),
                CheckCategoryCount()
                ); ;
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded + " " + product.ProductName);
        }

        //[Cache Aspect] // key , value
        [CacheAspect]
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

        [CacheAspect]
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


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckProductCount(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryID == product.CategoryID).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckSameNameProducts(Product product) 
        {
            var result = _productDal.GetAll(p => p.ProductName == product.ProductName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlredyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckCategoryCount(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryID > 15).Any();
            if (result)
            {
                return new ErrorResult(Messages.CategoryCountExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckCategoryCount()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryCountExceeded);
            }
            return new SuccessResult();
        }
    }
}
