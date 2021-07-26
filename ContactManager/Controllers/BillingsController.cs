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
    public class BillingsController : Controller
    {
        public BillingsController(IHttpClientHub httpClientHub)
        {
            _httpClientHub = httpClientHub;
        }

        private readonly IHttpClientHub _httpClientHub;
        // GET: Billings
        public async Task<IActionResult> Index()
        {
            var listResult = await _httpClientHub.PostAsync<List<Billing>>("https://localhost:44373/api/Billing/List");

            return View(listResult);
        }

        // GET: Billings/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Billing>($"https://localhost:44373/api/Billing/Get/{id}");

            return View(getResult);
        }

        // GET: Billings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Billings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreationDate,CreatorPersonId")] Billing Billing)
        {
            if (ModelState.IsValid)
            {
                var addResult = await _httpClientHub.PostAsync<Billing, string>(Billing, $"https://localhost:44373/api/Billing/Add");

                return RedirectToAction(nameof(Index));
            }
            return View(Billing);
        }

        // GET: Billings/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Billing>($"https://localhost:44373/api/Billing/Get/{id}");
            if (getResult == null)
            {
                return NotFound();
            }
            return View(getResult);
        }

        // POST: Billings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,CreationDate,CreatorPersonId")] Billing Billing)
        {
            if (id != Billing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var editResult = await _httpClientHub.PostAsync<Billing, string>(Billing, $"https://localhost:44373/api/Billing/Edit");
                return RedirectToAction(nameof(Index));
            }
            return View(Billing);
        }

        // GET: Billings/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Billing>($"https://localhost:44373/api/Billing/Get/{id}");
            if (getResult == null)
            {
                return NotFound();
            }

            return View(getResult);
        }

        // POST: Billings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var deleteResult = await _httpClientHub.PostAsync<Billing>($"https://localhost:44373/api/Billing/Delete/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
