using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
    }
}
