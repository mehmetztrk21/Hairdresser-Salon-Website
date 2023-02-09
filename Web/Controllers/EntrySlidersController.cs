using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = "admin")]

    public class EntrySlidersController : Controller
    {
        private readonly MekhannDb _context = new MekhannDb();

        // GET: EntrySliders
        public async Task<IActionResult> Index()
        {
            return View(await _context.EntrySliders.ToListAsync());
        }

        // GET: EntrySliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrySlider = await _context.EntrySliders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrySlider == null)
            {
                return NotFound();
            }

            return View(entrySlider);
        }

        // GET: EntrySliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntrySliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subtitle,Title,Description")] EntrySlider entrySlider,IFormFile image )
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    {
                        var extention = Path.GetExtension(image.FileName);  //resmin uzantısını bulduk.
                        var randomName = Guid.NewGuid().ToString(); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        var randomName2 = randomName+"@2x";
                        randomName = string.Format($"{randomName}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        randomName2 = string.Format($"{randomName2}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.

                        entrySlider.Image = randomName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\images", randomName); //resmin kaydedileceği yer.
                        var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\images", randomName2); //resmin kaydedileceği yer.

                        using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await image.CopyToAsync(stream);  //kaydettik.
                        }
                        using (var stream = new FileStream(path2, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await image.CopyToAsync(stream);  //kaydettik.
                        }
                    }
                }
                _context.Add(entrySlider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entrySlider);
        }

        // GET: EntrySliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrySlider = await _context.EntrySliders.FindAsync(id);
            if (entrySlider == null)
            {
                return NotFound();
            }
            return View(entrySlider);
        }

        // POST: EntrySliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subtitle,Title,Description,Image")] EntrySlider entrySlider,IFormFile image)
        {
            if (id != entrySlider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    {
                        var extention = Path.GetExtension(image.FileName);  //resmin uzantısını bulduk.
                        var randomName = Guid.NewGuid().ToString(); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        var randomName2 = randomName + "@2x";
                        randomName = string.Format($"{randomName}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        randomName2 = string.Format($"{randomName2}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.

                        entrySlider.Image = randomName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\images", randomName); //resmin kaydedileceği yer.
                        var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\images", randomName2); //resmin kaydedileceği yer.

                        using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await image.CopyToAsync(stream);  //kaydettik.
                        }
                        using (var stream = new FileStream(path2, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await image.CopyToAsync(stream);  //kaydettik.
                        }
                    }
                }

                try
                {
                    _context.Update(entrySlider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrySliderExists(entrySlider.Id))
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
            return View(entrySlider);
        }

        // GET: EntrySliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrySlider = await _context.EntrySliders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrySlider == null)
            {
                return NotFound();
            }

            return View(entrySlider);
        }

        // POST: EntrySliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrySlider = await _context.EntrySliders.FindAsync(id);
            _context.EntrySliders.Remove(entrySlider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrySliderExists(int id)
        {
            return _context.EntrySliders.Any(e => e.Id == id);
        }
    }
}
