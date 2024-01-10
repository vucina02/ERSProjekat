using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common1;
using Common1.Model;
using static Regulator.Program;
namespace Regulator
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RegulatorServis1:IRegulatorDevice
    {
        
        public  List<float> Temp { get; set; }
        public static object LockObject { get; set; }

        public RegulatorServis1(object lockObject)
        {
            LockObject=lockObject;
            Temp = new List<float>();

        }

         public void Hello()
        {
            Console.WriteLine("Hello");
        }
        public void Ispisi()
        {
            foreach (var item in Temp)
            {
                Console.WriteLine($"Temperatura {item}");
            }
        }
        public void posalji(float temperatura)
        {
            Temp.Add(temperatura);
            Monitor.Enter(LockObject);
            if(Temp.Count ==4) { Monitor.Pulse(LockObject); }
           
            Monitor.Exit(LockObject);
            //Program.temps.Add(temperatura);
           // Console.WriteLine(temperatura);
        }
        
        public  float ProsjekTemperatura() {
            float suma = 0;
            int brojac = 0;
            float prosjek;
            
            foreach (var item in Temp) {
                brojac++;
                suma += item;
            }
            prosjek=suma/brojac;
            Temp.Clear();
            return prosjek; 
        }
        

    }
}
