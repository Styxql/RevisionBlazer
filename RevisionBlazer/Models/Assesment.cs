using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RevisionBlazer.Models
{
    public class Assesment
    {
        [Key]
        [Column("assessmentid")]
        public int IdAssessment { get; set; }

        [Key]
        [Column("idcourse")]
        public int IdCourse { get; set; }

        [Column("title")]
        public string Title { get; set; } = null!;


        [Column("type")]
        public string Type { get; set; } = null!;

        [Column("totalmarks")]
        public string TotalMarks { get; set; } = null!;

        [Column("DueDate")]
        public DateTime? DueDate { get; set; }
    }
}
