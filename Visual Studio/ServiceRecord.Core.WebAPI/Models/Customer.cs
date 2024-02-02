using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRecord.Core.WebAPI.Models
{
    public class Customer
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int CustomerId { get; set; }

        [Key]
        [StringLength(4)]
        public string? CustomerCode { get; set; }
        //a key of CustomerCode can have many jobs
        //public ICollection<Job>? Jobs { get; set; }

        [StringLength(50)]
        public string? CustomerName { get; set; }

        [StringLength(50)]
        public string? CustomerAddress { get; set; }      
    }
}
