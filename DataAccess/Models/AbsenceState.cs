using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class AbsenceState
{
    public int AbsenceStateId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();
}
