using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportTemps
{
    public class Class1
    {
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Opis { get; set; }
        public static List<Class1> Get()
        {
            return new List<Class1>();
        }
    }
}