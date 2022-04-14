using ClassLibrary1.Models;
using ClassLibrary1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Poslovnicaa : Controller
    {
        private mojDbContext db;

        public Poslovnicaa(mojDbContext c)
        {
            db = c;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dodaj()
        {

            var model = new DodajPoslovnicu
            {


            };
            return View();

        }
       
        public IActionResult Spasi(DodajPoslovnicu model)
        {
            int last_id = db.Rezervacija.Count();

            Poslovnica pos = new Poslovnica();
            pos.PoslovnicaID = last_id + 1;
            pos.Adresa = model.Adresa;
            pos.Naziv = model.Naziv;
            pos.UserID = Autenfikacija.GetLogiraniKorisnik(HttpContext).UserID;

            db.Poslovnica.Add(pos);
            db.SaveChanges();

            return RedirectToAction("Pregled");
            
        }
       
        public IActionResult Izbrisi(int id)
        {
            var model = db.Poslovnica.Where(i => i.PoslovnicaID == id).FirstOrDefault();
            db.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Pregled");
        }
        
        public IActionResult Uredi(int id)
        {
            var model = db.Poslovnica.Where(i => i.PoslovnicaID == id).FirstOrDefault();
            return View(model);
        }
       
        public IActionResult SpasiUredi(Poslovnica mod)
        {
            var model = db.Poslovnica.Where(i => i.PoslovnicaID == mod.PoslovnicaID).FirstOrDefault();
            db.Remove(model);
            db.Add(mod);
            db.SaveChanges();
            return RedirectToAction("Pregled");
        }
        public IActionResult Pregled()
        {
            PoslovnicePregled model = new PoslovnicePregled();
            model.Listt = new List<PoslovnicaVM>();
            List<Poslovnica> list = db.Poslovnica.ToList();
            foreach(var item in list)
            {
                PoslovnicaVM vm = new PoslovnicaVM();
                vm.Adresa = item.Adresa;
                vm.Naziv = item.Naziv;
                vm.PoslovnicaID = item.PoslovnicaID;
                model.Listt.Add(vm);
            }
            return View(model);
        }
    }
}
