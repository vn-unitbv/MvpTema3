using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class StudyYear
{
    public int StudyYearId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<StudentSemesterStatus> StudentSemesterStatuses { get; set; } = new List<StudentSemesterStatus>();

    public virtual ICollection<StudentStudyYearStatus> StudentStudyYearStatuses { get; set; } = new List<StudentStudyYearStatus>();

    public virtual ICollection<StudentSubjectStatus> StudentSubjectStatuses { get; set; } = new List<StudentSubjectStatus>();

    public virtual ICollection<StudyYearSpecializationSubject> StudyYearSpecializationSubjects { get; set; } = new List<StudyYearSpecializationSubject>();

    public virtual ICollection<TeachingMaterial> TeachingMaterials { get; set; } = new List<TeachingMaterial>();

    public virtual ICollection<TezaGrade> TezaGrades { get; set; } = new List<TezaGrade>();
}
