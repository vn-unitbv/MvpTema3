using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class MvpTema3Context : DbContext
{
    public MvpTema3Context()
    {
    }

    public MvpTema3Context(DbContextOptions<MvpTema3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Absence> Absences { get; set; }

    public virtual DbSet<AbsenceState> AbsenceStates { get; set; }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassSubject> ClassSubjects { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<SemesterStatus> SemesterStatuses { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentSemesterStatus> StudentSemesterStatuses { get; set; }

    public virtual DbSet<StudentStudyYearStatus> StudentStudyYearStatuses { get; set; }

    public virtual DbSet<StudentSubjectStatus> StudentSubjectStatuses { get; set; }

    public virtual DbSet<StudyYear> StudyYears { get; set; }

    public virtual DbSet<StudyYearSpecializationSubject> StudyYearSpecializationSubjects { get; set; }

    public virtual DbSet<StudyYearStatus> StudyYearStatuses { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectStatus> SubjectStatuses { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeachingMaterial> TeachingMaterials { get; set; }

    public virtual DbSet<TezaGrade> TezaGrades { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MvpTema3;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Absence>(entity =>
        {
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Reason)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StudentUserId).HasColumnName("Student_UserId");

            entity.HasOne(d => d.AbsenceState).WithMany(p => p.Absences)
                .HasForeignKey(d => d.AbsenceStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Absences_AbsenceStates");

            entity.HasOne(d => d.Semester).WithMany(p => p.Absences)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK_Absences_Semesters");

            entity.HasOne(d => d.StudentUser).WithMany(p => p.Absences)
                .HasForeignKey(d => d.StudentUserId)
                .HasConstraintName("FK_Absences_Students");

            entity.HasOne(d => d.StudyYear).WithMany(p => p.Absences)
                .HasForeignKey(d => d.StudyYearId)
                .HasConstraintName("FK_Absences_StudyYears");

            entity.HasOne(d => d.Subject).WithMany(p => p.Absences)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Absences_Subjects");
        });

        modelBuilder.Entity<AbsenceState>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.AdministratorUserId);

            entity.Property(e => e.AdministratorUserId)
                .ValueGeneratedNever()
                .HasColumnName("Administrator_UserId");

            entity.HasOne(d => d.AdministratorUser).WithOne(p => p.Administrator)
                .HasForeignKey<Administrator>(d => d.AdministratorUserId)
                .HasConstraintName("FK_Administrators_Users");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.Property(e => e.ClassMasterTeacherUserId).HasColumnName("ClassMaster_Teacher_UserId");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ClassMasterTeacherUser).WithMany(p => p.Classes)
                .HasForeignKey(d => d.ClassMasterTeacherUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Classes_Teachers");

            entity.HasOne(d => d.Specialization).WithMany(p => p.Classes)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Classes_Specializations");

            entity.HasOne(d => d.StudyYear).WithMany(p => p.Classes)
                .HasForeignKey(d => d.StudyYearId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Classes_StudyYears");
        });

        modelBuilder.Entity<ClassSubject>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.SubjectId }).HasName("PK_ClassesSubjects");

            entity.ToTable("ClassSubject");

            entity.Property(e => e.TeacherUserId).HasColumnName("Teacher_UserId");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassSubjects)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_ClassesSubjects_Classes");

            entity.HasOne(d => d.Subject).WithMany(p => p.ClassSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_ClassesSubjects_Subjects");

            entity.HasOne(d => d.TeacherUser).WithMany(p => p.ClassSubjects)
                .HasForeignKey(d => d.TeacherUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_ClassesSubjects_Teachers");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Grade1)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Grade");
            entity.Property(e => e.StudentUserId).HasColumnName("Student_UserId");

            entity.HasOne(d => d.Semester).WithMany(p => p.Grades)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK_Grades_Semesters");

            entity.HasOne(d => d.StudentUser).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentUserId)
                .HasConstraintName("FK_Grades_Students");

            entity.HasOne(d => d.StudyYear).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudyYearId)
                .HasConstraintName("FK_Grades_StudyYears");

            entity.HasOne(d => d.Subject).WithMany(p => p.Grades)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_Grades_Subjects");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SemesterStatus>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentUserId);

            entity.Property(e => e.StudentUserId)
                .ValueGeneratedNever()
                .HasColumnName("Student_UserId");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Students_Classes");

            entity.HasOne(d => d.StudentUser).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.StudentUserId)
                .HasConstraintName("FK_Students_Users");
        });

        modelBuilder.Entity<StudentSemesterStatus>(entity =>
        {
            entity.HasKey(e => new { e.StudentUserId, e.StudyYearId, e.SemesterId });

            entity.Property(e => e.StudentUserId).HasColumnName("Student_UserId");
            entity.Property(e => e.AverageGrade).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.Semester).WithMany(p => p.StudentSemesterStatuses)
                .HasForeignKey(d => d.SemesterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSemesterStatuses_Semesters");

            entity.HasOne(d => d.SemesterStatus).WithMany(p => p.StudentSemesterStatuses)
                .HasForeignKey(d => d.SemesterStatusId)
                .HasConstraintName("FK_StudentSemesterStatuses_SemesterStatuses");

            entity.HasOne(d => d.StudentUser).WithMany(p => p.StudentSemesterStatuses)
                .HasForeignKey(d => d.StudentUserId)
                .HasConstraintName("FK_StudentSemesterStatuses_Students");

            entity.HasOne(d => d.StudyYear).WithMany(p => p.StudentSemesterStatuses)
                .HasForeignKey(d => d.StudyYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSemesterStatuses_StudyYears");
        });

        modelBuilder.Entity<StudentStudyYearStatus>(entity =>
        {
            entity.HasKey(e => new { e.StudentUserId, e.StudyYearId });

            entity.Property(e => e.StudentUserId).HasColumnName("Student_UserId");
            entity.Property(e => e.AverageGrade).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.StudentUser).WithMany(p => p.StudentStudyYearStatuses)
                .HasForeignKey(d => d.StudentUserId)
                .HasConstraintName("FK_StudentStudyYearStatuses_Students");

            entity.HasOne(d => d.StudyYear).WithMany(p => p.StudentStudyYearStatuses)
                .HasForeignKey(d => d.StudyYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentStudyYearStatuses_StudyYears");

            entity.HasOne(d => d.StudyYearStatus).WithMany(p => p.StudentStudyYearStatuses)
                .HasForeignKey(d => d.StudyYearStatusId)
                .HasConstraintName("FK_StudentStudyYearStatuses_StudyYearStatuses");
        });

        modelBuilder.Entity<StudentSubjectStatus>(entity =>
        {
            entity.HasKey(e => new { e.StudentUserId, e.SubjectId, e.StudyYearId, e.SemesterId });

            entity.Property(e => e.StudentUserId).HasColumnName("Student_UserId");
            entity.Property(e => e.AverageGrade).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.Semester).WithMany(p => p.StudentSubjectStatuses)
                .HasForeignKey(d => d.SemesterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubjectStatuses_Semesters");

            entity.HasOne(d => d.StudentUser).WithMany(p => p.StudentSubjectStatuses)
                .HasForeignKey(d => d.StudentUserId)
                .HasConstraintName("FK_StudentSubjectStatuses_Students");

            entity.HasOne(d => d.StudyYear).WithMany(p => p.StudentSubjectStatuses)
                .HasForeignKey(d => d.StudyYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubjectStatuses_StudyYears");

            entity.HasOne(d => d.Subject).WithMany(p => p.StudentSubjectStatuses)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_StudentSubjectStatuses_Subjects");

            entity.HasOne(d => d.SubjectStatus).WithMany(p => p.StudentSubjectStatuses)
                .HasForeignKey(d => d.SubjectStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubjectStatuses_SubjectStatuses");
        });

        modelBuilder.Entity<StudyYear>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudyYearSpecializationSubject>(entity =>
        {
            entity.HasKey(e => new { e.StudyYearId, e.SpecializationId, e.SubjectId });

            entity.ToTable("StudyYearSpecializationSubject");

            entity.HasOne(d => d.Specialization).WithMany(p => p.StudyYearSpecializationSubjects)
                .HasForeignKey(d => d.SpecializationId)
                .HasConstraintName("FK_StudyYearSpecializationSubject_Specializations");

            entity.HasOne(d => d.StudyYear).WithMany(p => p.StudyYearSpecializationSubjects)
                .HasForeignKey(d => d.StudyYearId)
                .HasConstraintName("FK_StudyYearSpecializationSubject_StudyYears");

            entity.HasOne(d => d.Subject).WithMany(p => p.StudyYearSpecializationSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_StudyYearSpecializationSubject_Subjects");
        });

        modelBuilder.Entity<StudyYearStatus>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubjectStatus>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherUserId);

            entity.Property(e => e.TeacherUserId)
                .ValueGeneratedNever()
                .HasColumnName("Teacher_UserId");

            entity.HasOne(d => d.TeacherUser).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.TeacherUserId)
                .HasConstraintName("FK_Teachers_Users");
        });

        modelBuilder.Entity<TeachingMaterial>(entity =>
        {
            entity.HasKey(e => e.TeachingMaterialId).HasName("PK_TeachingMaterial");

            entity.Property(e => e.TeachingMaterialId).ValueGeneratedNever();
            entity.Property(e => e.AddedByTeacherUserId).HasColumnName("AddedBy_Teacher_UserId");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Uri)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.AddedByTeacherUser).WithMany(p => p.TeachingMaterials)
                .HasForeignKey(d => d.AddedByTeacherUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_TeachingMaterial_Teachers");

            entity.HasOne(d => d.Class).WithMany(p => p.TeachingMaterials)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_TeachingMaterial_Classes");

            entity.HasOne(d => d.Semester).WithMany(p => p.TeachingMaterials)
                .HasForeignKey(d => d.SemesterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeachingMaterial_Semesters");

            entity.HasOne(d => d.StudyYear).WithMany(p => p.TeachingMaterials)
                .HasForeignKey(d => d.StudyYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeachingMaterial_StudyYears");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeachingMaterials)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_TeachingMaterial_Subjects");
        });

        modelBuilder.Entity<TezaGrade>(entity =>
        {
            entity.HasKey(e => new { e.StudentUserId, e.SubjectId, e.StudyYearId, e.SemesterId });

            entity.Property(e => e.StudentUserId).HasColumnName("Student_UserId");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Grade).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.Semester).WithMany(p => p.TezaGrades)
                .HasForeignKey(d => d.SemesterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TezaGrades_Semesters");

            entity.HasOne(d => d.StudentUser).WithMany(p => p.TezaGrades)
                .HasForeignKey(d => d.StudentUserId)
                .HasConstraintName("FK_TezaGrades_Students");

            entity.HasOne(d => d.StudyYear).WithMany(p => p.TezaGrades)
                .HasForeignKey(d => d.StudyYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TezaGrades_StudyYears");

            entity.HasOne(d => d.Subject).WithMany(p => p.TezaGrades)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_TezaGrades_Subjects");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
