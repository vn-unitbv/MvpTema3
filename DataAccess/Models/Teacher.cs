using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Teacher
{
    public int TeacherUserId { get; set; }

    public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual User TeacherUser { get; set; } = null!;

    public virtual ICollection<TeachingMaterial> TeachingMaterials { get; set; } = new List<TeachingMaterial>();
}
