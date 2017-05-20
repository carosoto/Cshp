using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    class HASH_ESTATICA
    {
        private long direccion_inicial;
        private long direccion_siguiente;
        private long[] casillas_direccionesCubeta;
        private long[][] cubetas_direccion_y_valor;
        private string[][] cubeta_direccion_y_caracter;


        public HASH_ESTATICA()
        {
            direccion_inicial = -1;
            direccion_siguiente = -1;
            casillas_direccionesCubeta = new long[3];
            cubetas_direccion_y_valor = new long[3][];
            cubeta_direccion_y_caracter = new String[3][];

        }
        public string[][] GS_cubeta_direccion_y_caracter
        {
            get { return cubeta_direccion_y_caracter; }
            set { cubeta_direccion_y_caracter = value; }
        }

        public long[][] GS_cubetas_direccion_y_valor
        {
            get { return cubetas_direccion_y_valor; }
            set { cubetas_direccion_y_valor = value; }
        }

        public long[] GS_casillas_direccionesCubeta
        {
            get { return casillas_direccionesCubeta; }
            set { casillas_direccionesCubeta = value; }
        }

        public long GS_direccion_siguiente
        {
            get { return direccion_siguiente; }
            set { direccion_siguiente = value; }
        }
        public long GS_direccion_inicial
        {
            get { return direccion_inicial; }
            set { direccion_inicial = value; }
        }







    }
}
