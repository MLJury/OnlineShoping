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
    public class AllInOnesController : Controller
    {
        private readonly AllInOneContext _context;

        public AllInOnesController(IHttpClientHub httpClientHub)
        {
            _httpClientHub = httpClientHub;
        }

        private readonly IHttpClientHub _httpClientHub;
        // GET: AllInOnes
        public async Task<IActionResult> Index()
        {
            var listResult = await _httpClientHub.PostAsync<List<AllInOne>>("https://localhost:44373/api/AllInOne/List");

            return View(listResult);
        }

        // GET: AllInOnes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<AllInOne>($"https://localhost:44373/api/AllInOne/Get/{id}");

            return View(getResult);
        }

        // GET: AllInOnes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllInOnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreationDate,CreatorPersonId")] AllInOne allInOne)
        {
            if (ModelState.IsValid)
            {
                var addResult = await _httpClientHub.PostAsync<AllInOne, string>(allInOne, $"https://localhost:44373/api/AllInOne/Add");

                return RedirectToAction(nameof(Index));
            }
            return View(allInOne);
        }

        // GET: AllInOnes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<AllInOne>($"https://localhost:44373/api/AllInOne/Get/{id}");
            if (getResult == null)
            {
                return NotFound();
            }
            return View(getResult);
        }

        // POST: AllInOnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,CreationDate,CreatorPersonId")] AllInOne allInOne)
        {
            if (id != allInOne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var editResult = await _httpClientHub.PostAsync<AllInOne, string>(allInOne, $"https://localhost:44373/api/AllInOne/Edit");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllInOneExists(allInOne.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(allInOne);
        }

        // GET: AllInOnes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getResult = await _httpClientHub.PostAsync<AllInOne>($"https://localhost:44373/api/AllInOne/Get/{id}");
            if (getResult == null)
            {
                return NotFound();
            }

            return View(getResult);
        }

        // POST: AllInOnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var deleteResult = await _httpClientHub.PostAsync<AllInOne>($"https://localhost:44373/api/AllInOne/Delete/{id}");
            return RedirectToAction(nameof(Index));
        }

        private bool AllInOneExists(long id)
        {
            return _context.AllInOnes.Any(e => e.Id == id);
        }
    }
}
