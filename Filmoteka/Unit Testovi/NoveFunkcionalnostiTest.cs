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
    }
}
