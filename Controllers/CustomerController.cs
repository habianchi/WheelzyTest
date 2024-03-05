using Microsoft.AspNetCore.Mvc;
using WheelzyTest.Model;
using WheelzyTest.Model.DTO;
using WheelzyTest.Services;
namespace WheelzyTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;


        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
     
        [HttpPost]
        [Route("UpdateCustomersBalanceByInvoices")]
        public ActionResult UpdateCustomersBalanceByInvoices()
        {
            List<Invoice> invoices = new List<Invoice>
            {
                new Invoice { Id = 1, CustomerId = 1, Total = 100 },
                new Invoice { Id = 2, CustomerId = 2, Total = 200 },
                new Invoice { Id = 3, CustomerId = 3, Total = 150 },
                new Invoice { Id = 4, CustomerId = 1, Total = 300 },
                new Invoice { Id = 5, CustomerId = 2, Total = 250 },
                new Invoice { Id = 6, CustomerId = 3, Total = 180 },
                new Invoice { Id = 7, CustomerId = 1, Total = 400 },
                new Invoice { Id = 8, CustomerId = 2, Total = 220 },
                new Invoice { Id = 9, CustomerId = 3, Total = 280 },
                new Invoice { Id = 10, CustomerId = 1, Total = 350 },
                new Invoice { Id = 11, CustomerId = 2, Total = 270 },
                new Invoice { Id = 12, CustomerId = 3, Total = 320 },
                new Invoice { Id = 13, CustomerId = 1, Total = 420 },
                new Invoice { Id = 14, CustomerId = 2, Total = 330 },
                new Invoice { Id = 15, CustomerId = 3, Total = 400 },
                new Invoice { Id = 16, CustomerId = 1, Total = 370 },
                new Invoice { Id = 17, CustomerId = 2, Total = 390 },
                new Invoice { Id = 18, CustomerId = 3, Total = 430 },
                new Invoice { Id = 19, CustomerId = 1, Total = 480 },
                new Invoice { Id = 20, CustomerId = 2, Total = 500 }
            };

            _customerService.UpdateCustomersBalanceByInvoices(invoices);

            var result = _customerService.GetCustomersData();
            return Ok(result);
        }
    }
}
