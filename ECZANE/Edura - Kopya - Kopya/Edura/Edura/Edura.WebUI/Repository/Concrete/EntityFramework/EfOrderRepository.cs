using Edura.WebUI.Entity;
using Edura.WebUI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfOrderRepository : EfGenericRepository<Order>, IOrderRepository
    {
        public EfOrderRepository(EduraContext context) : base(context)
        {
        }
        public void DeleteOrder(int OrderId)
        {
            var cmd = $"delete from Orders where OrderId={OrderId}";
            context.Database.ExecuteSqlCommand(cmd);
        }
        public void DeleteOrderLine(int OrderLineId, int OrderId)
        {
            var cmd = $"delete from OrderLines where OrderId={OrderId} and OrderLineId={OrderLineId}";
            context.Database.ExecuteSqlCommand(cmd);
            var cmd2 = $" IF NOT EXISTS(SELECT * FROM OrderLines WHERE OrderId={OrderId}) BEGIN delete from Orders where OrderId={OrderId} END";
            int a = context.Database.ExecuteSqlCommand(cmd2);
        }
        //public void GetOrder(string Username)
        //{
        //    var cmd = $"delete from OrderLines where OrderId={OrderId} and OrderLineId={OrderLineId}";
        //    context.Database.ExecuteSqlCommand(cmd);
        //    var cmd2 = $" IF NOT EXISTS(SELECT * FROM OrderLines WHERE OrderId={OrderId}) BEGIN delete from Orders where OrderId={OrderId} END";
        //    int a = context.Database.ExecuteSqlCommand(cmd2);
        //}
    }
}
