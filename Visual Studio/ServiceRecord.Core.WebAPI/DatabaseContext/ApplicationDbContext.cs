using Microsoft.EntityFrameworkCore;
using ServiceRecord.Core.WebAPI.Models;

namespace ServiceRecord.Core.WebAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        //level 1 tables
        public virtual DbSet<Customer>? Customers { get; set; }
        public virtual DbSet<Job>? Jobs { get; set; }
        public virtual DbSet<JobCorrespondent>? JobCorrespondents { get; set; }
        public virtual DbSet<SubJobType>? SubJobTypes { get; set; }

        //level 2 tables
        public virtual DbSet<JobSubJob>? JobSubJobs { get; set; }

        public virtual DbSet<ResourceType>? ResourceTypes { get; set; }
        public virtual DbSet<JobResourceType>? JobResourceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Composite primary keys can only be set using 'HasKey' in 'OnModelCreating'
            modelBuilder.Entity<JobResourceType>()
            .HasKey(x => new { x.JobID, x.ResourceTypeID });

            //Composite primary keys can only be set using 'HasKey' in 'OnModelCreating'
            modelBuilder.Entity<JobSubJob>()
            .HasKey(x => new { x.JobID, x.SubJobID });

        }
    }
}
