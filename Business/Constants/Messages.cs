using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string Maintancetime = "Sistem Bakımda";
        public static string UnitPriceInvalid = "Girilen fiyat geçersiz";
        public static string ProductCountOfCategoryError = "Bir kategoride maksimum 10 ürün olabilir";
        public static string ProductNameAlredyExists = "Aynı isimli başka bir ürün zaten var";
        public static string CategoryCountExceeded = "Kategori sayısı 15'i geçemez";
        public static string AuthorizationDenied = "Zart";
    }
}
