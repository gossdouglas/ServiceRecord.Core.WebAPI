using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class DailyReportTimeEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeEntryID { get; set; }

        public int DailyReportID { get; set; }

        [Required]
        [StringLength(1024)]
        public string? WorkDescription { get; set; }

        public int WorkDescriptionCategory { get; set; }

        public int? Hours { get; set; }

        //DailyReportTimeEntry is a primary table for DailyReportTimeEntryUser table
        public virtual ICollection<DailyReportTimeEntryUser>? DailyReportTimeEntryUsers { get; set; }
    }
}
