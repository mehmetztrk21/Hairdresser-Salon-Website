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

    public class ImagesController : Controller
    {
        private readonly MekhannDb _context = new MekhannDb();

        // GET: Images
        public async Task<IActionResult> Index()
        {
            var mekhannDb = _context.Images.OrderByDescending(i=>i.Id);
            return View(await mekhannDb.ToListAsync());
        }

        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // GET: Images/Create
        public IActionResult Create()
        {
          
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] Image image,List<IFormFile> images)
        {
            if (ModelState.IsValid)
            {

                if (images != null)
                {
                    foreach (var item in images)
                    {
                        var extention = Path.GetExtension(item.FileName);  //resmin uzantısını bulduk.
                        var randomName = Guid.NewGuid().ToString(); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        var randomName2 = randomName;
                        randomName = string.Format($"{randomName}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        randomName2 = string.Format($"{randomName2}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        var new_image = new Image() { Description = image.Description, img = randomName };
                        _context.Add(new_image);
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\dummy", randomName); //resmin kaydedileceği yer.
                        var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\dummy\\large-gallery", randomName2); //resmin kaydedileceği yer.

                        using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await item.CopyToAsync(stream);  //kaydettik.
                        }
                        using (var stream = new FileStream(path2, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await item.CopyToAsync(stream);  //kaydettik.
                        }
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                return View(image);

            }
          
            return View(image);
        }

        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
           
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,img,Description")] Image image,IFormFile img)
        {
            if (id != image.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    {
                        var extention = Path.GetExtension(img.FileName);  //resmin uzantısını bulduk.
                        var randomName = Guid.NewGuid().ToString(); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        var randomName2 = randomName;
                        randomName = string.Format($"{randomName}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        randomName2 = string.Format($"{randomName2}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.

                        image.img = randomName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\dummy", randomName); //resmin kaydedileceği yer.
                        var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\dummy\\large-gallery", randomName2); //resmin kaydedileceği yer.

                        using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await img.CopyToAsync(stream);  //kaydettik.
                        }
                        using (var stream = new FileStream(path2, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await img.CopyToAsync(stream);  //kaydettik.
                        }
                    }
                }


                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.Id))
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
          
            return View(image);
        }

        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.Images.FindAsync(id);
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
