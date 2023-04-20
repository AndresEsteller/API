using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Persona
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string profesion { get; set; }

        public Persona()
        {
            this.cedula = "";
            this.nombre = "";
            this.profesion = "";
        }
    }
}
