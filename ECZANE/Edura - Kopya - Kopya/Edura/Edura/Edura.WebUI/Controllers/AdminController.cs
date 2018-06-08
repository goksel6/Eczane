using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Edura.WebUI.Repository.Abstract;
using Edura.WebUI.Models;
using Edura.WebUI.Entity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IUnitOfWork unitofWork;
        

        public AdminController(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditOrder(Order entity)
        {
            if (ModelState.IsValid)
            {
                unitofWork.Orders.Edit(entity);
                unitofWork.SaveChanges();
                return RedirectToAction("CatalogList");
            }
            return View("Error");
        }

        [HttpGet]
        public IActionResult EditOrder(int id)
        {

            var entity = unitofWork.Orders.GetAll()
             
               .Include(i => i.OrderLines)
               .ThenInclude(i => i.Order)
               .Where(i => i.OrderId == id)
               .Select(i => new AdminEditOrderModel()
               {
                   Username=i.Username,
                   OrderId = i.OrderId,
                    KartNo=i.KartNo,
                   Adres=i.Adres,
                    Sehir=i.Sehir,
                    Semt=i.Semt,
                    OrderState=i.OrderState,
                    OrderDate=i.OrderDate,
                   orderLines = i.OrderLines.Select(a => new AdminEditOrderLineModel()
                   {
                       OrderLineId=a.OrderLineId,
                       ProductId = a.ProductId,
                       ProductName = a.Product.ProductName,
                       Image = a.Product.Image,
                       Price=a.Product.Price,
                       Quantity=a.Quantity
                   }).ToList()

               }).FirstOrDefault();
            return View(entity);
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var entity = unitofWork.Categories.GetAll()
                 .Include(i => i.ProductCategories)
                 .ThenInclude(i => i.Product)
                 .Where(i => i.CategoryId == id)
                 .Select(i => new AdminEditCategoryModel()
                 {
                     CategoryId = i.CategoryId,
                     CategoryName = i.CategoryName,
                     Products = i.ProductCategories.Select(a => new AdminEditProductModel()
                     {
                         ProductId = a.ProductId,
                         ProductName = a.Product.ProductName,
                         Image = a.Product.Image,
                         IsApproved = a.Product.IsApproved,
                         IsFeatured = a.Product.IsFeatured,
                         IsHome = a.Product.IsHome,
                     }).ToList()

                 }).FirstOrDefault();
            return View(entity);
        }
        
        [HttpPost]
        public IActionResult EditCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                unitofWork.Categories.Edit(entity);
                unitofWork.SaveChanges();
                return RedirectToAction("CatalogList");
            }
            return View("Error");
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
          
                            

            var entity = unitofWork.Products.GetAll()
                     .Include(i => i.ProductCategories)
                     .ThenInclude(i => i.Category)
                     .Where(i => i.ProductId == id)
                     .Select(i => new AdminEditProductModel()
                     {
                         
                         ProductName = i.ProductName,
                         ProductId = i.ProductId,          
                         Image=i.Image,
                         IsApproved=i.IsApproved,
                         IsFeatured=i.IsFeatured,
                         IsHome=i.IsHome,
                         Price=i.Price,
                         Categories = i.ProductCategories.Select(a => new AdminEditCategoryModel()
                         {
                             CategoryId = a.CategoryId,
                             CategoryName=a.Category.CategoryName,
                                  

                            }).ToList()

                 }).FirstOrDefault();
            return View(entity);
        }
        [HttpPost]
  
        public IActionResult EditProduct(Product entity, IFormFile file, string CategoryId)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products", file.FileName);


                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        entity.Image = file.FileName;

                    }

                }
               
                unitofWork.Products.Edit(entity);
                unitofWork.SaveChanges();
                if(CategoryId!= null)
                {
                    unitofWork.Products.AddProductCategory(entity.ProductId, Int32.Parse(CategoryId));
                }

                return RedirectToAction("EditProduct/" + entity.ProductId);
            }
            else {
                return View();
            }
            
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int CategoryId)
        {
            if (ModelState.IsValid)
            {
                //silme
                unitofWork.Categories.DeleteCategory(CategoryId);
                unitofWork.SaveChanges();
                return RedirectToAction("CatalogList");
            }
            return BadRequest();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int ProductId)
        {
            if (ModelState.IsValid)
            {
                //silme
                unitofWork.Products.DeleteProduct(ProductId);
                unitofWork.SaveChanges();
                return RedirectToAction("CatalogList");
            }
            return BadRequest();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOrder(int OrderId)
        {
            if (ModelState.IsValid)
            {
                //silme
                unitofWork.Orders.DeleteOrder(OrderId);
                unitofWork.SaveChanges();
                return RedirectToAction("CatalogList");
            }
            return BadRequest();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOrderLine(int OrderLineId, int OrderId)
        {
            if (ModelState.IsValid)
            {
                //silme
                unitofWork.Orders.DeleteOrderLine(OrderLineId,OrderId);
                unitofWork.SaveChanges();
                
               
                if (unitofWork.Orders.Get(OrderId) == null)
                {
                    return RedirectToAction("CatalogList");
                }
                return RedirectToAction("EditOrder/" + OrderId);
            }
            return BadRequest();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromCategory(int ProductId, int CategoryId)
        {
            if (ModelState.IsValid)
            {
                //silme
                unitofWork.Categories.RemoveFromCategory(ProductId, CategoryId);             
                unitofWork.SaveChanges();
                return RedirectToAction("EditCategory/"+CategoryId);
            }
            return BadRequest();
        }
        public IActionResult RemoveFromProduct(int ProductId, int CategoryId)
        {
            if (ModelState.IsValid)
            {
                //silme
                unitofWork.Products.RemoveFromProduct(ProductId, CategoryId);
                unitofWork.SaveChanges();
                if (unitofWork.Products.Get(ProductId) == null)
                {
                    return RedirectToAction("CatalogList");
                }
                return RedirectToAction("EditProduct/" + ProductId);

            }
            return BadRequest();
        }
        public IActionResult CatalogList()
        {
            var model = new CatalogListModel()
            {
                Categories = unitofWork.Categories.GetAll().ToList(),
                Products = unitofWork.Products.GetAll().ToList(),
                Orders= unitofWork.Orders.GetAll().ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                unitofWork.Categories.Add(entity);
                unitofWork.SaveChanges();
                return Ok(entity);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product entity, IFormFile file,string CategoryId,string Attribute, string Value)
        {

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images\\products", file.FileName);
                   

                    using (var stream= new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        entity.Image = file.FileName;

                    }        
                 
                }
         
        
                entity.DateAdded = DateTime.Now;
                unitofWork.Products.Add(entity);           
                unitofWork.SaveChanges();

                unitofWork.Products.AddProductAttribute(Attribute, Value,entity.ProductId);
                unitofWork.SaveChanges();
                unitofWork.Products.AddProductCategory(entity.ProductId, Int32.Parse(CategoryId));
                unitofWork.SaveChanges();
                return RedirectToAction("CatalogList");
                
            }
            return View(entity);
        }
    }
}