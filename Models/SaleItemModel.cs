using System;
using System.Collections.Generic;

namespace control_inventario.Models;

public partial class SaleItemModel
{
    public int Id { get; set; }

    public int IdSale { get; set; }

    public int IdProduct { get; set; }

    public decimal SalePrice { get; set; }

    public int QuantitySold { get; set; }

    public decimal Total { get; set; }

    public virtual ProductModel IdProductNavigation { get; set; } = null!;

    public virtual SaleModel IdSaleNavigation { get; set; } = null!;
}
