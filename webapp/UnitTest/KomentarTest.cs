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
    public class KomentarTest
    {
        private mojDbContext db;


        public KomentarTest()
        {
            TestniContext test = new TestniContext();
            db = test.InMemoryContext();
        }
        [TestMethod]
        public void Komentari_View_Not_Null()
        {
            KomentarController test = new KomentarController(db);
            Assert.IsNotNull(test.Dodaj());
        }

    }       
        
}
