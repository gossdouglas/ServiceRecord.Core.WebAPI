using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class DailyReport
    {
        [Key]
        public int DailyReportID { get; set; }

        [StringLength(8)]
        public string? JobID { get; set; }

        public int SubJobID { get; set; }

        public string? Equipment { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }       

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public decimal LunchHours { get; set; }   

        [StringLength(16)]
        public string? DailyReportAuthor { get; set; }

        public int SubmissionStatus { get; set; }

        //public virtual ICollection<tbl_dailyReportUsers> tbl_dailyReportUsers { get; set; }
    }
}
