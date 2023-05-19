using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class SubjectStatus
{
    public int SubjectStatusId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<StudentSubjectStatus> StudentSubjectStatuses { get; set; } = new List<StudentSubjectStatus>();
}
