using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class JobResourceType
    {
        //[Key]
        [Column(Order = 0)]
        [StringLength(8)]
        [ForeignKey("JobID")]
        public string? JobID { get; set; }

        public Job? Job { get; set; }

        //[Key]
        [Column(Order = 1)]
        [ForeignKey("ResourceTypeID")]
        public int ResourceTypeID { get; set; }

        [Precision(6, 2)]
        public decimal Rate { get; set; }
    }
}
