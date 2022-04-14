using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary1.Models;
using ClassLibrary1.ViewModels;
using WebApplication1.Helper;
using WebApplication1.Hubs;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class ObavijestController : Controller
    {
        private mojDbContext db;

        public ObavijestController(mojDbContext c)
        {
            db = c;
        }
        public IActionResult Novosti()
        {



            List<ObavijestVM> obavijest = db.Obavijest
                .Select(p => new ObavijestVM
                {
                    ObavijestID = p.ObavijestID,
                    NazivObavijesti = p.Naslov,
                    SadrZajObavijesti = p.Sadrzaj,
                    nazivSlike = p.Slika.lokacijaSlike


                }).OrderByDescending(p => p.ObavijestID).ToList();

            ViewData["obavijestiKljuc"] = obavijest;



            return View();
        }

        public int brojacObavijesti()
        {
            int br = 0;
            br = db.Obavijest.Select(o => o.ObavijestID).Count();
            return br;
        }

        



        public IActionResult Dodaj()
        {

            var model = new DodajRezervaciju
            {


            };
            return View();

        }
       

        public IActionResult Spasi(DodajObavijest model)
        {
            int last_id = db.Rezervacija.Count();  
            Obavijest obavijest = new Obavijest();
            obavijest.ObavijestID = last_id + 1;
            obavijest.Naslov = model.Naslov;
            obavijest.Sadrzaj = model.Sadrzaj;
            obavijest.VrijemeObjave = model.Vrijeme;
            obavijest.UserID = Autenfikacija.GetLogiraniKorisnik(HttpContext).UserID;
            db.Obavijest.Add(obavijest);    
            db.SaveChanges();
            return RedirectToAction("Pregled");

        }

        public IActionResult Uredi(int id)
        {
            var model = db.Obavijest.Where(i => i.ObavijestID == id).FirstOrDefault();
            return View(model);
        }

        public IActionResult SpasiUredi(Obavijest mod)
        {
            var model = db.Obavijest.Where(i => i.ObavijestID == mod.ObavijestID).FirstOrDefault();
            db.Remove(model);
            db.Add(mod);
            db.SaveChanges();

            return RedirectToAction("Pregled");

        }
        public IActionResult Izbrisi(int id)
        {
            var model = db.Obavijest.Where(i => i.ObavijestID == id).FirstOrDefault();
            db.Remove(model);
            db.SaveChanges();

            return RedirectToAction("Pregled");

        }
        public IActionResult Pregled(string q = "")
        {
            ObavijestPregled model = new ObavijestPregled();
            model.Listt = new List<ObavijestVM>();
            List<Obavijest> list = db.Obavijest.ToList();
            foreach (var item in list)
            {
                ObavijestVM vm = new ObavijestVM();
                vm.SadrZajObavijesti = item.Sadrzaj;
                vm.NazivObavijesti = item.Naslov;
                vm.datum = item.VrijemeObjave;
                vm.ObavijestID = item.ObavijestID;
                model.Listt.Add(vm);
            }

            if (!string.IsNullOrEmpty(q))
            {
                var lista = model.Listt.Where(x => x.NazivObavijesti.ToLower().Contains(q.ToLower())).ToList();
                model.Listt = lista;
            }

            return View(model);
        }

    }
}




