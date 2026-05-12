using System;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;
using LaboratoriumPojazdy.Enums;

namespace ClassLibrary1.Vehicles
{
    public class Samolot : Pojazd, IPojazdLadowy, IPojazdPowietrzny
    {
        public int LiczbaKol { get; set; }
        public double MinSzybkoscPowietrzna => 20;
        public double MaxSzybkoscPowietrzna => 900;

        public Samolot(string nazwa, int kola, double moc, TypPaliwa paliwo) 
            : base(nazwa, Srodowisko.Ladowe)
        {
            LiczbaKol = kola;
            Silnik = new Silnik(moc, paliwo);
        }

        public override void Uruchom() => CzySiePorusza = true;

        public override void Zatrzymaj()
        {
            if (AktualneSrodowisko == Srodowisko.Powietrzne) return; 
            AktualnaSzybkosc = 0;
            CzySiePorusza = false;
        }

        public override void Przyspiesz(double wartosc)
        {
            if (!CzySiePorusza) Uruchom();
            AktualnaSzybkosc += wartosc;

            if (AktualnaSzybkosc > 100) AktualneSrodowisko = Srodowisko.Powietrzne;
        }

        public override void Zwolnij(double wartosc)
        {
            AktualnaSzybkosc = Math.Max(0, AktualnaSzybkosc - wartosc);
            if (AktualnaSzybkosc < MinSzybkoscPowietrzna)
            {
                AktualneSrodowisko = Srodowisko.Ladowe;
            }
        }
    }
}