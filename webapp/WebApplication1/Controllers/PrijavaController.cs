using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using ClassLibrary1.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Helper;
using WebApplication1.Hubs;
using WebApplication1.Models;
using System.Runtime;
using Xceed.Wpf.Toolkit;

namespace WebApplication1.Controllers
{
    public class PrijavaController : Controller
    {
        private mojDbContext db;

        public PrijavaController(mojDbContext c)
        {
            db = c;
        }
        public IActionResult Index()
        {
            return PartialView();
        }

        public IActionResult Prijava(PrijavaVM model)
        {


            if (ModelState.IsValid)
            {
               
                User u = db.User.SingleOrDefault(k => k.Nalog.Email == model.Email && k.Nalog.Lozinka == model.Lozinka);

                if (u == null)
                {
                    TempData["neuspjesnaprijava"] = "pogrešno ste unjeli email ili lozinku";
                    return PartialView("Index", model);

                  

                }

                Autenfikacija.SetLogiraniKorisnik(HttpContext, u);

               
               

            }
             //ako je uloga id= 1 otvori za korisnike
             //ako je uloga id 2 otvori za admina
            return PartialView("Index", model);


        }
        public IActionResult PrijavaAngular(string model)
        {


         

                User u = db.User.SingleOrDefault(k => k.Nalog.Email == "admin@hotmail.com");

                if (u == null)
                {
                    TempData["neuspjesnaprijava"] = "pogrešno ste unjeli email ili lozinku";
                    return PartialView("Index", model);



                }

                Autenfikacija.SetLogiraniKorisnik(HttpContext, u);





            //ako je uloga id= 1 otvori za korisnike
            //ako je uloga id 2 otvori za admina
            return Ok(u);


        }

        //public string? FileName { get; }
        //public class FileNotFoundException : System.IO.FileNotFoundException { };


        [HttpPost]
        public IActionResult Registracija([FromQuery] string ime ,string prezime, string username,string lozinka)
        {
            int last_nalog_id = db.Nalog.ToList().Last().NalogID + 1;
            int last_user_id = db.User.ToList().Last().UserID + 1;

            var sr = new StreamReader(Request.Body);
            //string json = await sr.ReadAsync(Request.Body.Read());
            //var model = JsonConvert.DeserializeObject<RegistracijaUser>(json);
            string adresa = "adresa";
            string mob = "06374136";
            User u = new User();
            u.ime = ime;        
            u.prezime = prezime;
            u.adresaStanovanja = adresa;
            u.brojTelefona = mob;
            u.UserID = last_user_id;
            Nalog nalog = new Nalog();
            nalog.DatumKreiranja = DateTime.Now;
            nalog.Email =username;
            nalog.Lozinka= lozinka;
            nalog.NalogID=last_nalog_id;
            db.Nalog.Add(nalog);
            db.SaveChanges();
            u.NalogID = db.Nalog.Where(x=>x.Email==nalog.Email).FirstOrDefault().NalogID;
            db.User.Add(u);
            db.SaveChanges();
            return Ok();

        }
        public IActionResult Odjava()
        {



            Autenfikacija.SetLogiraniKorisnik(HttpContext, null);
            return RedirectToAction("Index","Home");
        }

        public IActionResult Pregled()
        {
            UserPregled model = new UserPregled();
            model.Listt = new List<User>();
            List<User> list = db.User.ToList();
            foreach(var item in list)
            {
                User vm = new User();
                vm.adresaStanovanja = item.adresaStanovanja;
                vm.brojTelefona = item.brojTelefona;
                vm.ime = item.ime;
                vm.prezime = item.prezime;
                vm.UserID = item.UserID;
                vm.UlogaID = item.UlogaID; 
                vm.NalogID = item.NalogID;
                model.Listt.Add(vm);
            }
            return View(model);
        }

        public IActionResult PregledAngular()
        {
            UserPregled model = new UserPregled();
            model.Listt = new List<User>();
            List<User> list = db.User.ToList();

            return Ok(list);
        }

    }
}