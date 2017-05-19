using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario
{
    class Entidades
    {
        /// <summary>
        /// Variables.
        /// </summary>
        public char[] nombre= new char[30];
        public long sig;
        public long atrb;
        public long pos;
        private long datos;
        private List<Atributos> listaAtrib;

        public Entidades(char[] nom)
        {
            nombre = nom;
            sig = -1;
            atrb = -1;
            pos = -1;
            datos = -1;
        }

        public long ApDatos
        {
            get { return datos; }
            set { datos = value; }
        }

        public List<Atributos> atributos
        {
            get { return listaAtrib; }
            set { listaAtrib = value; }
        }

        public static bool tieneClave(List<Atributos> lista)
        {
            bool band = false;

            foreach (Atributos atrib in lista)
            {
                if (atrib.esClave)
                {
                    band = true;
                }
            }
            return band;
        }
     
    }
}
