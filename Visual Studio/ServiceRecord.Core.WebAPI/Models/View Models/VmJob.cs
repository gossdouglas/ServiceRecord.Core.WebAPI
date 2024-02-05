using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models.View_Models
{
    public class VmJob
    {     
        public Job? Job { get; set; }

        //list of 
        public List<Job>? JobList { get; set; }
        //list of sub jobs to add to this job
        public List<SubJobType>? SubJobTypeList { get; set; }
        //list of 
        public List<Customer>? CustomerList { get; set; }       
        //list of 
        public List<ResourceType>? ResourceTypeList { get; set; }

        //JOB SUB JOB
        //list of sub jobs to add to this job
        public List<JobSubJobType>? JobSubJobTypeListAdd { get; set; }
        //list of sub jobs to add to this job
        public List<JobSubJobType>? JobSubJobTypeListDelete { get; set; }

        //JOB RESOURCE TYPE
        //list of resources to add to this job
        public List<JobResourceType>? JobResourceTypeListAdd { get; set; }
        //list of resources to add to this job
        public List<JobResourceType>? JobResourceTypeListDelete { get; set; }

        //RESOURCE TYPE
        //list of 
        public List<ResourceType>? ResourceTypeListAdd { get; set; }
        //list of 
        public List<ResourceType>? ResourceTypeListDelete { get; set; }
        //list of 
        public List<ResourceType>? ResourceTypeListEdit { get; set; }

        //JOB CORRESPONDENT
        //list of correspondents to add to this job
        public List<JobCorrespondent>? JobCorrespondentListAdd { get; set; }
        //list of correspondents to add to this job
        public List<JobCorrespondent>? JobCorrespondentListDelete { get; set; }
        //list of correspondents to add to this job
        public List<JobCorrespondent>? JobCorrespondentListEdit { get; set; }
    }
}
