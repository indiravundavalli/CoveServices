using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Models
{
    public class ServiceProviders
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ServiceId")]
        public List<Service> services { get; set; }

     
    }
}
