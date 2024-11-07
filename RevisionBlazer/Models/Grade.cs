using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RevisionBlazer.Models
{
    public class Grade
    {
        [Key]
        [Column("idgrade")]
        public int IdGrade { get; set; }

        [Column("enrollmentid")]
        public string IdEnrollment { get; set; } = null!;


        [Column("assessmentid")]
        public string IdAssessment { get; set; } = null!;

        [Column("score")]
        public string Score { get; set; } = null!;

        [Column("feedback")]
        public string? FeedBack{ get; set; }

       
    }
}
