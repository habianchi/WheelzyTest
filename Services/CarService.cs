using Microsoft.EntityFrameworkCore;
using WheelzyTest.Model.DTO;
using WheelzyTest.Model.EF;

namespace WheelzyTest.Services
{
    public class CarService : ICarService
    {
        private readonly WheelzyTestContext _context;

        public CarService(WheelzyTestContext context)
        {
            _context = context;
        }
        public List<CarDto> GetCarsEF()
        {
            var result = from car in _context.Car
                         join saleCase in _context.CarSaleCase on car.Id equals saleCase.CarId 
                         join caseStatus in _context.CaseStatus on saleCase.CurrentStatusId equals caseStatus.Id 
                         join status in _context.Status on caseStatus.StatusId equals status.Id
                         join buyer in _context.Buyer on saleCase.Id equals buyer.CarSaleCaseId 
                         where buyer.IsCurrent
                         select new CarDto
                         {
                            CarYear= car.Year,
                             CarMake = car.Make,
                             CarModel = car.Model,
                             CarSubmodel = car.Submodel,
                             CarZipCode = car.ZipCode,
                             CurrentBuyer  = buyer.Name,
                             CurrentBuyerQuote  = buyer.Quote,
                             CurrentStatus = status.Name,
                             CurrentStatusDate  = caseStatus.Date
                         };


            return result.ToList();
        }

    }
}
