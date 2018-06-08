using Edura.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edura.WebUI.Entity;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductRepository
    {
        public EfProductRepository(EduraContext context) : base(context)
        {
        }

        public EduraContext EduraContext
        {
            get { return context as EduraContext; }
        }

        public List<Product> GetTop5Products()
        {
            return EduraContext.Products
                 .OrderByDescending(i => i.ProductId)
                 .Take(5)
                 .ToList();
        }
        public void DeleteProduct(int ProductId)
        {


            var cmd1 = $"delete from Products where ProductId={ProductId}";

             context.Database.ExecuteSqlCommand(cmd1);

        }
        public void AddProductCategory(int ProductId, int CategoryId)
        {


            var cmd1 = $"insert into dbo.ProductCategory(ProductId,CategoryId) Values({ProductId},{CategoryId})";

           int a= context.Database.ExecuteSqlCommand(cmd1);
            context.SaveChanges();

        }
        public void AddProductAttribute(string attribute, string value,  int productId)
        {
            
            var cmd1 = $"insert into dbo.Attributes(Attribute,ProductId,Value) Values('{attribute}',{productId},'{value}')";
            int a = context.Database.ExecuteSqlCommand(cmd1);

            context.SaveChanges();
        }
        public void RemoveFromProduct(int ProductId, int CategoryId)
        {


            var cmd1 = $"delete from ProductCategory where ProductId={ProductId} and  CategoryId={CategoryId}";

            context.Database.ExecuteSqlCommand(cmd1);
            var cmd2 = $" IF NOT EXISTS(SELECT * FROM ProductCategory WHERE ProductId={ProductId}) BEGIN delete from Products where ProductId={ProductId} END";
            int a = context.Database.ExecuteSqlCommand(cmd2);
        }

    }
}
