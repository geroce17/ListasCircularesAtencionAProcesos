using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC___Atencion_a_procesos
{
    class Proceso
    {
        public string nombre { get; set; }
        public int ciclos { get; set; }
        public Proceso siguiente { get; set; }
        public Proceso anterior { get; set; }

        public override string ToString()
        {
            string cadena = "Proceso: " + nombre + "\r\n" + "No. ciclos: " + ciclos + "\r\n\r\n";
            return cadena;
        }
    }
}
