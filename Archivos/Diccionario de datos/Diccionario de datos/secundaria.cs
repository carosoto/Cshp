/*
░▐█▀▀▒▐█▀█▒▄█▀▀█░▐██▒██░░░▒▐█▀▀█▌▒██▄░▒█▌
░▐█▀▀▒▐█▄█▒▀▀█▄▄─░█▌▒██░░░▒▐█▄▒█▌▒▐█▒█▒█░
░▐█▄▄▒▐█░░▒█▄▄█▀░▐██▒██▄▄█▒▐██▄█▌▒██░▒██▌
Autor: Aarón Miranda Victorino
Proyecto : Diccionario de datos
Materia: Estructura de archivos
Correo: epsilon11101@gmail.com
Clase: Secundaria
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    class secundaria
    {
        //Variables de instancia
        long[] direcciones;
        string cadena;
        long direccion;
        long direccion_siguiente;
        long valor;
        //constructor
        public secundaria()
        {
            direcciones = new long[5];
            cadena = "";
            direccion = 0;
            direccion_siguiente = 0;
            valor = 0;

        }
        //obtener y modifica valor
        public long GS_valor
        {
            get { return valor; }
            set { valor = value; }
        }
        //obtener y modifica direccion siguiente
        public long GS_direccionSiguiente
        {
            get { return direccion_siguiente; }
            set { direccion_siguiente = value; }
        }
        //obtener y modifica direccion
        public long GS_direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        //obtener y modifica direcciones
        public long[] GS_direcciones
        {
            get { return direcciones; }
            set { direcciones = value; }
        }
        //obtener y modifica cadena
        public string GS_cadena
        {
            get { return cadena; }
            set { cadena = value; }
        }





    }
}
