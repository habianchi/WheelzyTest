using Microsoft.EntityFrameworkCore;
using WheelzyTest.Model;
using WheelzyTest.Model.DTO;
using WheelzyTest.Model.EF;

namespace WheelzyTest.Services
{
    public class OrderService : IOrderService
    {

        private readonly WheelzyTestContext _context;

        public OrderService(WheelzyTestContext context)
        {
            _context = context;
        }
        

    public async Task<List<OrderDTO>> GetOrders(DateTime dateFrom, DateTime dateTo, List<int> customerIds, List<int> statusIds, bool? isActive)
        {
            IQueryable<Order> query = _context.Order;

            if (isActive.HasValue)
            {
                query = query.Where(order => order.Active == isActive);
            }

            if (statusIds != null && statusIds.Any())
            {
                query = query.Where(order => statusIds.Contains(order.StatusId));
            }

            if (customerIds != null && customerIds.Any())
            {
                query = query.Where(order => customerIds.Contains(order.CustomerId));
            }

            if (dateFrom != DateTime.MinValue)
            {
                query = query.Where(order => order.Date >= dateFrom);
            }

            if (dateTo != DateTime.MinValue)
            {
                query = query.Where(order => order.Date <= dateTo);
            }


            return query.Select(order => new OrderDTO { Active = order.Active, CustomerId = order.CustomerId, Date =order.Date, Id = order.Id, StatusId = order.StatusId }).ToList();

        }
    }
}
