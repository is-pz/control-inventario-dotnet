namespace control_inventario.Models
{
    public class SaleModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public decimal TotalSale { get; set; }
        public DateTime SoldAt { get; set; }
        public virtual UserModel User { get; set; }
    }
}
