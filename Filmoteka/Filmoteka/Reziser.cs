using System;
using System.Collections.Generic;
using System.Text;

namespace Filmoteka
{
    public interface IReziser
    {
        bool DaLiJeReziraoFilm(Film f);
    }
    public class Reziser : IReziser
    {
        string imeRezisera;

        public string ImeRezisera
        {
            get
            {
                return imeRezisera;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Naziv ne smije biti prazan!");

                imeRezisera = value;
            }
        }
        public bool DaLiJeReziraoFilm(Film f)
        {
            if (f.Reziser == null) throw new NullReferenceException();
            return f.Reziser.ImeRezisera.Equals(imeRezisera);
        }
    }
}
