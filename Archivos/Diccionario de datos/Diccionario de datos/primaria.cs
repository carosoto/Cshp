using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    class primaria
    {
        private long apuntador;
        private string cadena;
        private long clave;
        private long dir;
        private long dato;
        private string nombre;
        private string tipo;
        
        public primaria()
        {
            
            cadena = "";
            apuntador = 0;
            clave = 0;
            dir = 0;
            dato = 0;

        }
        public long GS_dato
        {
            get { return dato; }
            set { dato = value; }
        }
        public string GS_tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string GS_nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public long GS_apuntador
        {
            get { return apuntador; }
            set { apuntador = value; }
        }
        public long GS_direccion
        {
            get { return dir; }
            set { dir = value; }
        }

        public long GS_clave
        {
            get { return clave; }
            set { clave = value; }
        }
        public string GS_cadena
        {
            get { return cadena; }
            set { cadena = value; }
        }
    }
}
