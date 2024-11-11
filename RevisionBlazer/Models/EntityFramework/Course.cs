using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RevisionBlazer.Models.EntityFramework
{
    [Table("t_e_course")]
    public class Course
    {

        [Key]
        [Column("idcourse")]
        public int IdCourse { get; set; }

        [Column("title")]
        public string Title { get; set; } = null!;


        [Column("description")]
        public string? Description { get; set; } = null!;

        [Column("duration")]
        public int? Duration { get; set; }

        [Column("startdate")]
        public DateTime? StartDate { get; set; }
        [Column("enddate")]
        public DateTime? EndDate { get; set; }

        [InverseProperty(nameof(Enrollment.IdCourseNavigation))]
        public virtual ICollection<Enrollment>? Enrollments { get; set; }

        [InverseProperty(nameof(JoinCourseInstructor.IdCourseNavigation))]
        public virtual ICollection<JoinCourseInstructor>? CourseInstructor { get; set; }

        [InverseProperty(nameof(Module.IdCourseNavigation))]
        public virtual ICollection<Module>? Modules { get; set; }

        [InverseProperty(nameof(Assesment.IdCourseNavigation))]
        public virtual ICollection<Assesment>? Assesments { get; set; }




    }
}
