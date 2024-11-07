using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RevisionBlazer.Models
{
    public class Enrollment
    {
        [Key]
        [Column("enrollmentid")]
        public int IdEnrollment { get; set; }

        [Column("idstudent")]
        public string IdStudent { get; set; } = null!;


        [Column("idcourse")]
        public string IdCourse { get; set; } = null!;

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


        
    }
}
