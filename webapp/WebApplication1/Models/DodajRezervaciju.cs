using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DodajRezervaciju
    {
        public int RezervacijaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Datum { get; set; }
        public string Napomena { get; set; }
        public DateTime VrijemeRezervacije { get; set; }
        public int UserId { get; set; }
        public int PoslovnicaId { get; set; }
        public List<SelectListItem> poslovnice { get; set; }

        public int TerminRezervacijaId { get; set; }
        public List<SelectListItem> TerminRezervacije { get; set; }

        public int brojOsobaID { get; set; }


        public List<SelectListItem> brojOsoba { get; set; }


    }
}
