using ClassLibrary1.Models;
using ClassLibrary1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Helper;

namespace WebApplication1.Controllers
{
    public class PodrskaController : Controller
    {
        

            private mojDbContext db;
            private IConfiguration Configuration;

            public PodrskaController(mojDbContext c, IConfiguration _config)
            {
                db = c;
                Configuration = _config;
            }


            public IActionResult Email()
            {
                return View();
            }

            public IActionResult SlanjeMaila(EmailVM model)
            {


                if (ModelState.IsValid)
                {
                    Nullable<int> userID = 0;

                    if (Autenfikacija.GetLogiraniKorisnik(HttpContext) != null)
                        userID = Autenfikacija.GetLogiraniKorisnik(HttpContext).UserID;
                    else
                        userID = null;



                EmailPostavka.SendEmail(Configuration, model.Ime, model.EmailAdresa, "Restoran public mail", model.Sadrzaj);
                    TempData["poslanEmail"] = "Email uspješno poslan";

                int last_id = db.Email.ToList().Last().EmailID;
                    Email n = new Email
                    {
                        EmailID= last_id+1,
                        Sadrzaj = model.Sadrzaj,
                        EmailAdresa = model.EmailAdresa,
                        VrijemeSlanja = DateTime.Now,
                        UserID = userID

                    };

                    db.Email.Add(n);
                    db.SaveChanges();
                }


                return RedirectToAction("Email");
            }
        }
    }
