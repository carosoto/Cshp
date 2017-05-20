using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    class secundaria
    {
        long[] direcciones;
        string cadena;
        long direccion;
        long direccion_siguiente;
        long valor;
        public secundaria()
        {
            direcciones = new long[5];
            cadena = "";
            direccion = 0;
            direccion_siguiente = 0;
            valor = 0;

        }
        public long GS_valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public long GS_direccionSiguiente
        {
            get { return direccion_siguiente; }
            set { direccion_siguiente = value; }
        }

        public long GS_direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public long[] GS_direcciones
        {
            get { return direcciones; }
            set { direcciones = value; }
        }

        public string GS_cadena
        {
            get { return cadena; }
            set { cadena = value; }
        }





    }
}
