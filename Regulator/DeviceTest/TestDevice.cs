using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceProject;
using Moq;
using NUnit.Framework;

namespace DeviceTest
{
    [TestFixture]
    public class TestDevice
    {
        private DeviceImpl deviceImpl;

        [SetUp]

        public void SetUp() {
            var deviceImplV = new Mock<DeviceImpl>();
            deviceImpl = deviceImplV.Object;
        }

        


    }
}
