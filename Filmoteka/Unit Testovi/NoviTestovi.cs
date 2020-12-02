using Filmoteka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class NoviTestovi
    {
        #region Zamjenski Objekti

        [TestMethod]
        public void TestZamjenskiObjekat()
        {
            Reziser r = new Reziser();

            r.ImeRezisera = "Nadir Kalajdzic";

            Film film = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" }, r);

            var filmoteka = new Filmoteka.Filmoteka();
            filmoteka.Filmovi.Add(film);

            List<Film> rezirani = filmoteka.DajSveFilmoveZaRezisera(r);

            Assert.IsTrue(rezirani.Contains(film));
        }

        #endregion

        #region TDD

        [TestMethod]
        public void TestDodajNastavakIstiGlumci()
        {
            Film film = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });

            var filmoteka = new Filmoteka.Filmoteka();
            filmoteka.Filmovi.Add(film);

            filmoteka.DodajNastavak(film, 4.0, true);

            //foreach(var f in filmoteka.Filmovi)  Console.WriteLine(f.Naziv + " " + f.Žanr.ToString() + " " + f.Glumci.Count);

            Assert.IsTrue(filmoteka.Filmovi.Find(f => f.Naziv == "Need For Speed 2" && f.Žanr == Zanr.Akcija && f.Glumci.Count == 2) != null);
        }

        [TestMethod]
        public void TestDodajNastavakRazlicitiGlumci()
        {
            Film film = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });

            var filmoteka = new Filmoteka.Filmoteka();
            filmoteka.Filmovi.Add(film);

            filmoteka.DodajNastavak(film, 4.0, false, new List<string>() { "Brad Pitt", "Chris Hemsworth", "Antonio Banderas" });

            Assert.IsTrue(filmoteka.Filmovi.Find(f => f.Naziv == "Need For Speed 2" && f.Žanr == Zanr.Akcija && f.Glumci.Count == 3) != null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestDodajNastavakIzuzetak()
        {
            Film film = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });

            var filmoteka = new Filmoteka.Filmoteka();

            filmoteka.DodajNastavak(film, 4.0, false, new List<string>() { "Brad Pitt", "Chris Hemsworth", "Antonio Banderas" });
        }

        #endregion
    }
}
