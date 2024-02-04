using System.ComponentModel.DataAnnotations;

namespace ServiceRecord.Core.WebAPI.Models.View_Models
{
    public class ViJob
    {
        public string? JobID { get; set; }

        public string CustomerId { get; set; } = string.Empty;

        public string? CustomerContact { get; set; }

        public string? Description { get; set; }

        public bool Active { get; set; }

        public string? Location { get; set; }

        public DateTime? NormalHoursStart { get; set; }

        public DateTime? NormalHoursEnd { get; set; }

        public int NormalHoursDaily { get; set; }

        public Boolean DoubleTimeHours { get; set; }
    }
}
