using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RevisionBlazer.Models.EntityFramework
{
    public class Grade
    {
        [Key]
        [Column("idgrade")]
        public int IdGrade { get; set; }

        [Column("enrollmentid")]
        public int IdEnrollment { get; set; }


        [Column("assessmentid")]
        public string IdAssessment { get; set; } = null!;

        [Column("score")]
        public string Score { get; set; } = null!;

        [Column("feedback")]
        public string? FeedBack { get; set; }

        [ForeignKey(nameof(IdEnrollment))]
        [InverseProperty(nameof(Enrollment.Grades))]
        public virtual Enrollment? IdEnrollmentNavigation { get; set; }

    }
}
