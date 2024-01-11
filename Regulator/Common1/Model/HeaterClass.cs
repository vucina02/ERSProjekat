using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common1.Model
{
    [DataContract]
    public class HeaterClass
    {
        [DataMember]
        public DateTime Pocetak { get; set; }
        [DataMember]
        public TimeSpan Trajanje { get; set; }
        [DataMember]
        public double PotroseniResursi { get; set; }
        

        public HeaterClass() { }

        public HeaterClass(DateTime pocetak, TimeSpan trajanje, double potroseniResursi)
        {
            Pocetak = pocetak;
            Trajanje = trajanje;
            PotroseniResursi = potroseniResursi;
        }

        
    }
}
