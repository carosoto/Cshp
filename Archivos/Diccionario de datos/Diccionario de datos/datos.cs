using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace Diccionario_de_datos
{
    public partial class datos : Form
    {

        private List<Entidad> ent_;
        private List<Atrib> atrib_;
        private List<String> tipo_datos;
        private Archivo arch;
        private long tamaño_dato;
        private List<String> datas;
        private List<String> datas_leidas;
        private List<datos> data;
        private Entidad entidad;
        private List<primaria> pk;
        private List<secundaria> fk;
        private List<List<primaria>> ppk;
        private List<List<secundaria>> ffk;
        private List<List<HASH_ESTATICA>> hhash;
        private List<HASH_ESTATICA> hash;
        private List<Arbol> arbol;
        private Arbol arbolAux;
        private secundaria fkaux;
        private primaria pkaux;
        private HASH_ESTATICA hashaux;
        private Atrib atributoHoja;
        private long tam_archivoI;
        private long tam_modificar;
        private long tamañoTotal;
        private Boolean modifica, elimina,hay_raiz;
        private int fila, columna;
        private Boolean hay_datos;
        int filas = 0;

        public datos(List<Entidad> ent, Archivo arch)
        {
            hay_datos = false;
            atributoHoja = new Atrib();
            ppk = new List<List<primaria>>();
            ffk = new List<List<secundaria>>();
            hhash = new List<List<HASH_ESTATICA>>();
            hash = new List<HASH_ESTATICA>();
            hashaux = new HASH_ESTATICA();
            arbol = new List<Arbol>();
            modifica = false;
            elimina = false;
            entidad = new Entidad();
            filas = 0;
            tam_modificar = 0;
            tamañoTotal = 0;
            tamaño_dato = 0;
            pkaux = new primaria();
            fkaux = new secundaria();
            InitializeComponent();
            foreach (Entidad e in ent)
            {
                comboBox1.Items.Add(new String(e.GS_NombreEntidad));

            }
            this.arch = arch;
            ent_ = new List<Entidad>();
            atrib_ = new List<Atrib>();
            ent_ = ent;
            data = new List<datos>();
            datas = new List<string>();
            tipo_datos = new List<string>();
            datas_leidas = new List<string>();
            pk = new List<primaria>();
            arbolAux = new Arbol();
            fk = new List<secundaria>();
            hay_raiz = false;
            
        }
        public datos() { }
        public void leer_atributos()
        {
            arch.GS_path = arch.GS_path;
            long cabezera = ent_[comboBox1.SelectedIndex].GS_Dir_atributos;
            Stream s = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(s);
            tipo_datos.Add("I");
            try
            {
                s.Seek(cabezera, SeekOrigin.Begin);
                while (cabezera != -1)
                {
                    tamaño_dato = 0;
                    Atrib aux = new Atrib();
                    aux.GS_nombre = r.ReadChars(30);
                    aux.GS_tipo = r.ReadChar();
                    aux.GS_longitud = r.ReadInt16();
                    aux.GS_dir_atributo = r.ReadInt64();
                    aux.GS_indice = r.ReadInt16();
                    aux.GS_dir_indice = r.ReadInt64();
                    aux.GS_dir_sig_atrib = r.ReadInt64();
                    cabezera = aux.GS_dir_sig_atrib;
                    if (aux.GS_tipo == 'I' || aux.GS_tipo == 'i') { tam_modificar += 8; tipo_datos.Add("I"); }
                    else { tam_modificar += 30; tipo_datos.Add("C"); }
                    if (cabezera != -1)
                        s.Seek(cabezera, SeekOrigin.Begin);
                    atrib_.Add(aux);


                }
                tam_modificar += 8;
                s.Close();
                s.Dispose();
                r.Close();
                r.Dispose();
                tamañoTotal = tam_modificar;
            }
            catch
            {
                s.Close();
                s.Dispose();
                r.Close();
                r.Dispose(); MessageBox.Show("NO EXISTEN DATOS PARA MOSTRAR");
            }

            tipo_datos.Add("I");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox2.Items.Clear();
            ppk.Clear();
            pk.Clear();
            fk.Clear();
            ffk.Clear();
            hash.Clear();
            hhash.Clear();
            int n;
            modifica = false;
            elimina = false;
            filas = 0;
            datas.Clear();
            atrib_.Clear();
            tipo_datos.Clear();
            tam_modificar = 0;
            leer_atributos();
            dataGridView1.Rows.Clear();
            foreach (Entidad en in ent_)
            {

                if (new String(en.GS_NombreEntidad) == comboBox1.SelectedItem.ToString()) { entidad = en; }

            }
            foreach (Atrib at in atrib_)
            {
                if (at.GS_indice != 0)
                {

                    String text = (new String(at.GS_nombre));
                    comboBox2.Items.Add(text);

                    if (at.GS_dir_indice == -1)
                    {
                        if (at.GS_indice == 1)
                        {
                            asigna_espacioLlaveprimaria(at);
                        }
                        if (at.GS_indice == 2)
                        {
                            asigna_espacioLlavesecundaria(at);
                        }
                        if (at.GS_indice == 4)
                        {

                            asigna_espacionHash(at);
                        }
                        if(at.GS_indice == 5)
                        {
                            atributoHoja = at;
                            asigna_espacioArbol(at,true,0);
                        }
                    }
                }


            }

            dataGridView1.ColumnCount = atrib_.Count + 2;
            dataGridView1.Columns[0].Name = "DIRECCION DATO";
            for (n = 0; n < atrib_.Count; n++)
            {

                dataGridView1.Columns[n + 1].Name = new String(atrib_[n].GS_nombre);

            }
            dataGridView1.Columns[n + 1].Name = "DIRECCION SIG";
            dataGridView1.RowCount = 100;
            leer_datos();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            modifica = false;
            sin_datos();
            //acomodar al momento de agregar los registros
            if (hay_raiz)
            {
                int pos = PosColumna();
                int valor = Convert.ToInt32(dataGridView1.Rows[filas - 1].Cells[pos].Value);
                pos = buscaRaiz();
                Boolean numMay = false;
                int posNodo = 0;

                int may = valor;
                int men = valor;
                int i = 0;
                for (; i < arbol[pos].GS_nodos.Count; i++)
                {
                    if (arbol[pos].GS_nodos[i].GS_valor > may)
                    {
                        may = -1;
                        break;
                    }
                  /*  if(arbol[pos].GS_nodos[i].GS_valor < men)
                    {
                        men = -1;
                    }*/


                    /*if (valor > arbol[pos].GS_nodos[i].GS_valor)
                    {
                        MessageBox.Show("el valor es mayor");
                        numMay = true;
                        posNodo = i;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("el valor es menor");
                        numMay = false;
                        posNodo = i;
                        break;
                    }*/
                }
                if(may == valor) { numMay = true; }

                // MessageBox.Show("valor del nodo = " + arbol[pos].GS_nodos[posNodo].GS_valor + " direccion del arbol " + arbol[pos].GS_direccion + " tipo de arbol " + arbol[pos].GS_tipo );
                // si el valor es mayor
                long direccion_hoja = 0;
                if (numMay)
                {
                    direccion_hoja = arbol[pos].GS_nodos[posNodo + 1].GS_dirSiguiente;
                    MessageBox.Show("ir a la izquierda a la direccion " + arbol[pos].GS_nodos[posNodo + 1].GS_dirSiguiente);


                }
                else
                {
                    direccion_hoja = arbol[pos].GS_nodos[posNodo].GS_dirSiguiente;
                    MessageBox.Show("ir a la derecha a la direccion " + arbol[pos].GS_nodos[posNodo].GS_dirSiguiente);

                }

                //buscar arbol con la direccion
                if (arbol[buscaHoja(direccion_hoja)].GS_datosPositivos() <= 3)
                {
                    arbol[buscaHoja(direccion_hoja)].AgregaValorNodo(valor, Convert.ToInt64(dataGridView1.Rows[filas - 1].Cells[0].Value));
                    arbol[buscaHoja(direccion_hoja)].ordena(dataGridView1, filas, PosColumna());
                }
                else
                {

                    MessageBox.Show("crea nueva hoja");
                    int PosC = PosColumna();
                    int valorDesbordado = arbol[buscaHoja(direccion_hoja)].ordenaValores(dataGridView1, filas, PosC, Convert.ToInt32(dataGridView1.Rows[filas - 1].Cells[PosC].Value));
                    Arbol hojaSig = new Arbol();


                    hojaSig.AsignaMemoria(arch); // siguiente hoja

                    hojaSig.AgregaValorNodo(arbol[buscaHoja(direccion_hoja)].GS_nodos[2].GS_valor, arbol[buscaHoja(direccion_hoja)].GS_nodos[2].GS_dirSiguiente);
                    hojaSig.AgregaValorNodo(arbol[buscaHoja(direccion_hoja)].GS_nodos[3].GS_valor, arbol[buscaHoja(direccion_hoja)].GS_nodos[3].GS_dirSiguiente);
                    //

                    int index = 0;
                    for (; index < filas; index++)
                    {
                        if (valorDesbordado == Convert.ToInt32(dataGridView1.Rows[index].Cells[PosC].Value)) break;

                    }

                    hojaSig.AgregaValorNodo(valorDesbordado, Convert.ToInt64(dataGridView1.Rows[index].Cells[0].Value));

                    arbol.Add(hojaSig);

                    int raizPos = buscaRaiz();
                    int posVaciaRaiz = arbol[raizPos].posRiazVacia();
                    Arbol auxA = new Arbol();
                    auxA = arbol[raizPos];
                  //  arbol[raizPos].AgregaValorNodo(arbol[buscaHoja(direccion_hoja)].GS_nodos[2].GS_valor, arbol[buscaHoja(direccion_hoja)].GS_direccion);
                    arbol[raizPos].AgregaValorNodo(arbol[buscaHoja(direccion_hoja)].GS_nodos[2].GS_valor, arbol[buscaHoja(direccion_hoja)].GS_direccion,posVaciaRaiz);
                    arbol[raizPos].ordenaRaiz(auxA,arbol);
                    if (posVaciaRaiz != -1)
                    {
                        arbol[raizPos].GS_nodos[posVaciaRaiz + 1].GS_dirSiguiente = hojaSig.GS_direccion;

                    }

                    arbol[buscaHoja(direccion_hoja)].GS_nodos[2].GS_valor = -1;
                    arbol[buscaHoja(direccion_hoja)].GS_nodos[2].GS_dirSiguiente = -1;
                    arbol[buscaHoja(direccion_hoja)].GS_nodos[3].GS_valor = -1;
                    arbol[buscaHoja(direccion_hoja)].GS_nodos[3].GS_dirSiguiente = -1;


                }
                EscribeHojaPrimeraVez();


            }
            if (!hay_raiz)
            {
                int pos = PosColumna();

                if (arbolAux.GS_tamNodo < 4)
                {
                    arbolAux.AgregaValorNodo(Convert.ToInt32(dataGridView1.Rows[filas - 1].Cells[pos].Value),
                        Convert.ToInt64(dataGridView1.Rows[filas - 1].Cells[0].Value));
                }
                else//hoja desbordada
                {
                    int valorDesbordado = arbolAux.ordenaValores(dataGridView1, filas, pos, Convert.ToInt32(dataGridView1.Rows[filas - 1].Cells[pos].Value));
                    Arbol hojaSig = new Arbol();
                    Arbol raiz = new Arbol('r');

                    arbolAux.GS_direccion = arbol[0].GS_direccion;
                    arbol[0] = arbolAux;

                    hojaSig.AsignaMemoria(arch); // siguiente hoja
                    raiz.AsignaMemoria(arch); // raiz
                                              //valores para el siguiente
                    hojaSig.AgregaValorNodo(arbol[0].GS_nodos[2].GS_valor, arbol[0].GS_nodos[2].GS_dirSiguiente);
                    hojaSig.AgregaValorNodo(arbol[0].GS_nodos[3].GS_valor, arbol[0].GS_nodos[3].GS_dirSiguiente);
                    int index = 0;
                    for (; index < filas; index++)
                    {
                        if (valorDesbordado == Convert.ToInt32(dataGridView1.Rows[index].Cells[pos].Value)) break;

                    }

                    hojaSig.AgregaValorNodo(valorDesbordado, Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value));

                    arbol.Add(hojaSig);
                    //valores para la raiz
                    raiz.AgregaValorNodo(arbol[0].GS_nodos[2].GS_valor, arbol[0].GS_direccion);
                    raiz.AgregaValorNodo(-1, hojaSig.GS_direccion);
                    arbol.Add(raiz);
                    asigna_espacioArbol(atributoHoja, false, raiz.GS_direccion);
                    arbol[0].GS_nodos[2].GS_valor = -1;
                    arbol[0].GS_nodos[2].GS_dirSiguiente = -1;
                    arbol[0].GS_nodos[3].GS_valor = -1;
                    arbol[0].GS_nodos[3].GS_dirSiguiente = -1;
                    EscribeHojaPrimeraVez();
                    hay_raiz = true;
                }
            }



        } //grabar datos

        private int buscaHoja(long direccion)
        {
            int i = 0;
            for (; i < arbol.Count; i++)
            {
                if (arbol[i].GS_tipo == 'h')
                {
                    if(arbol[i].GS_direccion == direccion)
                    break;
                }
            }
            return i;
        }
        private int buscaRaiz()
        {
            int i = 0;
           for(; i < arbol.Count; i++)
            {
                if (arbol[i].GS_tipo == 'r') break;
            }
            return i;

        }


        private void sin_datos()
        {

            datas.Clear();
            datas_leidas.Clear();
            //primero escribir la direccion inicial 
            FileStream stream;
            BinaryWriter writer;
            tam_archivoI = arch.Tam_archivo(); // tamaño inicial del archivo
            datas.Add(tam_archivoI.ToString()); // agregamos el tamaño inicial del archivo
            tamaño_dato += 8;
            stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            writer = new BinaryWriter(stream);
            stream.Seek(tam_archivoI, SeekOrigin.Begin);
            writer.Write(tam_archivoI); // escribimos tamaño inicial del archivo
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
            foreach (Atrib a in atrib_)
            {
                long ult_posicion = arch.Tam_archivo();

                if (a.GS_tipo == 'I' || a.GS_tipo == 'i')
                {
                    long num = 0;
                    String clave = Interaction.InputBox("DAME VALOR NUMERICO PARA : ->  " + new String(a.GS_nombre), "ADQUISICION DE DATOS");
                    datas.Add(clave);
                    if (clave != "")
                    {
                        num = Convert.ToInt64(clave);

                        stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                        writer = new BinaryWriter(stream);
                        stream.Seek(ult_posicion, SeekOrigin.Begin);
                        writer.Write(num);
                        writer.Close();
                        writer.Dispose();
                        stream.Close();
                        stream.Dispose();
                        tamaño_dato += 8;

                    }
                    else MessageBox.Show("NO SE PUSO NINGUN VALOR NUMERICO SE PONDRA 0 POR DEFAULT");

                }
                else
                {

                    String nombre = Interaction.InputBox("DAME VALOR PARA : ->  " + new String(a.GS_nombre), "ADQUISICION DE DATOS");

                    datas.Add(nombre);
                    stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    writer = new BinaryWriter(stream);
                    stream.Seek(ult_posicion, SeekOrigin.Begin);
                    writer.Write(convierteNombre(nombre));
                    writer.Close();
                    writer.Dispose();
                    stream.Close();
                    stream.Dispose();


                }

            }


            long ult_pos = arch.Tam_archivo();

            long ult_dir = -1;
            tamaño_dato += 8;

            stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            writer = new BinaryWriter(stream);
            stream.Seek(ult_pos, SeekOrigin.Begin);
            writer.Write(ult_dir);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
            datas.Add(ult_dir.ToString());
            if (filas <= 0)
            {
                entidad.GS_Dir_datos = tam_archivoI;
                arch.Modifica_entidad(entidad.GS_Dir_entidad, entidad);

            }
            else
            {

                long dir_principal = Convert.ToInt64(dataGridView1.Rows[filas - 1].Cells[0].Value);
                long dir_sig = tam_archivoI;

                modifica_datos(dir_principal, tam_modificar, dir_sig);
                ult_dir = dir_sig;


                dataGridView1.Rows[filas - 1].Cells[dataGridView1.ColumnCount - 1].Value = dir_sig;
            }

            Agregadatos();

            tamaño_dato = 0;

        }

        private void Agregadatos()
        {


            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Rows[filas].Cells[i].Value = datas[i];

            }

            filas++;


        }

        private char[] convierteNombre(String texto)
        {
            char[] c = new char[30];
            int k = 0;
            foreach (char p in texto)
            {
                c[k] = p;
                k++;
            }
            tamaño_dato += 30;
            return c;

        }//convertir Nombre

        private void modifica_datos(long direccion, long tamaño, long ultima_direccion)
        {
            long dir_fin = direccion + tamaño;
            FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            BinaryWriter writer = new BinaryWriter(stream);
            stream.Seek(dir_fin, SeekOrigin.Begin);
            writer.Write(ultima_direccion);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();

            //   MessageBox.Show("se escribio en la direccion " + (direccion + tamaño) + " el dato " + ultima_direccion);

        }

        private void leer_datos()
        {
            datas_leidas.Clear();
            int cantidad_filas = 0;
            int incremento = 0, cont = 0;
            arch.GS_path = arch.GS_path;
            long cabezera = ent_[comboBox1.SelectedIndex].GS_Dir_datos;
            long direction = 0;

            Stream s = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(s);

            try
            {
                s.Seek(cabezera, SeekOrigin.Begin);
                while (direction != -1)
                {


                    if (tipo_datos[incremento] == "I")
                    {
                        direction = r.ReadInt64();
                        datas_leidas.Add(direction.ToString());
                        cabezera += 8;

                    }
                    else
                    {
                        datas_leidas.Add(new String(r.ReadChars(30)));
                        cabezera += 30;
                    }
                    dataGridView1.Rows[cantidad_filas].Cells[incremento].Value = datas_leidas[cont++];
                    if (direction != -1)
                    {
                        if (incremento == tipo_datos.Count - 1)
                        {
                            cabezera = direction;
                        }
                        s.Seek(cabezera, SeekOrigin.Begin);
                        incremento++;
                    }

                    if (incremento == tipo_datos.Count) { incremento = 0; cantidad_filas++; ++filas; }



                }

                s.Close();
                s.Dispose();
                r.Close();
                r.Dispose();
            }
            catch
            {
                s.Close();
                s.Dispose();
                r.Close();
                r.Dispose();

                MessageBox.Show("NO EXISTEN DATOS PARA MOSTRAR");
            }

            if (cabezera != -1)
                filas++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (filas > 0)
            {
                modifica = false;
                elimina = true;
                MessageBox.Show("SELECCIONA LA FILA A ELIMINAR ;_; ");
            }
            else { elimina = false; modifica = false; MessageBox.Show("NO HAY DATOS POR ELIINAR >:( "); }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FileStream stream;
            BinaryWriter writer;
            long direccion_inicial = 0;
            long direccion_siguiente = 0;
            //calcular tamaño
            long tamaño_metadato = 0;
            foreach (String s in tipo_datos)
            {
                if (s == "I") tamaño_metadato += 8;
                else tamaño_metadato += 30;
            }

            if (elimina)
            {

                if (e.RowIndex == 0)
                {
                    
                    if (filas >= 0)
                        filas--;
                    if (filas <= 0)
                        entidad.GS_Dir_datos = -1;
                    else
                        entidad.GS_Dir_datos = Convert.ToInt64(dataGridView1.Rows[e.RowIndex + 1].Cells[0].Value);
                    arch.Modifica_entidad(entidad.GS_Dir_entidad, entidad);


                }

                if (e.RowIndex == filas - 1 && filas - 1 > 0)
                {
                    
                    direccion_siguiente = -1;
                    dataGridView1.Rows[e.RowIndex - 1].Cells[tipo_datos.Count - 1].Value = direccion_siguiente;
                    direccion_inicial = Convert.ToInt64(dataGridView1.Rows[e.RowIndex - 1].Cells[0].Value) + (tamaño_metadato - 8);
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    if (filas >= 0)
                        filas--;


                    stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    writer = new BinaryWriter(stream);
                    stream.Seek(direccion_inicial, SeekOrigin.Begin);
                    writer.Write(direccion_siguiente);
                    writer.Close();
                    writer.Dispose();
                    stream.Close();
                    stream.Dispose();


                }

                if (e.RowIndex != 0 && filas - 1 > 0 && e.RowIndex < filas - 1)
                {

                   
                    direccion_siguiente = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value);
                    dataGridView1.Rows[e.RowIndex - 1].Cells[dataGridView1.ColumnCount - 1].Value = direccion_siguiente;

                    if (filas >= 0)
                        filas--;


                    direccion_inicial = Convert.ToInt64(dataGridView1.Rows[e.RowIndex - 1].Cells[0].Value) + (tamaño_metadato - 8);



                    stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    writer = new BinaryWriter(stream);
                    stream.Seek(direccion_inicial, SeekOrigin.Begin);
                    writer.Write(direccion_siguiente);
                    writer.Close();
                    writer.Dispose();
                    stream.Close();
                    stream.Dispose();

                }



                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }//eliminar

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //seleccionar de clave
        {
            Atrib aux = new Atrib();
            int indice_ppk = 0, indice_pk = 0;
            int indice_ffk = 0, indice_fk = 0;
            ppk.Clear();
            pk.Clear();
            ffk.Clear();
            fk.Clear();
            foreach (Atrib a in atrib_)
            {
                if (new string(a.GS_nombre) == comboBox2.SelectedItem.ToString())
                {

                    aux = a;
                    break;
                }

            }

            long direccion_inicial = aux.GS_dir_indice;
            primaria prim = new primaria();
            if (aux.GS_indice == 1)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.ColumnCount = 4;
                dataGridView2.Columns[0].Name = "DIR";
                dataGridView2.Columns[1].Name = "DATO";
                dataGridView2.Columns[2].Name = "DIR DATO";
                dataGridView2.Columns[3].Name = "DIR SIG";

                leer_primaria();//recuperar datos
                //buscar indice 
                if (aux.GS_tipo == 'I')
                {
                    Boolean sal = false;
                    foreach (List<primaria> l in ppk)
                    {

                        foreach (primaria p in l)
                        {
                            indice_pk++;
                            if (p.GS_direccion == direccion_inicial)
                            {
                                sal = true;
                                break;
                            }
                        }
                        if (sal)
                        {

                            break;
                        }
                        else indice_ppk++;
                    }
                    int j = 0;
                    for (; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Columns[j].Name == comboBox2.SelectedItem.ToString())
                        {
                            j = dataGridView1.Columns[j].Index;
                            break;
                        }
                    }


                    long dir_fin = ppk[indice_ppk][indice_pk - 1].GS_direccion;
                    int indice = 0;
                    for (int i = 0; i < filas; i++)
                    {

                        ppk[indice_ppk][indice_pk - 1].GS_clave = Convert.ToInt64(dataGridView1.Rows[i].Cells[j].Value);
                        ppk[indice_ppk][indice_pk - 1].GS_dato = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                        FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                        BinaryWriter writer = new BinaryWriter(stream);
                        stream.Seek(dir_fin, SeekOrigin.Begin);
                        writer.Write(ppk[indice_ppk][indice_pk - 1].GS_direccion);
                        writer.Write(ppk[indice_ppk][indice_pk - 1].GS_clave);
                        writer.Write(ppk[indice_ppk][indice_pk - 1].GS_dato);
                        writer.Write(ppk[indice_ppk][indice_pk - 1].GS_apuntador);
                        dir_fin = ppk[indice_ppk][indice_pk - 1].GS_apuntador;
                        indice_pk++;
                        writer.Close();
                        writer.Dispose();
                        stream.Close();
                        stream.Dispose();
                        indice++;
                    }
                    if (indice_pk > 10) indice_pk--;
                    if (indice_ppk >= 1) indice_ppk--;
                    dir_fin = ppk[indice_ppk][indice_pk - 1].GS_apuntador;
                    for (int i = indice; i < 10; i++)
                    {
                        ppk[indice_ppk][indice].GS_clave = -1;
                        ppk[indice_ppk][indice].GS_dato = -1;
                        if (dir_fin != -1)
                        {
                            FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                            BinaryWriter writer = new BinaryWriter(stream);
                            stream.Seek(dir_fin, SeekOrigin.Begin);
                            writer.Write(ppk[indice_ppk][indice].GS_direccion);
                            writer.Write(ppk[indice_ppk][indice].GS_clave);
                            writer.Write(ppk[indice_ppk][indice].GS_dato);
                            writer.Write(ppk[indice_ppk][indice].GS_apuntador);
                            dir_fin = ppk[indice_ppk][indice].GS_apuntador;
                            indice++;
                            writer.Close();
                            writer.Dispose();
                            stream.Close();
                            stream.Dispose();
                        }

                    }
                    for (int i = 0; i < 10; i++)
                    {
                        dataGridView2.Rows.Add(pk[i].GS_direccion, pk[i].GS_clave, pk[i].GS_dato, pk[i].GS_apuntador);
                    }
                }
                else
                {
                    Boolean sal = false;
                    foreach (List<primaria> l in ppk)
                    {

                        foreach (primaria p in l)
                        {
                            indice_pk++;
                            if (p.GS_direccion == direccion_inicial)
                            {
                                sal = true;
                                break;
                            }
                        }
                        if (sal)
                        {

                            break;
                        }
                        else indice_ppk++;
                    }
                    int j = 0;
                    for (; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Columns[j].Name == comboBox2.SelectedItem.ToString())
                        {
                            j = dataGridView1.Columns[j].Index;
                            break;
                        }
                    }


                    long dir_fin = ppk[indice_ppk][indice_pk - 1].GS_direccion;
                    int indice = 0;
                    for (int i = 0; i < filas; i++)
                    {

                        ppk[indice_ppk][indice_pk - 1].GS_cadena = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        ppk[indice_ppk][indice_pk - 1].GS_dato = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                        FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                        BinaryWriter writer = new BinaryWriter(stream);
                        stream.Seek(dir_fin, SeekOrigin.Begin);
                        writer.Write(ppk[indice_ppk][indice_pk - 1].GS_direccion);
                        writer.Write(convierteNombre(ppk[indice_ppk][indice_pk - 1].GS_cadena));
                        writer.Write(ppk[indice_ppk][indice_pk - 1].GS_dato);
                        writer.Write(ppk[indice_ppk][indice_pk - 1].GS_apuntador);
                        dir_fin = ppk[indice_ppk][indice_pk - 1].GS_apuntador;
                        indice_pk++;
                        writer.Close();
                        writer.Dispose();
                        stream.Close();
                        stream.Dispose();
                        indice++;
                    }
                    if (indice_pk > 10) indice_pk--;
                    if (indice_ppk >= 1) indice_ppk--;
                    dir_fin = ppk[indice_ppk][indice_pk - 1].GS_apuntador;
                    for (int i = indice; i < 10; i++)
                    {
                        ppk[indice_ppk][indice].GS_clave = -1;
                        ppk[indice_ppk][indice].GS_cadena = "null";
                        FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                        BinaryWriter writer = new BinaryWriter(stream);
                        if (dir_fin != -1)
                        {
                            stream.Seek(dir_fin, SeekOrigin.Begin);
                            writer.Write(ppk[indice_ppk][indice].GS_direccion);
                            writer.Write(convierteNombre(ppk[indice_ppk][indice].GS_cadena));
                            writer.Write(ppk[indice_ppk][indice].GS_dato);
                            writer.Write(ppk[indice_ppk][indice].GS_apuntador);
                            dir_fin = ppk[indice_ppk][indice].GS_apuntador;

                            indice++;
                            writer.Close();
                            writer.Dispose();
                            stream.Close();
                            stream.Dispose();
                        }





                    }
                    for (int i = 0; i < 10; i++)
                    {
                        dataGridView2.Rows.Add(pk[i].GS_direccion, pk[i].GS_cadena, pk[i].GS_dato, pk[i].GS_apuntador);
                    }
                }
            }

            if (aux.GS_indice == 2)
            {

                dataGridView2.Rows.Clear();
                dataGridView2.ColumnCount = 8;
                dataGridView2.Columns[0].Name = "DIR";
                dataGridView2.Columns[1].Name = "DATO";
                dataGridView2.Columns[2].Name = "DIR 1";
                dataGridView2.Columns[3].Name = "DIR 2";
                dataGridView2.Columns[4].Name = "DIR 3";
                dataGridView2.Columns[5].Name = "DIR 4";
                dataGridView2.Columns[6].Name = "DIR 5";
                dataGridView2.Columns[7].Name = "DIR SIG";
                leer_secundaria();
                if (aux.GS_tipo == 'I')
                {
                    Boolean sal = false;
                    foreach (List<secundaria> l in ffk)
                    {

                        foreach (secundaria p in l)
                        {
                            indice_fk++;
                            if (p.GS_direccion == direccion_inicial)
                            {
                                sal = true;
                                break;
                            }
                        }
                        if (sal)
                        {

                            break;
                        }
                        else indice_ffk++;
                    }
                    int j = 0;
                    for (; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Columns[j].Name == comboBox2.SelectedItem.ToString())
                        {
                            j = dataGridView1.Columns[j].Index;
                            break;
                        }
                    }

                    List<long> datos = new List<long>();
                    for (int ind = 0; ind < filas; ind++) datos.Add(Convert.ToInt64(dataGridView1.Rows[ind].Cells[j].Value));
                    datos.Sort();

                    List<long> datos_sinR = datos.Distinct().ToList();
                    datos_sinR.Sort();
                    if (indice_fk > 10) indice_fk--;
                    if (indice_ffk >= 1) indice_ffk--;
                    foreach (long d in datos_sinR)
                    {
                        List<long> dir = new List<long>();
                        for (int i = 0; i < filas; i++)
                        {
                            if (Convert.ToInt64(dataGridView1.Rows[i].Cells[j].Value) == d)
                            {

                                dir.Add(Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value));
                            }

                        }
                        dir.Sort();
                        long[] di = new long[5];
                        int inx = 0;
                        for (; inx < dir.Count; inx++)
                        {
                            di[inx] = dir[inx];
                        }
                        for (int i = inx; i < 5; i++)
                        {
                            di[i] = -1;
                        }
                        if (indice_fk - 1 != -1)
                            ffk[indice_ffk][indice_fk - 1].GS_direcciones = di;
                        else
                        {
                            ffk[indice_ffk][0].GS_direcciones = di;
                        }
                        ffk[indice_ffk][indice_fk - 1].GS_direcciones = di;
                        ffk[indice_ffk][indice_fk - 1].GS_valor = d;
                        dataGridView2.Rows.Add(ffk[indice_ffk][indice_fk - 1].GS_direccion, ffk[indice_ffk][indice_fk - 1].GS_valor,
                             ffk[indice_ffk][indice_fk - 1].GS_direcciones[0], ffk[indice_ffk][indice_fk - 1].GS_direcciones[1],
                             ffk[indice_ffk][indice_fk - 1].GS_direcciones[2], ffk[indice_ffk][indice_fk - 1].GS_direcciones[3],
                             ffk[indice_ffk][indice_fk - 1].GS_direcciones[4], ffk[indice_ffk][indice_fk - 1].GS_direccionSiguiente);
                        long dir_fin = ffk[indice_ffk][indice_fk - 1].GS_direccion;
                        FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                        BinaryWriter writer = new BinaryWriter(stream);
                        stream.Seek(dir_fin, SeekOrigin.Begin);
                        writer.Write(ffk[indice_ffk][indice_fk - 1].GS_direccion);
                        writer.Write(ffk[indice_ffk][indice_fk - 1].GS_valor);
                        for (int i = 0; i < 5; i++)
                        {
                            writer.Write(ffk[indice_ffk][indice_fk - 1].GS_direcciones[i]);
                        }
                        writer.Write(ffk[indice_ffk][indice_fk - 1].GS_direccionSiguiente);
                        indice_fk++;

                        writer.Close();
                        writer.Dispose();
                        stream.Close();
                        stream.Dispose();

                    }

                }
                else
                {

                    Boolean sal = false;
                    foreach (List<secundaria> l in ffk)
                    {

                        foreach (secundaria p in l)
                        {
                            indice_fk++;
                            if (p.GS_direccion == direccion_inicial)
                            {
                                sal = true;
                                break;
                            }
                        }
                        if (sal)
                        {

                            break;
                        }
                        else indice_ffk++;
                    }
                    int j = 0;
                    for (; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Columns[j].Name == comboBox2.SelectedItem.ToString())
                        {
                            j = dataGridView1.Columns[j].Index;
                            break;
                        }
                    }


                    List<string> datos = new List<string>();
                    for (int ind = 0; ind < filas; ind++) datos.Add(dataGridView1.Rows[ind].Cells[j].Value.ToString());
                    datos.Sort();

                    List<string> datos_sinR = datos.Distinct().ToList();
                    datos_sinR.Sort();
                    if (indice_fk > 10) indice_fk--;
                    if (indice_ffk >= 1) indice_ffk--;
                    foreach (string d in datos_sinR)
                    {
                        List<long> dir = new List<long>();
                        for (int i = 0; i < filas; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString() == d)
                            {

                                dir.Add(Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value));
                            }

                        }
                        dir.Sort();
                        long[] di = new long[5];
                        int inx = 0;
                        for (; inx < dir.Count; inx++)
                        {
                            di[inx] = dir[inx];
                        }
                        for (int i = inx; i < 5; i++)
                        {
                            di[i] = -1;
                        }

                        if (indice_fk - 1 != -1)
                            ffk[indice_ffk][indice_fk - 1].GS_direcciones = di;
                        else
                        {
                            ffk[0][0].GS_direcciones = di;
                        }
                        ffk[indice_ffk][indice_fk - 1].GS_cadena = d;
                        dataGridView2.Rows.Add(ffk[indice_ffk][indice_fk - 1].GS_direccion, ffk[indice_ffk][indice_fk - 1].GS_cadena,
                             ffk[indice_ffk][indice_fk - 1].GS_direcciones[0], ffk[indice_ffk][indice_fk - 1].GS_direcciones[1],
                             ffk[indice_ffk][indice_fk - 1].GS_direcciones[2], ffk[indice_ffk][indice_fk - 1].GS_direcciones[3],
                             ffk[indice_ffk][indice_fk - 1].GS_direcciones[4], ffk[indice_ffk][indice_fk - 1].GS_direccionSiguiente);
                        long dir_fin = ffk[indice_ffk][indice_fk - 1].GS_direccion;
                        FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                        BinaryWriter writer = new BinaryWriter(stream);
                        stream.Seek(dir_fin, SeekOrigin.Begin);
                        writer.Write(ffk[indice_ffk][indice_fk - 1].GS_direccion);
                        writer.Write(convierteNombre(ffk[indice_ffk][indice_fk - 1].GS_cadena));
                        for (int i = 0; i < 5; i++)
                        {
                            writer.Write(ffk[indice_ffk][indice_fk - 1].GS_direcciones[i]);
                        }
                        writer.Write(ffk[indice_ffk][indice_fk - 1].GS_direccionSiguiente);
                        indice_fk++;
                        writer.Close();
                        writer.Dispose();
                        stream.Close();
                        stream.Dispose();

                    }
                }
            }

            if (aux.GS_indice == 3)
            {
                tamañoTotal += 8;
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();
                dataGridView2.ColumnCount = dataGridView1.ColumnCount;
                dataGridView2.RowCount = filas;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView2.Columns[i].Name = dataGridView1.Columns[i].Name;
                }

                int j = 0;
                for (; j < dataGridView2.ColumnCount; j++)
                {
                    if (dataGridView2.Columns[j].Name == comboBox2.SelectedItem.ToString())
                    {
                        j = dataGridView2.Columns[j].Index;
                        break;
                    }
                }
                if (aux.GS_tipo == 'C')
                {
                    List<String> value = new List<string>();
                    List<String> dir = new List<string>();
                    for (int i = 0; i < filas; i++)
                    {
                        for (int k = 0; k < dataGridView1.ColumnCount; k++)
                            dataGridView2.Rows[i].Cells[k].Value = dataGridView1.Rows[i].Cells[k].Value.ToString().Trim('\0');
                        value.Add(dataGridView1.Rows[i].Cells[j].Value.ToString().Trim('\0'));

                    }
                    value.Sort();
                    for (int i = 0; i < filas; i++)
                    {
                        for (int k = 0; k < filas; k++)
                        {
                            if (dataGridView1.Rows[k].Cells[j].Value.ToString().Trim('\0') == value[i])
                            {
                                dir.Add(dataGridView1.Rows[k].Cells[0].Value.ToString().Trim('\0'));
                            }
                        }
                    }
                    for (int i = 0; i < filas; i++)
                    {
                        //dataGridView2.Rows[i].Cells[dataGridView2.ColumnCount - 1].Value = 0;
                        dataGridView2.Rows[i].Cells[j].Value = value[i];
                        dataGridView2.Rows[i].Cells[0].Value = dir[i];
                    }


                    for (int i = 0; i < filas; i++)
                    {
                        if (i < filas - 1)
                            dataGridView2.Rows[i].Cells[dataGridView2.ColumnCount - 1].Value = dataGridView2.Rows[i + 1].Cells[0].Value;
                        else
                            dataGridView2.Rows[i].Cells[dataGridView2.ColumnCount - 1].Value = -1;
                    }

                }
                else
                {
                    List<long> value = new List<long>();

                    List<String> dir = new List<string>();
                    
                    for (int i = 0; i < filas; i++)
                    {
                        for (int k = 0; k < dataGridView1.ColumnCount; k++)
                            dataGridView2.Rows[i].Cells[k].Value = dataGridView1.Rows[i].Cells[k].Value.ToString().Trim('\0');
                        value.Add(Convert.ToInt64( dataGridView1.Rows[i].Cells[j].Value.ToString().Trim('\0')));

                    }
                    value.Sort();
                    for (int i = 0; i < filas; i++)
                    {
                        for (int k = 0; k < filas; k++)
                        {
                            if (Convert.ToInt64( dataGridView1.Rows[k].Cells[j].Value.ToString().Trim('\0')) == value[i])
                            {
                                dir.Add(dataGridView1.Rows[k].Cells[0].Value.ToString().Trim('\0'));
                            }
                        }
                    }
                    for (int i = 0; i < filas; i++)
                    {
                       
                        dataGridView2.Rows[i].Cells[j].Value = value[i];
                        dataGridView2.Rows[i].Cells[0].Value = dir[i];
                        
                    }
                    for(int i = 0; i < filas; i++)
                    {
                        if (i < filas - 1)
                            dataGridView2.Rows[i].Cells[dataGridView2.ColumnCount - 1].Value = dataGridView2.Rows[i + 1].Cells[0].Value;
                        else
                            dataGridView2.Rows[i].Cells[dataGridView2.ColumnCount - 1].Value = -1;
                    }
                }
                  con_datos(Convert.ToInt64(dataGridView2.Rows[0].Cells[0].Value));

                //  dataGridView2.Sort(dataGridView2.Columns[j],ListSortDirection.Ascending);


            }

            if(aux.GS_indice == 5)
            {
              

                dataGridView2.Rows.Clear();
                dataGridView2.ColumnCount = 11;
                dataGridView2.Columns[0].Name = "DIR";
                dataGridView2.Columns[1].Name = "TIPO";
                dataGridView2.Columns[2].Name = "AP";
                dataGridView2.Columns[3].Name = "VAL";
                dataGridView2.Columns[4].Name = "AP";
                dataGridView2.Columns[5].Name = "VAL";
                dataGridView2.Columns[6].Name = "AP";
                dataGridView2.Columns[7].Name = "VAL";
                dataGridView2.Columns[8].Name = "AP";
                dataGridView2.Columns[9].Name = "VAL";
                dataGridView2.Columns[10].Name = "DIR SIG";
             //   leerRaiz();
                foreach(Arbol a in arbol)
                {
                    dataGridView2.Rows.Add(a.GS_direccion,a.GS_tipo,a.GS_nodos[0].GS_dirSiguiente,a.GS_nodos[0].GS_valor,
                    a.GS_nodos[1].GS_dirSiguiente, a.GS_nodos[1].GS_valor, a.GS_nodos[2].GS_dirSiguiente, a.GS_nodos[2].GS_valor,
                    a.GS_nodos[3].GS_dirSiguiente, a.GS_nodos[3].GS_valor,a.GS_dirSiguiente);
                }

                //EscribeHojaPrimeraVez();
            }

        }

        private void asigna_espacioLlavesecundaria(Atrib at)
        {
            ffk.Clear();
            fk.Clear();
            long tam = 0;
            long dir_inicial = 0;
            long[] direcciones = new long[5];
            dir_inicial = arch.Tam_archivo();

            if (at.GS_indice == 2)
            {
               
                Atrib aux = new Atrib();
                aux = at;
                aux.GS_dir_indice = dir_inicial;
                arch.Modifica_atributo(aux.GS_dir_atributo, aux);
                if (at.GS_tipo == 'I' || at.GS_tipo == 'i')
                {
                    for (int i = 0; i < 10; i++)
                    {
                        fk.Add(new secundaria());
                        fk[i].GS_direccion = dir_inicial + tam;
                        tam = 64;
                        if (i < 9)
                            fk[i].GS_direccionSiguiente = fk[i].GS_direccion + tam;
                        else
                            fk[i].GS_direccionSiguiente = -1;
                        fk[i].GS_valor = -1;

                        for (int j = 0; j < 5; j++)
                        {
                            direcciones[j] = -1;
                        }
                        fk[i].GS_direcciones = direcciones;
                        dir_inicial = fk[i].GS_direccion;
                        FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                        BinaryWriter writer = new BinaryWriter(stream);
                        stream.Seek(fk[i].GS_direccion, SeekOrigin.Begin);
                        writer.Write(fk[i].GS_direccion);
                        writer.Write(fk[i].GS_valor);
                        for (int k = 0; k < 5; k++)
                        {
                            writer.Write(fk[i].GS_direcciones[k]);
                        }
                        writer.Write(fk[i].GS_direccionSiguiente);
                        writer.Close();
                        writer.Dispose();
                        stream.Close();
                        stream.Dispose();


                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        fk.Add(new secundaria());
                        fk[i].GS_direccion = dir_inicial + tam;


                        tam = 86;
                        if (i < 9)
                            fk[i].GS_direccionSiguiente = fk[i].GS_direccion + tam;

                        else
                            fk[i].GS_direccionSiguiente = -1;

                        fk[i].GS_cadena = "null";

                        for (int j = 0; j < 5; j++)
                        {
                            direcciones[j] = -1;
                        }
                        fk[i].GS_direcciones = direcciones;
                        dir_inicial = fk[i].GS_direccion;
                        FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                        BinaryWriter writer = new BinaryWriter(stream);

                        stream.Seek(fk[i].GS_direccion, SeekOrigin.Begin);
                        writer.Write(fk[i].GS_direccion);
                        writer.Write(convierteNombre(fk[i].GS_cadena));
                        for (int k = 0; k < 5; k++)
                        {
                            writer.Write(fk[i].GS_direcciones[k]);
                        }
                        writer.Write(fk[i].GS_direccionSiguiente);
                        writer.Close();
                        writer.Dispose();
                        stream.Close();
                        stream.Dispose();


                    }
                }

                ffk.Add(fk);
                fk.Clear();

            }
        }

        private void asigna_espacioLlaveprimaria(Atrib at)
        {
            ppk.Clear();
            pk.Clear();
            long tam = 0;
            long dir_inicial = 0;
            dir_inicial = arch.Tam_archivo();
            //para clave primaria




            if (at.GS_indice == 1)
            {
              

                Atrib aux = new Atrib();
                aux = at;
                aux.GS_dir_indice = dir_inicial;
                long new_dir = aux.GS_dir_atributo;
                arch.Modifica_atributo(new_dir, aux);
                if (at.GS_tipo == 'I' || at.GS_tipo == 'i')
                {
                    for (int i = 0; i < 10; i++)
                    {
                        pk.Add(new primaria());
                        pk[i].GS_direccion = dir_inicial + tam;
                        tam = 32;
                        pk[i].GS_tipo = "I";
                        if (i < 9)
                            pk[i].GS_apuntador = pk[i].GS_direccion + tam;
                        else
                            pk[i].GS_apuntador = -1;
                        dir_inicial = pk[i].GS_direccion;
                        pk[i].GS_clave = -1;
                        pk[i].GS_dato = -1;
                        //  

                        FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                        BinaryWriter writer = new BinaryWriter(stream);
                        stream.Seek(pk[i].GS_direccion, SeekOrigin.Begin);
                        writer.Write(pk[i].GS_direccion);
                        writer.Write(pk[i].GS_clave);
                        writer.Write(pk[i].GS_dato);
                        writer.Write(pk[i].GS_apuntador);
                        writer.Close();
                        writer.Dispose();
                        stream.Close();
                        stream.Dispose();

                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        pk.Add(new primaria());
                        pk[i].GS_direccion = dir_inicial + tam;
                        tam = 54;
                        pk[i].GS_tipo = "C";
                        if (i < 9)
                            pk[i].GS_apuntador = pk[i].GS_direccion + tam;
                        else
                            pk[i].GS_apuntador = -1;
                        dir_inicial = pk[i].GS_direccion;
                        pk[i].GS_cadena = "null";
                        pk[i].GS_dato = -1;
                        FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                        BinaryWriter writer = new BinaryWriter(stream);
                        stream.Seek(pk[i].GS_direccion, SeekOrigin.Begin);
                        writer.Write(pk[i].GS_direccion);
                        writer.Write(convierteNombre(pk[i].GS_cadena));
                        writer.Write(pk[i].GS_dato);
                        writer.Write(pk[i].GS_apuntador);
                        writer.Close();
                        writer.Dispose();
                        stream.Close();
                        stream.Dispose();

                    }

                }

                ppk.Add(pk);
                pk.Clear();



            }


        }

        private void asigna_espacionHash(Atrib at)
        {
            hhash.Clear();
            hash.Clear();
            long tam = 0;
            long dir_inicial = 0;
            dir_inicial = arch.Tam_archivo();
            if (at.GS_indice == 4)
            {
                Atrib aux = new Atrib();
                aux = at;
                aux.GS_dir_indice = dir_inicial;
                long new_dir = aux.GS_dir_atributo;
                arch.Modifica_atributo(new_dir, aux);
                if (at.GS_tipo == 'I')
                {

                    long[] casillas = new long[3];
                    //primero rellenar las casillas
                    for (int i = 0; i < 3; i++)
                    {
                        HASH_ESTATICA Haux = new HASH_ESTATICA();
                        Haux.GS_direccion_inicial = dir_inicial + tam;
                        tam += 24;
                        if (i == 0)
                            Haux.GS_casillas_direccionesCubeta[i] = dir_inicial + tam;
                        else
                            Haux.GS_casillas_direccionesCubeta[i] = -1;
                        Haux.GS_direccion_siguiente = dir_inicial + tam;
                        hash.Add(Haux);

                    }

                    long[][] cubeta = new long[3][];
                    // despues de rellenar las casillas crear solo el 1er cajon y rellenarlo
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {

                        }
                    }


                }

            }
        }

        private void asigna_espacioArbol(Atrib at,Boolean change,long dir)
        {
            Atrib aux = new Atrib();
            Arbol a = new Arbol();
            aux = at;
            if (change)
            {
                a.AsignaMemoria(arch);
                aux.GS_dir_indice = a.GS_direccion;
            }
            else
            {
                aux.GS_dir_indice = dir;
            }

            long new_dir = aux.GS_dir_atributo;
            arch.Modifica_atributo(new_dir, aux);
            if(change)
            arbol.Add(a);
        }

        private void leer_secundaria()
        {
            Atrib aux = new Atrib();
            fk.Clear();
            ffk.Clear();
            foreach (Atrib a in atrib_)
            {
                if (new string(a.GS_nombre) == comboBox2.SelectedItem.ToString())
                {
                    aux = a;
                    break;
                }

            }
            long direccion_inicial = aux.GS_dir_indice;
            if (aux.GS_tipo == 'I')
            {
                Stream s = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(s);
                while (direccion_inicial != -1)
                {

                    secundaria se = new secundaria();
                    s.Seek(direccion_inicial, SeekOrigin.Begin);

                    se.GS_direccion = r.ReadInt64();
                    se.GS_valor = r.ReadInt64();
                    long[] dir = new long[5];
                    for (int k = 0; k < 5; k++)
                    {
                        dir[k] = r.ReadInt64();
                    }
                    se.GS_direcciones = dir;
                    se.GS_direccionSiguiente = r.ReadInt64();
                    direccion_inicial = se.GS_direccionSiguiente;
                    fk.Add(se);
                }
                s.Close();
                r.Close();
                s.Dispose();
                r.Dispose();
                ffk.Add(fk);
            }
            else
            {
                Stream s = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(s);
                while (direccion_inicial != -1)
                {

                    secundaria se = new secundaria();
                    s.Seek(direccion_inicial, SeekOrigin.Begin);

                    se.GS_direccion = r.ReadInt64();
                    se.GS_cadena = new String(r.ReadChars(30));
                    long[] dir = new long[5];
                    for (int k = 0; k < 5; k++)
                    {
                        dir[k] = r.ReadInt64();
                    }
                    se.GS_direcciones = dir;
                    se.GS_direccionSiguiente = r.ReadInt64();
                    direccion_inicial = se.GS_direccionSiguiente;
                    fk.Add(se);
                }
                s.Close();
                r.Close();
                s.Dispose();
                r.Dispose();
                ffk.Add(fk);

            }
        }

        private void leer_primaria()
        {


            Atrib aux = new Atrib();
            pk.Clear();
            foreach (Atrib a in atrib_)
            {
                if (new string(a.GS_nombre) == comboBox2.SelectedItem.ToString())
                {

                    aux = a;
                    break;
                }

            }

            long direccion_inicial = aux.GS_dir_indice;

            if (aux.GS_tipo == 'I')
            {
                Stream s = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(s);
                while (direccion_inicial != -1)
                {

                    primaria p = new primaria();
                    s.Seek(direccion_inicial, SeekOrigin.Begin);
                    p.GS_direccion = r.ReadInt64();
                    p.GS_clave = r.ReadInt64();
                    p.GS_dato = r.ReadInt64();
                    p.GS_apuntador = r.ReadInt64();
                    direccion_inicial = p.GS_apuntador;

                    pk.Add(p);
                }
                s.Close();
                r.Close();
                s.Dispose();
                r.Dispose();
                ppk.Add(pk);
            }
            else
            {
                Stream s = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(s);
                while (direccion_inicial != -1)
                {

                    primaria p = new primaria();
                    s.Seek(direccion_inicial, SeekOrigin.Begin);
                    p.GS_direccion = r.ReadInt64();
                    p.GS_cadena = new String(r.ReadChars(30));
                    p.GS_dato = r.ReadInt64();
                    p.GS_apuntador = r.ReadInt64();
                    direccion_inicial = p.GS_apuntador;

                    pk.Add(p);
                }
                s.Close();
                r.Close();
                s.Dispose();
                r.Dispose();
                ppk.Add(pk);
            }



        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (modifica)
            {
                fila = e.RowIndex;
                columna = e.ColumnIndex;
                long nuevo = 0;
                string nuevo_dato = "";
                int i = 0;
                long dir = Convert.ToInt64(dataGridView1.Rows[fila].Cells[0].Value);
                long tam = 0;

                for (; i < columna; i++) ;

                if (tipo_datos[i] == "I") nuevo = Convert.ToInt64(dataGridView1.Rows[fila].Cells[columna].Value);
                else nuevo_dato = dataGridView1.Rows[fila].Cells[columna].Value.ToString();


                for (int j = 0; j < i; j++)
                {
                    if (tipo_datos[j] == "I") tam += 8;
                    else tam += 30;
                }


                long dir_fin = dir + tam;
                FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                BinaryWriter writer = new BinaryWriter(stream);
                stream.Seek(dir_fin, SeekOrigin.Begin);
                if (tipo_datos[i] == "I")
                    writer.Write(nuevo);
                else
                    writer.Write(convierteNombre(nuevo_dato));
                writer.Close();
                writer.Dispose();
                stream.Close();
                stream.Dispose();


            }

        }//modificar 

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SELECCIONE LA CELDA QUE DESEA MODIFICAR ;)");
            modifica = true;
            elimina = false;
        }
       
        private void con_datos(long primera_dir)
        {
            Entidad aux = new Entidad();
            aux = entidad;
            long d = aux.GS_Dir_entidad;
            aux.GS_Dir_datos = primera_dir;
            arch.Modifica_entidad(d,aux);
            
            int i = 0;
            Boolean activa = false;
            long dir = Convert.ToInt64(dataGridView2.Rows[0].Cells[i].Value);
            for (int j = 0; j < filas; j++)
            {
                i = 0;
               
                activa = true;
                for (; i < dataGridView1.ColumnCount; i++)
                {
                    FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    BinaryWriter writer = new BinaryWriter(stream);
                    stream.Seek(dir, SeekOrigin.Begin);
                    if (i == 0)
                    {
                        writer.Write(Convert.ToInt64(dataGridView2.Rows[j].Cells[i].Value));
                        dir += 8;

                    }
                    if (activa)
                    {
                        for (int k = 1; k < dataGridView2.ColumnCount - 1; k++)
                        {
                            if (atrib_[k - 1].GS_tipo == 'I')
                            {
                                writer.Write(Convert.ToInt64(dataGridView2.Rows[j].Cells[k].Value));
                                dir += 8;
                            }
                            else
                            {
                                writer.Write(convierteNombre(dataGridView2.Rows[j].Cells[k].Value.ToString()));
                                dir += 30;
                            }

                        }
                        activa = false;
                    }
                    if (i == dataGridView2.ColumnCount - 1)
                    {
                        writer.Write(Convert.ToInt64(dataGridView2.Rows[j].Cells[i].Value));
                        dir = Convert.ToInt64(dataGridView2.Rows[j].Cells[i].Value);
                    }
                    writer.Close();
                    writer.Dispose();
                    stream.Close();
                    stream.Dispose();
                }
            }

        }

        private void leerRaiz()
        {
            Atrib aux = new Atrib();
            arbol.Clear();
            foreach (Atrib aa in atrib_)
            {
                if (new string(aa.GS_nombre) == comboBox2.SelectedItem.ToString())
                {
                    aux = aa;
                    break;
                }

            }
            long direccion_inicial = aux.GS_dir_indice;
            
                Stream s = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(s);
                Arbol a = new Arbol();
                s.Seek(direccion_inicial, SeekOrigin.Begin);
                a.GS_direccion = r.ReadInt64();
                a.GS_tipo = r.ReadChar();
                a.GS_nodos[0].GS_dirSiguiente = r.ReadInt64();
                a.GS_nodos[0].GS_valor = r.ReadInt32();
                a.GS_nodos[1].GS_dirSiguiente = r.ReadInt64();
                a.GS_nodos[1].GS_valor = r.ReadInt32();
                a.GS_nodos[2].GS_dirSiguiente = r.ReadInt64();
                a.GS_nodos[2].GS_valor = r.ReadInt32();
                a.GS_nodos[3].GS_dirSiguiente = r.ReadInt64();
                a.GS_nodos[3].GS_valor = r.ReadInt32();
                a.GS_dirSiguiente = r.ReadInt64();
                s.Close();
                r.Close();
                s.Dispose();
                r.Dispose();
                arbol.Add(a);

                for(int i = 0; i < 4; i++)
                    {
                if(a.GS_nodos[i].GS_dirSiguiente != -1)
                {
                    leerHoja(a.GS_nodos[i].GS_dirSiguiente);
                }
                    }
                
                hay_raiz = true;

            }

        private void leerHoja(long dir)
        {

            Stream s = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(s);
            Arbol a = new Arbol();
            s.Seek(dir, SeekOrigin.Begin);
            a.GS_direccion = r.ReadInt64();
            a.GS_tipo = r.ReadChar();
            a.GS_nodos[0].GS_dirSiguiente = r.ReadInt64();
            a.GS_nodos[0].GS_valor = r.ReadInt32();
            a.GS_nodos[1].GS_dirSiguiente = r.ReadInt64();
            a.GS_nodos[1].GS_valor = r.ReadInt32();
            a.GS_nodos[2].GS_dirSiguiente = r.ReadInt64();
            a.GS_nodos[2].GS_valor = r.ReadInt32();
            a.GS_nodos[3].GS_dirSiguiente = r.ReadInt64();
            a.GS_nodos[3].GS_valor = r.ReadInt32();
            a.GS_dirSiguiente = r.ReadInt64();
            s.Close();
            r.Close();
            s.Dispose();
            r.Dispose();
            arbol.Add(a);
            hay_raiz = true;
            
        }
        

        private void EscribirHoja()
        {
            long dir = 0;
            for(int i = 0; i < dataGridView2.RowCount-1; i++)
            {
                
                dir = Convert.ToInt64(dataGridView2.Rows[i].Cells[0].Value);
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    
                    
                    FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    BinaryWriter writer = new BinaryWriter(stream);
                    stream.Seek(dir, SeekOrigin.Begin);
                    if (dataGridView2.Columns[j].Name == "DIR" || dataGridView2.Columns[j].Name == "AP" || dataGridView2.Columns[j].Name == "DIRS")
                    {
                        writer.Write(Convert.ToInt64(dataGridView2.Rows[i].Cells[j].Value));
                        dir += 8;
                    }
                    if (dataGridView2.Columns[j].Name == "TIPO")
                    {
                        writer.Write(Convert.ToChar(dataGridView2.Rows[i].Cells[j].Value));
                        dir += 1;

                    }
                    if(dataGridView2.Columns[j].Name == "VAL")
                    {
                        writer.Write(Convert.ToInt32(dataGridView2.Rows[i].Cells[j].Value));
                        dir += 4;
                    }
                   
                    writer.Close();
                    writer.Dispose();
                    stream.Close();
                    stream.Dispose();

                }
                dir = 0;
            }

        }

        private void EscribeHojaPrimeraVez()
        {
            foreach (Arbol a in arbol)
            {
                long dir = a.GS_direccion;
                FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                BinaryWriter writer = new BinaryWriter(stream);
                stream.Seek(dir, SeekOrigin.Begin);
                writer.Write(a.GS_direccion);
                writer.Write(a.GS_tipo);
                for (int i = 0; i < 4; i++)
                {
                    writer.Write(a.GS_nodos[i].GS_dirSiguiente);
                    writer.Write(a.GS_nodos[i].GS_valor);
                }
                writer.Write(a.GS_dirSiguiente);
                writer.Close();
                writer.Dispose();
                stream.Close();
                stream.Dispose();

            }
        }

        private int PosColumna()
        {
            int j = 0;
            String nombre = "";
            foreach (Atrib a in atrib_)
            {
                if (a.GS_indice == 5)
                {
                    nombre = new string(a.GS_nombre);
                    break;
                }

            }

            for (; j < dataGridView1.ColumnCount; j++)
            {
                if (dataGridView1.Columns[j].Name == nombre)
                {
                    j = dataGridView1.Columns[j].Index;
                    break;
                }
            }
            return j;
        }
       
    }
}
