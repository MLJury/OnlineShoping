using AllInOneAPI.EF;
using LaptopAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : Controller
    {
        public LaptopController()
        {
            _context = new UnitOfWork();
        }
        private readonly UnitOfWork _context;
        // GET: api/<AllInOneController>
        [HttpPost("List")]
        public IEnumerable<Laptop> List()
        {
            return _context.LaptopRepository.Get();
        }

        // GET api/<AllInOneController>/5
        [HttpPost("Get/{id}")]
        public Laptop Get(long id)
        {
            return _context.LaptopRepository.GetByID(id);
        }

        // POST api/<AllInOneController>
        [HttpPost("Add")]
        public void Add([FromBody] Laptop value)
        {
            value.CreationDate = DateTime.Now;
            value.CreatorPersonId = 1;

            _context
                .LaptopRepository
                .Insert(value);

            _context
                .Save();
        }

        // PUT api/<AllInOneController>/5
        [HttpPost("Edit")]
        public void Edit(Laptop value)
        {
            _context
                .LaptopRepository
                .Update(value);

            _context
                .Save();
        }

        // DELETE api/<AllInOneController>/5
        [HttpPost("Delete/{id}")]
        public void Delete(long id)
        {
            _context
                .LaptopRepository
                .Delete(id);

            _context
                .Save();
        }
    }
}
