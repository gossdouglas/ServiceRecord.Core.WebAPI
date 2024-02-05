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

        //[HttpGet]
        //[Route("GetJobs")]
        //public ReturnObject<List<Customer>> GetJobs()
        //{
        //    List<Customer> list = new List<Customer>();

        //    if (_context.Customers == null)
        //    {
        //        //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
        //        return new ReturnObject<List<Customer>>() { Success = false, Data = list, Validated = true, ReturnCode = 1 };
        //    }

        //    list = _context.Customers.ToList();

        //    return new ReturnObject<List<Customer>>() { Success = true, Data = list, Validated = true };
        //}

        //// GET: api/Jobs/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Job>> GetJob(string id)
        //{
        //  if (_context.Jobs == null)
        //  {
        //      return NotFound();
        //  }
        //    var job = await _context.Jobs.FindAsync(id);

        //    if (job == null)
        //    {
        //        return NotFound();
        //    }

        //    return job;
        //}

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
      
        [HttpPost]
        [Route("AddJob")]
        public ReturnObject<VmJob> AddJob(VmJob? data)
        {
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
                }
                else
                {
                    //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                    return new ReturnObject<VmJob>() { Success = false, Data = data, Validated = true, ReturnCode = 3 };
                }

                //save outrightly because there is no chance there will be a duplicate jobId and subJobId due to the logic above
                if (data.JobSubJobAdd != null && _context.JobSubJobs != null)
                {
                    _context.JobSubJobs.AddRange(data.JobSubJobAdd);
                }

                //save changes in the end
                _context.SaveChanges();
            }
            //return upon exception
            catch (DbUpdateException e)
            {               
                    return new ReturnObject<VmJob>() { Success = false, Data = data, Validated = true, Message = e.Message };
            }

            //return upon success
            return new ReturnObject<VmJob>() { Success = true, Data = null, Validated = true };
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
