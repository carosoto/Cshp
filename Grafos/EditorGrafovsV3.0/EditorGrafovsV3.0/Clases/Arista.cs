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
namespace EditorGrafovsV3._0.Clases
{
    [Serializable]
   public class Arista
    {
        Vertice inicio, fin;
        private Color color_linea;
        private Point xy1, xy2;
        private Boolean dirigida;
        private Boolean marca;
        public Arista() { inicio = new Vertice(); fin = new Vertice(); }
        public Arista(Vertice inicio, Vertice fin, Boolean dirigida)
        {
            this.inicio = new Vertice();
            this.fin = new Vertice();
            GS_dirigida = dirigida;
            GS_RelacionDirecta = inicio;
            GS_RelacionIndirecta = fin;
            xy1 = calculaCoorXY1();
            xy2 = calculaCoorXY2();
            marca = false;
        }
        public Arista(Vertice inicio, Vertice fin, Boolean dirigida,Boolean marca)
        {
            this.inicio = new Vertice();
            this.fin = new Vertice();
            GS_dirigida = dirigida;
            GS_RelacionDirecta = inicio;
            GS_RelacionIndirecta = fin;
            xy1 = calculaCoorXY1();
            xy2 = calculaCoorXY2();
            this.marca = marca;
        }

        public Boolean GS_marca
        {
            get { return marca; }
            set { marca = value; }
        }
        private Point calculaCoorXY1()
        {
            Point pxy1 = inicio.GS_coordenadas;
            Double angulo = calculaAngulo();

            pxy1.X = inicio.GS_coordenadas.X - (int)CalculaX(angulo);
            pxy1.Y = inicio.GS_coordenadas.Y - (int)calculaY(angulo);
            return pxy1;
        }
        private Point calculaCoorXY2()
        {
            Point pxy2 = fin.GS_coordenadas;
            Double angulo = calculaAngulo();

            pxy2.X = fin.GS_coordenadas.X + (int)CalculaX(angulo);
            pxy2.Y = fin.GS_coordenadas.Y + (int)calculaY(angulo);
            return pxy2;
        }
        private Double calculaAngulo()
        {
            Double angulo = Math.Atan2((inicio.GS_coordenadas.Y - fin.GS_coordenadas.Y), (inicio.GS_coordenadas.X - fin.GS_coordenadas.X));
            return angulo;
        }
        private double CalculaX(double ang)
        {
            return (inicio.GS_radio * Math.Cos(ang));
        }
        private double calculaY(double ang)
        {

            return (fin.GS_radio * Math.Sin(ang));
        }
        public Point p1xy
        {
            get { return calculaCoorXY1(); }
        }
        public Point p2xy
        {
            get { return calculaCoorXY2(); }
        }
        public Boolean GS_dirigida
        {
            get { return dirigida; }
            set { dirigida = value; }
        }
        public Color GS_color
        {
            get { return color_linea; }
            set { color_linea = value; }
        }
        public Point GS_xy1
        {
            get { return xy1; }
            set { xy1 = value; }
        }
        public Point GS_xy2
        {
            get { return xy2; }

            set { xy2 = value; }
        }
        public Vertice GS_RelacionDirecta
        {
            get { return inicio; }
            set { inicio = value; }
        }
        public Vertice GS_RelacionIndirecta
        {
            get { return fin; }
            set { fin = value; }
        }

        





    }
}
