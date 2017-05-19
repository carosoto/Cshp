using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario
{
    public class indice
    {
        private int ini;
        private int fin;
        private long datos;
        private long siguiente;

        public indice()
        {
            ini = -1;
            fin = -1;
            datos = -1;
            siguiente = -1;
        }

        public int dameIni
        {
            get { return ini; }
            set { ini = value; }
        }

        public int dameFin
        {
            get { return fin; }
            set { fin = value; }
        }

        public long ApDatos
        {
            get { return datos; }
            set { datos = value; }
        }

        public long ApSig
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
    }
}
