using System;
using System.Collections.Generic;
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
            Random rand = new Random(br*br*br);
            int minTemperatura = 1;
            int maxTemperatura = 30;
            while(true)
            {

                float temperatura = threadRandom.Value.Next(minTemperatura, maxTemperatura);
                Console.WriteLine(temperatura);
                Proxy.posalji(temperatura);
                Thread.Sleep( 1000 );

            }

        }



    }
}
