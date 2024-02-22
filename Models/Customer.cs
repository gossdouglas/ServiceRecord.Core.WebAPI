using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class Customer
    {
        [Key]
        [StringLength(4)]
        public string CustomerId { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string? CustomerName { get; set; }

        [StringLength(50)]
        public string? CustomerAddress { get; set; }


        //one CustomerId can have many jobs
        //Collection navigation containing dependents
        public ICollection<Job> Jobs { get; } = new List<Job>();
        //https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-many

    }
}
