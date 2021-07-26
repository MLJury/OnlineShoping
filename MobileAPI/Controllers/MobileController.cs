using AllInOneAPI.EF;
using Microsoft.AspNetCore.Mvc;
using MobileAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        public MobileController()
        {
            _context = new UnitOfWork();
        }
        private readonly UnitOfWork _context;
        // GET: api/<AllInOneController>
        [HttpPost("List")]
        public IEnumerable<Mobile> List()
        {
            return _context.MobileRepository.Get();
        }

        // GET api/<AllInOneController>/5
        [HttpPost("Get/{id}")]
        public Mobile Get(long id)
        {
            return _context.MobileRepository.GetByID(id);
        }

        // POST api/<AllInOneController>
        [HttpPost("Add")]
        public void Add([FromBody] Mobile value)
        {
            value.CreationDate = DateTime.Now;
            value.CreatorPersonId = 1;

            _context
                .MobileRepository
                .Insert(value);

            _context
                .Save();
        }

        // PUT api/<AllInOneController>/5
        [HttpPost("Edit")]
        public void Edit(Mobile value)
        {
            _context
                .MobileRepository
                .Update(value);

            _context
                .Save();
        }

        // DELETE api/<AllInOneController>/5
        [HttpPost("Delete/{id}")]
        public void Delete(long id)
        {
            _context
                .MobileRepository
                .Delete(id);

            _context
                .Save();
        }
    }
}
