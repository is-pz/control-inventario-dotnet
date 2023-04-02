namespace control_inventario.Models
{
    public class RolModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int IdStatus { get; set; }
        public virtual StatusModel Status { get; set; }
    }
}
