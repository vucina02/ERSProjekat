using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common1;
using Common1.Model;

namespace HeaterProject
{
    public class Program
    {
        static void Main(string[] args)
        {

            ChannelFactory<IRegulatorHeater> channel =
                new ChannelFactory<IRegulatorHeater>("ServiceName1");

            IRegulatorHeater proxy = channel.CreateChannel();


            DeviceClass d = new DeviceClass(1, new DateTime(2019, 10, 10), 100.0f);
            proxy.posalji(d);
            Console.Read();
        }
    }
}
