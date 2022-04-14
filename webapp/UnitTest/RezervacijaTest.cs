using ClassLibrary1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.Controllers;
using WebApplication1.Helper;

namespace UnitTest
{
    [TestClass]
  public  class RezervacijaTest
    {
        private mojDbContext db;
        private IConfiguration conf;

        public RezervacijaTest()
        {
            TestniContext test = new TestniContext();
            db = test.InMemoryContext();


        }



        [TestMethod]
        public void Lista_View_Not_null()
        {

            RezervacijaController pc = new RezervacijaController(db, conf);
            ViewResult vr = (ViewResult)pc.Dodaj();
            Assert.IsNotNull(vr);


        }
    }
}
