using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DodajObavijest
    {
        public string Sadrzaj { get; set; }
        public string Naslov { get; set; }
        public DateTime Vrijeme { get; set; }
        public int UserId { get; set; }
        public int ObavijestID { get;  set; }
    }
}
