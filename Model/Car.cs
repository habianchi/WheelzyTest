namespace WheelzyTest.Model
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Submodel { get; set; }
        public string ZipCode { get; set; }
        public ICollection<CarSaleCase> Cases { get; set; }
    }
}
