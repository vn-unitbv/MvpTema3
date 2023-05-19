using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public int? StudyYearId { get; set; }

    public int? SpecializationId { get; set; }

    public int? ClassMasterTeacherUserId { get; set; }

    public DateTime CreationDate { get; set; }

    public string? Name { get; set; }

    public virtual Teacher? ClassMasterTeacherUser { get; set; }

    public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();

    public virtual Specialization? Specialization { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual StudyYear? StudyYear { get; set; }

    public virtual ICollection<TeachingMaterial> TeachingMaterials { get; set; } = new List<TeachingMaterial>();
}
