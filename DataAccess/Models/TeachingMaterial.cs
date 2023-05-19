using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class TeachingMaterial
{
    public int TeachingMaterialId { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public int StudyYearId { get; set; }

    public int SemesterId { get; set; }

    public int? AddedByTeacherUserId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Uri { get; set; }

    public virtual Teacher? AddedByTeacherUser { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Semester Semester { get; set; } = null!;

    public virtual StudyYear StudyYear { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
