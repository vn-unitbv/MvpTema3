using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();

    public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<StudentSubjectStatus> StudentSubjectStatuses { get; set; } = new List<StudentSubjectStatus>();

    public virtual ICollection<StudyYearSpecializationSubject> StudyYearSpecializationSubjects { get; set; } = new List<StudyYearSpecializationSubject>();

    public virtual ICollection<TeachingMaterial> TeachingMaterials { get; set; } = new List<TeachingMaterial>();

    public virtual ICollection<TezaGrade> TezaGrades { get; set; } = new List<TezaGrade>();
}
