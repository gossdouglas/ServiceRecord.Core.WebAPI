﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceRecord.Core.WebAPI.DatabaseContext;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240203222912_Job-CustomerCode_add")]
    partial class JobCustomerCode_add
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.Customer", b =>
                {
                    b.Property<string>("CustomerCode")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("CustomerAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerCode");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.DailyReport", b =>
                {
                    b.Property<int>("DailyReportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DailyReportID"), 1L, 1);

                    b.Property<string>("DailyReportAuthor")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Equipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobID")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<decimal>("LunchHours")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("SubJobID")
                        .HasColumnType("int");

                    b.Property<int>("SubmissionStatus")
                        .HasColumnType("int");

                    b.HasKey("DailyReportID");

                    b.HasIndex("JobID");

                    b.ToTable("DailyReport");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.DailyReportTimeEntry", b =>
                {
                    b.Property<int>("TimeEntryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeEntryID"), 1L, 1);

                    b.Property<int>("DailyReportID")
                        .HasColumnType("int");

                    b.Property<int?>("Hours")
                        .HasColumnType("int");

                    b.Property<string>("WorkDescription")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("WorkDescriptionCategory")
                        .HasColumnType("int");

                    b.HasKey("TimeEntryID");

                    b.HasIndex("DailyReportID");

                    b.ToTable("DailyReportTimeEntrys");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.DailyReportTimeEntryUser", b =>
                {
                    b.Property<int>("TimeEntryID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("UserName")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnOrder(1);

                    b.Property<int?>("DailyReportID")
                        .HasColumnType("int");

                    b.HasKey("TimeEntryID", "UserName");

                    b.HasIndex("DailyReportID");

                    b.ToTable("DailyReportTimeEntryUsers");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.DailyReportUser", b =>
                {
                    b.Property<int>("DailyReportID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("UserName")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnOrder(1);

                    b.HasKey("DailyReportID", "UserName");

                    b.ToTable("DailyReportUsers");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.Job", b =>
                {
                    b.Property<string>("JobID")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CustomerCode")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("CustomerContact")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("DoubleTimeHours")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("NormalHoursDaily")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NormalHoursEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NormalHoursStart")
                        .HasColumnType("datetime2");

                    b.HasKey("JobID");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.JobCorrespondent", b =>
                {
                    b.Property<int>("JobCorrespondentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobCorrespondentID"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("JobID")
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("JobCorrespondentID");

                    b.HasIndex("JobID");

                    b.ToTable("JobCorrespondents");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.JobResourceType", b =>
                {
                    b.Property<string>("JobID")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnOrder(0);

                    b.Property<int>("ResourceTypeID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<decimal>("Rate")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("JobID", "ResourceTypeID");

                    b.HasIndex("ResourceTypeID");

                    b.ToTable("JobResourceTypes");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.JobSubJob", b =>
                {
                    b.Property<string>("JobID")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnOrder(0);

                    b.Property<int>("SubJobID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("JobID", "SubJobID");

                    b.ToTable("JobSubJobs");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.ResourceType", b =>
                {
                    b.Property<int>("ResourceTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResourceTypeID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Rate")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("ResourceDescShort")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ResourceTypeID");

                    b.ToTable("ResourceTypes");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.SubJobType", b =>
                {
                    b.Property<int>("SubJobID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubJobID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("JobSubJobJobID")
                        .HasColumnType("nvarchar(8)");

                    b.Property<int?>("JobSubJobSubJobID")
                        .HasColumnType("int");

                    b.HasKey("SubJobID");

                    b.HasIndex("JobSubJobJobID", "JobSubJobSubJobID");

                    b.ToTable("SubJobTypes");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.DailyReport", b =>
                {
                    b.HasOne("ServiceRecord.Core.WebAPI.Models.Job", null)
                        .WithMany("DailyReports")
                        .HasForeignKey("JobID");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.DailyReportTimeEntry", b =>
                {
                    b.HasOne("ServiceRecord.Core.WebAPI.Models.DailyReport", null)
                        .WithMany("DailyReportTimeEntry")
                        .HasForeignKey("DailyReportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.DailyReportTimeEntryUser", b =>
                {
                    b.HasOne("ServiceRecord.Core.WebAPI.Models.DailyReport", null)
                        .WithMany("DailyReportTimeEntryUser")
                        .HasForeignKey("DailyReportID");

                    b.HasOne("ServiceRecord.Core.WebAPI.Models.DailyReportTimeEntry", null)
                        .WithMany("DailyReportTimeEntryUsers")
                        .HasForeignKey("TimeEntryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.DailyReportUser", b =>
                {
                    b.HasOne("ServiceRecord.Core.WebAPI.Models.DailyReport", null)
                        .WithMany("DailyReportUser")
                        .HasForeignKey("DailyReportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.JobCorrespondent", b =>
                {
                    b.HasOne("ServiceRecord.Core.WebAPI.Models.Job", null)
                        .WithMany("JobCorrespondents")
                        .HasForeignKey("JobID");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.JobResourceType", b =>
                {
                    b.HasOne("ServiceRecord.Core.WebAPI.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceRecord.Core.WebAPI.Models.ResourceType", null)
                        .WithMany("JobResourceTypes")
                        .HasForeignKey("ResourceTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.SubJobType", b =>
                {
                    b.HasOne("ServiceRecord.Core.WebAPI.Models.JobSubJob", "JobSubJob")
                        .WithMany("SubJobTypes")
                        .HasForeignKey("JobSubJobJobID", "JobSubJobSubJobID");

                    b.Navigation("JobSubJob");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.DailyReport", b =>
                {
                    b.Navigation("DailyReportTimeEntry");

                    b.Navigation("DailyReportTimeEntryUser");

                    b.Navigation("DailyReportUser");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.DailyReportTimeEntry", b =>
                {
                    b.Navigation("DailyReportTimeEntryUsers");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.Job", b =>
                {
                    b.Navigation("DailyReports");

                    b.Navigation("JobCorrespondents");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.JobSubJob", b =>
                {
                    b.Navigation("SubJobTypes");
                });

            modelBuilder.Entity("ServiceRecord.Core.WebAPI.Models.ResourceType", b =>
                {
                    b.Navigation("JobResourceTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
