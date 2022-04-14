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
    public class PoslovnicaTest
    {
        private mojDbContext db;

        public PoslovnicaTest()
        {
            TestniContext test = new TestniContext();
            db = test.InMemoryContext();
        }

        [TestMethod]
        public void Obavijesti_View_Not_Null()
        {
            Poslovnicaa test = new Poslovnicaa(db);
            Assert.IsNotNull(test.Dodaj());
        }
    }
}
