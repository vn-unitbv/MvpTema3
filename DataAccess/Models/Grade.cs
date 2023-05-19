using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int StudentUserId { get; set; }

    public int SubjectId { get; set; }

    public int StudyYearId { get; set; }

    public int SemesterId { get; set; }

    public decimal Grade1 { get; set; }

    public DateTime Date { get; set; }

    public virtual Semester Semester { get; set; } = null!;

    public virtual Student StudentUser { get; set; } = null!;

    public virtual StudyYear StudyYear { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
