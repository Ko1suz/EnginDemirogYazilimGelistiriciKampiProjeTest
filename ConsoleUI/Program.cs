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
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByPrice(5,10))
            {
                //Console.WriteLine("CategoryID = "+product.CategoryID +" ProductName = " +product.ProductName);
                Console.WriteLine(" ProductName = " +product.ProductName+ "--- Product Price = " + product.Price);
                Console.WriteLine("zort");
            }

            Console.ReadLine();
        }
    }
}