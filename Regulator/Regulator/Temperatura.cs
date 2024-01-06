using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regulator
{
    public class Temperatura
    {
        public static List<float> temps;

        public Temperatura()
        { 
            temps=new List<float>();
        }

        public void Ispisi()
        {
            foreach (var item in temps)
            {
                Console.WriteLine($"Temperatura {item}");
            }
        }

        public void Dodaj(float temp)
        {
            temps.Add(temp);
        }






    }
}
