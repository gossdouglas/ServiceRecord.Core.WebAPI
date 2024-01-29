using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class Job
    {
        [Key]
        [StringLength(8)]
        public string? JobID { get; set; }
        //a key of job id can have many job correspondents
        public virtual ICollection<JobCorrespondent>? JobCorrespondents { get; set; }

        //a key of job id can have only one customer code from table customer
        [ForeignKey("CustomerCode")]
        public Customer? Customer { get; set; }

        [StringLength(50)]
        public string? CustomerContact { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }
    
        public bool Active { get; set; }
        [StringLength(255)]
        public string? Location { get; set; }

        public string? NrmlHoursStart { get; set; }

        public string? NrmlHoursEnd { get; set; }

        public int NrmlHoursDaily { get; set; }

        public Boolean DblTimeHours { get; set; }      
    }
}
