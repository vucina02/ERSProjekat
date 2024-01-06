using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common1;
using Common1.Model;
namespace DeviceProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IRegulatorDevice> channel =
              new ChannelFactory<IRegulatorDevice>("ServiceName2");

             IRegulatorDevice proxy = channel.CreateChannel();


            
             
            DeviceImpl impl=new DeviceImpl(proxy);

            impl.pokreniNiti(4);


            Console.Read();
        }
    }
}
