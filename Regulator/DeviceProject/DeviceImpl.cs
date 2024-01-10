using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common1;

namespace DeviceProject
{
    public class DeviceImpl:IDevice
    {
        public static IRegulatorDevice Proxy;
        static ThreadLocal<Random> threadRandom = new ThreadLocal<Random>(() => new Random());
        
        public DeviceImpl(IRegulatorDevice proxy)
        {
            Proxy = proxy;
        }
        public void pokreniNiti(int brojNiti)
        {
            Thread[] threads = new Thread[brojNiti];

            // Create and start threads
            for (int i = 0; i < brojNiti; i++)
            {
                threads[i] = new Thread(()=>spavaj(i));
                Thread.Sleep(500);
                threads[i].Start();
            }

            // Wait for all threads to complete
            for (int i = 0; i < brojNiti; i++)
            {
                threads[i].Join();
            }


        }
        public  void spavaj(int br)
        {

            StreamReader sr = new StreamReader("C:\\Users\\10\\Downloads\\Regulator\\Regulator\\Regulator\\bin\\Debug\\Temperature.txt");
            string unos= sr.ReadLine();
            sr.Close();
            float trenutna= float.Parse(unos);  
            Random rand = new Random(br*br*br);
            float minTemperatura = trenutna-1;
            float maxTemperatura = trenutna+1;
            while(true)
            {
                double randomDouble=rand.NextDouble();  
                //float temperatura = threadRandom.Value.Next((int)minTemperatura,(int)maxTemperatura);
                float temperatura = (float)(minTemperatura + (maxTemperatura - minTemperatura) * randomDouble);
                Console.WriteLine(temperatura);
                Proxy.posalji(temperatura);
                Thread.Sleep( 10000 );
                StreamReader sr1 = new StreamReader("C:\\Users\\10\\Downloads\\Regulator\\Regulator\\Regulator\\bin\\Debug\\Temperature.txt");
                unos = sr1.ReadLine();
                sr1.Close();
                trenutna = float.Parse(unos);

            }

        }



    }
}
