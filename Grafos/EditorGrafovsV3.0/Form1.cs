using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EditorGrafovsV3._0.Clases;
using System.Drawing.Drawing2D;

namespace EditorGrafovsV3._0
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        /*****************************************VARIABLES DE INSTANCIA*****************************************************/
        private Grafo g;
        private Banderas b;
        private int opcion; //VARIABLE QUE ME AYUDA A SELECCIONAR LA OPCION
        private int contador; //VARIABLE QUE ME AYUDA A CONTAR CLICS PARA SABER NODO INICIO Y NODO FIN
        private int indexP, indexS; //VARIABLES PARA LOCALIZAR NODO INICIO Y NODO FIN PARA CREAR ARISTA
        private int indiceNodo; //Variable para ir almacenando el indice del nodo;
        private Boolean dirigida;//BANDERA PARA DIBUJAR ARISTA DIRIGIDA O NO DIRIGIDA TRUE--DIRIGIDA FALSE--NO DIRIGIDA
        private Boolean mover_nodo;//habilitar bandera para mover nodo
        public Form1()
        {
            g = new Grafo();
            b = new Banderas();
            mover_nodo = false;
            opcion = 0;
            contador = 0;
            indexP = indexS = indiceNodo = -1;
            InitializeComponent();
        }
        /*****************************************EVENTOS PARA DIBUJAR***************************************************************/
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (g.GS_Vertice != null)
                Dibuja_Vertices(e.Graphics);
            if (g.GS_Arista != null)
                Dibuja_Arista(e.Graphics);
        }

        public void Dibuja_Vertices(Graphics dibuja)
        {
            foreach (Vertice v in g.GS_Vertice)
            {
                dibuja.FillEllipse(new SolidBrush(v.GS_colorF), v.GS_coordenadas.X - v.GS_radio, v.GS_coordenadas.Y - v.GS_radio, v.GS_radio * 2, v.GS_radio * 2); // se rellena la elipse   
                dibuja.DrawEllipse(new Pen(v.GS_colorC), v.GS_coordenadas.X - v.GS_radio, v.GS_coordenadas.Y - v.GS_radio, v.GS_radio * 2, v.GS_radio * 2); // se dibuja contorno de elipse
                dibuja.DrawString(v.GS_nombre, v.GS_letra, new SolidBrush(v.GS_colorL), v.GS_coordenadas.X - 15, v.GS_coordenadas.Y - 10);//dibujar letra
            }
        } // dibujar elipse
        public void Dibuja_Arista(Graphics dibuja)
        {

            Pen p = new Pen(g.GS_config.GS_colorLinea, g.GS_config.GS_tamañoArista);
            foreach (Arista a in g.GS_Arista)
            {
                if (!a.GS_dirigida) { p.EndCap = LineCap.Flat; }
                else { AdjustableArrowCap tamFlecha = new AdjustableArrowCap(5, 5); p.CustomEndCap = tamFlecha; }
                dibuja.DrawLine(p, a.p1xy, a.p2xy);
            }
        }// Dibujar Linea

        /*********************************************EVENTOS MOUSE************************************************************************/
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (opcion)
            {
                case 1:
                    mover_nodo = false;
                    g.Nuevo_Vertice(e.Location);

                    break;
                case 2:
                    mover_nodo = false;
                    if (g.clicNodo(e.Location))
                    {
                        contador++;
                        if (contador == 1) indexP = g.buscaIndice(e.Location);
                        if (contador == 2) { indexS = g.buscaIndice(e.Location); contador = 0; g.Nueva_Arista(indexP, indexS, dirigida); }
                    }
                    break;
                case 3:
                    if (g.clicNodo(e.Location))
                        indiceNodo = g.buscaIndice(e.Location);

                    break;
            }
            this.Invalidate();
        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover_nodo)
            {
                if (indiceNodo != -1)
                {
                    g.mueveNodo(e.Location, indiceNodo);
                    this.Invalidate();
                }
            }
        } // MOVER NODO

        /***********************************************EVENTOS DE MENU ICONOS *********************************************************/
        private void BotonVertice_Click(object sender, EventArgs e)
        {
            opcion = 1;
        }// CREAR NUEVO VERTICE

        private void AristaDirigida_Click(object sender, EventArgs e)
        {
            opcion = 2;
            dirigida = true;
        }// CREAR ARISTA DIRIGDA

        private void MueveNodo_Click(object sender, EventArgs e) // MOVER NODO
        {
            opcion = 3;
            mover_nodo = true;

        }



        private void NoDirigida_Click(object sender, EventArgs e)
        {
            opcion = 2;
            dirigida = false;
        }// CREAR ARISTA NO DIRIGIDA



        /************************************************HABILITAR MENUS*****************************************************************/
    }
}
