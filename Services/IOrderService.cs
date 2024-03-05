using WheelzyTest.Model.DTO;

namespace WheelzyTest.Services
{
    public interface IOrderService
    {
        public  Task<List<OrderDTO>> GetOrders(DateTime dateFrom, DateTime dateTo, List<int> customerIds, List<int> statusIds, bool? isActive);
    }
}
