using System;
using ClassLibrary1.Models;
using LaboratoriumPojazdy.Enums;

namespace ClassLibrary1.Vehicles
{
    public class Rower : Pojazd // Changed to public
    {
        public Rower(string nazwa) : base(nazwa, Srodowisko.Ladowe)
        {
            Silnik = null!; // Rowers don't have engines, fixes CS8625 warning
        }

        public override void Uruchom() => CzySiePorusza = true;
        public override void Zatrzymaj() { AktualnaSzybkosc = 0; CzySiePorusza = false; }
        public override void Przyspiesz(double wartosc) => AktualnaSzybkosc = Math.Min(AktualnaSzybkosc + wartosc, 50);
        public override void Zwolnij(double wartosc) => AktualnaSzybkosc = Math.Max(0, AktualnaSzybkosc - wartosc);
    }
}