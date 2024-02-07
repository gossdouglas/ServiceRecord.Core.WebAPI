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
        public virtual DbSet<JobSubJobType>? JobSubJobTypes { get; set; }

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
            modelBuilder.Entity<JobSubJobType>()
            .HasKey(x => new { x.JobID, x.SubJobID });

            //Composite primary keys can only be set using 'HasKey' in 'OnModelCreating'
            modelBuilder.Entity<DailyReportUser>()
            .HasKey(x => new { x.DailyReportID, x.UserName });

            //Composite primary keys can only be set using 'HasKey' in 'OnModelCreating'
            modelBuilder.Entity<DailyReportTimeEntryUser>()
            .HasKey(x => new { x.TimeEntryID, x.UserName });

            //Composite primary keys can only be set using 'HasKey' in 'OnModelCreating'
            modelBuilder.Entity<JobCorrespondent>()
            .HasKey(x => new { x.JobID, x.Email });

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

            modelBuilder.Entity<ResourceType>().HasData(
            new ResourceType { ResourceDescShort = "CE", Description = "CONTROL ENGINEER", Rate = 250, ResourceTypeID = 1 },
            new ResourceType { ResourceDescShort = "ME", Description = "MECHANICAL ENGINEER", Rate = 110, ResourceTypeID = 2 },
            new ResourceType { ResourceDescShort = "EE", Description = "ELECTRICAL ENGINEER", Rate = 115, ResourceTypeID = 3 },
            new ResourceType { ResourceDescShort = "GT", Description = "GENERAL TECHNICIAN", Rate = 120, ResourceTypeID = 4 },
            new ResourceType { ResourceDescShort = "MT", Description = "MECHANICAL TECHNICIAN", Rate = 125, ResourceTypeID = 5 },
            new ResourceType { ResourceDescShort = "ET", Description = "ELECTRICAL TECHNICIAN", Rate = 130, ResourceTypeID = 6 },
            new ResourceType { ResourceDescShort = "SE", Description = "STRUCTURAL ENGINEER", Rate = 135, ResourceTypeID = 7 },
            new ResourceType { ResourceDescShort = "ST", Description = "STRUCTUAL TECHNICIAN", Rate = 140, ResourceTypeID = 8 },
            new ResourceType { ResourceDescShort = "FT", Description = "FABRICATION TECHNICIAN", Rate = 145, ResourceTypeID = 9 },
            new ResourceType { ResourceDescShort = "WD", Description = "WELDER", Rate = 150, ResourceTypeID = 10 }
        );

            modelBuilder.Entity<SubJobType>().HasData(
            new SubJobType { SubJobID = 1, Description = "Commissioning" },
            new SubJobType { SubJobID = 2, Description = "Shutdown" },
            new SubJobType { SubJobID = 3, Description = "SAT" },
            new SubJobType { SubJobID = 4, Description = "General Support" },
            new SubJobType { SubJobID = 5, Description = "Mechanical Install" },
            new SubJobType { SubJobID = 6, Description = "Electrical Install" },
            new SubJobType { SubJobID = 7, Description = "Startup/Commissioning" },
            new SubJobType { SubJobID = 8, Description = "Engineering Discovery" },
            new SubJobType { SubJobID = 9, Description = "Training Service" },
            new SubJobType { SubJobID = 10, Description = "Audit/PM Service" },
            new SubJobType { SubJobID = 11, Description = "Drawing Updates" },
            new SubJobType { SubJobID = 12, Description = "Welding" },
            new SubJobType { SubJobID = 13, Description = "Production Support" }


        );

        }
    }
}
