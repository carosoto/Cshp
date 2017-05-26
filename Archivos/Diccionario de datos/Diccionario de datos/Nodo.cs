using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    class Nodo
    {
        private int valor;
        private long dir_siguiente;
        private int m;
        public Nodo()
        {
            valor = -1;
            dir_siguiente = -1;
            m = 0;
        }

        public int GS_contador
        {
            get { return m; ; }
        }


        public int  GS_valor{
            get { return valor; }
            set { m++; valor = value; }

                }

        public long GS_dirSiguiente
        {
            get { return dir_siguiente; }
            set { dir_siguiente = value; }
        }

    }
}
