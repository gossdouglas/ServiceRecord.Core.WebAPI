namespace ServiceRecord.Core.WebAPI.Models.View_Models.JobVms
{
    public class VmGetJobs
    {
        //list of 
        public List<Job>? JobList { get; set; }
        //list of sub jobs to add to this job
        public List<SubJobType>? SubJobTypeList { get; set; }       
        //list of 
        public List<ResourceType>? ResourceTypeList { get; set; }
        //list of 
        public List<Customer>? CustomerList { get; set; }
    }
}
