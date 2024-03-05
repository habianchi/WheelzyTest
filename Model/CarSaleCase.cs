using System.Threading.Tasks;

namespace WheelzyTest.Model
{
    public class CarSaleCase
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CurrentStatusId { get; set; }
        public Car Car { get; set; }
        public ICollection<Buyer> Buyers { get; set; }
        public CaseStatus CurrentStatus { get; set; }
        public ICollection<CaseStatus> StatusHistory { get; set; }
    }
}
