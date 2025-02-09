using System;
using System.Collections.Generic;

namespace SaleSystem.Entity;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegisterDate { get; set; }

    public virtual ICollection<RolMenu> RolMenus { get; set; } = new List<RolMenu>();

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
