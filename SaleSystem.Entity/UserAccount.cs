using System;
using System.Collections.Generic;

namespace SaleSystem.Entity;

public partial class UserAccount
{
    public int IdUserAccount { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? IdRol { get; set; }

    public string? PhotoUrl { get; set; }

    public string? PhotoName { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegisterDate { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
