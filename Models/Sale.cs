using System;
using System.Collections.Generic;

namespace control_inventario.Models;

public partial class Sale
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public decimal TotalSale { get; set; }

    public byte[] SoleAt { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<SalesItem> SalesItems { get; } = new List<SalesItem>();
}
