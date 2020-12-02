using Filmoteka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class GostTest
    {
        #region GostTest

        [TestMethod]
        public void TestKontruktora()
        {
            Gost gost = new Gost("Userqwe", "BERINACOCALIC", "Qwerty", "Qwerty");
            var filmoteka = new Filmoteka.Filmoteka();
            filmoteka.Gosti.Add(gost);

            Assert.IsTrue(filmoteka.Gosti.Count == 1);
        }

        [TestMethod]
        public void TestIme()
        {
            Gost gost = new Gost("Userqwe", "BERINACOCALIC", "Qwerty", "Qwerty");
            Assert.IsNotNull(gost.Ime);
        }

        [TestMethod]
        public void TestPrezime()
        {
            Gost gost = new Gost("Userqwe", "BERINACOCALIC", "Qwerty", "Qwerty");
            Assert.IsNotNull(gost.Prezime);
        }

        [TestMethod]
        public void TestUser()
        {
            Gost gost = new Gost("Userqwe", "BERINACOCALIC", "Qwerty", "Qwerty");
            Assert.IsNotNull(gost.Username);
            Assert.IsTrue(gost.Username.Length > 5 && gost.Username.Length < 20);
        }

        [TestMethod]
        public void TestPassword()
        {
            Gost gost = new Gost("Userqwe", "BERINACOCALIC", "Qwerty", "Qwerty");
            Assert.IsNotNull(gost.Password);
            Assert.IsTrue(gost.Password.Length > 10 && gost.Password.Length < 20);
        }
        #endregion
    }
}