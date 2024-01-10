using Common1;
using Common1.Model;
using System;

namespace Baza
{
    public class BazaServis : IBazaRegulator
    {
        public BazaImpl baza = BazaImpl.GetBaza();

        public float GetProsjek()
        {
            return baza.ProsjekTemperaturaDeviceBaza();
        }

        public void posalji(DeviceClass d)
        {
            Console.WriteLine(d);
        }



        public void UpisiHeater(HeaterClass heater)
        {
            baza.InsertHeater(heater);
        }


    }
}
