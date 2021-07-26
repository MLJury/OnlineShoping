using AllInOneAPI.EF;
using CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {
            _context = new UnitOfWork();
        }
        private readonly UnitOfWork _context;
        // GET: api/<AllInOneController>
        [HttpPost("List")]
        public IEnumerable<Customer> List()
        {
            return _context.CustomerRepository.Get();
        }

        // GET api/<AllInOneController>/5
        [HttpPost("Get/{id}")]
        public Customer Get(long id)
        {
            return _context.CustomerRepository.GetByID(id);
        }

        // POST api/<AllInOneController>
        [HttpPost("Add")]
        public void Add([FromBody] Customer value)
        {
            value.CreationDate = DateTime.Now;
            value.CreatorPersonId = 1;

            _context
                .CustomerRepository
                .Insert(value);

            _context
                .Save();
        }

        // PUT api/<AllInOneController>/5
        [HttpPost("Edit")]
        public void Edit(Customer value)
        {
            _context
                .CustomerRepository
                .Update(value);

            _context
                .Save();
        }

        // DELETE api/<AllInOneController>/5
        [HttpPost("Delete/{id}")]
        public void Delete(long id)
        {
            _context
                .CustomerRepository
                .Delete(id);

            _context
                .Save();
        }
    }
}
