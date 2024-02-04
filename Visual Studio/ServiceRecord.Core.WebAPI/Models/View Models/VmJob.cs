using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models.View_Models
{
    public class VmJob
    {
        //public List<tbl_Jobs> lstJobs { get; set; }

        //public List<vmCustomerInfo> lstCustomers { get; set; }

        //public List<vmSubJobTypes> lstSubJobTypes { get; set; }
        //public List<vmResourceTypes> lstResourceTypes { get; set; }

        public Job? job { get; set; }
        //public string[]? arrJobSubJobsAdd { get; set; }
        //public string[] arrJobSubJobsDelete { get; set; }

        //public List<ResourceType>? lstResourceTypesAdd { get; set; }
        //public List<ResourceType> lstResourceTypesDelete { get; set; }
        //public List<ResourceType> lstResourceTypesEdit { get; set; }
        //public List<JobCorrespondent> lstJobCrspdtInfoAdd { get; set; }
        //public List<JobCorrespondent lstJobCrspdtInfoDelete { get; set; }
        //public List<JobCorrespondent> lstJobCrspdtInfoEdit { get; set; }
    }
}
