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



       public void reiniciaNodo()
        {
          
          for(int i = 0; i < nodo.Count; i++)
            {
                nodo[0].GS_dirSiguiente = -1;
                nodo[0].GS_valor = -1;
            }
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
