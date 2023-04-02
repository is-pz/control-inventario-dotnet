using System;
using System.Collections.Generic;

namespace control_inventario.Models;

public partial class ProductModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal CostPrice { get; set; }

    public decimal SalePrice { get; set; }

    public int QuantityStock { get; set; }

    public virtual ICollection<SaleItemModel> SalesItems { get; } = new List<SaleItemModel>();
}
