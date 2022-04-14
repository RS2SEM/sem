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

    public  class PosebnaPonudaTest
    {
        private mojDbContext db;

        public PosebnaPonudaTest()
        {
            TestniContext test = new TestniContext();
            db = test.InMemoryContext();
        }

        [TestMethod]
        public void Obavijesti_View_Not_Null()
        {
            PosebnaPonuda test = new PosebnaPonuda(db);
            Assert.IsNotNull(test.Dodaj());
        }
    }
}
