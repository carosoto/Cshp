using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorGrafovsV3._0.Clases
{
    [Serializable]
    public class Grafo
    {
        /***********************************VARIABLES PARA GRAFOS***************************************************/
        private List<Arista> Ari;
        private List<Vertice> Ver;
        private List<GraphicsPath> Arista_eliminar;
        private Configuracion configura;
        private Config apariencia, apariencia_aux;
        private String conjuntos;//variable para mostrar conjuntos
        private Point Pos_actual, Pos_anterior;

        /***************************************VARIABLES PARA LOS NODOS*********************************************/
        private int letra, NumNodo; //variables para asignarle un nombre al nodo
        private Boolean ponNumero;//variales para activar el numero en el nombre del nodo :)
        /**************************************VARIABLES PARA ARISTAS*************************************************/
        /****************************************CONSTRUCTORES*********************************************************/
        public Grafo()
        {
            apariencia = new Config();
            Ari = new List<Arista>();
            Arista_eliminar = new List<GraphicsPath>();
            Ver = new List<Vertice>();
            configura = new Configuracion(Color.Silver);
            apariencia = new Config();
            GS_Arista = Ari;
            GS_Vertice = Ver;
            conjuntos = "";
            apariencia = configura.GS_config;
            apariencia_aux = apariencia;
            letra = 64;
            NumNodo = 0;
            Pos_actual.X = Pos_anterior.X = 0;
            Pos_actual.Y = Pos_anterior.Y = 0;
            ponNumero = false;

        }
        /*******************************************CREACION DE ARISTAS *********************************************/

        public void Nueva_Arista(int indexPrincipal, int indexDestino, Boolean dirigida)
        {
          
            if (indexPrincipal != -1 && indexDestino != -1)
            {
                Nueva_Arista(new Arista(dameNodo(indexPrincipal), dameNodo(indexDestino), dirigida));
                Ver[indexPrincipal].AgregaRelacion(dameNodo(indexDestino), 1);//relacion directa A --- B
                Ver[indexPrincipal].AgregaRelacion(dameNodo(indexDestino), 3);
                Ver[indexDestino].AgregaRelacion(dameNodo(indexPrincipal), 2);//relacion indirecta B --- A
                Ver[indexDestino].AgregaRelacion(dameNodo(indexPrincipal), 3);

            }


        }
        public void Nueva_Arista(Arista ari)
        {
            Ari.Add(ari);
        }
        
        /********************************************CREACION DE NODOS*************************************/

        public void Nuevo_Vertice(Point Location)
        {
            Ver.Add(new Vertice(apariencia.GS_radio, Location, apariencia.GS_colorRelleno,
                                apariencia.GS_colorContorno, generaNombreVertice(),
                                apariencia.GS_tipoLetra, apariencia.GS_colorLetra));
        }
        /*****************************************METODOS DE ACCESO    GRAFO ********************************************/
        public List<Arista> GS_Arista
        {
            get { return Ari; }
            set { Ari = value; }
        }
        public List<Vertice> GS_Vertice
        {
            get { return Ver; }
            set { Ver = value; }
        }
        public List<GraphicsPath> GS_AristaEliminada
        {
            get { return Arista_eliminar; }
            set { Arista_eliminar = value; }
        }
        public Config GS_config
        {
            get { return apariencia; }
            set { apariencia = value; }
        }
        public String GS_conjuntos
        {
            get { return conjuntos; }
            set { conjuntos = value; }
        }
        public Point GS_posActual
        {
            get { return Pos_actual; }
            set { Pos_actual = value; }
        }
        public Point GS_anterior
        {
            get { return Pos_anterior; }
            set { Pos_anterior = value; }
        }
        /******************************************CONFIGURACION  GRAFICA DE GRAFO*********************************************/
        public void actualiza_config(Config conf)
        {


            apariencia = conf;

            foreach (Vertice v in GS_Vertice)
            {
                v.GS_colorC = apariencia.GS_colorContorno;
                v.GS_colorF = apariencia.GS_colorRelleno;
                v.GS_radio = apariencia.GS_radio;
                v.GS_colorL = apariencia.GS_colorLetra;
                v.GS_letra = apariencia.GS_tipoLetra;

            }
            if (GS_Arista != null)
            {
                foreach (Arista a in GS_Arista)
                    a.GS_color = apariencia.GS_colorLinea;
            }
            //  this.BackColor = apariencia.GS_colorFondo;


            GS_config = apariencia;
        }//actualizar configuracion

        /**************************************** ALGORITMOS DE GRAFO *************************************************/
        public void Calcula_Recorrido(Boolean muestra)
        {
            conjuntos = "";
            foreach (Vertice v in GS_Vertice) { v.GS_visita = false; }
            int i = 0;
            if (GS_Vertice != null)
            {
                foreach (Vertice v in GS_Vertice)
                {
                    if (v.GS_visita == false) //el grafo no ha sido visitado?
                    {
                        recorrido_Profundidad(v, Convert.ToInt16(i));
                        conjuntos += "\n";
                        i++;

                    }

                }
                 if (muestra)
                 {
                     if (i > 1) MessageBox.Show("El grafo NO esta conectado\n EXISTEN " + i + " CONJUNTO(S)");

                     else MessageBox.Show("El grafo SI esta conectado");
                    MessageBox.Show("CONJUNTO(S)\n" + conjuntos);
                }
               
            }

        } //recorrido en profundidad y añadir conjunto a cada vertice
        private void recorrido_Profundidad(Vertice v, short n) // BPF  BUSQUEDA DE PROFUNDIDAD 
        {
            short aux = n;
            v.GS_visita = true; // marcamos el nodo como visitado
            v.GS_conjunto = aux; // pasamos a cada grafo el conjunto al que pertenece
            conjuntos += v.GS_nombre;
            if (v.GS_relacionIndirecta != null)
            {
                foreach (Vertice v1 in v.GS_relacionNodirigido)
                {
                    if (!v1.GS_visita) recorrido_Profundidad(v1, aux);

                }
            }
        }
        public void Mueve_grafo(Point pMove)
        {
            Point auxAcuatl = GS_posActual;

            auxAcuatl.X = pMove.X - auxAcuatl.X;
            auxAcuatl.Y = pMove.Y - auxAcuatl.Y;

            GS_posActual = auxAcuatl;

            if (GS_Vertice != null)
                foreach (Vertice v in GS_Vertice) v.GS_coordenadas = new Point(GS_posActual.X + v.GS_coordenadas.X, GS_posActual.Y + v.GS_coordenadas.Y);

            if (GS_Arista != null)
            {
                foreach (Arista a in GS_Arista)
                {
                    foreach (Vertice v in GS_Vertice) if (a.GS_RelacionDirecta.GS_nombre == v.GS_nombre) { a.GS_xy1 = v.GS_coordenadas; }

                    foreach (Vertice v in GS_Vertice) if (a.GS_RelacionIndirecta.GS_nombre == v.GS_nombre) { a.GS_xy2 = v.GS_coordenadas; }

                }
            }


        }//mover graf
        public void Elimina_Grafo()
        {
            apariencia = apariencia_aux;
            if (GS_Arista != null)
                GS_Arista.Clear();
            if (GS_Vertice != null)
                GS_Vertice.Clear();
            letra = 64;
            NumNodo = 0;

        }//eliminar grafo
        public Boolean colision(Vertice velimina , Vertice vnuevo,Boolean arista_dirigida)
        {
            Calcula_Recorrido(false);
            if(velimina.GS_conjunto != vnuevo.GS_conjunto)
            {
                if (velimina.GS_relacionDirecta.Count != 0 || velimina.GS_relacionIndirecta.Count != 0)
                {

                    foreach (Vertice v1 in velimina.GS_relacionDirecta)
                    {
                        Ari.Add(new Arista(vnuevo, v1, arista_dirigida));
                    }
                    foreach (Vertice v1 in velimina.GS_relacionIndirecta)
                    {
                        Ari.Add(new Arista(v1, vnuevo, arista_dirigida));
                    }
                    
                    return true;



                }// SI TIENE MAS ARISTAS

                if (velimina.GS_relacionDirecta.Count == 0 && velimina.GS_relacionIndirecta.Count == 0) // nodo abandonado 
                {
                    foreach (Vertice v in GS_Vertice)
                    {
                        if (v.GS_nombre == velimina.GS_nombre)
                        {
                            velimina.GS_coordenadas = new Point(vnuevo.GS_coordenadas.X + 70, vnuevo.GS_coordenadas.Y + 70);
                        }
                    }
                    
                    
                    Ari.Add(new Arista(vnuevo, velimina, arista_dirigida));
                    return false;
                }


            }

            return false;
            

        }
        public Boolean colisionK5(Vertice velimina, Vertice nuevo)
        {


            if (!Colorario2(false) || !Colorario1(false))
            {
                if (velimina.GS_relacionDirecta.Count != 0 || velimina.GS_relacionIndirecta.Count != 0) // si tiene aunque sea alguna arista
                {
                    
                    borrarNodo(buscaIndice(velimina.GS_coordenadas));
                    
                    return true;
                }
            }

            else
            {
                MessageBox.Show("el grafo ya es plano");
                return true;
            }
            return false;
        }
        public void complemento(Boolean dirigida)
        {
            List<String> nombres = new List<string>();
            foreach (Arista a in GS_Arista) a.GS_marca = false;
            
            
            //guarda los nombres de los nodos
            foreach (Vertice v in GS_Vertice)
                nombres.Add(v.GS_nombre);
            foreach (Vertice v in GS_Vertice)
            {
                nombres.Remove(v.GS_nombre); // remover nodo inicial
                foreach (Vertice ri in v.GS_relacionNodirigido)
                {
                    nombres.Remove(ri.GS_nombre); // remover nodos del inicial
                }
                //busca vertice del nombre
                if (nombres.Count > 0)
                {
                    foreach (Vertice nuevo in GS_Vertice)
                    {
                        for (int i = 0; i < nombres.Count; i++)
                        {
                            if (nuevo.GS_nombre == nombres[i])
                            {
                                Ari.Add(new Arista(v, nuevo, dirigida, true)); break;
                            }

                        }
                    }
                    actualizaRelacionesAristas();
                }
                
               
                nombres.Clear();
                foreach (Vertice v1 in GS_Vertice)
                    nombres.Add(v1.GS_nombre);
            }

            List<Arista> aux = new List<Arista>();
           for(int i = 0; i < Ari.Count; i++) if (Ari[i].GS_marca) aux.Add(Ari[i]);
            
            GS_Arista = aux;

        }

        public Boolean VerificaCaminoEuler()
        {
            
            if (GS_Vertice.Count > 1)
            {
                foreach (Vertice v in GS_Vertice)
                {
                    v.calculaGradosVertice_Nodirigida();
                    if (v.GS_grado % 2 != 0) { return false; }
                }
                return true;

            }
            return false;
        }

        /******************************************* COLORARIOS*******************************************************/
        public Boolean Colorario1(Boolean muestra)
        {
            int op = ((3 * GS_Vertice.Count) - 6);
            String message = "";

            if (GS_Arista.Count <= op)
            {
                if (muestra)
                {
                    message = "COLORARIO 1: GRAFO  PLANO\n" + "[" + GS_Arista.Count.ToString() + "<=" + op.ToString() + "]";
                    MessageBox.Show(message);

                }
                return true;
            }
            else
            {
                if (muestra)
                {
                    message = "COLORARIO 1: GRAFO NO PLANO\n" + "[" + GS_Arista.Count.ToString() + "<=" + op.ToString() + "]";
                    MessageBox.Show(message);
                }
                return false;
            }

        }
        public Boolean Colorario2(Boolean muestra)
        {
            int op = ((2 * GS_Vertice.Count) - 4);

            if (GS_Arista.Count <= op)
            {
                if (muestra)
                    MessageBox.Show("COLORARIO 2: GRAFO PLANO\n" + "[" + GS_Arista.Count.ToString() + "<=" + op.ToString() + "]");
                return true;
            }
            else
            {
                if (muestra)
                    MessageBox.Show("COLORARIO 2: GRAFO NO PLANO\n" + "[" + GS_Arista.Count.ToString() + "<=" + op.ToString() + "]");
                return false;
            }

        }
        public Boolean verificaCircuitos()
        {
            Boolean circuito3 = false;

            foreach (Vertice nodo_inicial in GS_Vertice)
            {
                foreach (Vertice v in nodo_inicial.GS_relacionNodirigido)
                {

                    foreach (Vertice vv in v.GS_relacionNodirigido)
                    {
                        foreach (Vertice chec in nodo_inicial.GS_relacionNodirigido)
                        {

                            if (vv.GS_nombre == chec.GS_nombre) {  circuito3 = true; }

                        }

                    }
                }

            }
            return circuito3;
        }
        /****************************************GRAFOS ESPECIALES*****************************************************/
        public void calculaKN()
        {
            int index = 0;
            foreach (Vertice v in GS_Vertice)
            {
                for (int i = index; i < GS_Vertice.Count - 1; i++) Nueva_Arista(new Arista(v, GS_Vertice[i + 1], false));

                index++;
            }

        } // dibujar grafo KN
        public void calculaWN()
        {

            foreach (Vertice v in GS_Vertice)
            {
                if (v.GS_nombre != GS_Vertice[GS_Vertice.Count - 1].GS_nombre) Nueva_Arista(new Arista(v, GS_Vertice[GS_Vertice.Count - 1], false));


            }


        } // dibujar grafo WN
        public void calculaCN()
        {

            for (int i = 0; i < GS_Vertice.Count - 1; i++) Nueva_Arista(new Arista(GS_Vertice[i], GS_Vertice[i + 1], false));

            Nueva_Arista(new Arista(GS_Vertice[GS_Vertice.Count - 1], GS_Vertice[0], false));


        } //dibujar grafo CN
        public void AlgoritmoCirculo(int nodos,String especiales,int ancho , int alto)
        {
            Elimina_Grafo();
            calculaPuntos(nodos,ancho,alto,especiales);
            switch (especiales)
            {
                case "cn":
                    calculaCN();
                    break;
                case "kn":
                    calculaKN();
                    break;
                case "wn":
                    calculaWN();
                    break;

            }
            
        } //seleccionar opcion para calcular puntos
        private void calculaPuntos(int nodos , int ancho , int alto,String especiales)
        {

            int numPuntos = nodos;
            Point c = new Point(250, 250);
            double siguiente = Math.PI * 2 / numPuntos;
            Point centro = new Point(ancho / 2, alto/ 2);
            double u = Math.PI;//+ (Math.PI * 2);
            for (int i = 0; i < numPuntos; i++, u += siguiente)
            {
                Point n = new Point((int)(centro.X + (c.X * (float)Math.Cos(u))), (int)(centro.Y + (c.Y * (float)Math.Sin(u))));
                //  dibuja.DrawLine(new Pen(Color.BlueViolet), centro.X, centro.Y, n.X, n.Y);
                GS_Vertice.Add(new Vertice(apariencia.GS_radio, n, apariencia.GS_colorRelleno, apariencia.GS_colorContorno, generaNombreVertice(), apariencia.GS_tipoLetra, apariencia.GS_colorLetra));

            }
            if (especiales == "wn")
            {
                calculaCN();
                GS_Vertice.Add(new Vertice(apariencia.GS_radio, centro, apariencia.GS_colorRelleno, apariencia.GS_colorContorno, generaNombreVertice(), apariencia.GS_tipoLetra, apariencia.GS_colorLetra));
            }
        }//calcula los puntos para los grafos
         /************************************ALGORITMOS PARA NODOS******************************************************/
        public Boolean clicNodo(Point Location)
        {
            foreach (Vertice v in GS_Vertice)
            {
                if (Location.X >= (v.GS_coordenadas.X - v.GS_radio) &&
                       Location.X <= (v.GS_coordenadas.X + v.GS_radio) &&
                       Location.Y >= (v.GS_coordenadas.Y - v.GS_radio) && Location.Y
                       <= (v.GS_coordenadas.Y + v.GS_radio))
                {
                    return true;
                }
            }
            return false;
        }// buscar si se esta daando clic en un nodo

        public int buscaIndice(Point Location)
        {

            int index = 0;
            for (; index < GS_Vertice.Count; index++)
            {
                if (Location.X >= (GS_Vertice[index].GS_coordenadas.X - GS_Vertice[index].GS_radio) &&
                   Location.X <= (GS_Vertice[index].GS_coordenadas.X + GS_Vertice[index].GS_radio) &&
                   Location.Y >= (GS_Vertice[index].GS_coordenadas.Y - GS_Vertice[index].GS_radio) && Location.Y
                   <= (GS_Vertice[index].GS_coordenadas.Y + GS_Vertice[index].GS_radio))
                {
                    break;
                }
            }

            return index;

        }//buscar el indice a mover

        public void mueveNodo(Point Location, int index)
        {
           
            GS_Vertice[index].GS_coordenadas = Location;

        } //MOVER NODO

        public void borrarNodo(int index)
        {
            List<Arista> ari = new List<Arista>();
            List<Arista> aux = new List<Arista>();
            List<Vertice> v = new List<Vertice>();
            v = GS_Vertice;
            ari = GS_Arista;
            aux = GS_Arista;
            int contador = 0;
            

            //Eliminar aristas que contengan ese nodo
            if (ari != null)
            {
               
                    for (int i = 0; i < ari.Count; i++)
                    {
                        if (ari[i].GS_RelacionDirecta.GS_nombre == v[index].GS_nombre|| ari[i].GS_RelacionIndirecta.GS_nombre == v[index].GS_nombre)
                        {
                        contador++;
                        }
                    }
                


                    for(int i = 0; i < contador; i++)
                {
                    for(int j = 0; j < ari.Count; j++)
                    if (ari[j].GS_RelacionDirecta.GS_nombre == v[index].GS_nombre || ari[j].GS_RelacionIndirecta.GS_nombre == v[index].GS_nombre)
                    {
                        aux.RemoveAt(j);
                    }
                }


                GS_Arista = aux;

            }
            //Eliminar vertice
            if (GS_Vertice != null)
            {
                v.RemoveAt(index);
                GS_Vertice = v;
            }
        }//Borrar nodo

        private String generaNombreVertice() // generar nombre
        {
            String nombre = "";
            string n = "";

            if (letra <= 90 || letra >= 97) letra++;

            if (letra > 90 && letra < 97) letra = 97;

            if (letra > 122) { letra = 65; ponNumero = true; NumNodo++; }



            nombre = Encoding.ASCII.GetString(BitConverter.GetBytes(letra));


            // eliminar /0 que nos pone el bitconverter
            for (int i = 0; i < nombre.Length; i++)
            {
                if (nombre[i] == 0) break;
                n += nombre[i].ToString();
            }

            if (ponNumero) { n += NumNodo.ToString(); }

            return (n.Trim());
        } // funcion para generar numeros o letras
        private Vertice dameNodo(int indice)
        {
            return Ver[indice];
        }
        /************************************ALGORITMOS PARA ARISTAS****************************************************/
        // CAMBIAR LA CONFIGURACION DE PEN CUANDO SE TENGA LA NUEVA PANTALLA DE CONFIGURACION
        public void eliminaArista(Point e)
        {
            List<Arista> a = new List<Arista>();
            a = GS_Arista;
            actualizaAristaEliminada();
            
            for (int j = 0; j < Arista_eliminar.Count; j++)
            {
                if (Arista_eliminar[j].IsOutlineVisible(e.X,e.Y, new Pen(Color.Black, 3)))
                {
                    a.RemoveAt(j);
                    GS_Arista = a;
                    break;
                }
            }
        }
        
        private void actualizaAristaEliminada()
        {
            Arista_eliminar.Clear();
            foreach (Arista a in GS_Arista) {

                GraphicsPath aux = new GraphicsPath();
                aux.AddLine(a.p1xy, a.p2xy);
                Arista_eliminar.Add(aux);

            }
        }

        public void actualizaRelacionesAristas()
        {
            if(GS_Arista != null)
            {
                foreach (Vertice v in GS_Vertice)
                { v.GS_relacionDirecta.Clear();
                  v.GS_relacionIndirecta.Clear();
                  v.GS_relacionNodirigido.Clear();
                }

                
                //relacion  Directa
                foreach(Vertice v in GS_Vertice)
                {
                    foreach (Arista a in GS_Arista)
                    {
                        if (a.GS_RelacionDirecta.GS_nombre == v.GS_nombre) // buscamos todos los nodos relacion A -> B
                        {
                            // aqui guardo los nodos con los que tenga relaciones directas
                            v.GS_relacionDirecta.Add(a.GS_RelacionIndirecta);

                        }

                    }//arista

                }//vertice
                 //relacion Indirecta
                foreach (Vertice v in GS_Vertice)
                {
                    foreach (Arista a in GS_Arista)
                    {
                        if (a.GS_RelacionIndirecta.GS_nombre == v.GS_nombre) // buscamos todos los nodos relacion B -> A
                        {
                            // aqui guardo los nodos con los que tenga relaciones indirectas                            
                            v.GS_relacionIndirecta.Add(a.GS_RelacionDirecta);

                        }

                    }//arista

                }//vertice
                //relaciones 
                foreach (Vertice v in GS_Vertice)
                {
                    foreach (Vertice v1 in v.GS_relacionDirecta) v.GS_relacionNodirigido.Add(v1);

                    foreach (Vertice v2 in v.GS_relacionIndirecta) v.GS_relacionNodirigido.Add(v2);

                }
            }

        }

        private void eliminaAristaEspecifica(Vertice inicio, Vertice fin)
        {

            for (int i = 0; i < GS_Arista.Count; i++)
            {
                if (GS_Arista[i].GS_RelacionDirecta.GS_nombre == inicio.GS_nombre && GS_Arista[i].GS_RelacionIndirecta.GS_nombre == fin.GS_nombre ||
                   GS_Arista[i].GS_RelacionDirecta.GS_nombre == fin.GS_nombre && GS_Arista[i].GS_RelacionIndirecta.GS_nombre == inicio.GS_nombre)
                {

                   
                    GS_Arista.RemoveAt(i);
                    break;
                }
            }
            
        }
    }
}
