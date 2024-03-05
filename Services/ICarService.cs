using WheelzyTest.Model.DTO;

namespace WheelzyTest.Services
{
    public interface ICarService
    {
        public List<CarDto> GetCarsEF();
    }
}
