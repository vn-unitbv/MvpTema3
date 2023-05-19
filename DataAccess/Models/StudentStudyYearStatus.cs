using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class StudentStudyYearStatus
{
    public int StudentUserId { get; set; }

    public int StudyYearId { get; set; }

    public decimal? AverageGrade { get; set; }

    public int? StudyYearStatusId { get; set; }

    public virtual Student StudentUser { get; set; } = null!;

    public virtual StudyYear StudyYear { get; set; } = null!;

    public virtual StudyYearStatus? StudyYearStatus { get; set; }
}
