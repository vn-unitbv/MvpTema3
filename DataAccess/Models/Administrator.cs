using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Administrator
{
    public int AdministratorUserId { get; set; }

    public virtual User AdministratorUser { get; set; } = null!;
}
