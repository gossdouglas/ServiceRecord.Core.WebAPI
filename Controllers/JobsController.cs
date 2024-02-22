using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceRecord.Core.WebAPI.DatabaseContext;
using ServiceRecord.Core.WebAPI.Models;
using ServiceRecord.Core.WebAPI.Models.View_Models;
using ServiceRecord.Core.WebAPI.Models.View_Models.JobVms;

//System.Diagnostics.Debug.WriteLine("get ready.");
//System.Diagnostics.Debug.WriteLine(incomingDataCopy); 

namespace ServiceRecord.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetJobs")]
        public ReturnObject<VmGetJobs> GetJobs()
        {
            //create an object for return
            VmGetJobs jobsReturn = new VmGetJobs();

            try
            {
                //get a list of all jobs
                jobsReturn.JobList = _context.Jobs.ToList();
                //get a list of all sub job types
                jobsReturn.SubJobTypeList = _context.SubJobTypes.ToList();
                //get a list of all resource types
                jobsReturn.ResourceTypeList = _context.ResourceTypes.ToList();  
                //get a list of all customers
                jobsReturn.CustomerList = _context.Customers.ToList();                          
            }

            //return upon exception
            catch (DbUpdateException e)
            {
                return new ReturnObject<VmGetJobs>() { Success = false, Data = null, Validated = true, Message = e.InnerException.ToString() };
            }

            //return upon success
            return new ReturnObject<VmGetJobs>() { Success = true, Data = jobsReturn, Validated = true };
        }

        [HttpPost]
        [Route("UpdateJob")]
        public ReturnObject<VmEditJob> UpdateJob(VmEditJob? data)
        {
            try
            {
                //EDIT-EDIT-EDIT-EDIT-EDIT-EDIT-EDIT-EDIT-EDIT-EDIT-EDIT-EDIT-EDIT-EDIT-EDIT

                //JOB
                if (data.Job != null)
                {
                    _context.Entry(data.Job).State = EntityState.Modified;
                }
                //JobResourceTypes
                if (_context.JobResourceTypes != null && data.JobResourceTypeListEdit != null)
                {
                    _context.JobResourceTypes.UpdateRange(data.JobResourceTypeListEdit);
                }
                //JobCorrespondents
                if (_context.JobCorrespondents != null && data.JobCorrespondentListEdit != null)
                {
                    _context.JobCorrespondents.UpdateRange(data.JobCorrespondentListEdit);
                }

                //ADD-ADD-ADD-ADD-ADD-ADD-ADD-ADD-ADD-ADD-ADD-ADD-ADD-ADD-ADD-ADD-ADD-ADD

                //JobSubJobTypes
                if (data.JobSubJobTypeListAdd != null && _context.JobSubJobTypes != null)
                {
                    _context.JobSubJobTypes.AddRange(data.JobSubJobTypeListAdd);
                }

                //JobResourceTypes
                if (data.JobResourceTypeListAdd != null && _context.JobResourceTypes != null)
                {
                    _context.JobResourceTypes.AddRange(data.JobResourceTypeListAdd);
                }

                //JobCorrespondents
                if (data.JobCorrespondentListAdd != null && _context.JobCorrespondents != null)
                {
                    _context.JobCorrespondents.AddRange(data.JobCorrespondentListAdd);
                }

                //DELETE-DELETE-DELETE-DELETE-DELETE-DELETE-DELETE-DELETE-DELETE-DELETE-DELETE

                //JobSubJobTypes
                if (data.JobSubJobTypeListDelete != null && _context.JobSubJobTypes != null)
                {
                    _context.JobSubJobTypes.RemoveRange(data.JobSubJobTypeListDelete);
                }

                //JobResourceTypes
                if (data.JobResourceTypeListDelete != null && _context.JobResourceTypes != null)
                {
                    _context.JobResourceTypes.RemoveRange(data.JobResourceTypeListDelete);
                }

                //JobCorrespondents
                if (data.JobCorrespondentListDelete != null && _context.JobCorrespondents != null)
                {
                    _context.JobCorrespondents.RemoveRange(data.JobCorrespondentListDelete);
                }

            }
            catch (DbUpdateConcurrencyException e)
            {
                return new ReturnObject<VmEditJob>() { Success = false, Data = null, Validated = true, Message = e.Message };
            }
           
            _context.SaveChanges();

            return new ReturnObject<VmEditJob>() { Success = true, Data = null, Validated = true };
        }

        [HttpPost]
        [Route("AddJob")]
        public ReturnObject<VmAddJob> AddJob(VmAddJob? data)
        {
            if (_context.Jobs == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<VmAddJob>() { Success = false, Data = data, Validated = true, ReturnCode = 1 };
            }

            try
            {
                //save if doesn't exist
                if (!JobExists(data.Job.JobID))
                {
                    _context.Jobs.Add(data.Job);
                }
                else
                {
                    //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                    return new ReturnObject<VmAddJob>() { Success = false, Data = data, Validated = true, ReturnCode = 3 };
                }

                //save outrightly because there is no chance there will be a duplicate jobId and subJobId due to the logic above
                if (data.JobSubJobTypeListAdd != null && _context.JobSubJobTypes != null)
                {
                    _context.JobSubJobTypes.AddRange(data.JobSubJobTypeListAdd);
                }

                //save outrightly because there is no chance there will be a duplicate jobId and subJobId due to the logic above
                if (data.JobResourceTypeListAdd != null && _context.JobResourceTypes != null)
                {
                    _context.JobResourceTypes.AddRange(data.JobResourceTypeListAdd);
                }

                //save outrightly because there is no chance there will be a duplicate jobId and subJobId due to the logic above
                if (data.JobCorrespondentListAdd != null && _context.JobCorrespondents != null)
                {
                    //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.JobCorrespondents ON");
                    _context.JobCorrespondents.AddRange(data.JobCorrespondentListAdd);
                    //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.JobCorrespondents OFF");
                }
            }
            //return upon exception
            catch (DbUpdateException e)
            {               
                    return new ReturnObject<VmAddJob>() { Success = false, Data = null, Validated = true, Message = e.InnerException.ToString() };
            }

            //save changes if there was no exception
            _context.SaveChanges();

            //return upon success
            return new ReturnObject<VmAddJob>() { Success = true, Data = null, Validated = true };
        }

        [HttpPost]
        [Route("DeleteJob")]
        public ReturnObject<Job> DeleteJob(string id)
        {
            if (_context.Jobs == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<Job>() { Success = false, Data = null, Validated = true, ReturnCode = 1 };
            }

            var item = _context.Jobs.Find(id);
            if (item == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<Job>() { Success = false, Data = item, Validated = true, ReturnCode = 2 };
            }

            _context.Jobs.Remove(item);
            _context.SaveChangesAsync();

            return new ReturnObject<Job>() { Success = true, Data = item, Validated = true };
        }

        private bool JobExists(string id)
        {
            return (_context.Jobs?.Any(e => e.JobID == id)).GetValueOrDefault();
        }

        //[HttpPost]
        //[Route("AddJob")]
        //public JsonResult AddJob()
        //{
        //    Job job = new Job();

        //    job.Active = true;


        //    return new JsonResult((new ReturnObject<Job>() { Success = false, Data = job, Validated = true }));
        //}
    }
}
