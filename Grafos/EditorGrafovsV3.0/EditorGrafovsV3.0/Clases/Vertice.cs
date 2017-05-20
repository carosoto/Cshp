/*
 
░▐█▀▀▒▐█▀█▒▄█▀▀█░▐██▒██░░░▒▐█▀▀█▌▒██▄░▒█▌
░▐█▀▀▒▐█▄█▒▀▀█▄▄─░█▌▒██░░░▒▐█▄▒█▌▒▐█▒█▒█░
░▐█▄▄▒▐█░░▒█▄▄█▀░▐██▒██▄▄█▒▐██▄█▌▒██░▒██▌
Autor: Aarón Miranda Victorino
Proyecto : Editor de grafos
Materia: Grafos
Correo: epsilon11101@gmail.com
Clase: Vertice
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace EditorGrafovsV3._0.Clases
{
    [Serializable]

    
   public  class Vertice
    {

        private int radio;
        private int Grado;
        private Point p;
        private Color color_fondo, color_contorno, color_letra;
        private Font tipo_letra;
        private String nombre;
        private List<Vertice> relacion_directa;
        private List<Vertice> relacion_indirecta;
        private List<Vertice> relaciones_nodirigido;
        List<String> nombres;
        private Boolean visitado;
        private short conjunto; //variable que me indica en que conjunto pertenece
        public Vertice()
        {

            relacion_directa = new List<Vertice>();
            relacion_indirecta = new List<Vertice>();
            relaciones_nodirigido = new List<Vertice>();
            nombres = new List<string>();
            visitado = false;
        }
        public Vertice(int radio, Point p, Color color_fondo, Color color_contorno, String nombre, Font tipo_letra, Color color_letra)
        {
            GS_radio = radio;
            GS_coordenadas = p;
            GS_colorF = color_fondo;
            GS_colorC = color_contorno;
            GS_nombre = nombre;
            GS_letra = tipo_letra;
            GS_colorL = color_letra;
            relacion_directa = new List<Vertice>();
            relacion_indirecta = new List<Vertice>();
            nombres = new List<string>();
            relaciones_nodirigido = new List<Vertice>();
            visitado = false;
            conjunto = 0;
        }

        public int GS_grado
        {
            get { return Grado; }
            set { Grado = value; }
        }
        public short GS_conjunto
        {
            get { return conjunto; }
            set { conjunto = value; }
        }
        public int GS_radio
        {
            get { return radio; }
            set { radio = value; }
        }
        public Boolean GS_visita
        {
            get { return visitado; }
            set { visitado = value; }
        }
        public Point GS_coordenadas
        {
            get { return p; }
            set { p = value; }
        }
        public Color GS_colorF
        {
            get { return color_fondo; }
            set { color_fondo = value; }
        }
        public Color GS_colorL
        {
            get { return color_letra; }
            set { color_letra = value; }
        }
        public Font GS_letra
        {
            get { return tipo_letra; }

            set { tipo_letra = value; }
        }
        public Color GS_colorC
        {
            get { return color_contorno; }
            set { color_contorno = value; }
        }
        public String GS_nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public List<Vertice> GS_relacionDirecta
        {
            get { return relacion_directa; }
            set { relacion_directa = value; }
        }
        public List<Vertice> GS_relacionIndirecta
        {
            get { return relacion_indirecta; }
            set { relacion_indirecta = value; }
        }
        public List<Vertice> GS_relacionNodirigido
        {
            get { return relaciones_nodirigido; }
            set { relaciones_nodirigido = value; }

        }
        public void AgregaRelacion(Vertice relacion, int Tipo_relacion)
        {
               
            switch (Tipo_relacion)
            {
                case 1: relacion_directa.Add(relacion);break;
                case 2: relacion_indirecta.Add(relacion); break;
                case 3: relaciones_nodirigido.Add(relacion); break;

            }
            ordenaAlfabeticamente(Tipo_relacion);
        } //AGREGAR UNA NUEVAA RELACION Y TIO DE RELACION LAS ORDENA ALFABETICAMENTE  Y CALCULA LOS GRADOS DEL VERTICE
       
        private void ordenaAlfabeticamente(int Tipo_relacion)
        {
            
            switch (Tipo_relacion)
            {
                case 1: foreach (Vertice v in GS_relacionDirecta) nombres.Add(v.GS_nombre);  break;
                case 2: foreach (Vertice v in GS_relacionIndirecta) nombres.Add(v.GS_nombre); break;
                case 3: foreach (Vertice v in GS_relacionNodirigido) nombres.Add(v.GS_nombre); break;
              
            }
            cambiaNombresOrdenados(nombres, Tipo_relacion);
            nombres.Clear();
        }

        private void cambiaNombresOrdenados(List<String> nombres, int Tipo_relacion)
        {
            List<Vertice> aux = new List<Vertice>();
            nombres.Sort();
            switch (Tipo_relacion)
            {
                case 1:
                    foreach (Vertice v in GS_relacionDirecta)
                    {
                        foreach (String n in nombres)
                        {
                            if (n == v.GS_nombre)
                            {
                                aux.Add(v);
                            }
                        }

                    }
                    relacion_directa.Clear();
                    GS_relacionDirecta = aux;
                    break;
                case 2:
                    foreach (Vertice v in GS_relacionIndirecta)
                    {
                        foreach (String n in nombres)
                        {
                            if (n == v.GS_nombre)
                            {
                                aux.Add(v);
                            }
                        }

                    }
                    relacion_indirecta.Clear();
                    GS_relacionIndirecta = aux;

                    break;
                case 3:

                    foreach (Vertice v in GS_relacionNodirigido)
                    {
                        foreach (String n in nombres)
                        {
                            if (n == v.GS_nombre)
                            {
                               
                                aux.Add(v);
                                
                            }
                           
                        }
                    }
                    relaciones_nodirigido.Clear();
                    GS_relacionNodirigido = aux;

                    break;

            }


        }

        public void calculaGradosVertice_Nodirigida()
        {
            int grados=0;
            foreach (Vertice v in GS_relacionNodirigido) grados++;
            GS_grado = grados;
        }


    }
}



