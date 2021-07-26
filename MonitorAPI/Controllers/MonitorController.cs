using AllInOneAPI.EF;
using Microsoft.AspNetCore.Mvc;
using MonitorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonitorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        public MonitorController()
        {
            _context = new UnitOfWork();
        }
        private readonly UnitOfWork _context;
        // GET: api/<AllInOneController>
        [HttpPost("List")]
        public IEnumerable<Monitor> List()
        {
            return _context.MonitorRepository.Get();
        }

        // GET api/<AllInOneController>/5
        [HttpPost("Get/{id}")]
        public Monitor Get(long id)
        {
            return _context.MonitorRepository.GetByID(id);
        }

        // POST api/<AllInOneController>
        [HttpPost("Add")]
        public void Add([FromBody] Monitor value)
        {
            value.CreationDate = DateTime.Now;
            value.CreatorPersonId = 1;

            _context
                .MonitorRepository
                .Insert(value);

            _context
                .Save();
        }

        // PUT api/<AllInOneController>/5
        [HttpPost("Edit")]
        public void Edit(Monitor value)
        {
            _context
                .MonitorRepository
                .Update(value);

            _context
                .Save();
        }

        // DELETE api/<AllInOneController>/5
        [HttpPost("Delete/{id}")]
        public void Delete(long id)
        {
            _context
                .MonitorRepository
                .Delete(id);

            _context
                .Save();
        }
    }
}
