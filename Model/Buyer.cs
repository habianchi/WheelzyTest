namespace WheelzyTest.Model
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quote { get; set; }
        public bool IsCurrent { get; set; }
        public int CarSaleCaseId { get; set; }
        public CarSaleCase CarSaleCase { get; set; }
    }
}
