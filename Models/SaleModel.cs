using System;
using System.Collections.Generic;

namespace control_inventario.Models;

public partial class SaleModel
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public decimal TotalSale { get; set; }

    public byte[] SoleAt { get; set; } = null!;

    public virtual UserModel IdUserNavigation { get; set; } = null!;

    public virtual ICollection<SaleItemModel> SalesItems { get; } = new List<SaleItemModel>();
}
