using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class JobCorrespondent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobCorrespondentID { get; set; }

        //a key of JobCorrespondentID can have only one JobID from table job
        [ForeignKey("JobID")]
        //public Job? Job { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

        public bool Active { get; set; }
    }
}
