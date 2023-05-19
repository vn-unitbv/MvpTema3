using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class StudyYearSpecializationSubject
{
    public int StudyYearId { get; set; }

    public int SpecializationId { get; set; }

    public int SubjectId { get; set; }

    public bool? HasTeza { get; set; }

    public virtual Specialization Specialization { get; set; } = null!;

    public virtual StudyYear StudyYear { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
