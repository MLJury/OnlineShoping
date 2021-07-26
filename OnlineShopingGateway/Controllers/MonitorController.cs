using Microsoft.AspNetCore.Mvc;
using OnlineShopingGatewayAPI.Models;
using OnlineShopingGatewayAPI.Utils;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonitorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        public MonitorController(IHttpClientHub httpClientHub)
        {
            _httpClientHub = httpClientHub;
        }
        private readonly IHttpClientHub _httpClientHub;

        // GET: api/<MonitorController>
        [HttpPost("List")]
        public async Task<string> List()
        {
            var listResult = await _httpClientHub.PostAsync("https://localhost:44382/api/Monitor/List");

            return listResult;
        }

        // GET api/<MonitorController>/5
        [HttpPost("Get/{id}")]
        public async Task<string> Get(int id)
        {
            var getResult = await _httpClientHub.PostAsync($"https://localhost:44382/api/Monitor/Get/{id}");
            return getResult;
        }

        // POST api/<MonitorController>
        [HttpPost("Add")]
        public async Task AddAsync(JsonObject model)
        {
            await _httpClientHub.PostAsync<string>(model, "https://localhost:44382/api/Monitor/Add");
        }

        // PUT api/<MonitorController>/5
        [HttpPost("Edit")]
        public async Task Edit(JsonObject model)
        {
            await _httpClientHub.PostAsync<string>(model, "https://localhost:44382/api/Monitor/Edit");
        }

        // DELETE api/<MonitorController>/5
        [HttpPost("Delete/{id}")]
        public async Task Delete(long id)
        {
            var deleteResult = await _httpClientHub.PostAsync($"https://localhost:44382/api/Monitor/Delete/{id}");
        }
    }
}
