﻿using Microsoft.EntityFrameworkCore;

namespace RevisionBlazer.Models.EntityFramework
{
    public partial class ClassDBContext : DbContext
    {
        public ClassDBContext()
        {
        }

        public ClassDBContext(DbContextOptions<ClassDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Assesment> Assesments { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Instructor> Instructors { get; set; } = null!;
        public virtual DbSet<Module> Modules { get; set; } = null!;






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>().HasKey(c => new { c.IdCourse, c.IdStudent });
            modelBuilder.Entity<Enrollment>()
                   .HasOne(e => e.IdCourseNavigation)
                   .WithMany(c => c.Enrollments)
                   .HasForeignKey(e => e.IdCourse)
                   .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Assesment>().HasKey(c => c.IdAssessment);
            modelBuilder.Entity<Enrollment>().HasKey(c => c.IdEnrollment);
            modelBuilder.Entity<Grade>().HasKey(c => c.IdGrade);
            modelBuilder.Entity<Module>().HasKey(c => c.IdModule);




            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.IdStudentNavigation)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.IdStudent)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JoinCourseInstructor>().HasKey(c => new { c.IdCourse, c.IdInstructor });

            modelBuilder.Entity<JoinCourseInstructor>()
               .HasOne(e => e.IdCourseNavigation)
               .WithMany(s => s.CourseInstructor)
               .HasForeignKey(e => e.IdCourse)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<JoinCourseInstructor>()
              .HasOne(e => e.IdInstructorNavigation)
              .WithMany(s => s.CourseInstrutor)
              .HasForeignKey(e => e.IdInstructor)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>().HasMany(c => c.Assesments).WithOne(c => c.IdCourseNavigation);
            modelBuilder.Entity<Course>().HasMany(c => c.Modules).WithOne(c => c.IdCourseNavigation);
            modelBuilder.Entity<Enrollment>().HasMany(c => c.Grades).WithOne(c => c.IdEnrollmentNavigation);






        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

