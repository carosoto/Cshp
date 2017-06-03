
/*
░▐█▀▀▒▐█▀█▒▄█▀▀█░▐██▒██░░░▒▐█▀▀█▌▒██▄░▒█▌
░▐█▀▀▒▐█▄█▒▀▀█▄▄─░█▌▒██░░░▒▐█▄▒█▌▒▐█▒█▒█░
░▐█▄▄▒▐█░░▒█▄▄█▀░▐██▒██▄▄█▒▐██▄█▌▒██░▒██▌
Autor: Aarón Miranda Victorino
Proyecto : Diccionario de datos
Materia: Estructura de archivos
Correo: epsilon11101@gmail.com
Clase: Entidad
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    public class Entidad
    {
        //Variables de instancia
        private char[] nombre;
        private long Dir_entidad;
        private long Dir_datos;
        private long Dir_atributos;
        private long Dir_Sig_entidad;
        private List<Atrib> atrib;
        //obtener y modificar nombre de la entidad
        public char[] GS_NombreEntidad
        {
            get { return nombre; }
            set { nombre = value;}
        }
        //obtener y modificar dir de entidad
        public long GS_Dir_entidad
        {
            get { return Dir_entidad; }
            set { Dir_entidad = value; }
        }
        //obtener y modificar dir de datos
        public long GS_Dir_datos
        {
            get { return Dir_datos; }
            set { Dir_datos = value; }
        }
        //obtener y modificar dir de atributos
        public long GS_Dir_atributos
        {
            get { return Dir_atributos; }
            set { Dir_atributos = value; }
        }
        //obtener y modificar dir sig entidad
        public long GS_Dir_Sig_entidad
        {
            get { return Dir_Sig_entidad; }
            set { Dir_Sig_entidad = value; }
        }
        //obtener y modificar lista de atributos
        public List<Atrib> GS_atrib
        {
            get { return atrib; }
            set { atrib = value; }
        }
        //constructor
        public Entidad() {
            nombre = new char[30];
            atrib = new List<Atrib>();
        }


    }
}
