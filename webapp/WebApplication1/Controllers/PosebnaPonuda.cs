using ClassLibrary1.Models;
using ClassLibrary1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PosebnaPonuda : Controller
    {
        private mojDbContext db;

        public PosebnaPonuda(mojDbContext c)
        {
            db = c;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dodaj()
        {

            var model = new DodajPonudu
            {


            };
            return View();

        }

       

        public IActionResult Spasi(DodajPonudu model)
        {
            int last_id = db.Rezervacija.Count();


            Proizvod proizvod = new Proizvod();
            proizvod.ProizvodID = last_id + 1;
            proizvod.Naziv = model.Naziv;
            proizvod.Opis = model.Opis;
            proizvod.Cijena = model.Cijena;
            proizvod.TipProizvodaID = model.TipProizvodaId;
            db.Proizvod.Add(proizvod);
            db.SaveChanges();
            return RedirectToAction("Pregled");
        }
        public IActionResult Uredi(int id)
        {
            var model = db.Proizvod.Where(i => i.ProizvodID == id).FirstOrDefault();
            return View(model);
        }

        public IActionResult SpasiUredi(Proizvod mod)
        {
            var model = db.Proizvod.Where(i => i.ProizvodID == mod.ProizvodID).FirstOrDefault();
            db.Remove(model);
            db.Add(mod);
            db.SaveChanges();
            return RedirectToAction("Pregled");
        }
        public IActionResult Izbrisi(int id)
        {
            var model = db.Proizvod.Where(i => i.ProizvodID == id).FirstOrDefault();
            db.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Pregled");

        }
        public IActionResult Pregled(string q = "")
        {
            PonudaPregled model = new PonudaPregled();
            model.Listt = new List<ProizvodJelovnikVM>();

            List<Proizvod> list = db.Proizvod.ToList();
            foreach (var item in list)
            {
                ProizvodJelovnikVM vm = new ProizvodJelovnikVM();
                vm.nazivProizvoda = item.Naziv;
                vm.opisProizvoda = item.Opis;
                vm.cijenaProizvoda = item.Cijena;
                //  vm.tipProizvoda = item.TipProizvoda.TipProizvodaID.ToString();
                vm.ProizvodID = item.ProizvodID;
                model.Listt.Add(vm);
            }

            if (!string.IsNullOrEmpty(q))
            {
                var lista = model.Listt.Where(x => x.nazivProizvoda.ToLower().Contains(q.ToLower())).ToList();
                model.Listt = lista;
            }

            return View(model);
        }
    }
}
