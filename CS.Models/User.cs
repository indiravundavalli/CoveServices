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
        public Roles Role { get; set; }

    }
}
