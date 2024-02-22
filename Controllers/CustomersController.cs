using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceRecord.Core.WebAPI.DatabaseContext;
using ServiceRecord.Core.WebAPI.Models;

namespace ServiceRecord.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//if [ApiController] is omitted then [FromBody] has to be added to the routes
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public ReturnObject<List<Customer>> GetCustomers()
        {
            List<Customer> list = new List<Customer>();

          if (_context.Customers == null)
          {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<List<Customer>>() { Success = false, Data = list, Validated = true, ReturnCode = 1 };
            }

            list = _context.Customers.ToList();

            return new ReturnObject<List<Customer>>() { Success = true, Data = list, Validated = true };
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public ReturnObject<Customer> UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!CustomerExists(customer.CustomerId))
                {
                    //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                    return new ReturnObject<Customer>() { Success = false, Data = customer, Validated = true, ReturnCode = 2 };
                }
                else
                {
                    //throw;
                    return new ReturnObject<Customer>() { Success = false, Data = customer, Validated = true, Message = e.Message };
                }
            }

            return new ReturnObject<Customer>() { Success = true, Data = customer, Validated = true };
        }

        [HttpPost]
        [Route("AddCustomer")]
        public ReturnObject<Customer> AddCustomer(Customer customer)
        {
            if (_context.Customers == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<Customer>() { Success = false, Data = customer, Validated = true, ReturnCode = 1 };
            }

            _context.Customers.Add(customer);
            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                //if the customer already exists...
                if (CustomerExists(customer.CustomerId))
                {
                    //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                    return new ReturnObject<Customer>() { Success = false, Data = customer, Validated = true, ReturnCode = 3 };
                }
                else
                {  
                    return new ReturnObject<Customer>() { Success = false, Data = customer, Validated = true, Message = e.Message };
                }
            }

            return new ReturnObject<Customer>() { Success = true, Data = customer, Validated = true };
        }

        [HttpPost]
        [Route("DeleteCustomer")]
        public ReturnObject<Customer> DeleteCustomer(string id)
        {
            if (_context.Customers == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<Customer>() { Success = false, Data = null, Validated = true, ReturnCode = 1 };
            }

            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<Customer>() { Success = false, Data = customer, Validated = true, ReturnCode = 2 };
            }

            _context.Customers.Remove(customer);
            _context.SaveChangesAsync();

            return new ReturnObject<Customer>() { Success = true, Data = customer, Validated = true };
        }

        private bool CustomerExists(string id)
        {
            return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }

        //// GET: api/Customers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomer(string id)
        //{
        //  if (_context.Customers == null)
        //  {
        //      return NotFound();
        //  }
        //    var customer = await _context.Customers.FindAsync(id);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return customer;
        //}
    }
}
