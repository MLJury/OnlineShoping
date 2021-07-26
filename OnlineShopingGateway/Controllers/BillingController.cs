using Microsoft.AspNetCore.Mvc;
using OnlineShopingGatewayAPI.Models;
using OnlineShopingGatewayAPI.Utils;
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
        public BillingController(IHttpClientHub httpClientHub)
        {
            _httpClientHub = httpClientHub;
        }
        private readonly IHttpClientHub _httpClientHub;

        // GET: api/<BillingController>
        [HttpPost("List")]
        public async Task<string> List()
        {
            var listResult = await _httpClientHub.PostAsync("https://localhost:44304/api/Billing/List");

            return listResult;
        }

        // GET api/<BillingController>/5
        [HttpPost("Get/{id}")]
        public async Task<string> Get(int id)
        {
            var getResult = await _httpClientHub.PostAsync($"https://localhost:44304/api/Billing/Get/{id}");
            return getResult;
        }

        // POST api/<BillingController>
        [HttpPost("Add")]
        public async Task AddAsync(JsonObject model)
        {
            await _httpClientHub.PostAsync<string>(model, "https://localhost:44304/api/Billing/Add");
        }

        // PUT api/<BillingController>/5
        [HttpPost("Edit")]
        public async Task Edit(JsonObject model)
        {
            await _httpClientHub.PostAsync<string>(model, "https://localhost:44304/api/Billing/Edit");
        }

        // DELETE api/<BillingController>/5
        [HttpPost("Delete/{id}")]
        public async Task Delete(long id)
        {
            var deleteResult = await _httpClientHub.PostAsync($"https://localhost:44304/api/Billing/Delete/{id}");
        }
    }
}
