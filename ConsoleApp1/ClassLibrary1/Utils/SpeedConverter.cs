using LaboratoriumPojazdy.Enums;

namespace ClassLibrary1.Utils
{
    public static class Konwerter 
    {
        public static double DoKmH(double predkosc, Srodowisko srodowisko)
        {
            return srodowisko switch
            {
                Srodowisko.Wodne => predkosc * 1.852,  
                Srodowisko.Powietrzne => predkosc * 3.6, 
                _ => predkosc                           
            };
        }
    }
}