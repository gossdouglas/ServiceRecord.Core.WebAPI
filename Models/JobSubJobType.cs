using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class JobSubJobType
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string? JobID { get; set; }
        public Job? Job { get; set; }

        [Key]
        [ForeignKey("SubJobID")]
        [Column(Order = 1)]
        public int SubJobID { get; set; }

        ////open a channel to table SubJobTypes
        //public virtual ICollection<SubJobType>? SubJobTypes { get; set; }

        //open a channel to table JobSubJob
        public SubJobType? SubJobTypes { get; set; }
    }
}
