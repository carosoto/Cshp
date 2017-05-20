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
        private String especiales;
        private int opcion; //VARIABLE QUE ME AYUDA A SELECCIONAR LA OPCION
        private int contador; //VARIABLE QUE ME AYUDA A CONTAR CLICS PARA SABER NODO INICIO Y NODO FIN
        private int indexP, indexS; //VARIABLES PARA LOCALIZAR NODO INICIO Y NODO FIN PARA CREAR ARISTA
        private int indiceNodo; //Variable para ir almacenando el indice del nodo;
        private Boolean dirigida;//BANDERA PARA DIBUJAR ARISTA DIRIGIDA O NO DIRIGIDA TRUE--DIRIGIDA FALSE--NO DIRIGIDA
        private Boolean mover_nodo;//habilitar bandera para mover nodo
        private Boolean mueve_grafo,desplaza_grafo;//habilitar bandera para mover grafo
        private Boolean activa_colision;//habilitar colision para union de nodos
        private Boolean pega_nodo;//habilita colision para verificar K5
        public Form1()
        {
            g = new Grafo();
            b = new Banderas();
            especiales = "";
            mover_nodo = false;
            mueve_grafo=desplaza_grafo = false;
            activa_colision=pega_nodo = false;
            opcion = 0;
            contador = 0;
            indexP = indexS = indiceNodo = -1;
            InitializeComponent();
        }
        /*****************************************EVENTOS PARA DIBUJAR***************************************************************/
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.actualizaRelacionesAristas();
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
                    activa_colision = false;
                    g.Nuevo_Vertice(e.Location);
                    break;
                case 2:
                    mover_nodo = false;
                    activa_colision = false;
                    if (g.clicNodo(e.Location))
                    {
                        contador++;
                        if (contador == 1) indexP = g.buscaIndice(e.Location);
                        if (contador == 2) { indexS = g.buscaIndice(e.Location); contador = 0; g.Nueva_Arista(indexP, indexS, dirigida); }
                    }
                    break;
                case 3:
                    if (g.clicNodo(e.Location))
                    {
                       
                        indiceNodo = g.buscaIndice(e.Location);
                        mover_nodo = true;
                    }
                    break;
                case 4:
                    mover_nodo = false;
                    activa_colision = false;
                    if (g.clicNodo(e.Location))
                    {
                        
                        indiceNodo = g.buscaIndice(e.Location);
                        g.borrarNodo(indiceNodo);
                    }
                    break;
                case 5:
                    mover_nodo = false;
                    activa_colision = false;
                    g.eliminaArista(e.Location);
                    break;
                case 6:
                    mover_nodo = false;
                    activa_colision = false;
                    if (mueve_grafo)
                    {
                        if (g.clicNodo(e.Location))
                        {
                            g.GS_posActual = e.Location;

                            desplaza_grafo = true;
                        }
                    }
                    break;
                case 7:

                    if (g.clicNodo(e.Location))
                    {

                        indiceNodo = g.buscaIndice(e.Location);

                        activa_colision = true;
                        mover_nodo = true;
                    }
                    
                    break;
            }
            this.Invalidate();
        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(opcion == 3)
            mover_nodo = false;
            if(opcion == 6) { mueve_grafo = false; desplaza_grafo = false; }


        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover_nodo )
            {
                if (indiceNodo != -1)
                {
                    g.mueveNodo(e.Location, indiceNodo);
                    this.Invalidate();
                }
            }

            if (desplaza_grafo)
            {
                mueve_grafo = false;
                g.Mueve_grafo(e.Location);
                g.GS_posActual = e.Location;
                this.Invalidate();
            }

            if (activa_colision)
            {
                if (indiceNodo != -1)
                {
                    if (g.clicNodo(e.Location))
                    {
                        for (int i = 0; i < g.GS_Vertice.Count; i++)
                        {
                            if (g.GS_Vertice[i].GS_nombre != g.GS_Vertice[indiceNodo].GS_nombre)
                            {
                                if (g.GS_Vertice[indiceNodo].GS_coordenadas.X <= g.GS_Vertice[i].GS_coordenadas.X + g.GS_Vertice[i].GS_radio &&
                                    g.GS_Vertice[indiceNodo].GS_coordenadas.X >= g.GS_Vertice[i].GS_coordenadas.X - g.GS_Vertice[i].GS_radio &&
                                    g.GS_Vertice[indiceNodo].GS_coordenadas.Y >= g.GS_Vertice[i].GS_coordenadas.Y - g.GS_Vertice[i].GS_radio &&
                                    g.GS_Vertice[indiceNodo].GS_coordenadas.Y <= g.GS_Vertice[i].GS_coordenadas.Y + g.GS_Vertice[i].GS_radio)
                                {
                                    if (pega_nodo)
                                    {
                                        if (g.colision(g.GS_Vertice[indiceNodo], g.GS_Vertice[i], dirigida))
                                        {
                                            g.borrarNodo(indiceNodo);
                                            indiceNodo = -1;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (g.colisionK5(g.GS_Vertice[indiceNodo], g.GS_Vertice[i]))
                                        {
                                            opcion = -1;
                                            indiceNodo = -1;
                                            activa_colision = false;
                                            mover_nodo = false;
                                            break;
                                        }
                                    }
                                }
                            }

                        }
                    }
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
            activa_colision = false;

        }

        private void BorrarNodo_Click(object sender, EventArgs e)
        {
            opcion = 4;
            
        }//BORRAR NODO

        private void BorrarArista_Click(object sender, EventArgs e)
        {
            opcion = 5;
        } //BORRAR ARISTA

        private void EliminarGrafo_Click(object sender, EventArgs e) //BORRAR GRAFO
        {
            g.Elimina_Grafo();
            this.Invalidate();
        }

        private void Recorrido_Click(object sender, EventArgs e) 
        {
            g.Calcula_Recorrido(true);
        }//RECORRIDO EN PROFUNDIDAD

        private void Union_Click(object sender, EventArgs e)
        {
            activa_colision = true;
            pega_nodo = true;
            opcion = 3;
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           
            switch (especiales)
            {
                case "cn": g.AlgoritmoCirculo((int)numericUpDown1.Value,especiales,this.ClientSize.Width,this.ClientSize.Height); break;
                case "kn": g.AlgoritmoCirculo((int)numericUpDown1.Value, especiales, this.ClientSize.Width, this.ClientSize.Height); break;
                case "wn": g.AlgoritmoCirculo((int)numericUpDown1.Value, especiales, this.ClientSize.Width, this.ClientSize.Height); break;

            }
            this.Invalidate();
        }//GRAFOS ESPECIALES

        private void Cn_Click(object sender, EventArgs e)
        {
            especiales = "cn";
            Point p = new Point(0, 0);
            p.X = (Cn.Bounds.Location.X + Cn.Bounds.Width);
            p.Y = (Cn.Bounds.Y + Cn.Bounds.Width);
            numericUpDown1.Minimum = 3;
            numericUpDown1.Value = 3;
            numericUpDown1.Location = p;
            numericUpDown1.Visible = true;
            numericUpDown1_ValueChanged(null, null);
        }//CONFIGURACION CN

        private void Kn_Click(object sender, EventArgs e)
        {
            especiales = "kn";
            numericUpDown1.Minimum = 1;
            numericUpDown1.Value = 1;
            Point p = new Point(0, 0);
            p.X = (Kn.Bounds.Location.X + Kn.Bounds.Width);
            p.Y = Kn.Bounds.Y + Kn.Bounds.Width;
            numericUpDown1.Location = p;
            numericUpDown1.Visible = true;
            numericUpDown1_ValueChanged(null, null);
        }//CONFIGURACION KN

        private void Wn_Click(object sender, EventArgs e)
        {
            especiales = "wn";
            Point p = new Point(0, 0);
            p.X = (Wn.Bounds.Location.X + Wn.Bounds.Width);
            p.Y = Wn.Bounds.Y + Wn.Bounds.Width;
            numericUpDown1.Value = 3;
            numericUpDown1.Minimum = 3;
            numericUpDown1.Location = p;
            numericUpDown1.Visible = true;
            numericUpDown1_ValueChanged(null, null);
        }//CONFIGURACION WN

        private void Colorarios_Click(object sender, EventArgs e)
        {
            String resultado = "";
            foreach (Arista a in g.GS_Arista)
            {
                a.GS_marca = false;
            }


            if (g.GS_Vertice.Count >= 3) // si v>=3 se aplican colorarios|
            {
                g.Colorario1(true); // colorario 1


                if (g.verificaCircuitos()) resultado += ("NO SE PUEDE APLICAR COLORARIO 2 \n");

                else g.Colorario2(true);

            }
            else
            {

                MessageBox.Show("NO SE PUEDEN APLICAR COLORARIOS  V < 3");
            }

            if (resultado != "")
                MessageBox.Show(resultado);

            this.Invalidate();
        }//CALCULA COLORARIOS

        private void Homeomorfico_Click(object sender, EventArgs e)
        {
            pega_nodo = false;
            if (!g.verificaCircuitos())
            {

                if (g.Colorario1(false) && g.Colorario2(false)) { MessageBox.Show("el grafo es plano"); activa_colision = false; opcion = -1; }
                else if (g.Colorario1(false) && !g.Colorario2(false)) { MessageBox.Show("el grafo no es  plano"); opcion = 7; }
                else if (!g.Colorario1(false) && g.Colorario2(false)) { MessageBox.Show("el grafo es plano"); activa_colision = false; opcion = -1; }
                else if ((!g.Colorario1(false) && !g.Colorario2(false)))
                {
                    if (g.GS_Vertice.Count == 5)
                    {
                        MessageBox.Show("el grafo no es plano y es homeomorfico a k5");
                        opcion = 7;

                    }
                    else
                    {
                        MessageBox.Show("el grafo no es plano :) ");
                        opcion = 7;

                    }
                }


            }

            else
            {
                if (g.Colorario1(false)) { MessageBox.Show("el grafo es plano"); activa_colision = false; opcion = -1; }
                if (!g.Colorario1(false))
                {
                    if (g.GS_Vertice.Count == 5)
                    {
                        MessageBox.Show("el grafo no es plano y es homeomorfico a k5");
                        opcion = 7;
                    }
                    else
                    {
                        MessageBox.Show("el grafo no es plano >:(");
                        opcion = 7;
                    }
                }
            }
            this.Invalidate();
        }//HOMEOMORFICO A K5

        private void Complemento_Click(object sender, EventArgs e)
        {
            g.complemento(dirigida);
            this.Invalidate();
        }

        private void Euler_Click(object sender, EventArgs e)
        {

            if (g.VerificaCaminoEuler()) MessageBox.Show("true");
            else MessageBox.Show("false");
        }

        private void MoverGrafo_Click(object sender, EventArgs e)
        {
            opcion = 6;
            mueve_grafo = true;
        }//MOVER GRAFO

        private void NoDirigida_Click(object sender, EventArgs e)
        {
            opcion = 2;
            dirigida = false;
        }// CREAR ARISTA NO DIRIGIDA



        /************************************************HABILITAR MENUS*****************************************************************/
    }
}
