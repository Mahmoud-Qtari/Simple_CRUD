namespace Task2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
