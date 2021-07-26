using AllInOneAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOneAPI.EF;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AllInOneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllInOneController : ControllerBase
    {
        public AllInOneController()
        {
            _context = new UnitOfWork();
        }
        private readonly UnitOfWork _context;
        // GET: api/<AllInOneController>
        [HttpPost("List")]
        public IEnumerable<AllInOne> List()
        {
            return _context.AllInOneRepository.Get();
        }

        // GET api/<AllInOneController>/5
        [HttpPost("Get/{id}")]
        public AllInOne Get(long id)
        {
            return _context.AllInOneRepository.GetByID(id);
        }

        // POST api/<AllInOneController>
        [HttpPost("Add")]
        public void Add([FromBody] AllInOne value)
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
        public void Edit(AllInOne value)
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
