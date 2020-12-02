﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filmoteka
{
    public class Filmoteka
    {
        #region Atributi

        static List<Gost> gosti = new List<Gost>();
        static List<Clan> clanovi = new List<Clan>();
        static List<Film> filmovi = new List<Film>();

        #endregion

        #region Properties

        public List<Gost> Gosti
        {
            get => gosti;
        }

        public List<Clan> Clanovi
        {
            get => clanovi;
        }

        public List<Film> Filmovi
        {
            get => filmovi;
        }

        #endregion

        #region Konstruktor

        public Filmoteka()
        {
            gosti = new List<Gost>();
            clanovi = new List<Clan>();
            filmovi = new List<Film>();
        }

        #endregion

        #region Metode

        public void RadSaKorisnicima(Gost korisnik, int opcija)
        {
            if (opcija == 0)
            {
                Gost postojeci = gosti.Find(k => k.Id == korisnik.Id);
                if (postojeci == null)
                    postojeci = clanovi.Find(k => k.Id == korisnik.Id);

                if (postojeci == null)
                    if (korisnik is Clan)
                        clanovi.Add((Clan)korisnik);
                    else
                        gosti.Add(korisnik);

                else
                    throw new InvalidOperationException("Korisnik već postoji u sistemu!");
            }

            else if (opcija == 1)
            {
                Gost postojeci = gosti.Find(k => k.Id == korisnik.Id);
                if (postojeci == null)
                    postojeci = clanovi.Find(k => k.Id == korisnik.Id);
                else
                {
                    gosti.Remove(postojeci);
                    return;
                }
                if (postojeci == null)
                    throw new ArgumentNullException("Korisnik ne postoji u sistemu!");
                else
                    clanovi.Remove(clanovi.Find(k => k.Id == korisnik.Id));
            }
        }

        public void DodajWatchlistu(Clan c, List<Film> filmovi, string naziv)
        {
            foreach (Film film in filmovi)
                if (film.Naziv.Length < 1)
                    throw new ArgumentNullException("Ime filma je prazno!");

            c.Watchliste.Add(new Watchlist(naziv, filmovi));
        }

        public List<Film> DajSveFilmoveZaRezisera(IReziser reziser)
        {
            List<Film> rezirani = new List<Film>();

            foreach (Film f in Filmovi)
            {
                if (reziser.DaLiJeReziraoFilm(f))
                    rezirani.Add(f);
            }

            return rezirani;
        }

        /// <summary>
        /// Metoda za filtriranje liste filmova prema glumcima.
        /// Ukoliko je lista filmova ili glumaca prazna, baca se izuzetak.
        /// U suprotnom, vraćaju se svi filmovi koji u listi glumaca imaju sve glumce koji su proslijeđeni kao parametar.
        /// </summary>
        /// <param name="glumci"></param>
        /// <returns></returns>
        public List<Film> DajSveFilmoveSGlumcima(List<string> glumci)
        {
            Console.WriteLine(filmovi.Count);
            if(glumci.Count == 0 || filmovi.Count == 0)
               throw new ArgumentNullException();

            List<Film> temp = new List<Film>();

            for (int i = 0; i < filmovi.Count; i++) {
                var brojGlumaca = 0;
                for (int j = 0; j < glumci.Count; j++) {

                    bool imaLiGlumacUFilmu = filmovi[i].Glumci.Any(glumci[j].Contains);
                    if (imaLiGlumacUFilmu) brojGlumaca++; 
                    
                }

                if (brojGlumaca == glumci.Count) temp.Add(filmovi[i]);
          
            }
            
            return temp;
        }

        public void DodajNastavak(Film film, double rating, bool istiGlumci, List<string> noviGlumci = null)
        {
            if(filmovi.Count == 0) throw new ArgumentNullException();
            char zadnjiZnak = film.Naziv.Last();
            if(Char.IsLetter(zadnjiZnak))
            {
                film.Naziv = film.Naziv + " 2";
            }
            else
            {
                int nastavak = zadnjiZnak - '0';
                nastavak++;
                film.Naziv = film.Naziv + " " + nastavak.ToString();

            }
            film.Ocjena = rating;
            if(!istiGlumci)
            {
                film.Glumci = noviGlumci;
            }
        }

        #endregion
    }
}
