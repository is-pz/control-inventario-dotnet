using System;
using System.Collections.Generic;

namespace control_inventario.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; } = new List<Category>();

    public virtual ICollection<Rol> Roles { get; } = new List<Rol>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
