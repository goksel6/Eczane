using Edura.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetTop5Products();
         void DeleteProduct(int ProductId);
        void AddProductCategory(int ProductId, int CategoryId);
        void AddProductAttribute(string attribute, string value, int productId);
        void RemoveFromProduct(int ProductId, int CategoryId);
    }
}
