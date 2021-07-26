using Microsoft.AspNetCore.Mvc;
using OnlineShopingGatewayAPI.Models;
using OnlineShopingGatewayAPI.Utils;
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
        public MobileController(IHttpClientHub httpClientHub)
        {
            _httpClientHub = httpClientHub;
        }
        private readonly IHttpClientHub _httpClientHub;

        // GET: api/<MobileController>
        [HttpPost("List")]
        public async Task<string> List()
        {
            var listResult = await _httpClientHub.PostAsync("https://localhost:44372/api/Mobile/List");

            return listResult;
        }

        // GET api/<MobileController>/5
        [HttpPost("Get/{id}")]
        public async Task<string> Get(int id)
        {
            var getResult = await _httpClientHub.PostAsync($"https://localhost:44372/api/Mobile/Get/{id}");
            return getResult;
        }

        // POST api/<MobileController>
        [HttpPost("Add")]
        public async Task AddAsync(JsonObject model)
        {
            await _httpClientHub.PostAsync<string>(model, "https://localhost:44372/api/Mobile/Add");
        }

        // PUT api/<MobileController>/5
        [HttpPost("Edit")]
        public async Task Edit(JsonObject model)
        {
            await _httpClientHub.PostAsync<string>(model, "https://localhost:44372/api/Mobile/Edit");
        }

        // DELETE api/<MobileController>/5
        [HttpPost("Delete/{id}")]
        public async Task Delete(long id)
        {
            var deleteResult = await _httpClientHub.PostAsync($"https://localhost:44372/api/Mobile/Delete/{id}");
        }
    }
}
