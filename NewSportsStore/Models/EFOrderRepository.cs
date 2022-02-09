using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewSportsStore.Models
{
    public class EFOrderRepository:IOrderRepository
    {
        private NewStoreDbContext context;
        public EFOrderRepository(NewStoreDbContext ctx)
        {
            context = ctx;
        }
          public IQueryable<Order> Orders => context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }

    }
}
