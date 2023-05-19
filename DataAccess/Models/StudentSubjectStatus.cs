using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class StudentSubjectStatus
{
    public int StudentUserId { get; set; }

    public int SubjectId { get; set; }

    public int StudyYearId { get; set; }

    public int SemesterId { get; set; }

    public decimal AverageGrade { get; set; }

    public int SubjectStatusId { get; set; }

    public virtual Semester Semester { get; set; } = null!;

    public virtual Student StudentUser { get; set; } = null!;

    public virtual StudyYear StudyYear { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual SubjectStatus SubjectStatus { get; set; } = null!;
}
