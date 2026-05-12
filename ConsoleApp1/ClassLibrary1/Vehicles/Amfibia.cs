using System;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;
using LaboratoriumPojazdy.Enums;

namespace ClassLibrary1.Vehicles
{
    public class Amfibia : Pojazd, IPojazdLadowy, IPojazdWodny
    {
        public int LiczbaKol { get; set; }
        public double Wypornosc { get; set; }

        public Amfibia(string nazwa, int kola, double wypornosc, double moc)
            : base(nazwa, Srodowisko.Ladowe)
        {
            LiczbaKol = kola;
            Wypornosc = wypornosc;
            Silnik = new Silnik(moc, TypPaliwa.Olej);
        }

        public override void Uruchom() => CzySiePorusza = true;

        public override void Zatrzymaj()
        {
            AktualnaSzybkosc = 0;
            CzySiePorusza = false;
        }

        public override void Przyspiesz(double wartosc)
        {
            if (!CzySiePorusza) Uruchom();

            double limit = (AktualneSrodowisko == Srodowisko.Ladowe)
                ? ((IPojazdLadowy)this).MaxSzybkoscLadowa
                : ((IPojazdWodny)this).MaxSzybkoscWodna;

            AktualnaSzybkosc = Math.Min(AktualnaSzybkosc + wartosc, limit);
        }

        public override void Zwolnij(double wartosc)
        {
            AktualnaSzybkosc = Math.Max(AktualnaSzybkosc - wartosc, 0);
            if (AktualnaSzybkosc == 0) CzySiePorusza = false;
        }

        public void PrzelaczSrodowisko(Srodowisko nowe)
        {
            if (nowe == Srodowisko.Powietrzne) return;
            AktualneSrodowisko = nowe;
        }
    }
}