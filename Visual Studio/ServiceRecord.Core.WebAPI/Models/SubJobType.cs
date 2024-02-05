using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class SubJobType
    {
        [Key]
        //[ForeignKey("SubJobID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]      
        public int SubJobID { get; set; }
        //open a channel to table SubJobTypes
        public virtual ICollection<JobSubJobType>? JobSubJobTypes { get; set; }

        ////open a channel to table JobSubJob
        //public JobSubJob? JobSubJob { get; set; }

        [Required]
        [StringLength(25)]
        public string? Description { get; set; }
    }
}
