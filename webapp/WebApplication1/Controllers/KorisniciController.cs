using ClassLibrary1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly mojDbContext dbContext;

        public KorisniciController(mojDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var rezultat = dbContext.User.ToList();

            return Ok(rezultat);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var rezultat = dbContext.User.Find(id);

            return Ok(rezultat);
        }

        [HttpPost("{id}")]
        public IActionResult Uredi(int id,[FromBody]User korisnik)
        {
            var user = dbContext.User.Find(id);

            user.brojTelefona = korisnik.brojTelefona;
            user.ime = korisnik.ime;
            user.prezime = korisnik.prezime;
            user.adresaStanovanja = korisnik.adresaStanovanja;

            dbContext.SaveChanges();

            return Ok(user);
        }
       
    }
}
