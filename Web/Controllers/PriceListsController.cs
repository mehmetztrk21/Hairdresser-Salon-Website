using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entity;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = "admin")]

    public class PriceListsController : Controller
    {
        private readonly MekhannDb _context = new MekhannDb();

        // GET: PriceLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.PriceList.ToListAsync());
        }

        // GET: PriceLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceList = await _context.PriceList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceList == null)
            {
                return NotFound();
            }

            return View(priceList);
        }

        // GET: PriceLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PriceLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] PriceList priceList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priceList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(priceList);
        }

        // GET: PriceLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceList = await _context.PriceList.FindAsync(id);
            if (priceList == null)
            {
                return NotFound();
            }
            return View(priceList);
        }

        // POST: PriceLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] PriceList priceList)
        {
            if (id != priceList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priceList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceListExists(priceList.Id))
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
            return View(priceList);
        }

        // GET: PriceLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceList = await _context.PriceList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceList == null)
            {
                return NotFound();
            }

            return View(priceList);
        }

        // POST: PriceLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var priceList = await _context.PriceList.FindAsync(id);
            _context.PriceList.Remove(priceList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriceListExists(int id)
        {
            return _context.PriceList.Any(e => e.Id == id);
        }
    }
}
