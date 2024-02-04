using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class DailyReportUser
    {
        //[Key]
        [ForeignKey("DailyReportID")]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DailyReportID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string? UserName { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        //public virtual tbl_dailyReport tbl_dailyReport { get; set; }
    }
}
