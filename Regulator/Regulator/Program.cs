using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common1;
using Common1.Model;

namespace Regulator
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            //ChannelFactory<IBazaRegulator> channel =
            //    new ChannelFactory<IBazaRegulator>("ServiceName");

            //IBazaRegulator proxy = channel.CreateChannel();




            /*using (ServiceHost host = new ServiceHost(typeof(RegulatorServis)))
            {

                host.Open();
                Console.WriteLine("Servis je uspesno pokrenut");
                Console.ReadKey();
            }*/
            ServiceHost host = new ServiceHost(typeof(RegulatorServis));

            host.AddServiceEndpoint(typeof(IRegulatorHeater),
                 new NetTcpBinding(),
               new Uri("net.tcp://localhost:4001/IRegulatorHeater"));
                host.Open();
            Console.WriteLine("Servis1 je uspesno pokrenut");





            ServiceHost host1 = new ServiceHost(typeof(RegulatorServis1));

            host1.AddServiceEndpoint(typeof(IRegulatorDevice),
                 new NetTcpBinding(),
               new Uri("net.tcp://localhost:4002/IRegulatorDevice"));
            host1.Open();
            Console.WriteLine("Servis2 je uspesno pokrenut");



            
            Console.ReadLine();


            Console.WriteLine("Temperature");

            foreach (var item in RegulatorServis1.Temp)
            {
                Console.WriteLine();
                Console.WriteLine(item);
            }

            Console.ReadLine();


            Console.WriteLine("Unesite pocetak dnevnog merenja:");
            DateTime pocetak_dnevnog = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Unesite kraj dnevnog merenja:");
            DateTime kraj_dnevnog = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Unesite zeljenu dnevnu temperaturu");
            float dnevna_temperatura=float.Parse(Console.ReadLine());

            Console.WriteLine("Unesite zeljenu nocnu temperaturu");
            float nocna_temperatura = float.Parse(Console.ReadLine());

            DateTime pocetak_nocnog = kraj_dnevnog;
            DateTime kraj_nocnog = pocetak_dnevnog;






        }
    }
}
