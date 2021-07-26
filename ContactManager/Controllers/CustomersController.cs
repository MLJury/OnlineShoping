using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Models;
using OnlineShoping.Utils;

namespace OnlineShoping.Controllers
{
    public class CustomersController : Controller
    {
        public CustomersController(IHttpClientHub httpClientHub)
        {
            _httpClientHub = httpClientHub;
        }

        private readonly IHttpClientHub _httpClientHub;
        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var listResult = await _httpClientHub.PostAsync<List<Customer>>("https://localhost:44373/api/Customer/List");

            return View(listResult);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Customer>($"https://localhost:44373/api/Customer/Get/{id}");

            return View(getResult);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreationDate,CreatorPersonId")] Customer Customer)
        {
            if (ModelState.IsValid)
            {
                var addResult = await _httpClientHub.PostAsync<Customer, string>(Customer, $"https://localhost:44373/api/Customer/Add");

                return RedirectToAction(nameof(Index));
            }
            return View(Customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Customer>($"https://localhost:44373/api/Customer/Get/{id}");
            if (getResult == null)
            {
                return NotFound();
            }
            return View(getResult);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,CreationDate,CreatorPersonId")] Customer Customer)
        {
            if (id != Customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var editResult = await _httpClientHub.PostAsync<Customer, string>(Customer, $"https://localhost:44373/api/Customer/Edit");
                
                return RedirectToAction(nameof(Index));
            }
            return View(Customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Customer>($"https://localhost:44373/api/Customer/Get/{id}");
            if (getResult == null)
            {
                return NotFound();
            }

            return View(getResult);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var deleteResult = await _httpClientHub.PostAsync<Customer>($"https://localhost:44373/api/Customer/Delete/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
