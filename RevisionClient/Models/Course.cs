using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RevisionClient.Models
{
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
    }
}
