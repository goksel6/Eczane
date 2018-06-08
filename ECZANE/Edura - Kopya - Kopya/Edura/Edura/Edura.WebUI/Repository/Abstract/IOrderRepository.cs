using Edura.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Abstract
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        void DeleteOrder(int OrderId);
      void DeleteOrderLine(int OrderLineId, int OrderId);
      
    }
    
}
