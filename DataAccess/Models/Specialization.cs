using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Specialization
{
    public int SpecializationId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<StudyYearSpecializationSubject> StudyYearSpecializationSubjects { get; set; } = new List<StudyYearSpecializationSubject>();
}
