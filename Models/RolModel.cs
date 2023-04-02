using System;
using System.Collections.Generic;

namespace control_inventario.Models;

public partial class RolModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int IdStatus { get; set; }

    public virtual StatusModel IdStatusNavigation { get; set; } = null!;

    public virtual ICollection<UserModel> Users { get; } = new List<UserModel>();
}
