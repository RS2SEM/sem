using ClassLibrary1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.Controllers;
using WebApplication1.Helper;

namespace UnitTest
{
    [TestClass]
 public   class Galerija
    {
        private mojDbContext db;

        public Galerija()
        {

            TestniContext test = new TestniContext();
            db = test.InMemoryContext();
        }




        [TestMethod]
        public void Slike_View_Not_Null()
        {
            GalerijaController test = new GalerijaController(db);
            Assert.IsNotNull(test.Dodaj());
        }

       
    }
}
