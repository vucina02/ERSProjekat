using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common1.Model;

namespace Common1
{
    [ServiceContract]
    public interface IBazaRegulator
    {
        [OperationContract]
        void posalji(DeviceClass d);

        [OperationContract]

        void UpisiHeater(HeaterClass heater);

        [OperationContract]

        float GetProsjek();
    }
}
