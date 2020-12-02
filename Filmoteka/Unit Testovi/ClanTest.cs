using Filmoteka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class ClanTest
    {
        #region ProduziRok

        [TestMethod]
        public void ClanKonstruktor1()
        {
            Clan clan = new Clan("qwerty", "qwerty", "IME", "PREZIME", new DateTime(2020, 11, 10));
            var filmoteka = new Filmoteka.Filmoteka();
            filmoteka.Clanovi.Add(clan);

            Assert.AreEqual(filmoteka.Clanovi.Count, 1);

        }

        [TestMethod]
        public void vratiWatchList()
        {
            var clan = new Clan("qwerty", "qwerty", "IME", "PREZIME", new DateTime(2020, 11, 10));
            var filmoteka = new Filmoteka.Filmoteka();

            filmoteka.Clanovi.Add(clan);
            List<Film> lista = new List<Film> { new Film("Ime Filma", 1.5, Zanr.Horor, new List<string>() { "Jensen Ackles", "Jared Padalecki" } ) };
            filmoteka.DodajWatchlistu(clan, lista, "HOROR");
            Assert.IsTrue(filmoteka.Clanovi[0].Watchliste.Equals("HORROR"));

        }

        [TestMethod]
        public void vratiRokPreplate()
        {
            var clan = new Clan("qwerty", "qwerty", "IME", "PREZIME", new DateTime(2020, 11, 10));
            var filmoteka = new Filmoteka.Filmoteka();

            filmoteka.Clanovi.Add(clan);
            DateTime d = new DateTime(2020, 11, 10);
            Assert.AreEqual((filmoteka.Clanovi[0].RokPretplate).ToString(), d.ToString());

        }


        #endregion 
    }
}