/*
░▐█▀▀▒▐█▀█▒▄█▀▀█░▐██▒██░░░▒▐█▀▀█▌▒██▄░▒█▌
░▐█▀▀▒▐█▄█▒▀▀█▄▄─░█▌▒██░░░▒▐█▄▒█▌▒▐█▒█▒█░
░▐█▄▄▒▐█░░▒█▄▄█▀░▐██▒██▄▄█▒▐██▄█▌▒██░▒██▌
Autor: Aarón Miranda Victorino
Proyecto : Diccionario de datos
Materia: Estructura de archivos
Correo: epsilon11101@gmail.com
Clase: Primaria
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    class primaria
    {
        //variables de instancia
        private long apuntador;
        private string cadena;
        private long clave;
        private long dir;
        private long dato;
        private string nombre;
        private string tipo;
        //constructor 
        public primaria()
        {
            
            cadena = "";
            apuntador = 0;
            clave = 0;
            dir = 0;
            dato = 0;

        }
        //obtener y modifica datos
        public long GS_dato
        {
            get { return dato; }
            set { dato = value; }
        }
        //obtener y modifica tipo
        public string GS_tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        //obtener y modifica nombre
        public string GS_nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        //obtener y modifica apuntador
        public long GS_apuntador
        {
            get { return apuntador; }
            set { apuntador = value; }
        }
        //obtener y modifica direccion
        public long GS_direccion
        {
            get { return dir; }
            set { dir = value; }
        }
        //obtener y modifica clave
        public long GS_clave
        {
            get { return clave; }
            set { clave = value; }
        }
        //obtener y modifica cadena
        public string GS_cadena
        {
            get { return cadena; }
            set { cadena = value; }
        }
    }
}
