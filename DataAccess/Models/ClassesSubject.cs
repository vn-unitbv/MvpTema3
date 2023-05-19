using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ClassesSubject
{
    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public int? TeacherUserId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher? TeacherUser { get; set; }
}
