using System;
using System.Collections.Generic;

namespace control_inventario.Models;

public partial class UserModel
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdRol { get; set; }

    public int IdStatus { get; set; }

    public DateTime? LastLogin { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public virtual RolModel IdRolNavigation { get; set; } = null!;

    public virtual StatusModel IdStatusNavigation { get; set; } = null!;

    public virtual ICollection<SaleModel> Sales { get; } = new List<SaleModel>();
}
