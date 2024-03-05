using Microsoft.AspNetCore.Mvc;
using WheelzyTest.Model.DTO;
using WheelzyTest.Services;

namespace WheelzyTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;


        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        [Route("GetOrders")]
        public async Task<List<OrderDTO>> GetOrders([FromQueryAttribute] DateTime dateFrom, [FromQueryAttribute] DateTime dateTo,
[FromQueryAttribute] List<int> customerIds, [FromQueryAttribute] List<int> statusIds, [FromQueryAttribute] bool? isActive)
        {
            return await _orderService.GetOrders(dateFrom, dateTo, customerIds, statusIds, isActive);

    
        }

 

    }
}

