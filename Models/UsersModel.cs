namespace control_inventario.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Id_Rol { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set;  }

    }
}
