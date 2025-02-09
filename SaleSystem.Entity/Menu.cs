using System;
using System.Collections.Generic;

namespace SaleSystem.Entity;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string? Description { get; set; }

    public int? IdMenuFather { get; set; }

    public string? Icon { get; set; }

    public string? Controller { get; set; }

    public string? PageAction { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegisterDate { get; set; }

    public virtual Menu? IdMenuFatherNavigation { get; set; }

    public virtual ICollection<Menu> InverseIdMenuFatherNavigation { get; set; } = new List<Menu>();

    public virtual ICollection<RolMenu> RolMenus { get; set; } = new List<RolMenu>();
}
