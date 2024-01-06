using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common1.Model
{
    public class RegulatorClass
    {
        public int TempId { get; set; }
        public DateTime Pocetak_dnevnog { get; set; }

        public DateTime Pocetak_nocnog { get; set; }

        public DateTime Kraj_dnevnog { get; set; }

        public DateTime Kraj_nocnog { get; set; }

        public float Dnevna_temperatura { get; set; }

        public float Nocna_temperatura { get; set; }


        public RegulatorClass() { }

        public RegulatorClass(DateTime pdnevni, DateTime pnocni, DateTime kdnevni, DateTime knocni, float dtemp, float ntemp)
        {
            this.Pocetak_dnevnog = pdnevni;
            this.Pocetak_nocnog = pnocni;
            this.Kraj_dnevnog = kdnevni;
            this.Kraj_nocnog = knocni;
            this.Dnevna_temperatura = dtemp;
            this.Nocna_temperatura = ntemp;
        }

        public override string ToString()
        {
            return $"Pocetak dnevnog: {Pocetak_dnevnog}  Pocetak nocnog: {Pocetak_nocnog} Kraj dnevnog: {Kraj_dnevnog}" +
                $"Kraj nocnog: {Kraj_nocnog} Dnevna temperatura: {Dnevna_temperatura} Nocna temperatura: {Nocna_temperatura}";
        }
    }
}
