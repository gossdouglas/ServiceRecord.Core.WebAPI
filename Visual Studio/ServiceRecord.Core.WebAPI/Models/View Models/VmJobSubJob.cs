using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceRecord.Core.WebAPI.Models.View_Models
{
    public class VmJobSubJob
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string? JobID { get; set; }
        public Job? Job { get; set; }

        [Key]
        [Column(Order = 1)]
        public int SubJobID { get; set; }
    }
}
