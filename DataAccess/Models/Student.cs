using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Student
{
    public int StudentUserId { get; set; }

    public int? ClassId { get; set; }

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();

    public virtual Class? Class { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<StudentSemesterStatus> StudentSemesterStatuses { get; set; } = new List<StudentSemesterStatus>();

    public virtual ICollection<StudentStudyYearStatus> StudentStudyYearStatuses { get; set; } = new List<StudentStudyYearStatus>();

    public virtual ICollection<StudentSubjectStatus> StudentSubjectStatuses { get; set; } = new List<StudentSubjectStatus>();

    public virtual User StudentUser { get; set; } = null!;

    public virtual ICollection<TezaGrade> TezaGrades { get; set; } = new List<TezaGrade>();
}
