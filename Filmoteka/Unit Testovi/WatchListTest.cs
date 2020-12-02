using Filmoteka;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Unit_Testovi
{
    [TestClass]
    public class WatchListTest
    {
        #region TDD

        [TestMethod]
        public void TestKonstruktor1()
        {
            List<Film> filmovi = new List<Film>();
            Film film = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            filmovi.Add(film);
            Watchlist wl = new Watchlist("Lista omiljenih filmova", filmovi);
            Assert.IsTrue(wl.Naziv.Equals("Lista omiljenih filmova"));
        }

        [TestMethod]
        public void TestKonstruktor2()
        {
            List<Film> filmovi = new List<Film>();
            var filmoteka = new Filmoteka.Filmoteka();
            Film film = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            filmovi.Add(film);
            filmoteka.Filmovi.Add(film);
            filmoteka.DodajNastavak(film,5,true);
            filmovi.Add(film);
            Watchlist wl = new Watchlist("Lista omiljenih filmova", filmovi);
            Assert.IsTrue(wl.Filmovi.Find(f => f.Naziv == "Need For Speed 2" && f.Ocjena == 5 && f.Žanr == Zanr.Akcija && f.Glumci.Count == 2) != null);
        }

        [TestMethod]
        public void TestDajSrednjuOcjenuSvihFilmova()
        {
            List<Film> filmovi = new List<Film>();
            Film film1 = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            Film film2 = new Film("Ace Ventura", 4.8, Zanr.Komedija, new List<string>() { "Bruce Willis" });
            Film film3 = new Film("Finding Nemo", 3.0, Zanr.None, new List<string>() { "Dwayne Wade" });
            Film film4 = new Film("Police Chase 3", 5.0, Zanr.Kriminalisticki, new List<string>() { "Nadir Kalajdzic" , "Andrej Vujcic" });
            filmovi.Add(film1);
            filmovi.Add(film2);
            filmovi.Add(film3);
            filmovi.Add(film4);
            Watchlist wl = new Watchlist("Lista filmova", filmovi);
            double prosjecnaOcjenaSvihFilmova = wl.DajSrednjuOcjenuSvihFilmova();
            Assert.AreEqual(prosjecnaOcjenaSvihFilmova,4.075);
        }

        #endregion

        #region Exceptions

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestDajSrednjuOcjenuSvihFilmovaIzuzetak()
        {
            Watchlist wl = new Watchlist("Lista filmova");
            double prosjecnaOcjenaSvihFilmova = wl.DajSrednjuOcjenuSvihFilmova();
            Assert.AreEqual(prosjecnaOcjenaSvihFilmova, 4.075);
        }

        #endregion
    }
}