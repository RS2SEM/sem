using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using ClassLibrary1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.Helper;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class KomentarController : Controller
    {

        private mojDbContext db;
       // IHubContext<MyHub> _hubContext;


        public KomentarController(mojDbContext c/* IHubContext<MyHub> hubContext*/)
        {
            db = c;
           // _hubContext = hubContext;

        }


        public IActionResult Lista()
        {
            //mojDbContext db = new mojDbContext();

            ViewData["komentariVD"] = db.Komentar
                .Select(k => new KomentarVM
                {
                    Username = k.User.ime,
                    Sadrzaj = k.Sadrzaj,
                    vrijemePostavljanja = k.VrijemePostavljanja.ToShortDateString(),
                    KomentarID= k.KomentarID

                }).OrderByDescending(v=> v.KomentarID).ToList();


           // db.Dispose();



            return View();
        }
        [Autorizacija(true, true)]

       
        public IActionResult Dodaj()
        {

            var model = new DodajKomn
            {


            };
            return View();

        }
       
        public IActionResult Spasi(DodajKomn model)
        {
            int last_id = db.Rezervacija.Count();

            Komentar komn = new Komentar();
            komn.KomentarID = last_id + 1;

            komn.Sadrzaj = model.Sadrzaj;
                komn.VrijemePostavljanja = model.VrijemePostavljanja;
                 komn.UserID = Autenfikacija.GetLogiraniKorisnik(HttpContext).UserID;
                db.Komentar.Add(komn);
                db.SaveChanges();
            User k = komn.User;

            string poruka = "Vama je upravo evidentirana novi komn: " + model.Sadrzaj;

            TempData["PorukaWarning"] = "Uspješno ste evidentirali komentar "; //transport podataka iz akcije 1 u (akciju 2 + njegov view)
           // _hubContext.Clients.Group(k.ime).SendAsync("prijemPoruke", k.ime, poruka);


            return RedirectToAction("Pregled");
        }

        public IActionResult Pregled()
        {
            KomnPregled model = new KomnPregled();
            model.Listt = new List<KomentarVM>();
            List<Komentar> list = db.Komentar.ToList();
            foreach(var item in list)
            {
                KomentarVM vm = new KomentarVM();
                vm.KomentarID = item.KomentarID;
                vm.Sadrzaj = item.Sadrzaj;
                vm.vrijemePostavljanja = item.VrijemePostavljanja.ToString();
               vm.Username =item.UserID.ToString();
                model.Listt.Add(vm);
            }
            return View(model);


        }
        //public IActionResult Snimi(KomentarVM model)
        //{
        //    //testiranje rada kontrolera


        //    if (ModelState.IsValid)
        //    {
        //       // mojDbContext db = new mojDbContext();
        //        Komentar novi = new Komentar
        //        {
        //            Sadrzaj = model.Sadrzaj,
        //            VrijemePostavljanja = DateTime.Now,
        //            UserID = Autenfikacija.GetLogiraniKorisnik(HttpContext).UserID




        //        };

        //        db.Komentar.Add(novi);
        //        db.SaveChanges();
        //        //db.Dispose();

        //    }

        //    return RedirectToAction("Lista");
        //}

       
        public IActionResult Uredi(int id)
        {
            var model = db.Komentar.Where(i => i.KomentarID == id).FirstOrDefault();
            return View(model);
        }
        public IActionResult SpasiUredi(Komentar mod)
        {
            var model = db.Komentar.Where(i => i.KomentarID == mod.KomentarID).FirstOrDefault();
           // mod.UserID = model.UserID;//Autenfikacija.GetLogiraniKorisnik(HttpContext).UserID;
            db.Remove(model);
            db.Add(mod);
            db.SaveChanges();

            return RedirectToAction("Pregled");

        }

        public IActionResult Izbrisi(int id)
        {
            var model = db.Komentar.Where(i => i.KomentarID == id).FirstOrDefault();
            db.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Pregled");
        }
        public IActionResult Ponisti()
        {


            return PartialView("DodajButtonPartial");
        }
    }
   
   
}

namespace WebApplication1
{
    public class MyHub:Hub 
    {
        public override async Task OnConnectedAsync()
        {
            if (Context.User.Identity.Name != null)
                await Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            await base.OnConnectedAsync();
        }
    }
}