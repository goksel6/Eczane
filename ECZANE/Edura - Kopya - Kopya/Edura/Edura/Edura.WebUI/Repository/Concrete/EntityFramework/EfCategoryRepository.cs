﻿using Edura.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edura.WebUI.Entity;
using System.Linq.Expressions;
using Edura.WebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(EduraContext context) : base(context)
        {
        }

        public EduraContext EduraContext
        {
            get { return context as EduraContext; }
        }

        public IEnumerable<CategoryModel> GetAllWithProductCount()
        {
            return GetAll().Select(i => new CategoryModel()
            {
                CategoryId = i.CategoryId,
                CategoryName = i.CategoryName,
                Count = i.ProductCategories.Count()
            });
        }

        public Category GetByName(string name)
        {
            return EduraContext.Categories
                .Where(i => i.CategoryName == name)
                .FirstOrDefault();
        }

        public void RemoveFromCategory(int ProductId, int CategoryId)
        {
        
           
            var cmd1 = $"delete from ProductCategory where ProductId={ProductId} and  CategoryId={CategoryId}";
            
           context.Database.ExecuteSqlCommand(cmd1);
            var cmd2 = $" IF NOT EXISTS(SELECT * FROM ProductCategory WHERE ProductId={ProductId}) BEGIN delete from Products where ProductId={ProductId} END";
            int a = context.Database.ExecuteSqlCommand(cmd2);
        }
        public void DeleteCategory(int CategoryId)
        {


            var cmd1 = $"delete from Categories where CategoryId={CategoryId}";

            int b=context.Database.ExecuteSqlCommand(cmd1);

        }
    }
}
