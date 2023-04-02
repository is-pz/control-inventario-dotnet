namespace control_inventario.Models
{
    public class SaleItemModel
    {
        public int Id { get; set; }
        public int IdSale { get; set; }
        public int IdProduct { get; set; }
        public decimal SalePrice { get; set; }
        public int QuantitySold { get; set; }
        public decimal Total { get; set; }

    }
}
