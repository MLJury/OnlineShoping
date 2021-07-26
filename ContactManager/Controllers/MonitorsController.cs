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
    public class MonitorsController : Controller
    {
        public MonitorsController(IHttpClientHub httpClientHub)
        {
            _httpClientHub = httpClientHub;
        }

        private readonly IHttpClientHub _httpClientHub;
        // GET: Monitors
        public async Task<IActionResult> Index()
        {
            var listResult = await _httpClientHub.PostAsync<List<Monitor>>("https://localhost:44373/api/Monitor/List");

            return View(listResult);
        }

        // GET: Monitors/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Monitor>($"https://localhost:44373/api/Monitor/Get/{id}");

            return View(getResult);
        }

        // GET: Monitors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreationDate,CreatorPersonId")] Monitor Monitor)
        {
            if (ModelState.IsValid)
            {
                var addResult = await _httpClientHub.PostAsync<Monitor, string>(Monitor, $"https://localhost:44373/api/Monitor/Add");

                return RedirectToAction(nameof(Index));
            }
            return View(Monitor);
        }

        // GET: Monitors/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Monitor>($"https://localhost:44373/api/Monitor/Get/{id}");
            if (getResult == null)
            {
                return NotFound();
            }
            return View(getResult);
        }

        // POST: Monitors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,CreationDate,CreatorPersonId")] Monitor Monitor)
        {
            if (id != Monitor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var editResult = await _httpClientHub.PostAsync<Monitor, string>(Monitor, $"https://localhost:44373/api/Monitor/Edit");
                return RedirectToAction(nameof(Index));
            }
            return View(Monitor);
        }

        // GET: Monitors/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Monitor>($"https://localhost:44373/api/Monitor/Get/{id}");
            if (getResult == null)
            {
                return NotFound();
            }

            return View(getResult);
        }

        // POST: Monitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var deleteResult = await _httpClientHub.PostAsync<Monitor>($"https://localhost:44373/api/Monitor/Delete/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
