using AspNetCore.Reporting;
using ClassLibrary1.Models;
using Microsoft.AspNetCore.Mvc;
using ReportTemps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Helper;

namespace WebApplication1.Controllers
{
    public class ReportController1 : Controller
    {
        private mojDbContext db;

        public ReportController1(mojDbContext c)
        {
            db = c;
        }
        public static List<Class1> getproizvodi(mojDbContext db)
        {

            List<Class1> podaci = db.Proizvod.Select(s => new Class1
            {
                Naziv = s.Naziv,
                Opis = s.Opis,
                Cijena = s.Cijena

            }).ToList();

            return podaci;
        }
        public IActionResult Index()
        {
            LocalReport _localReport = new LocalReport("Report/Report1.rdlc");
            List<Class1> podaci = getproizvodi(db);
            DataSet ds = new DataSet();
            _localReport.AddDataSource("DataSet1", podaci);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ReportNapravio", Autenfikacija.GetLogiraniKorisnik(HttpContext).ime);

            //ReportResult result = _localReport.Execute(RenderType.ExcelOpenXml, parameters: parameters);
            //return File(result.MainStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");


            ReportResult result = _localReport.Execute(RenderType.Pdf, parameters: parameters);
            return File(result.MainStream, "application/pdf");
            ///*vnd.openxmlformats-officedocument.spreadsheetml.sheet*
        }
    }
}

