using AllInOneAPI.EF;
using BillingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        public BillingController()
        {
            _context = new UnitOfWork();
        }
        private readonly UnitOfWork _context;
        // GET: api/<AllInOneController>
        [HttpPost("List")]
        public IEnumerable<Billing> List()
        {
            return _context.AllInOneRepository.Get();
        }

        // GET api/<AllInOneController>/5
        [HttpPost("Get/{id}")]
        public Billing Get(long id)
        {
            return _context.AllInOneRepository.GetByID(id);
        }

        // POST api/<AllInOneController>
        [HttpPost("Add")]
        public void Add([FromBody] Billing value)
        {
            value.CreationDate = DateTime.Now;
            value.CreatorPersonId = 1;

            _context
                .AllInOneRepository
                .Insert(value);

            _context
                .Save();
        }

        // PUT api/<AllInOneController>/5
        [HttpPost("Edit")]
        public void Edit(Billing value)
        {
            _context
                .AllInOneRepository
                .Update(value);

            _context
                .Save();
        }

        // DELETE api/<AllInOneController>/5
        [HttpPost("Delete/{id}")]
        public void Delete(long id)
        {
            _context
                .AllInOneRepository
                .Delete(id);

            _context
                .Save();
        }
    }
}
