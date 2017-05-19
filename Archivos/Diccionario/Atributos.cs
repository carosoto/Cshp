using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario
{
    class Atributos
    {
      
        private char[] nom = new char[30];
        public Int16 tipo;
        public Int32 tam;
        private long apSig;
        private bool clave;
        private long pos;

        public Atributos(char[] nom, Int16 type,Int32 size)
        {
            this.nom = nom;
            tipo = type;
            tam = size;
            apSig = -1;
        }

       
        public Atributos()
        {
            tipo = -1;
            tam = -1;
            apSig = -1;
        }

       
        public bool esClave
        {
            get { return clave; }
            set { clave = value; }
        }

       
        public long posicion
        {
            get { return pos; }
            set { pos = value; }
        }

        
        public long siguienteAtrib
        {
            get { return apSig; }
            set { apSig = value; }
        }

        public char[] nombre
        {
            get { return nom; }
            set { nom = value; }
        }

    }
}
