using System;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;
using LaboratoriumPojazdy.Enums;

namespace ClassLibrary1.Vehicles
{
    public class Samochod : Pojazd, IPojazdLadowy
    {
        public int LiczbaKol { get; set; }

        public Samochod(string nazwa, int kola, double moc, TypPaliwa paliwo)
            : base(nazwa, Srodowisko.Ladowe)
        {
            LiczbaKol = kola;
            Silnik = new Silnik(moc, paliwo);
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

            double nowaSzybkosc = AktualnaSzybkosc + wartosc;
            // Accessing default interface property for max speed
            double limit = ((IPojazdLadowy)this).MaxSzybkoscLadowa;

            AktualnaSzybkosc = Math.Min(nowaSzybkosc, limit);
        }

        public override void Zwolnij(double wartosc)
        {
            AktualnaSzybkosc = Math.Max(AktualnaSzybkosc - wartosc, 0);
            if (AktualnaSzybkosc == 0) CzySiePorusza = false;
        }

        public override string ToString()
        {
            return base.ToString() + $", Koła: {LiczbaKol}";
        }
    }
}