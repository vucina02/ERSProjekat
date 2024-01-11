using System;
using System.IO;

namespace Regulator
{
    public class HeaterImpl : IHeater
    {
        public float TemperaturaHeatera { get; set; }
        public bool HeaterRadi { get; set; }

        public DateTime PocetakRada { get; set; }

        public DateTime KrajRada { get; set; }
        public double KolicinaResursa { get; set; }

        public RegulatorImpl regulator { get; set; }

       
    
        public void Ukljuci()
        {
            HeaterRadi = true;
            PocetakRada = DateTime.Now;
            
        }

        public void Povecaj()
        {
            
            TemperaturaHeatera += 0.01f;
            Console.WriteLine( $"Temp heatera je {TemperaturaHeatera}" );
            
            string filePath = "Temperature.txt"; 

            
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(TemperaturaHeatera);
            }

          
        }


        public void Iskljuci()
        {
            HeaterRadi = false;

           
            
            KrajRada = DateTime.Now;
            
            Funkcija();
        }


        public HeaterImpl()
        {
            HeaterRadi = false;
            TemperaturaHeatera = 0;
        }

        public HeaterImpl(float temperatura,RegulatorImpl regulator)
        {
            TemperaturaHeatera=temperatura ;    
            this.regulator = regulator;
        }

        public void Funkcija()
        {
            

            TimeSpan vremeRadaHeatera;
            vremeRadaHeatera = PocetakRada - KrajRada;
            double resursi = vremeRadaHeatera.TotalHours * KolicinaResursa;
            regulator.posalji(PocetakRada, vremeRadaHeatera, resursi);
        }


    }
}
