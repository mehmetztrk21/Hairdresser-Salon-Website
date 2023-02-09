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

    public class TeamsController : Controller
    {
        private readonly MekhannDb _context = new MekhannDb();

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Team.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,description,instagram,mail,phone")] Team team,IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    {
                        var extention = Path.GetExtension(image.FileName);  //resmin uzantısını bulduk.
                        var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        team.image = randomName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\images", randomName); //resmin kaydedileceği yer.

                        using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await image.CopyToAsync(stream);  //kaydettik.
                        }
                    }
                }

                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,description,image,instagram,mail,phone")] Team team,IFormFile image)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    {
                        var extention = Path.GetExtension(image.FileName);  //resmin uzantısını bulduk.
                        var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        team.image = randomName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\images", randomName); //resmin kaydedileceği yer.

                        using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await image.CopyToAsync(stream);  //kaydettik.
                        }
                    }
                }

                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
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
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Team.FindAsync(id);
            _context.Team.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.Id == id);
        }
    }
}
