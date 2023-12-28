using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza.Model;

namespace Baza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BazaImpl baza=BazaImpl.GetBaza();

            Device d = new Device(1, new DateTime(2022, 10, 21), 100);
            Device d1 = new Device(1, new DateTime(2022, 10, 21), 200);

            baza.InsertDevice(d);
            baza.UpdateDevice(d1, 1);
            baza.DeleteDevice(3);


        }
    }
}
