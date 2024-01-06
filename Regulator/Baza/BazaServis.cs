using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common1;
using Common1.Model;

namespace Baza
{
    public class BazaServis : IBazaRegulator
    {
        void IBazaRegulator.posalji(DeviceClass d)
        {
            Console.WriteLine(d);
        }
    }
}
