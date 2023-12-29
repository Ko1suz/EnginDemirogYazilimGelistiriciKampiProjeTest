using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine("CategoryName ->" + category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProductDetails())
            {
                //Console.WriteLine("CategoryID = "+product.CategoryID +" ProductName = " +product.ProductName);
                //Console.WriteLine(" ProductName = " + product.ProductName + "--- Product Price = " + product.Price);
                Console.WriteLine("ProductName  = "+ product.ProductName + "\nCategoryName = "+product.CategoryName+"\n");
            }

            Console.ReadLine();
        }
    }
}