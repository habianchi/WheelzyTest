using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WheelzyTest.Model.DTO;
using WheelzyTest.Services;

namespace WheelzyTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;


        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Route("GetCarsEF")]
        public IEnumerable<CarDto> GetCarsEF()
        {
            return _carService.GetCarsEF();
        }

    }
}
