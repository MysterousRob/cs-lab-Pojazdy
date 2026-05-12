using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;
using LaboratoriumPojazdy.Enums;

public class Motorowka : Pojazd, IPojazdWodny
{
    public double Wypornosc { get; set; }

    public Motorowka(string nazwa, double wypornosc, double moc)
        : base(nazwa, Srodowisko.Wodne)
    {
        Wypornosc = wypornosc;
        // Requirement: Motorized water vehicles are always Oil (Olej)
        Silnik = new Silnik(moc, TypPaliwa.Olej);
    }

    public override void Uruchom() => CzySiePorusza = true;
    public override void Zatrzymaj() { AktualnaSzybkosc = 0; CzySiePorusza = false; }

    public override void Przyspiesz(double wartosc)
    {
        if (!CzySiePorusza) Uruchom();
        double limit = ((IPojazdWodny)this).MaxSzybkoscWodna;
        AktualnaSzybkosc = Math.Min(AktualnaSzybkosc + wartosc, limit);
    }

    public override void Zwolnij(double wartosc)
    {
        AktualnaSzybkosc = Math.Max(AktualnaSzybkosc - wartosc, 0);
    }
}