using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.ViewModels
{
   public class ObavijestDodaj
    {
        public int UserId { get; set; }
        public string User { get; set; }
        public int ObavijestId { get; set; }
        public string Obavijest { get; set; }
        public int SlikaId { get; set; }
        public string Slika { get; set; }
        
        public DateTime Datum { get; set; }
    }
}
