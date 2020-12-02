using Filmoteka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class FilmotekaTest
    {
        #region Filmoteka

        [TestMethod]
        public void TestGosti()
        {
            Gost gost = new Gost("User", "password", "qwerty", "qwerty1234");
            var filmoteka = new Filmoteka.Filmoteka();
            filmoteka.Gosti.Add(gost);
            Assert.IsTrue(filmoteka.Gosti.Count == 1);

        }

        [TestMethod]
        public void TestClanovi()
        {
            Clan clan = new Clan("user", "pass", "ime", "prezime", new DateTime(2020, 05, 21));
            var filmoteka = new Filmoteka.Filmoteka();
            filmoteka.Clanovi.Add(clan);
            Assert.IsTrue(filmoteka.Clanovi.Count == 1);
        }

        [TestMethod]
        public void TestFilmovi()
        {
            Film film = new Film("imeFilma", 5, Zanr.Akcija, new List<String> { });
            var filmoteka = new Filmoteka.Filmoteka();
            filmoteka.Filmovi.Add(film);
            Assert.IsTrue(filmoteka.Filmovi.Count == 1);

        }

        [TestMethod]
        public void TestKontruktor()
        {
            var f = new Filmoteka.Filmoteka();
            Assert.IsNull(f);

        }


        #endregion 
    }
}