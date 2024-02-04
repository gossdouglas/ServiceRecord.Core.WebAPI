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

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        {
          if (_context.Jobs == null)
          {
              return NotFound();
          }
            return await _context.Jobs.ToListAsync();
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(string id)
        {
          if (_context.Jobs == null)
          {
              return NotFound();
          }
            var job = await _context.Jobs.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // PUT: api/Jobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(string id, Job job)
        {
            if (id != job.JobID)
            {
                return BadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //// POST: api/Jobs
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Job>> PostJob(Job job)
        //{
        //  if (_context.Jobs == null)
        //  {
        //      return Problem("Entity set 'ApplicationDbContext.Jobs'  is null.");
        //  }
        //    _context.Jobs.Add(job);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (JobExists(job.JobID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetJob", new { id = job.JobID }, job);
        //}

        //[HttpPost]
        //[Route("AddJob")]
        //public JsonResult AddJob()
        //{
        //    Job job = new Job();

        //    job.Active = true;


        //    return new JsonResult((new ReturnObject<Job>() { Success = false, Data = job, Validated = true }));
        //}

        [HttpPost]
        [Route("AddJob")]
        public ReturnObject<VmJob> AddJob(VmJob? data)
        {
            VmJob incomingDataCopy = new VmJob();
            incomingDataCopy = data;

            if (_context.Jobs == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<VmJob>() { Success = false, Data = data, Validated = true, ReturnCode = 1 };
            }

            try
            {
                //save if doesn't exist
                if (!JobExists(data.Job.JobID))
                {
                    _context.Jobs.Add(data.Job);
                    //_context.SaveChangesAsync();
                    //_context.SaveChanges();
                }
                else
                {
                    //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                    return new ReturnObject<VmJob>() { Success = false, Data = data, Validated = true, ReturnCode = 3 };
                }

                if (data.JobSubJobAdd != null)
                {
                    //foreach (JobSubJob item in data.JobSubJobAdd)
                    //{                        
                    //        _context.JobSubJobs.Add(item);
                    //        _context.SaveChanges();                       
                    //}

                    foreach (JobSubJob item in data.JobSubJobAdd)
                    {
                        //save if doesn't exist
                        if (!JobSubJobExists(item.JobID, item.SubJobID))
                        {
                            _context.JobSubJobs.Add(item);
                            //_context.SaveChangesAsync();
                            //_context.SaveChanges();
                        }
                        else
                        {
                            //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                            return new ReturnObject<VmJob>() { Success = false, Data = data, Validated = true, ReturnCode = 3 };
                        }
                    }

                    //save changes to the JobSubJob table
                    //_context.SaveChanges();
                }

            }
            catch (DbUpdateException e)
            {               
                    return new ReturnObject<VmJob>() { Success = false, Data = data, Validated = true, Message = e.Message };
            }
            _context.SaveChanges();

            return new ReturnObject<VmJob>() { Success = true, Data = data, Validated = true };
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

        private bool JobSubJobExists(string jobId, int subJobId)
        {
            //return whether there are any records in the JobSubJobs table that have the passed jobId and subJobId
            return (_context.JobSubJobs?.Any(e => e.JobID == jobId)).GetValueOrDefault() 
                && (_context.JobSubJobs?.Any(e => e.SubJobID == subJobId)).GetValueOrDefault();
        }
    }
}
