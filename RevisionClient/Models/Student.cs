using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RevisionClient.Models
{
    public class Student
    {
        [Key]
        [Column("idstudent")]
        public int IdStudent { get; set; }

        [Column("fullname")]
        public string FullName { get; set; } = null!;


        [Column("email")]
        public string? Email { get; set; }

        [Column("dateofbirth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("phonenumber")]
        public string? PhoneNumber { get; set; }
        [Column("address")]
        public string? Address { get; set; }
        [Column("enrollmentdate")]
        public string? EnrollmentDate { get; set; }
        [Column("status")]
        public string? Status { get; set; }
    }
}
