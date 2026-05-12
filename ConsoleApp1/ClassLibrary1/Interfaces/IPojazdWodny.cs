using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    public interface IPojazdWodny
    {
        double Wypornosc { get; set; }
        double MinSzybkoscWodna => 1;
        double MaxSzybkoscWodna => 40;
    }
}
