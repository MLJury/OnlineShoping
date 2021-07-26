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
    public class LaptopsController : Controller
    {
        public LaptopsController(IHttpClientHub httpClientHub)
        {
            _httpClientHub = httpClientHub;
        }

        private readonly IHttpClientHub _httpClientHub;
        // GET: Laptops
        public async Task<IActionResult> Index()
        {
            var listResult = await _httpClientHub.PostAsync<List<Laptop>>("https://localhost:44373/api/Laptop/List");

            return View(listResult);
        }

        // GET: Laptops/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Laptop>($"https://localhost:44373/api/Laptop/Get/{id}");

            return View(getResult);
        }

        // GET: Laptops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreationDate,CreatorPersonId")] Laptop Laptop)
        {
            if (ModelState.IsValid)
            {
                var addResult = await _httpClientHub.PostAsync<Laptop, string>(Laptop, $"https://localhost:44373/api/Laptop/Add");

                return RedirectToAction(nameof(Index));
            }
            return View(Laptop);
        }

        // GET: Laptops/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Laptop>($"https://localhost:44373/api/Laptop/Get/{id}");
            if (getResult == null)
            {
                return NotFound();
            }
            return View(getResult);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,CreationDate,CreatorPersonId")] Laptop Laptop)
        {
            if (id != Laptop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var editResult = await _httpClientHub.PostAsync<Laptop, string>(Laptop, $"https://localhost:44373/api/Laptop/Edit");
                return RedirectToAction(nameof(Index));
            }
            return View(Laptop);
        }

        // GET: Laptops/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Laptop>($"https://localhost:44373/api/Laptop/Get/{id}");
            if (getResult == null)
            {
                return NotFound();
            }

            return View(getResult);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var deleteResult = await _httpClientHub.PostAsync<Laptop>($"https://localhost:44373/api/Laptop/Delete/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
