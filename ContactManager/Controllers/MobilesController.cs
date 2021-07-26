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
    public class MobilesController : Controller
    {
        public MobilesController(IHttpClientHub httpClientHub)
        {
            _httpClientHub = httpClientHub;
        }

        private readonly IHttpClientHub _httpClientHub;
        // GET: Mobiles
        public async Task<IActionResult> Index()
        {
            var listResult = await _httpClientHub.PostAsync<List<Mobile>>("https://localhost:44373/api/Mobile/List");

            return View(listResult);
        }

        // GET: Mobiles/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Mobile>($"https://localhost:44373/api/Mobile/Get/{id}");

            return View(getResult);
        }

        // GET: Mobiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mobiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreationDate,CreatorPersonId")] Mobile Mobile)
        {
            if (ModelState.IsValid)
            {
                var addResult = await _httpClientHub.PostAsync<Mobile, string>(Mobile, $"https://localhost:44373/api/Mobile/Add");

                return RedirectToAction(nameof(Index));
            }
            return View(Mobile);
        }

        // GET: Mobiles/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Mobile>($"https://localhost:44373/api/Mobile/Get/{id}");
            if (getResult == null)
            {
                return NotFound();
            }
            return View(getResult);
        }

        // POST: Mobiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,CreationDate,CreatorPersonId")] Mobile Mobile)
        {
            if (id != Mobile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var editResult = await _httpClientHub.PostAsync<Mobile, string>(Mobile, $"https://localhost:44373/api/Mobile/Edit");
                
                return RedirectToAction(nameof(Index));
            }
            return View(Mobile);
        }

        // GET: Mobiles/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<Mobile>($"https://localhost:44373/api/Mobile/Get/{id}");
            if (getResult == null)
            {
                return NotFound();
            }

            return View(getResult);
        }

        // POST: Mobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var deleteResult = await _httpClientHub.PostAsync<Mobile>($"https://localhost:44373/api/Mobile/Delete/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
