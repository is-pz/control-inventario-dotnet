namespace control_inventario.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Id_Rol { get; set; }
        public int IdStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set;  }
        public virtual RolModel Rol { get; set; }
        public virtual StatusModel Status { get; set; }

    }
}
