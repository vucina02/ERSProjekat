using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common1;

namespace Regulator
{
    public class RegulatorImpl
    {
       public IBazaRegulator Proxy {  get; set; }  
        
        public RegulatorImpl(IBazaRegulator proxy)
        {
            Proxy = proxy;
        }

        public void posalji(DateTime pocetak,TimeSpan trajanje,double resursi)
        {

            Proxy.UpisiHeater(new Common1.Model.HeaterClass(pocetak,trajanje,resursi));
        }



    }
}
