namespace WheelzyTest.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public bool Active { get; set; }

        public int StatusId { get; set; }
    }
}
