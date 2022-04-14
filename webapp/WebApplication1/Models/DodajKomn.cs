using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DodajKomn
    {
        public int KomentarId { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime VrijemePostavljanja { get; set; }
        public int UserId { get; set; }
    }
}
