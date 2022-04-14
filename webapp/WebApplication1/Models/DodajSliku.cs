using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DodajSliku
    {
        public int SlikaId { get; set; }
        public int UserId { get; set; }
        public DateTime Datum { get; set; }
        public string Lokacija { get; set; }
        public byte[] Slika { get; set; }
        [Required]
        public string Naziv { get; set; }
        public IFormFile slikaStudentaNew { set; get; }


    }
}
