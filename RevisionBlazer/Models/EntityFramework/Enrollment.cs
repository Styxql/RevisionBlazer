using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RevisionBlazer.Models.EntityFramework
{
    public class Enrollment
    {
        [Key]
        [Column("enrollmentid")]
        public int IdEnrollment { get; set; }

        [Column("idstudent")]
        public int IdStudent { get; set; }


        [Column("idcourse")]
        public int IdCourse { get; set; }

        [Column("status")]
        public string Status { get; set; } = null!;

        [Column("finalgrade")]
        public double? FinalGrade { get; set; }

        [Column("progress")]
        public double? Progress { get; set; }


        [ForeignKey("IdCourse")]
        public virtual Course? IdCourseNavigation { get; set; }

        [ForeignKey("IdStudent")]
        public virtual Student? IdStudentNavigation { get; set; }

        [InverseProperty(nameof(Grade.IdEnrollmentNavigation))]
        public virtual ICollection<Grade>? Grades { get; set; }

    }
}
