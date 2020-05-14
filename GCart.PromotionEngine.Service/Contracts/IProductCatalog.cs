using System;
using System.Collections.Generic;
using System.Text;

namespace GCart.PromotionEngine.Service.Contracts
{
    public interface IProductCatalog
    {
        void AddProduct(Char product, double price);
        IDictionary<char, double> FindProducts();
        KeyValuePair<Char,double> FindProduct(Char product);
        double GetPrice(Char product);
    }
}
