using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models.View_Models
{
    public class VmJob
    {
        //public class Job {

        //    public string? JobID { get; set; }

        //    public string CustomerId { get; set; } = string.Empty;

        //    public string? CustomerContact { get; set; }

        //    public string? Description { get; set; }

        //    public bool Active { get; set; }

        //    public string? Location { get; set; }

        //    public DateTime? NormalHoursStart { get; set; }

        //    public DateTime? NormalHoursEnd { get; set; }

        //    public int NormalHoursDaily { get; set; }

        //    public Boolean DoubleTimeHours { get; set; }

        //    public List<VmJobSubJob>? JobSubJobAdd { get; set; }
        //}

        //public ViJob? Job { get; set; }


        /// <summary>
        /// ////////////////
        /// </summary>
        public Job? Job { get; set; }

        //list of sub jobs to add to this job
        public List<JobSubJob>? JobSubJobAdd { get; set; }
        //public List<VmJobSubJob>? JobSubJobAdd { get; set; }


    }
}
