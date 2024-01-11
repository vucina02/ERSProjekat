using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Regulator;

namespace HeaterTest1
{

    [TestFixture]
    public class TestHeater
    {
        private HeaterImpl heaterImpl;

        [SetUp]

        public void SetUp()
        {
            var hetaerImplV = new Mock<HeaterImpl>();
            heaterImpl = hetaerImplV.Object;


        }
        [Test]
        public void TestirajHeater()
        {
            heaterImpl.Ukljuci();
            Assert.That(heaterImpl.HeaterRadi, Is.True, "Heater je ukljucen");




            


            heaterImpl.Povecaj();
            heaterImpl.Povecaj();
            heaterImpl.Povecaj();
            Assert.That(heaterImpl.TemperaturaHeatera == 0.03f, Is.True, "Povecali smo temperaturu za 0.03");




        }



        
    }
}
