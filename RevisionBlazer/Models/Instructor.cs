using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RevisionBlazer.Models
{
    [Table("t_e_instructor")]
    public class Instructor
    {

    
        [Key]
        [Column("idinstructor")]
        public int IdInstructor { get; set; }

        [Column("fullname")]
        public string FullName { get; set; } = null!;


        [Column("email")]
        public string Email { get; set; } = null!;

        [Column("expertise")]
        public string Expertise { get; set; } = null!;

        [Column("phonenumber")]
        public string? PhoneNumber { get; set; }

        [InverseProperty(nameof(JoinCourseInstructor.IdInstructorNavigation))]
        public ICollection<JoinCourseInstructor>? CourseInstrutor { get;set; }
   


    }
}
