using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models.View_Models
{
    public class VmJob
    {     
        public Job? Job { get; set; }

        //list of sub jobs to add to this job
        public List<JobSubJob>? JobSubJobAdd { get; set; }
    }
}
