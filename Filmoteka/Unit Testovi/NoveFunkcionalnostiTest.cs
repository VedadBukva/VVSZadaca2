using Filmoteka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class NoveFunkcionalnostiTest
    {
        #region DajSveFilmoveSGlumcima

        [TestMethod]
        public void TestDajSveFilmoveSGlumcima1()
        {
            Film film = new Film("Ime Filma", 1.5, Zanr.Horor, new List<string>() { "Jensen Ackles", "Jared Padalecki" });

            var filmoteka = new Filmoteka.Filmoteka();
            filmoteka.Filmovi.Add(film);

            var lista = filmoteka.DajSveFilmoveSGlumcima(new List<string>() { "Jensen Ackles" });
         
            Assert.IsTrue(lista.Count == 1);
        }


        [TestMethod]
        public void TestDajSveFilmoveSGlumcima2()
        {
            Film film = new Film("Ime Filma", 1.5, Zanr.Horor, new List<string>() { "Jensen Ackles", "Jared Padalecki" });

            var filmoteka = new Filmoteka.Filmoteka();
            filmoteka.Filmovi.Add(film);

            List<Film> lista = filmoteka.DajSveFilmoveSGlumcima(new List<string>() { "Johnny Depp" });
            Assert.IsTrue(lista.Count == 0);
        }

        #endregion 

        #region Bacanje exception-a

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestDajSveFilmoveSaGlumcimaIzuzetak()
        {
            Film film = new Film("Ime Filma", 1.5, Zanr.Horor, new List<string>() { "Jensen Ackles", "Jared Padalecki" });

            var filmoteka = new Filmoteka.Filmoteka();

            filmoteka.DajSveFilmoveSGlumcima(new List<string>() { "Jensen Ackles", "Jared Padalecki" });
        }

        #endregion

        #region Produzi Rok 

        [TestMethod]
        public void TestProdužiRok1()
        {
            var d = DateTime.Today.AddMonths(-6);
            var c = new Clan(d);
            var novi = DateTime.Today.AddYears(2);
            c.ProdužiRok(novi);
            Assert.AreEqual(c.RokPretplate, novi);

        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestProdužiRok2()
        {
            var d = DateTime.Today.AddMonths(-7);
            var c = new Clan(d);
            var novi = DateTime.Today.AddYears(2);
            c.ProdužiRok(novi);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestProdužiRok3()
        {
            var d = DateTime.Today.AddMonths(1);
            var c = new Clan(d);
            var novi = DateTime.Today.AddYears(2);
            c.ProdužiRok(novi);
        }

        #endregion

        #region AutomatskiKorisničkiPodaci

        [TestMethod]
        public void TestAutomatskiKorisničkiPodaci1()
        {
            Assert.AreEqual(new Tuple<string, string>("nakalajdzicdir", "NAKALAJDZICDIR"), Gost.AutomatskiKorisničkiPodaci("Nadir", "Kalajdzic"));

        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestAutomatskiKorisničkiPodaci2()
        {
            Gost.AutomatskiKorisničkiPodaci("Nadir1", "Kalajdzic1"); // ne smiju biti brojevi u imenu

        }


        [TestMethod]
        public void TestAutomatskiKorisničkiPodaci3()
        {
            Assert.AreEqual(new Tuple<string, string>("nakalajdzicdirrrrrrr", "NAKALAJDZICDIRRRRRRR"), 
                Gost.AutomatskiKorisničkiPodaci("NadirRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", "Kalajdzic"));

        }

        #endregion

        #region Srednja ocjena filmova

        [TestMethod]
        public void DajSrednjuOcjenuSvihFilmova1()
        {
            List<Film> lista = new List<Film>();

            for (int i = 1; i <= 10; i++)
            {
                Film film = new Film("Supernatural " + i, i % 4 + 1, Zanr.Horor, new List<string>() { "Jensen Ackles", "Jared Padalecki" });
                lista.Add(film);
            }

            var watchLista = new Watchlist("lista", lista);

            Assert.AreEqual(2.5, watchLista.DajSrednjuOcjenuSvihFilmova());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void DajSrednjuOcjenuSvihFilmova2()
        {
            List<Film> lista = new List<Film>();
            var watchLista = new Watchlist("lista");
            watchLista.DajSrednjuOcjenuSvihFilmova();
        }

        #endregion

    }
}
