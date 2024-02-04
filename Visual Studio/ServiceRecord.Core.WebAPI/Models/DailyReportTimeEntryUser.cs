using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class DailyReportTimeEntryUser
    {
        //[Key]
        [ForeignKey("TimeEntryID")]
        [Column(Order = 0)]
        public int TimeEntryID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string? UserName { get; set; }
    }
}
