using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class Job
    {
        [Key]
        [StringLength(8)]
        public string? JobID { get; set; }

        //a key of job id can have only one customer code from table customer
        //[ForeignKey("CustomerCode")]
        //public Customer? Customer { get; set; }

        [StringLength(4)]
        public string? CustomerCode { get; set; }

        [StringLength(50)]
        public string? CustomerContact { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }
    
        public bool Active { get; set; }
        [StringLength(255)]
        public string? Location { get; set; }

        public TimeOnly? NormalHoursStart { get; set; }

        public TimeOnly? NormalHoursEnd { get; set; }

        public int NormalHoursDaily { get; set; }

        public Boolean DoubleTimeHours { get; set; }

        //a key of job id can have many job correspondents
        public virtual ICollection<JobCorrespondent>? JobCorrespondents { get; set; }
        //a key of job id can have many job sub jobs
        //public virtual ICollection<JobSubJob>? JobSubJobs { get; set; }

        public virtual ICollection<DailyReport>? DailyReports { get; set; }
    }
}
