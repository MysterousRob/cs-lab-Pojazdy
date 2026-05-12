using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    internal interface IPojazdPowietrzny
    {
        double MinSzybkoscPowietrzna => 20;
        double MaxSzybkoscPowietrzna => 200;
    }
}
