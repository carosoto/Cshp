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
        private long dir_izquierda;
        private long dir_derecha;
        private int m;
        public Nodo()
        {
            valor = -1;
            dir_siguiente = -1;
            dir_izquierda = -1;
            dir_derecha = -1;
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
        public long GS_dirIzquierda
        {
            get { return dir_izquierda; }
            set { dir_izquierda = value; }
        }
        public long GS_dirDerecha
        {
            get { return dir_derecha; }
            set { dir_derecha = value; }
        }

    }
}
