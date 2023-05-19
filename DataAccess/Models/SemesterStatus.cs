using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class SemesterStatus
{
    public int SemesterStatusId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<StudentSemesterStatus> StudentSemesterStatuses { get; set; } = new List<StudentSemesterStatus>();
}
