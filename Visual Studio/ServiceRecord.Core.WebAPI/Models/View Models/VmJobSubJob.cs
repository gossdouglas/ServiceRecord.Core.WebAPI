using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceRecord.Core.WebAPI.Models.View_Models
{
    public class VmJobSubJob
    {
        public string? JobID { get; set; }

        public int SubJobID { get; set; }
    }
}
