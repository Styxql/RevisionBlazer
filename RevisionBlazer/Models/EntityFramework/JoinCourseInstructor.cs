using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevisionBlazer.Models.EntityFramework
{
    [Table("joincourseinstructor")]
    public class JoinCourseInstructor
    {
        [Key]
        [Column("idinstructor")]
        public int IdInstructor { get; set; }

        [Column("idcourse")]
        public int IdCourse { get; set; }

        [ForeignKey(nameof(IdCourse))]
        public virtual Course? IdCourseNavigation { get; set; }

        [ForeignKey(nameof(IdInstructor))]
        public virtual Instructor? IdInstructorNavigation { get; set; }
    }
}
