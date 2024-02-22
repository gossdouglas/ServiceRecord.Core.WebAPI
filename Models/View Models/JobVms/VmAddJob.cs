namespace ServiceRecord.Core.WebAPI.Models.View_Models.JobVms
{
    public class VmAddJob
    {
        public Job? Job { get; set; }

        //list of sub jobs to add to this job
        public List<JobSubJobType>? JobSubJobTypeListAdd { get; set; }
        //list of resources to add to this job
        public List<JobResourceType>? JobResourceTypeListAdd { get; set; }
        //list of 
        public List<ResourceType>? ResourceTypeListAdd { get; set; }
        //list of correspondents to add to this job
        public List<JobCorrespondent>? JobCorrespondentListAdd { get; set; }
    }
}
