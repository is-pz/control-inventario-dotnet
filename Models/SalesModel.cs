namespace control_inventario.Models
{
    public class SalesModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public decimal TotalSale { get; set; }
        public DateTime SoldAt { get; set; }
    }
}
