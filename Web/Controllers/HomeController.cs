using Data;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MekhannDb _context = new MekhannDb();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new GeneralModel() { Elemanlar = _context.Team.ToList(), EntrySliders = _context.EntrySliders.ToList(), Fiyatlar = _context.PriceList.ToList(), Kampanyalar = _context.Campaigns.OrderBy(i=>i.Date).ToList(), Resimler = _context.Images.OrderByDescending(i => i.Id).ToList(), Servisler = _context.Services.ToList(), General = _context.General.Find(1) };

            return View(model);
        }

        public IActionResult About()
        {
            var model = new GeneralModel() { Elemanlar = _context.Team.ToList(), EntrySliders = _context.EntrySliders.ToList(), Fiyatlar = _context.PriceList.ToList(), Kampanyalar = _context.Campaigns.ToList(), Resimler = _context.Images.OrderByDescending(i => i.Id).ToList(), Servisler = _context.Services.ToList(), General = _context.General.Find(1) };

            return View(model);
        }
        public IActionResult Contact()
        {
            var model = new GeneralModel() { Elemanlar = _context.Team.ToList(), EntrySliders = _context.EntrySliders.ToList(), Fiyatlar = _context.PriceList.ToList(), Kampanyalar = _context.Campaigns.ToList(), Resimler = _context.Images.OrderByDescending(i => i.Id).ToList(), Servisler = _context.Services.ToList(), General = _context.General.Find(1) };

            return View(model);
        }
        public IActionResult Gallery()
        {
            var model = new GeneralModel() { Elemanlar = _context.Team.ToList(), EntrySliders = _context.EntrySliders.ToList(), Fiyatlar = _context.PriceList.ToList(), Kampanyalar = _context.Campaigns.ToList(), Resimler = _context.Images.OrderByDescending(i => i.Id).ToList(), Servisler = _context.Services.ToList(), General = _context.General.Find(1) };

            return View(model);
        }
        public IActionResult Service()
        {
            var model = new GeneralModel() { Elemanlar = _context.Team.ToList(), EntrySliders = _context.EntrySliders.ToList(), Fiyatlar = _context.PriceList.ToList(), Kampanyalar = _context.Campaigns.ToList(), Resimler = _context.Images.ToList(), Servisler = _context.Services.ToList(), General = _context.General.Find(1) };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Send(string name, string email, string phone, string content)
        {
            if (ModelState.IsValid)
            {
                Messages message = new Messages() { Name = name, Email = email, Phone = phone, Context = content, Date = DateTime.Now };
                _context.Messages.Add(message);
                _context.SaveChanges();
                TempData["success"] = "Mesajınız iletildi. Size en kısa sürede dönüş yapacağız.";
                return RedirectToAction("Index", "Home");
            }
            return View("Contact", "Home");
        }
    }
}