using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Edura.WebUI.Repository.Abstract;
using Edura.WebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IUnitOfWork unitofWork;

        public OrderController(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ShowOrder()
        {
 
            var username = User.Identity.Name;
            var orders = unitofWork.Orders.GetAll()
                   .Include(i => i.OrderLines)
                   .ThenInclude(i => i.Order)
                    .Where(i=> i.Username== username)
                   .Select(i => new AdminEditOrderModel()
                   {
                       OrderId = i.OrderId,
                       KartNo = i.KartNo,
                       Sehir=i.Sehir,
                        Adres=i.Adres,
                        Semt=i.Semt,
                       OrderState = i.OrderState,
                       OrderDate = i.OrderDate,
                       
                       orderLines = i.OrderLines.Select(a => new AdminEditOrderLineModel()
                       {
                           
                           OrderLineId = a.OrderLineId,
                           ProductId = a.ProductId,
                           ProductName = a.Product.ProductName,
                           Image = a.Product.Image,
                           Price = a.Product.Price,
                           Quantity = a.Quantity
                       }).ToList()

                   }).OrderByDescending(i => i.OrderDate).ToList();
            return View(orders);
        }
 
    }
}