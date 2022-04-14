using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary1.ViewModels;
using ClassLibrary1.Models;
using WebApplication1.Models;
using WebApplication1.Helper;
using System.IO;

namespace WebApplication1.Controllers
{
    public class GalerijaController : Controller
    {
        private mojDbContext db;

        public GalerijaController(mojDbContext c)
        {
            db = c;
        }
        public IActionResult Slike()
        {

           

            List<SlikaVM> slika = db.Slika
                .Select(s => new SlikaVM
                {
                   SlikaID= s.SlikaID,
                   nazivSlike= s.lokacijaSlike


                }).ToList();

            ViewData["slikaKljuc"] = slika;
            //db.Dispose();


            return View();

        }

        public IActionResult Dodaj()
        {

            var model = new DodajSliku
            {


            };
            return View();

        }
        [HttpPost]

        public IActionResult Spasi(DodajSliku model)
        {
            int last_id = db.Slika.Count();

            Slika obavijest = new Slika();
            obavijest.SlikaID = last_id + 1;
            obavijest.datumPostavljanja = model.Datum;
            obavijest.lokacijaSlike = model.Lokacija;
            //obavijest.UserID = Autenfikacija.GetLogiraniKorisnik(HttpContext).UserID;
            // obavijest.UserID = model.UserId;
             obavijest.slika = model.Slika;
           
            if (model.slikaStudentaNew != null)
            {
                string ekstenzija = Path.GetExtension(model.slikaStudentaNew.FileName);
                string contentType = model.slikaStudentaNew.ContentType;

                var filename = $"{Guid.NewGuid()}{ekstenzija}";
                string folder = "wwwroot/uploads/";
                bool exists = System.IO.Directory.Exists(folder);
                if (!exists)
                    System.IO.Directory.CreateDirectory(folder);

                model.slikaStudentaNew.CopyTo(new FileStream(folder + filename, FileMode.Create));
                obavijest.lokacijaSlike = filename;
            }
            db.Slika.Add(obavijest);
            db.SaveChanges();
            return RedirectToAction("Pregled");

        }
        public IActionResult Pregled()
        {
            SlikaPregled model = new SlikaPregled();
            model.Listt = new List<SlikaVM>();
            List<Slika> list = db.Slika.ToList();
            foreach (var item in list)
            {
                SlikaVM vm = new SlikaVM();
                vm.SlikaID = item.SlikaID;
              
                vm.Lokacija = item.lokacijaSlike;
                vm.Datum = item.datumPostavljanja;
                model.Listt.Add(vm);
            }
            return View(model);
        }
        public IActionResult Izbrisi(int id)
        {
            var model = db.Slika.Where(i => i.SlikaID == id).FirstOrDefault();
            db.Remove(model);
            db.SaveChanges();

            return RedirectToAction("Pregled");

        }
        public IActionResult Uredi(int id)
        {
            var model = db.Slika.Where(i => i.SlikaID == id).FirstOrDefault();
            return View(model);
        }
        public IActionResult SpasiUredi(Slika mod)
        {
            var model = db.Slika.Where(i => i.SlikaID == mod.SlikaID).FirstOrDefault();
            db.Remove(model);
            db.Add(mod);
            db.SaveChanges();

            return RedirectToAction("Pregled");

        }
    }
}