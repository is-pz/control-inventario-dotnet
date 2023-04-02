using System;
using System.Collections.Generic;

namespace control_inventario.Models;

public partial class StatusModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<RolModel> Roles { get; } = new List<RolModel>();

    public virtual ICollection<UserModel> Users { get; } = new List<UserModel>();
}
