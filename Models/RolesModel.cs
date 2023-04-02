namespace control_inventario.Models
{
    public class RolesModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Status { get; set; }
    }
}
