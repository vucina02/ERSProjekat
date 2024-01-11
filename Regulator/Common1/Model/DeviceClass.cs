using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Common1.Model
{
    [DataContract]
    public class DeviceClass
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Vreme_merenja { get; set; }
        [DataMember]
        public float Temperatura_merenja { get; set; }

        public DeviceClass(int v, string v1) { }

        public DeviceClass(int idd, DateTime vreme, float temperatura)
        {
            this.Id = idd;
            this.Vreme_merenja = vreme;
            this.Temperatura_merenja = temperatura;
        }

        public override string ToString()
        {
            return $"ID: {Id} VREME: {Vreme_merenja} TEMPERATURA: {Temperatura_merenja}";
        }
    }
}
