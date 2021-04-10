using Beecow.Entities;
using Beecow.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Beecow.Services
{
    public class OrderService : IOrderService
    {
        private readonly BeecowDbContext customersDbContext;

        public OrderService(BeecowDbContext customersDbContext)
        {
            this.customersDbContext = customersDbContext;
        }
        public async Task<List<Order>> GetOrdersByCustomerId(int id)
        {
            var orders = await customersDbContext.Order.Where(order => order.CustomerId == id).ToListAsync();

            return orders;
        }
    }
}
