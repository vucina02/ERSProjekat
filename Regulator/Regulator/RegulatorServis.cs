using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common1;
using Common1.Model;

namespace Regulator
{
    public class RegulatorServis:IRegulatorHeater
    {
        public float GetProsek()
        {
            throw new NotImplementedException();
        }

        public void posalji(DeviceClass d)
        {
            Console.WriteLine(d);
        }
    }
}
