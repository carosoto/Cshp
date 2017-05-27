using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Diccionario_de_datos
{
    class Arbol
    {
        private long direccion;
        private char tipo;
        private int orden;
        private long dir_siguiente;
        private List<Nodo> nodo;
        private long tamaño_hoja;
        private int cont;
        public Arbol()
        {
            cont = 0;
            direccion = -1;
            tipo = 'h';
            orden = 2;
            dir_siguiente = -1;
            nodo = new List<Nodo>();
            tamaño_hoja = 65;
            for (int i = 0; i < 4; i++) nodo.Add(new Nodo());

        }

        public Arbol(char tipo){
            direccion = -1;
            cont = 0;
            this.tipo = tipo;
            orden = 2;
            dir_siguiente = -1;
            nodo = new List<Nodo>();
            tamaño_hoja = 65;
            for (int i = 0; i < 4; i++) nodo.Add(new Nodo());
        }

        public long GS_direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public char GS_tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public int GS_orden
        {
            get { return orden; }
        }

        public long GS_dirSiguiente
        {
            get { return dir_siguiente; }
            set { dir_siguiente = value; }
        }

        public List<Nodo> GS_nodos
        {
            get { return nodo; }
        }

        public int GS_tamNodo
        {
            get { return cont; }
        }

        public int posRiazVacia()
        {
            int j = 0;
            for(;j< GS_nodos.Count; j++)
            {
                if (GS_nodos[j].GS_valor == -1) { return j; }
            }
            return -1;
        }
        
        public void ordenaRaiz( Arbol a ,long ultDir,Boolean may)
        {
            List<int> n = new List<int>();
            List<Nodo> ln = new List<Nodo>();
            Arbol aux = new Arbol();
            aux = a;
            foreach(Nodo nax in GS_nodos)
            {
                if (nax.GS_valor != -1) { n.Add(nax.GS_valor); ln.Add(nax);}
            }
            n.Sort();
            this.reiniciaNodo();
           
            for (int i = 0; i < n.Count; i++)
            {
                GS_nodos[i].GS_valor = n[i];

            }
            if (may)
            {

                for (int i = 0; i < ln.Count; i++)
                {
                    if (ln[i].GS_valor == GS_nodos[i].GS_valor)
                    {
                        if (i <= 2)
                            GS_nodos[i + 1].GS_dirSiguiente = ln[i].GS_dirDerecha;
                        //
                        else
                        {
                            GS_nodos[3].GS_dirSiguiente = GS_nodos[2].GS_dirDerecha;
                            GS_dirSiguiente = ln[i].GS_dirDerecha;
                            break;
                        }
                    }
                }
            }
           
        }


        public void ordenaRaizMen(List<Arbol> arbol, int indice, Arbol raiz)
        {

            int valor = 0;

            List<int> n = new List<int>();
            List<Nodo> ln = new List<Nodo>();
            foreach (Nodo nax in GS_nodos)
            {
                if (nax.GS_valor != -1) { n.Add(nax.GS_valor); ln.Add(nax); }
            }
            n.Sort();
            this.reiniciaNodo();

            for (int i = 0; i < n.Count; i++)
            {
                GS_nodos[i].GS_valor = n[i];

            }

            for (int i = 0; i < arbol[indice].GS_nodos.Count; i++)
            {
                if (arbol[indice].GS_nodos[i].GS_valor != -1)
                {
                    valor = arbol[indice].GS_nodos[i].GS_valor;

                    foreach (Arbol a in arbol)
                    {
                        if (a.GS_tipo != 'r')
                        {
                            foreach (Nodo n1 in a.GS_nodos)
                            {
                                if (n1.GS_valor == valor)
                                {

                                    arbol[indice].GS_nodos[i].GS_dirIzquierda = a.GS_direccion;
                                    break;


                                }

                            }
                        }


                    }

                }

            }

            for(int i = 0; i < arbol[indice].GS_nodos.Count; i++)
            {
                if(i < 3)
                GS_nodos[i+1].GS_dirSiguiente = arbol[indice].GS_nodos[i].GS_dirIzquierda;
                else
                {
                    GS_dirSiguiente = arbol[indice].GS_nodos[i].GS_dirIzquierda;
                }
            }

            
        }

       public int ordenaValores(DataGridView tabla, int filas,int pos, int valorDesbordado)
        {
            List<int> valores = new List<int>();
            foreach (Nodo n in nodo) {
                if(n.GS_valor != -1)
                valores.Add(n.GS_valor);
            }
            valores.Add(valorDesbordado);
            valores.Sort();
            nodo.Clear();
            for (int j = 0; j < 4; j++)
            {
                    for (int i = 0; i < filas ; i++)
                    {
                        if (Convert.ToInt32(tabla.Rows[i].Cells[pos].Value) == valores[j])
                        {
                            Nodo n = new Nodo();
                            n.GS_valor = valores[j];
                            n.GS_dirSiguiente = Convert.ToInt64(tabla.Rows[i].Cells[0].Value);
                            nodo.Add(n);
                            
                        }
                    }
                
            }
            return valores[4];
            
        }

        public int DameValDesRaiz(int valorDesbordado)
        {
            List<int> datos = new List<int>();
            foreach(Nodo n in GS_nodos)
            {
                datos.Add(n.GS_valor);
            }

            datos.Add(valorDesbordado);
            datos.Sort();

            return datos[4];


            

        }

        public void buscaDirMay(List<Arbol> arbol)
        {

            //primero buscar el numero mayor

            int may = 0;
            long dir = 0;
            foreach(Nodo n in GS_nodos)
            {
                if(n.GS_valor > may) { may = n.GS_valor;}
            }
            foreach(Arbol a in arbol)
            {
                if(a.GS_tipo != 'i' && a.GS_tipo != 'r')
                {
                    foreach(Nodo n in a.GS_nodos)
                    {
                        if(may == n.GS_valor)
                        {
                            dir = a.GS_direccion;
                            break;
                        }
                    }


                }
            }
            
            int pos = GS_datosPositivos();
            
            GS_nodos[pos].GS_dirSiguiente = dir;



        }

       public void reiniciaNodo()
        {
          
          for(int i = 0; i < nodo.Count; i++)
            {
                nodo[0].GS_dirSiguiente = -1;
                nodo[0].GS_valor = -1;
            }
        }

        public void AgregaValorNodo(int value,long dir , int pos)
        {
            nodo[pos].GS_dirSiguiente = dir;
            nodo[pos].GS_valor = value;

        }

       public void AgregaValorNodo(int value,long dir)
        {
            Nodo n = new Nodo();
            n.GS_valor = value;
            n.GS_dirSiguiente = dir;
            nodo.Add(n);
            ReacomodaValores();
            cont++;
       

        }

        private void ReacomodaValores()
        {
            List<Nodo> aux = new List<Nodo>();
            for (int i = 0; i < 4; i++) aux.Add(new Nodo());
            int c = 0;
            for(int i = 0; i < nodo.Count; i++)
            {
                if ( nodo[i].GS_dirSiguiente != -1) { aux[c].GS_valor = nodo[i].GS_valor; aux[c].GS_dirSiguiente = nodo[i].GS_dirSiguiente; c++; }
                
            }
            nodo.Clear();
            nodo = aux;

        }

        public void ordena(DataGridView tabla,int filas , int pos)
        {
            List<int> aux = new List<int>();
           
            foreach(Nodo n in GS_nodos)
            {
                if (n.GS_valor != -1) aux.Add(n.GS_valor);
            }
            aux.Sort();
            
            nodo.Clear();
            for (int j = 0; j < aux.Count; j++)
            {
                for (int i = 0; i < filas; i++)
                {
                    if (Convert.ToInt32(tabla.Rows[i].Cells[pos].Value) == aux[j])
                    {
                        Nodo n = new Nodo();
                        n.GS_valor = aux[j];
                        n.GS_dirSiguiente = Convert.ToInt64(tabla.Rows[i].Cells[0].Value);
                        nodo.Add(n);

                    }
                }

            }
            if (GS_datosPositivos() <= 3){
                Nodo n = new Nodo();
                nodo.Add(n);
            }



        }

        public int GS_datosPositivos()
        {
            int contador = 0;

            foreach (Nodo n in GS_nodos) {
                if (n.GS_valor != -1) contador++;

            }
            return contador;

        }

        public long GS_tamHoja
        {
            get { return tamaño_hoja; }
        }

        public void AsignaMemoria(Archivo arch)
        {
           
            long dir_inicial = 0;
            dir_inicial = arch.Tam_archivo();
            GS_direccion = dir_inicial;
            FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            BinaryWriter writer = new BinaryWriter(stream);
            stream.Seek(dir_inicial, SeekOrigin.Begin);
            writer.Write(GS_direccion);
            writer.Write(GS_tipo);
            foreach (Nodo n in GS_nodos)
            {
                writer.Write(n.GS_dirSiguiente);
                writer.Write(n.GS_valor);
            }

            writer.Write(GS_dirSiguiente);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();


        }
    }
}
