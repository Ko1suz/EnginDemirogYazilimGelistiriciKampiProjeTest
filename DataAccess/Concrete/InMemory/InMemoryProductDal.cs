using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product {ProductID =1,CategoryID= 1,ProductName= "Bardak",Price = 15,Unit= "15", },
                new Product {ProductID =2,CategoryID= 1,ProductName= "Kamera",Price = 500,Unit= "3", },
                new Product {ProductID =3,CategoryID= 2,ProductName= "Telefon",Price = 1500,Unit= "2", },
                new Product {ProductID =4,CategoryID= 2,ProductName= "Klavye",Price = 150,Unit= "65", },
                new Product {ProductID =5,CategoryID= 2,ProductName= "Fare",Price = 85,Unit= "1", },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Foreach gbi listede ki tüm elemanları dolaşıyor gibi
           
            Product productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            #region Üstteki kodun eş değer kodu
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            #endregion
            _products.Remove(productToDelete);

        }
        public void Update(Product product)
        {
            //Delete yazdıgım aynı mantık
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductID = product.ProductID;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.Price = product.Price;
            productToUpdate.Unit = product.Unit;
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=> p.CategoryID == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> fiter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> fiter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
