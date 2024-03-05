namespace WheelzyTest.Model.DTO
{
    public class CarDto
    {
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarSubmodel { get; set; }
        public string CarZipCode { get; set; }
        public string CurrentBuyer { get; set; }
        public decimal CurrentBuyerQuote { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime? CurrentStatusDate { get; set; }

    }
}
