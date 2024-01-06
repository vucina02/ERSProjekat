using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common1;
using Common1.Model;
namespace Regulator
{
    public class RegulatorServis1:IRegulatorDevice
    {
        
        public static List<float> Temp=new List<float>();
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
            Console.WriteLine(temperatura);
        }

        
    }
}
