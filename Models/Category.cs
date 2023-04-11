using System;
using System.Collections.Generic;

namespace control_inventario.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Status { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual Status StatusNavigation { get; set; } = null!;
}
