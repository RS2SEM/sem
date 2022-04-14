using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary1.ViewModels;
using ClassLibrary1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Helper;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class RezervacijaController : Controller
    {
        private mojDbContext db;
        private IConfiguration Configuration;

        public RezervacijaController(mojDbContext c, IConfiguration _config)
        {
            db = c;
            Configuration = _config;
        }
       


        [Autorizacija(true, true)]
        public IActionResult Index()
        {

            return View("Rezervacija");
        }
        [Autorizacija(true, true)]
        public IActionResult RezervacijaPartial(RezervacijaVM mod)
        {
            RezervacijaVM model = new RezervacijaVM();

            if (mod != null)
            {
                RezervacijaVM modeli = new RezervacijaVM();
                modeli = mod;
            }

            model.brojOsoba = db.BrojOsoba
            .Select(p => new SelectListItem
            {
                Value = p.BrojOsobaID.ToString(),
                Text = p.brOsoba.ToString()


            }).ToList();







            model.TerminRezervacije = db.TerminRezervacije
                     .Select(p => new SelectListItem
                     {
                         Value = p.TerminRezervacijeID.ToString(),
                         Text = p.terminRez


                     }).ToList();


            model.poslovnice = db.Poslovnica
                     .Select(p => new SelectListItem
                     {
                         Value = p.PoslovnicaID.ToString(),
                         Text = p.Naziv + ", " + p.Adresa


                     }).ToList();
            model.PoslovnicaID = 1;




            return PartialView(model);
        }

        public IActionResult ProvjeraDatuma(string DatumRezervacije)
        {
            DateTime odabraniDatum = Convert.ToDateTime(DatumRezervacije);
            DateTime trenutniDatum = DateTime.Now;

            if (!(odabraniDatum.Date > trenutniDatum.Date && odabraniDatum.Month >= trenutniDatum.Month && odabraniDatum.Year >= trenutniDatum.Year))
                return Json(false/*"datum mora biti minimalno za jedan dan veci od trenutnog datuma"*/);

            return Json(true);

        }
        [ValidateAntiForgeryToken]
        public IActionResult dodajRezervacija(RezervacijaVM x)
        {

            if (ModelState.IsValid)
            {

                int last_id = db.Rezervacija.Count()+1;


                Rezervacija nova = new Rezervacija
                {
                    RezervacijaID = last_id,
                    PoslovnicaID = x.PoslovnicaID,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Email = x.Email,
                    DatumRezervacije = x.DatumRezervacije,
                    VrijemeZahtjeva = DateTime.Now,
                    TerminRezervacijeID = x.TerminRezervacijeID,
                    BrojOsobaID = x.brojOsobaID,
                    Napomena = x.Napomena,
                    BrojTelefona = x.BrojTelefona,
                    UserID = Autenfikacija.GetLogiraniKorisnik(HttpContext).UserID



                };

                db.Rezervacija.Add(nova);
                db.SaveChanges();

                TempData["uspjesnaRezervacija"] = "rezervacija uspjesno obavljena";
            }
            else
                TempData["uspjesnaRezervacija"] = "rezervacija nije uspjesno obavljena";


            return RedirectToAction("Index", "Home");







        }




        public IActionResult ListaRezervacija()
        {

            return View();
        }

        [Autorizacija(true, true)]
        public IActionResult PrikazRezervacija(int userID)
        {

            ViewData["aktivneRezervacije"] = db.Rezervacija
                .Where(u => u.User.UserID == userID)
               .Select(k => new RezervacijaPrikazVM
               {
                   RezervacijaID = k.RezervacijaID,
                   Lokacija = k.Poslovnica.Adresa,
                   Datum = k.DatumRezervacije,
                   Termin = k.TerminRezervacije.terminRez,
                   BrojOsoba = k.BrojOsoba.brOsoba

               }).ToList();

            return PartialView("ListaRezervacijaPartial");
        }

        [Autorizacija(true, true)]
        public IActionResult PonistiRezervaciju(int rezervacijaID, int userID)
        {
            User u = Autenfikacija.GetLogiraniKorisnik(HttpContext);
            if (u.UserID == userID)
            {
                Rezervacija r = db.Rezervacija.Find(rezervacijaID);
                db.Remove(r);
                db.SaveChanges();

                return RedirectToAction("PrikazRezervacija", new { userID = userID });
            }
            return Redirect("/Home/Index");

        }
    


    public IActionResult Dodaj()
        {


            var model = new DodajRezervaciju
            {


            };
            return View();

        }

        public IActionResult Spasi(DodajRezervaciju model)
        {
            Rezervacija rez = new Rezervacija 
            {
                Ime = model.Ime,
                Prezime = model.Prezime,
            Napomena = model.Napomena,
            VrijemeZahtjeva = model.VrijemeRezervacije,
            BrojTelefona = model.BrojTelefona,
            DatumRezervacije = model.Datum,
            BrojOsobaID = model.brojOsobaID,
            PoslovnicaID = model.PoslovnicaId,
            Email = model.Email,
            TerminRezervacijeID = model.TerminRezervacijaId,
            UserID = Autenfikacija.GetLogiraniKorisnik(HttpContext).UserID
            
        };
            db.Add(rez);
            db.SaveChanges();
            return Redirect("/Home/IndexAdmin/");
        }
    

        public IActionResult Pregled()
        {
            RzervacijePregled model = new RzervacijePregled();
            model.Listt = new List<RezervacijaVM>();
            List<Rezervacija> list = db.Rezervacija.ToList();
            foreach (var item in list)
            {

                RezervacijaVM vm = new RezervacijaVM();
                vm.RezervacijaID = item.RezervacijaID;
                vm.TerminRezervacijeID = (int)item.TerminRezervacijeID;
                vm.Prezime = item.Prezime;
                vm.PoslovnicaID = (int)item.PoslovnicaID;
                vm.Napomena = item.Napomena;
                vm.Ime = item.Ime;
                vm.Email = item.Email;
                vm.DatumRezervacije = item.DatumRezervacije;
                vm.BrojTelefona = item.BrojTelefona;
                vm.brojOsobaID = (int)item.BrojOsobaID;
                model.Listt.Add(vm);
            }
            return View(model);
        }
        public IActionResult Uredi(int id)
        {
            var model = db.Rezervacija.Where(i => i.RezervacijaID == id).FirstOrDefault();
            return View(model);
        }
        public IActionResult SpasiUredi(Rezervacija mod)
        {
            var model = db.Rezervacija.Where(i => i.RezervacijaID == mod.RezervacijaID).FirstOrDefault();
            db.Remove(model);
            db.Add(mod);
            db.SaveChanges();

            return RedirectToAction("PrikazRezervacija");

        }


    }

}