using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Absence
{
    public int AbsenceId { get; set; }

    public int StudentUserId { get; set; }

    public int? SubjectId { get; set; }

    public int StudyYearId { get; set; }

    public int SemesterId { get; set; }

    public int AbsenceStateId { get; set; }

    public string? Reason { get; set; }

    public DateTime Date { get; set; }

    public virtual AbsenceState AbsenceState { get; set; } = null!;

    public virtual Semester Semester { get; set; } = null!;

    public virtual Student StudentUser { get; set; } = null!;

    public virtual StudyYear StudyYear { get; set; } = null!;

    public virtual Subject? Subject { get; set; }
}
