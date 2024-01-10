using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common1;
using Common1.Model;

namespace Regulator
{

    public class Program
    {
        public List<float> temps;

        #region Promjenljive
        public static DateTime Pocetak_dnevnog { get; set; }
        public static DateTime Kraj_dnevnog { get; set; }
        public static DateTime Pocetak_nocnog { get; set; }
        public static DateTime Kraj_nocnog { get; set; }
        public static float Dnevna_temperatura { get; set; }
        public static float Nocna_temperatura { get; set; }
        public static bool Radi { get; set; }
        public static float Prosek { get; set; }
        private readonly static object lockObject = new object();
        #endregion
        static void Main(string[] args)
        {

            ChannelFactory<IBazaRegulator> channel =
                new ChannelFactory<IBazaRegulator>("ServiceName");

            IBazaRegulator proxy = channel.CreateChannel();



            

            ServiceHost host = new ServiceHost(typeof(RegulatorServis));

            host.AddServiceEndpoint(typeof(IRegulatorHeater),
                 new NetTcpBinding(),
               new Uri("net.tcp://localhost:4001/IRegulatorHeater"));
            host.Open();
            Console.WriteLine("Servis1 je uspesno pokrenut");


            RegulatorServis1 reg = new RegulatorServis1(lockObject);


                ServiceHost host1 = new ServiceHost(reg);
                
                host1.AddServiceEndpoint(typeof(IRegulatorDevice),
                     new NetTcpBinding(),
                   new Uri("net.tcp://localhost:4002/IRegulatorDevice"));

                host1.Open();
              
                //reg.Hello();
                
                Console.WriteLine("Servis2 je uspesno pokrenut");

                 Console.ReadLine();










            RegulatorImpl regulator = new RegulatorImpl(proxy);
            HeaterImpl heater = new HeaterImpl(16,regulator);

            meni(heater);
            Radi = true;
            Thread thread = new Thread(() => start(proxy, heater, reg));
            thread.Start();
            Thread thread1 = new Thread(() => PovecavajTemperaturu(heater));
            thread1.Start();


            // Glavna nit čeka da se druga nit završi
            thread.Join();
            thread1.Join();

            Console.ReadLine();
        }

        public static void PovecavajTemperaturu(HeaterImpl heater)
        {
            while(true)
            {
                if (heater.HeaterRadi)
                {
                    Console.WriteLine("Povecaj");
                    heater.Povecaj();
                }
                Thread.Sleep(5000);
            }
          
        }
        private static void UnosPodataka()
        {
            Console.WriteLine("Unesite pocetak dnevnog merenja (u formatu godina,dan,mesec,sat,minut,sekunda)");
             string unos= Console.ReadLine();
            string[] delovi = unos.Split(',');
            Pocetak_dnevnog = new DateTime(Convert.ToInt32(delovi[0]), Convert.ToInt32( delovi[1]), Convert.ToInt32(delovi[2]), Convert.ToInt32(delovi[3]), Convert.ToInt32(delovi[4]), Convert.ToInt32(delovi[5]));
            
            Console.WriteLine("Unesite kraj dnevnog merenja (u formatu godina,dan,mesec,sat,minut,sekunda):");
            unos = Console.ReadLine();
            delovi = unos.Split(',');
            Kraj_dnevnog = new DateTime(Convert.ToInt32(delovi[0]), Convert.ToInt32(delovi[1]), Convert.ToInt32(delovi[2]), Convert.ToInt32(delovi[3]), Convert.ToInt32(delovi[4]), Convert.ToInt32(delovi[5]));
            

            Console.WriteLine("Unesite zeljenu dnevnu temperaturu");
            Dnevna_temperatura = float.Parse(Console.ReadLine());

            Console.WriteLine("Unesite zeljenu nocnu temperaturu");
            Nocna_temperatura = float.Parse(Console.ReadLine());

            Pocetak_nocnog = Kraj_dnevnog;
            Kraj_nocnog = Pocetak_dnevnog;
        }

        public static void meni(HeaterImpl heater)
        {
            bool uslov = true;
            while (uslov)
            {
                Console.WriteLine("1.Unesite parametre");
                Console.WriteLine("2.Ukljuci/Iskljuci Heater");
                Console.WriteLine("Unesite opciju");

                int opcija=Int32.Parse(Console.ReadLine()); 

                switch (opcija)
                {
                    case 1:
                        UnosPodataka(); uslov = false; break;  
                    case 2:
                        UkljuciIliIskljuciHeater(heater);
                        break;

                    default:
                        Console.WriteLine("Niste uneli odgovarajucu opciju");
                        break;

                }

            }

            

        }

        public static void UkljuciIliIskljuciHeater(HeaterImpl heater) {
            Console.WriteLine("1.Ukljuci");
            Console.WriteLine("2.Iskljuci");
            int opcija=Int32.Parse(Console.ReadLine());

            if (opcija == 1)
            {
                heater.Ukljuci();
            }
            else if (opcija == 2)
            {
               heater.Iskljuci();
            }
            else {
                Console.WriteLine("Niste uneli odgovarajucu opciju");
            }



        }

        public static void start(IBazaRegulator proxy,  HeaterImpl heater,RegulatorServis1 regg)
        {
            Prosek = proxy.GetProsjek();
            heater.Ukljuci();
            while(Radi)
            {
                if (SignalZaPaljenje())
                {
                    heater.Ukljuci();
                }
                else
                {
                    heater.Iskljuci();
                }



                if (regg.Temp.Count==0)
                {
                    Console.WriteLine("zakljucavam");
                    Monitor.Enter(lockObject);
                    Monitor.Wait(lockObject);
                    Monitor.Exit(lockObject);
                    Console.WriteLine("otkljucavam");
                }
                   
                
                Prosek = regg.ProsjekTemperatura();
            }
        }


        public static bool SignalZaPaljenje()
        {
            float prosecnaTemp = Prosek;
            DateTime vremeTemp=DateTime.Now;
            if (vremeTemp > Pocetak_dnevnog && vremeTemp <Kraj_dnevnog)
            {
                if (prosecnaTemp < Dnevna_temperatura)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (prosecnaTemp < Nocna_temperatura)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }




    }
}
