using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace EditorGrafovsV3._0.Clases
{
    [Serializable]
    public class Grafo
    {
        /***********************************VARIABLES PARA GRAFOS***************************************************/
        private List<Arista> Ari;
        private List<Vertice> Ver;
        private Configuracion configura;
        private Config apariencia, apariencia_aux;
        private String conjuntos;//variable para mostrar conjuntos


        /***************************************VARIABLES PARA LOS NODOS*********************************************/
        private int letra, NumNodo; //variables para asignarle un nombre al nodo
        private Boolean ponNumero;//variales para activar el numero en el nombre del nodo :)
        /**************************************VARIABLES PARA ARISTAS*************************************************/
        /****************************************CONSTRUCTORE*********************************************************/
        public Grafo()
        {
            apariencia = new Config();
            Ari = new List<Arista>();
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
            ponNumero = false;

        }
        /*******************************************CREACION DE ARISTAS *********************************************/

        public void Nueva_Arista(int indexPrincipal, int indexDestino, Boolean dirigida)
        {
            MessageBox.Show("nueva arista de " + Ver[indexPrincipal].GS_nombre + " a " + Ver[indexDestino].GS_nombre);
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



        /********************************************CREACION DE NODOS Y ARISTAS*************************************/

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
        public void Calcula_Recorrido()
        {

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
                /* if (muestra)
                 {
                     if (i > 1) MessageBox.Show("El grafo NO esta conectado\n EXISTEN " + i + " CONJUNTO(S)");

                     else MessageBox.Show("El grafo SI esta conectadon");
                 }*/
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
        public void Mueve_grafo(Point PmouseActual, Point Anterior)
        {


            PmouseActual.X = Anterior.X - PmouseActual.X;
            PmouseActual.Y = Anterior.Y - PmouseActual.Y;

            if (GS_Vertice != null)
                foreach (Vertice v in GS_Vertice) v.GS_coordenadas = new Point(PmouseActual.X + v.GS_coordenadas.X, PmouseActual.Y + v.GS_coordenadas.Y);

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

        }//eliminar grafo

        /******************************************* COLORARIOS*******************************************************/
        public String Colorario1()
        {
            int op = ((3 * GS_Vertice.Count) - 6);
            if (GS_Arista.Count <= op) return "COLORARIO 1: GRAFO  PLANO\n" + "[" + GS_Arista.Count.ToString() + "<=" + op.ToString() + "]";
            else return "COLORARIO 1: GRAFO NO PLANO\n" + "[" + GS_Arista.Count.ToString() + "<=" + op.ToString() + "]";
        }
        public String Colorario2()
        {
            int op = ((2 * GS_Vertice.Count) - 4);
            if (GS_Arista.Count <= op) return "COLORARIO 2: GRAFO PLANO\n" + "[" + GS_Arista.Count.ToString() + "<=" + op.ToString() + "]";
            else return "COLORARIO 2: GRAFO NO PLANO\n" + "[" + GS_Arista.Count.ToString() + "<=" + op.ToString() + "]";

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

            //Eliminar aristas que contengan ese nodo
            if (GS_Arista != null)
            {
                for (int i = 0; i < GS_Arista.Count; i++)
                {
                    if (GS_Arista[i].GS_RelacionDirecta.GS_nombre == GS_Vertice[index].GS_nombre ||
                       GS_Arista[i].GS_RelacionIndirecta.GS_nombre == GS_Vertice[index].GS_nombre)

                        GS_Vertice.RemoveAt(i);

                }
            }
            //Eliminar vertice
            if (GS_Vertice != null)
                GS_Vertice.RemoveAt(index);

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



    }
}
