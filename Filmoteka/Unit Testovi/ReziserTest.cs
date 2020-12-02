using Filmoteka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class ReziserTest
    {
        #region TDD

        [TestMethod]
        public void ReziserTestKonstruktor1()
        {
            Reziser r = new Reziser
            {
                ImeRezisera = "Vedad Bukva"
            };
            Reziser r1 = new Reziser()
            {
                ImeRezisera = "Nadir Kalajdzic"
            };
            Assert.AreNotEqual(r, r1);

        }

        [TestMethod]
        public void DaLiJeReziraoFilmTest1()
        {
            Film film = new Film("Film", 1.0, Zanr.Drama, new List<string>{ "Glumac" }, new Reziser() { ImeRezisera = "Reziser" });
            Reziser r = new Reziser
            {
                ImeRezisera = "Reziser"
            };
            Assert.IsTrue(r.DaLiJeReziraoFilm(film));
        }

        #endregion

        #region Exceptions

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DaLiJeReziraoFilmTest2()
        {
            Film film = new Film("Film", 1.0, Zanr.Drama, new List<string> { "Glumac" });
            Reziser r = new Reziser
            {
                ImeRezisera = "Nema rezisera"
            };
            Assert.IsFalse(r.DaLiJeReziraoFilm(film));
        }


        #endregion 
    }
}