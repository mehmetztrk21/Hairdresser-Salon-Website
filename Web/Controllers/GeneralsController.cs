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

    public class GeneralsController : Controller
    {
        private readonly MekhannDb _context = new MekhannDb();

        // GET: Generals
        public async Task<IActionResult> Index()
        {
            return View(await _context.General.ToListAsync());
        }

        // GET: Generals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var general = await _context.General
                .FirstOrDefaultAsync(m => m.Id == id);
            if (general == null)
            {
                return NotFound();
            }

            return View(general);
        }

        // GET: Generals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Generals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Slogan,Description,Saloon_img,Saloon_Context,About_Context,Adress,Mail,Phone,Map,Instagram,Youtube,Whatsapp")] General general)
        {
            if (ModelState.IsValid)
            {
                _context.Add(general);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(general);
        }

        // GET: Generals/Edit/5
        public async Task<IActionResult> Edit(int id = 1)
        {


            var general = await _context.General.FindAsync(id);
            if (general == null)
            {
                return NotFound();
            }
            return View(general);
        }

        // POST: Generals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Slogan,Description,avatar_context,avatar,ServiceParagraf,ContactParagraf,Saloon_img,Saloon_Context,About_Context,Adress,Mail,Phone,Map,Instagram,Youtube,Whatsapp")] General general, IFormFile image, IFormFile image_avatar)
        {
            if (id != general.Id)
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
                        general.Saloon_img = randomName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\images", randomName); //resmin kaydedileceği yer.

                        using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await image.CopyToAsync(stream);  //kaydettik.
                        }
                    }
                }
                if (image_avatar != null)
                {
                    {
                        var extention = Path.GetExtension(image_avatar.FileName);  //resmin uzantısını bulduk.
                        var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        general.avatar = randomName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\images", randomName); //resmin kaydedileceği yer.

                        using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await image_avatar.CopyToAsync(stream);  //kaydettik.
                        }
                    }
                }

                try
                {
                    _context.Update(general);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralExists(general.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Edit));
            }
            return View(general);
        }

        // GET: Generals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var general = await _context.General
                .FirstOrDefaultAsync(m => m.Id == id);
            if (general == null)
            {
                return NotFound();
            }

            return View(general);
        }

        // POST: Generals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var general = await _context.General.FindAsync(id);
            _context.General.Remove(general);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralExists(int id)
        {
            return _context.General.Any(e => e.Id == id);
        }
    }
}
