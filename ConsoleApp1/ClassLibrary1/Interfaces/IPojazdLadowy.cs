using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    public interface IPojazdLadowy
    {
        int LiczbaKol { get; set; }
        double MinSzybkoscLadowa => 1;
        double MaxSzybkoscLadowa => 350;
    }
}
