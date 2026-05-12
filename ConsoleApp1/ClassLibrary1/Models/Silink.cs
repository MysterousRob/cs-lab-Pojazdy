using LaboratoriumPojazdy.Enums;

namespace ClassLibrary1.Models
{
    public class Silnik
    {
        public double MocKM { get; set; }
        public TypPaliwa Paliwo { get; set; }

        public Silnik(double moc, TypPaliwa paliwo)
        {
            MocKM = moc;
            Paliwo = paliwo;
        }

        public override string ToString() => $"{MocKM} KM, Paliwo: {Paliwo}";
    }
}
