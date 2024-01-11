using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Regulator;

namespace RegulatorTest
{
    [TestFixture]
    public class TestRegulator
    {
        private RegulatorImpl regulatorImpl;

        [SetUp]

        public void SetUp()
        {
            var regulatorImplV = new Mock<RegulatorImpl>();
            regulatorImpl = regulatorImplV.Object;
        }

       
    }
}
