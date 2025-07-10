using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Roles? Role { get; set; }

    }
}
