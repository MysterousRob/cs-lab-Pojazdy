using LaboratoriumPojazdy.Enums;
using System;

namespace ClassLibrary1.Models
{
    public abstract class Pojazd
    {
        public string Nazwa { get; protected set; }
        public double AktualnaSzybkosc { get; protected set; }
        public bool CzySiePorusza { get; protected set; }
        public Srodowisko AktualneSrodowisko { get; protected set; }
        public Silnik Silnik { get; protected set; }

        protected Pojazd(string nazwa, Srodowisko startowe)
        {
            Nazwa = nazwa;
            AktualneSrodowisko = startowe;
            AktualnaSzybkosc = 0;
            CzySiePorusza = false;
        }

        // Abstract methods that EVERY vehicle must implement specifically
        public abstract void Uruchom();
        public abstract void Zatrzymaj();
        public abstract void Przyspiesz(double wartosc);
        public abstract void Zwolnij(double wartosc);

        public override string ToString()
        {
            string stan = CzySiePorusza ? $"Jedzie ({AktualnaSzybkosc})" : "Stoi";
            string silnikInfo = Silnik != null ? $"Silnik: {Silnik}" : "Brak silnika";
            return $"{Nazwa} [{AktualneSrodowisko}] - Stan: {stan}. {silnikInfo}";
        }
    }
}
