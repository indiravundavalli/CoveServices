namespace CS.Models
{
    public class ServiceProvider
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }

        public Service Service { get; set; }
        public User User { get; set; }
    }
}
