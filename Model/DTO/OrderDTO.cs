namespace WheelzyTest.Model.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public bool Active { get; set; }

        public int StatusId { get; set; }
    }
}
