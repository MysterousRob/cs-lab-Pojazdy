using System;
using System.Collections.Generic;
using System.Linq;
using LaboratoriumPojazdy.Enums;      
using ClassLibrary1.Interfaces; 
using ClassLibrary1.Models;     
using ClassLibrary1.Vehicles;   
using ClassLibrary1.Utils;

namespace LaboratoriumPojazdy
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Create a list of different vehicles
            List<Pojazd> flota = new List<Pojazd>
            {
                new Samochod("Tesla Model S", 4, 670, TypPaliwa.Prad),
                new Rower("Giant MTB"),
                new Samolot("Boeing 737", 3, 20000, TypPaliwa.Benzyna),
                new Motorowka("Bayliner", 1.5, 250),
                new Samochod("Fiat 500", 4, 70, TypPaliwa.Benzyna)
            };

            // 2. Simulate some movement
            flota[0].Przyspiesz(120); // Tesla
            flota[1].Przyspiesz(25);  // Rower
            flota[2].Przyspiesz(150); // Samolot (This will move it to Air environment!)
            flota[3].Przyspiesz(30);  // Motorowka (In knots)

            // 3. Output original list
            Console.WriteLine("--- Oryginalna Lista ---");
            flota.ForEach(p => Console.WriteLine(p));

            // 4. Filter: Only Land Vehicles
            Console.WriteLine("\n--- Tylko Pojazdy Lądowe ---");
            var ladowe = flota.OfType<IPojazdLadowy>();
            foreach (var p in ladowe) Console.WriteLine(p);

            // 5. Sort by Speed (Must convert to Km/h for fair comparison)
            Console.WriteLine("\n--- Posortowane wg Szybkości (Rosnąco w km/h) ---");
            var posortowane = flota.OrderBy(p => Konwerter.DoKmH(p.AktualnaSzybkosc, p.AktualneSrodowisko));
            foreach (var p in posortowane)
            {
                double predkoscKmH = Konwerter.DoKmH(p.AktualnaSzybkosc, p.AktualneSrodowisko);
                Console.WriteLine($"{p.Nazwa}: {predkoscKmH:F2} km/h");
            }

            // 6. Filter: Currently in Land Environment (Desc speed)
            Console.WriteLine("\n--- Aktualnie na Lądzie (od najszybszego) ---");
            var aktualnieNaLadzie = flota
                .Where(p => p.AktualneSrodowisko == Srodowisko.Ladowe)
                .OrderByDescending(p => p.AktualnaSzybkosc);

            foreach (var p in aktualnieNaLadzie) Console.WriteLine(p);
        }
    }
}