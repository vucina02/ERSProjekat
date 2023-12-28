using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Baza.Model
{
    public class Device
    {
        

        public int Id { get; set; }

        public DateTime  Vreme_merenja { get; set; }

        public float Temperatura_merenja { get; set; }

        public Device() { }

        public Device(int idd,DateTime vreme,float temperatura)
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
