using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza;
using Common1.Model;
using Moq;
using NUnit.Framework;

namespace BazaTest
{
    [TestFixture]
    public class TestBaza
    {
        private BazaImpl dataBase;

        [SetUp]

        public void SetUp()
        {
            var dataBaseV = new Mock<BazaImpl>();
            dataBase=dataBaseV.Object;  
        }

        [Test]

        public void TestiranjeDevice() { 
            dataBase.DeleteAllDevice();
            List<DeviceClass> devices1 = new List<DeviceClass>();
            devices1=dataBase.GetDevices(); 
            Assert.That( devices1.Count== 0, Is.True, "Izbrisali smo sve");
            DeviceClass d=new DeviceClass(1,new DateTime(2024,10,1,12,12,12),5);
            DeviceClass d1 = new DeviceClass(2, new DateTime(2024, 10, 1, 12, 12, 12), 5);
            DeviceClass d2 = new DeviceClass(3, new DateTime(2024, 10, 1, 12, 12, 12), 5);
            DeviceClass d3 = new DeviceClass(4, new DateTime(2024, 10, 1, 12, 12, 12), 5);
            List<DeviceClass> devices= new List<DeviceClass>();

            dataBase.InsertDevice(d);
            dataBase.InsertDevice(d1);
            dataBase.InsertDevice(d2);
            dataBase.InsertDevice(d3);
            devices = dataBase.GetDevices();
            float prosjek = dataBase.ProsjekTemperaturaDeviceBaza();
            Assert.That(prosjek == 5, Is.True, "Tacan prosjek");
            Assert.That(devices.Count==4,Is.True,"Dodali smo 4");


            
        }
        [Test]
        public void TestiranjeRegulatora() {
            dataBase.DeleteAllRegulator();
            List<RegulatorClass> regulatori = new List<RegulatorClass>();
            regulatori = dataBase.GetRegulator();
            Assert.That(regulatori.Count == 0, Is.True, "Izbrisali smo sve");
            RegulatorClass r = new RegulatorClass(1, new DateTime(2024, 10, 1, 7, 0, 0), new DateTime(2024, 10, 1, 19, 0, 0),
                                                new DateTime(2024, 10, 1, 19, 0, 0), new DateTime(2024, 10, 1, 7, 0, 0), 22, 19);
            List<RegulatorClass> regulatori1 = new List<RegulatorClass>();
            dataBase.InsertRegulator(r);
            regulatori1 = dataBase.GetRegulator();
            Assert.That(regulatori1.Count == 1, Is.True, "Dodali smo 1 regulator");
        }

        [Test]
        public void TestiranjeHeatera() {
            dataBase.DeleteAllHeater();
            List<HeaterClass> hiteri = new List<HeaterClass>();
            hiteri = dataBase.GetHeater();
            Assert.That(hiteri.Count == 0, Is.True, "Izbrisali smo sve heatere");
            HeaterClass h = new HeaterClass(new DateTime(2024,10,1,10,0,0),new TimeSpan(1,0,0),12);
            List<HeaterClass> hiteri1 = new List<HeaterClass>();
            dataBase.InsertHeater(h);
            hiteri1=dataBase.GetHeater();
            Assert.That(hiteri1.Count == 1, Is.True, "Dodali smo 1 heater");
        }
    }
}
