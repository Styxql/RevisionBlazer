using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevisionBlazer.Models
{
    [Table("joincourseinstructor")]
    public class JoinCourseInstructor
    {
        [Key]
        [Column("idinstructor")]
        public int IdInstructor { get; set; }

        [Column("idcourse")]
        public int IdCourse { get; set; }

        [ForeignKey(nameof(IdCourseNavigation))]
        public virtual Course? IdCourseNavigation { get; set; }

        [ForeignKey(nameof(IdInstructor))]

        public virtual Instructor? IdInstructorNavigation { get; set; }
    }
}
