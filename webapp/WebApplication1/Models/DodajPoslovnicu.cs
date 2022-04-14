using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DodajPoslovnicu
    {
        public int PoslovnicaId { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int UserId { get; set; }

    }
}
