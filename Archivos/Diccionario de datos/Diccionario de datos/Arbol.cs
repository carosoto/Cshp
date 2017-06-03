/*
░▐█▀▀▒▐█▀█▒▄█▀▀█░▐██▒██░░░▒▐█▀▀█▌▒██▄░▒█▌
░▐█▀▀▒▐█▄█▒▀▀█▄▄─░█▌▒██░░░▒▐█▄▒█▌▒▐█▒█▒█░
░▐█▄▄▒▐█░░▒█▄▄█▀░▐██▒██▄▄█▒▐██▄█▌▒██░▒██▌
Autor: Aarón Miranda Victorino
Proyecto : Diccionario de datos
Materia: Estructura de archivos
Correo: epsilon11101@gmail.com
Clase: Arbol
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Diccionario_de_datos
{
    //Clase Arbol
    class Arbol
    {
        //direccion inicial
        private long direccion;
        //tipo de arbol
        private char tipo;
        //orden del arbol
        private int orden;
        //apuntador a siguiente
        private long dir_siguiente;
        //lista de nodos
        private List<Nodo> nodo;
        //tamaño de hoja
        private long tamaño_hoja;
        //contador para primer nodo
        private int cont;
        //constructor 
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
        //constructor sobrecargado
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

        //metodos de acceso get set

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
            set { cont = value; }
        }

        //verifiar si la raiz no tiene datos
        public int posRiazVacia()
        {
            int j = 0;
            for(;j< GS_nodos.Count; j++)
            {
                if (GS_nodos[j].GS_valor == -1) { return j; }
            }
            return -1;
        }
        //ordena los datos de menor a mayor y cambia las direcciones 
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

        //ordena los datos de mayor a menor y cambia direcciones
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
        //ordena valores de hojas
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
        //retorna el valor de la raiz desbordada
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
        //retorna direccion mayor
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
        //reiniciar hoja
       public void reiniciaNodo()
        {
          
          for(int i = 0; i < nodo.Count; i++)
            {
                nodo[0].GS_dirSiguiente = -1;
                nodo[0].GS_valor = -1;
            }
        }
        //agrega valor a hoja
        public void AgregaValorNodo(int value,long dir , int pos)
        {
            nodo[pos].GS_dirSiguiente = dir;
            nodo[pos].GS_valor = value;

        }
        //metodo sobrecargado
       public void AgregaValorNodo(int value,long dir)
        {
            Nodo n = new Nodo();
            n.GS_valor = value;
            n.GS_dirSiguiente = dir;
            nodo.Add(n);
            ReacomodaValores();
            cont++;
       

        }

        //eliminar numeros negativos
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
        //ordena hoja
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
        //datos positivos en un nodo
        public int GS_datosPositivos()
        {
            int contador = 0;

            foreach (Nodo n in GS_nodos) {
                if (n.GS_valor != -1) contador++;

            }
            return contador;

        }
        //tamaño de hoja
        public long GS_tamHoja
        {
            get { return tamaño_hoja; }
        }
        //ordena nodo intermedio
        public void ordenaIntermedio(List<Arbol> arbol , int posIntermedio)
        {
            List<int> valores = new List<int>();
            //obtengo los valores de los nodos
          
            foreach (Nodo n in arbol[posIntermedio].GS_nodos)

            {
                if(n.GS_valor != -1)
                valores.Add(n.GS_valor);

            }
            //ordenamos los valores de los nodos 
            valores.Sort();
            nodo.Clear();
            for(int i = 0; i < 4; i++)
            {

                nodo.Add(new Nodo());
            }
            //reordenar los valores

            for(int i = 0; i < valores.Count; i++)
            {
                nodo[i].GS_valor = valores[i];
            }




            //buscar la direccion siguiente en la tabla

            for (int j = 0; j < arbol[posIntermedio].GS_nodos.Count; j++)

            {
                if (arbol[posIntermedio].GS_nodos[j].GS_valor != -1)
                {
                    for (int i = 0; i < arbol.Count; i++)
                    {

                        if (arbol[i].GS_tipo != 'r' && arbol[i].GS_tipo != 'i')
                        {

                            for (int k = 0; k < arbol[i].GS_nodos.Count; k++)
                            {
                                if (arbol[posIntermedio].GS_nodos[j].GS_valor != -1 && arbol[posIntermedio].GS_nodos[j].GS_valor == arbol[i].GS_nodos[k].GS_valor)
                                {
                                    if (j < 3)
                                    {
                                        arbol[posIntermedio].GS_nodos[j + 1].GS_dirSiguiente = arbol[i].GS_direccion;
                                        break;
                                    }
                                    else
                                    {
                                        arbol[posIntermedio].GS_nodos[j].GS_dirSiguiente = arbol[i].GS_direccion;
                                        break;
                                    }


                                }
                            }

                        }

                    }
                }
            }





        }
        //asigna memoria en archivo
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
