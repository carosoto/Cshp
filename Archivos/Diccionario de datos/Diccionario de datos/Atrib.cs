
/*
░▐█▀▀▒▐█▀█▒▄█▀▀█░▐██▒██░░░▒▐█▀▀█▌▒██▄░▒█▌
░▐█▀▀▒▐█▄█▒▀▀█▄▄─░█▌▒██░░░▒▐█▄▒█▌▒▐█▒█▒█░
░▐█▄▄▒▐█░░▒█▄▄█▀░▐██▒██▄▄█▒▐██▄█▌▒██░▒██▌
Autor: Aarón Miranda Victorino
Proyecto : Diccionario de datos
Materia: Estructura de archivos
Correo: epsilon11101@gmail.com
Clase: ATRIBUTO
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
   public class Atrib
    {
        private char[] nombre;
        private char tipo;
        private Int16 longitud;
        private long dir_atrib;
        private Int16 indice;
        private long dir_indice;
        private long dir_sig_atrib;
        
        public Atrib()
        {

        }


        public long GS_dir_sig_atrib
        {
            get { return dir_sig_atrib; }
            set { dir_sig_atrib = value; }
        }

        public long GS_dir_indice
        {
            get { return dir_indice; }
            set { dir_indice = value; }
        }
        public Int16 GS_indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public long GS_dir_atributo
        {
            get { return dir_atrib; }
            set { dir_atrib = value; }
        }

        public Int16 GS_longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }

        public char GS_tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public char[] GS_nombre
        {
           get { return nombre; }
           set { nombre =  value; }
        }


    }
}
