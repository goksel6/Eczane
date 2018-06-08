using Edura.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Models
{
    public class AdminEditCategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<AdminEditProductModel> Products { get; set; }
    }
    public class AdminEditProductModel
    {
        
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public bool IsApproved { get; set; }
        public double Price { get; set; }
        public bool IsHome { get; set; }
        public bool IsFeatured { get; set; }
        public List<AdminEditCategoryModel> Categories { get; set; }
     
    }
    public class AdminEditOrderModel
    {
        public int OrderId { get; set; }
        public string Username { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
      
        public EnumOrderState OrderState { get; set; }
        public List<AdminEditOrderLineModel> orderLines { get; set; }
        public string KartNo { get; set; }
        public DateTime OrderDate { get; set; }
    }
    public class AdminEditOrderLineModel
    {
        public int OrderLineId { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
