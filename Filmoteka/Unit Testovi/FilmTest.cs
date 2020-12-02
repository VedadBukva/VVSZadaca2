using Filmoteka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class FilmTest
    {
        #region Film

        [TestMethod]
        public void FilmTestKonstruktor1()
        {
            Film film1 = new Film("Ime Filma1", 1.5, Zanr.Horor, new List<string>() { "Jensen Ackles", "Jared Padalecki" });
            Film film2 = new Film("Ime Filma2", 1.5, Zanr.Horor, new List<string>() {  });

            var filmoteka = new Filmoteka.Filmoteka();
            filmoteka.Filmovi.Add(film1);
            filmoteka.Filmovi.Add(film2);

            Assert.IsTrue(filmoteka.Filmovi.Count == 2);

        }


        [TestMethod]
        public void FilmTestNaziv()
        {
            Film film1 = new Film("Ime Filma1", 1.5, Zanr.Horor, new List<string>() { "Jensen Ackles", "Jared Padalecki" });
            Assert.Equals(film1.Naziv, "Ime Filma1");

        }

        [TestMethod]
        public void FilmTestOcjena()
        {
            Film film1 = new Film("Ime Filma1", 1.5, Zanr.Horor, new List<string>() { "Jensen Ackles", "Jared Padalecki" });
            Assert.Equals(film1.Ocjena, "1.5");

        }

        [TestMethod]
        public void FilmTestZanr()
        {
            Film film1 = new Film("Ime Filma1", 1.5, Zanr.Horor, new List<string>() { "Jensen Ackles", "Jared Padalecki" });
            Assert.Equals(film1.Žanr, "Horor");

        }

        [TestMethod]
        public void FilmTestGlumci()
        {
            Film film1 = new Film("Ime Filma1", 1.5, Zanr.Horor, new List<string>() { "Jensen Ackles", "Jared Padalecki" });
            List<string> lista = new List<String> { "Jensen Ackles", "Jared Padalecki" };
            Assert.Equals(film1.Glumci, lista);

        }

        #endregion 
    }
}