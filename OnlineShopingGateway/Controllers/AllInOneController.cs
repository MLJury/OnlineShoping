using Microsoft.AspNetCore.Mvc;
using OnlineShopingGatewayAPI.Models;
using OnlineShopingGatewayAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllInOneController : ControllerBase
    {
        public AllInOneController(IHttpClientHub httpClientHub)
        {
            _httpClientHub = httpClientHub;
        }
        private readonly IHttpClientHub _httpClientHub;

        // GET: api/<AllInOneController>
        [HttpPost("List")]
        public async Task<string> List()
        {
            var listResult = await _httpClientHub.PostAsync("https://localhost:44369/api/AllInOne/List");

            return listResult;
        }

        // GET api/<AllInOneController>/5
        [HttpPost("Get/{id}")]
        public async Task<string> Get(int id)
        {
            var getResult = await _httpClientHub.PostAsync($"https://localhost:44369/api/AllInOne/Get/{id}");
            return getResult;
        }

        // POST api/<AllInOneController>
        [HttpPost("Add")]
        public async Task AddAsync(JsonObject model)
        {
            await _httpClientHub.PostAsync<string>(model, "https://localhost:44369/api/AllInOne/Add");
        }

        // PUT api/<AllInOneController>/5
        [HttpPost("Edit")]
        public async Task Edit(JsonObject model)
        {
            await _httpClientHub.PostAsync<string>(model, "https://localhost:44369/api/AllInOne/Edit");
        }

        // DELETE api/<AllInOneController>/5
        [HttpPost("Delete/{id}")]
        public async Task Delete(long id)
        {
            var deleteResult = await _httpClientHub.PostAsync($"https://localhost:44369/api/AllInOne/Delete/{id}");
        }
    }
}
