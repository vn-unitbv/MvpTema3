using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class StudentSemesterStatus
{
    public int StudentUserId { get; set; }

    public int StudyYearId { get; set; }

    public int SemesterId { get; set; }

    public decimal? AverageGrade { get; set; }

    public int? SemesterStatusId { get; set; }

    public virtual Semester Semester { get; set; } = null!;

    public virtual SemesterStatus? SemesterStatus { get; set; }

    public virtual Student StudentUser { get; set; } = null!;

    public virtual StudyYear StudyYear { get; set; } = null!;
}
