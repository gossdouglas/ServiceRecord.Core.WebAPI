using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class Job
    {
        [Key]
        [StringLength(8)]
        public string? JobID { get; set; }

        [StringLength(4)]
        public string CustomerId { get; set; } = string.Empty;
        //one JobID can have one CustomerId
        // Required reference navigation to principal
        public Customer? Customer { get; set; }
        //https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-many

        [StringLength(50)]
        public string? CustomerContact { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }
    
        public bool Active { get; set; }
        [StringLength(255)]
        public string? Location { get; set; }

        public DateTime? NormalHoursStart { get; set; }

        public DateTime? NormalHoursEnd { get; set; }

        public int NormalHoursDaily { get; set; }

        public Boolean DoubleTimeHours { get; set; }

        //a key of job id can have many job correspondents
        public virtual ICollection<JobCorrespondent>? JobCorrespondents { get; set; }
        public virtual ICollection<DailyReport>? DailyReports { get; set; }
        public virtual ICollection<JobSubJobType>? JobSubJobTypes { get; set; }
    }
}
