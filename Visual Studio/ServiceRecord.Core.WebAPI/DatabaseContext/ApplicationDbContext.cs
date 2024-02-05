using Microsoft.EntityFrameworkCore;
using ServiceRecord.Core.WebAPI.Models;
using System.Reflection.Metadata;

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

        public virtual DbSet<DailyReport>? DailyReport { get; set; }
        public virtual DbSet<DailyReportUser>? DailyReportUsers { get; set; }
        public virtual DbSet<DailyReportTimeEntryUser>? DailyReportTimeEntryUsers { get; set; }
        public virtual DbSet<DailyReportTimeEntry>? DailyReportTimeEntrys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Composite primary keys can only be set using 'HasKey' in 'OnModelCreating'
            modelBuilder.Entity<JobResourceType>()
            .HasKey(x => new { x.JobID, x.ResourceTypeID });

            //Composite primary keys can only be set using 'HasKey' in 'OnModelCreating'
            modelBuilder.Entity<JobSubJob>()
            .HasKey(x => new { x.JobID, x.SubJobID });

            //Composite primary keys can only be set using 'HasKey' in 'OnModelCreating'
            modelBuilder.Entity<DailyReportUser>()
            .HasKey(x => new { x.DailyReportID, x.UserName });

            //Composite primary keys can only be set using 'HasKey' in 'OnModelCreating'
            modelBuilder.Entity<DailyReportTimeEntryUser>()
            .HasKey(x => new { x.TimeEntryID, x.UserName });

            //modelBuilder.Entity<Customer>()
            //.HasMany(e => e.Jobs)
            //.WithOne(e => e.Customer)
            //.HasForeignKey(e => e.CustomerId)
            //.IsRequired();

            //modelBuilder.Entity<Job>()
            //.HasMany(e => e.JobSubJob)
            //.WithOne(e => e.Job)
            //.HasForeignKey(e => e.JobID)
            //.IsRequired();

        }
    }
}
