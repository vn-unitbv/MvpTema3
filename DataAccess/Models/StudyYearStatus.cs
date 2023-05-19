using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class StudyYearStatus
{
    public int StudyYearStatusId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<StudentStudyYearStatus> StudentStudyYearStatuses { get; set; } = new List<StudentStudyYearStatus>();
}
