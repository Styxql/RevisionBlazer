using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RevisionBlazer.Models
{
    [Table("t_e_module")]
    public class Module
    {

        [Key]
        [Column("idmodule")]
        public int IdModule { get; set; }

        [Key]
        [Column("idcourse")]
        public int IdCourse { get; set; }

        [Column("title")]
        public string Title { get; set; } = null!;


        [Column("Content")]
        public string Content { get; set; } = null!;

        [Column("duration")]
        public int Duration { get; set; }

        [Column("startdate")]
        public DateTime? StartDate { get; set; }
        [Column("enddate")]
        public DateTime? EndDate { get; set; }



    }
}
