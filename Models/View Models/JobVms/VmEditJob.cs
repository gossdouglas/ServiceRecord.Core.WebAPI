namespace ServiceRecord.Core.WebAPI.Models.View_Models.JobVms
{
    public class VmEditJob : VmAddJob
    {
        //ADD IS INHERITED

        //JOB SUB JOB
        //list of sub jobs to delete for this job
        public List<JobSubJobType>? JobSubJobTypeListDelete { get; set; }

        //JOB RESOURCE TYPE
        //list of resources to to delete for this job
        public List<JobResourceType>? JobResourceTypeListDelete { get; set; }
        //list of resources to edit for this job
        public List<JobResourceType>? JobResourceTypeListEdit { get; set; }

        //JOB CORRESPONDENT
        //list of correspondents to delete for this job
        public List<JobCorrespondent>? JobCorrespondentListDelete { get; set; }
        //list of correspondents to edit for this job
        public List<JobCorrespondent>? JobCorrespondentListEdit { get; set; }
    }
}
