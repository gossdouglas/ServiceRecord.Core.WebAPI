using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class ResourceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceTypeID { get; set; }

        //open a channel to table JobResourceTypes
        public virtual ICollection<JobResourceType>? JobResourceTypes { get; set; }

        [Required]
        [StringLength(50)]
        public string? ResourceDescShort { get; set; }

        [Required]
        [StringLength(50)]
        public string? Description { get; set; }
        [Precision(6, 2)]
        public decimal Rate { get; set; }
    }
}
