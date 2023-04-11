using System;
using System.Collections.Generic;

namespace control_inventario.Models;

public partial class Product
{
    public int Id { get; set; }

    public int IdCategory { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal CostPrice { get; set; }

    public decimal SalePrice { get; set; }

    public int QuantityStock { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual ICollection<SalesItem> SalesItems { get; } = new List<SalesItem>();
}
