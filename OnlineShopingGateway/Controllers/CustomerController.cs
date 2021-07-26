using Microsoft.AspNetCore.Mvc;
using OnlineShopingGatewayAPI.Models;
using OnlineShopingGatewayAPI.Utils;
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
        public CustomerController(IHttpClientHub httpClientHub)
        {
            _httpClientHub = httpClientHub;
        }
        private readonly IHttpClientHub _httpClientHub;

        // GET: api/<CustomerController>
        [HttpPost("List")]
        public async Task<string> List()
        {
            var listResult = await _httpClientHub.PostAsync("https://localhost:44387/api/Customer/List");

            return listResult;
        }

        // GET api/<CustomerController>/5
        [HttpPost("Get/{id}")]
        public async Task<string> Get(int id)
        {
            var getResult = await _httpClientHub.PostAsync($"https://localhost:44387/api/Customer/Get/{id}");
            return getResult;
        }

        // POST api/<CustomerController>
        [HttpPost("Add")]
        public async Task AddAsync(JsonObject model)
        {
            await _httpClientHub.PostAsync<string>(model, "https://localhost:44387/api/Customer/Add");
        }

        // PUT api/<CustomerController>/5
        [HttpPost("Edit")]
        public async Task Edit(JsonObject model)
        {
            await _httpClientHub.PostAsync<string>(model, "https://localhost:44387/api/Customer/Edit");
        }

        // DELETE api/<CustomerController>/5
        [HttpPost("Delete/{id}")]
        public async Task Delete(long id)
        {
            var deleteResult = await _httpClientHub.PostAsync($"https://localhost:44387/api/Customer/Delete/{id}");
        }
    }
}
