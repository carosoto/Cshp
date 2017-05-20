
/*
░▐█▀▀▒▐█▀█▒▄█▀▀█░▐██▒██░░░▒▐█▀▀█▌▒██▄░▒█▌
░▐█▀▀▒▐█▄█▒▀▀█▄▄─░█▌▒██░░░▒▐█▄▒█▌▒▐█▒█▒█░
░▐█▄▄▒▐█░░▒█▄▄█▀░▐██▒██▄▄█▒▐██▄█▌▒██░▒██▌
Autor: Aarón Miranda Victorino
Proyecto : Diccionario de datos
Materia: Estructura de archivos
Correo: epsilon11101@gmail.com
Clase: Principal
*/
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

namespace Diccionario_de_datos
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {

        private Archivo archivo;
        private List<Entidad> entidad;
        private String path;
        private int dirEntidad;
        public Form1()
        {
            InitializeComponent();
           
            archivo = new Archivo();
            entidad = new List<Entidad>();
            path = Directory.GetCurrentDirectory();

        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            
            
            long cabezera = archivo.Dame_cabezera();

            Entidad ent = new Entidad();
            if (buscaRepetidos(EntidadText.Text))
            {
                ent.GS_NombreEntidad = convierteNombre(EntidadText.Text);
                ent.GS_Dir_atributos = -1;
                ent.GS_Dir_entidad = archivo.Tam_archivo();
                ent.GS_Dir_datos = -1;
                ent.GS_Dir_Sig_entidad = -1;

            if (cabezera == -1) { archivo.Modifica_cab(ent.GS_Dir_entidad); entidad.Add(ent); archivo.insertaListaEntidad(ent); }

            else { entidad.Add(ent);   ordena(); actualizaIndices(); }

                
                actualizaData();
            }
            else
            {
                MessageBox.Show("NO SE PUEDEN REPETIR LOS CAMPOS");
            }
            EntidadText.Text = "";
        } //grabar entidad

       
        private void actualizaIndices()
        {
            for(int i = 0; i < entidad.Count-1; i++)
            {
                entidad[i].GS_Dir_Sig_entidad = entidad[i + 1].GS_Dir_entidad;
            }
            for(int i = 0; i< entidad.Count; i++)
            {
                archivo.Modifica_entidad(entidad[i].GS_Dir_entidad,entidad[i]);
            }
            archivo.Modifica_cab(entidad[0].GS_Dir_entidad);

        } // actualizar direcciones y cabezera

        private Boolean buscaRepetidos(String nombre)
        {
            foreach (Entidad e in entidad) {

                if(String.Compare(new string(e.GS_NombreEntidad),nombre) == 0)
                {
                    return false;
                }
            }

            return true;
        } // buscar repetidos

        private void ordena()
        {
            List<String> str = new List<String>();
            List<Entidad> aux = new List<Entidad>();
            foreach (Entidad ent in entidad)   str.Add(new String(ent.GS_NombreEntidad));
            str.Sort();
            //ordenar lista alfabeticamente
            foreach (String s in str)
            {
                foreach (Entidad e in entidad)
                {
                    if(String.Compare(s,new string(e.GS_NombreEntidad)) == 0) { aux.Add(e); }
                }
            }
            entidad.Clear();
            entidad = aux;
         
        }

        private char[] convierteNombre(String texto)
        {
            char[] c = new char[30];
            int i = 0;
            foreach (char p in texto)
            {
                c[i] = p;
                i++;
            }

            return c;

        }//convertir Nombre
        private void actualizaData()
        {
            dataGridView1.Rows.Clear();
            
            foreach (Entidad e in entidad)
            {
                string nombre = new string(e.GS_NombreEntidad);
                dataGridView1.Rows.Add(nombre, e.GS_Dir_atributos, e.GS_Dir_entidad, e.GS_Dir_datos, e.GS_Dir_Sig_entidad);
            }
            
        } // muestra datos en datagrid
        private void Nuevo_Click(object sender, EventArgs e)
        {
            
            EntidadText.Text = "";

        } //habilitar nueva entidad
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {try
            {
               
                EntidadText.Text = new String(entidad[e.RowIndex].GS_NombreEntidad);
                dirEntidad = e.RowIndex;
            }
            catch
            {
                MessageBox.Show("NO EXISTEN ENTIDADES QUE MODIFICAR O ELIMINAR");
            }
        }//busca indice
       
        private void button1_Click(object sender, EventArgs e)
        {
           //
            
           
            Stream s = new FileStream(archivo.GS_path, FileMode.Open, FileAccess.Read);
            long cab = archivo.Dame_cabezera();
            BinaryReader r = new BinaryReader(s);
            entidad.Clear();
            try
            {
                s.Seek(cab, SeekOrigin.Begin);
                while (cab != -1)
                {
                    long diratrib, direntidad, dirDatos, dirnext;
                    char[] c;
                    Entidad eaux = new Entidad();
                    c = r.ReadChars(30);
                    diratrib = r.ReadInt64();
                    direntidad = r.ReadInt64();
                    dirDatos = r.ReadInt64();
                    dirnext = r.ReadInt64();

                    eaux.GS_NombreEntidad = c;
                    eaux.GS_Dir_atributos = diratrib;
                    eaux.GS_Dir_entidad = direntidad;
                    eaux.GS_Dir_datos = dirDatos;
                    eaux.GS_Dir_Sig_entidad = dirnext;
                    cab = dirnext;
                    if (cab != -1)
                        s.Seek(cab, SeekOrigin.Begin);
                    entidad.Add(eaux);
                    //      MessageBox.Show(new string(eaux.GS_NombreEntidad));
                }
            }
            catch { MessageBox.Show("NO EXISTEN DATOS PARA MOSTRAR"); }
            s.Close();
            s.Dispose();
            r.Close();
            r.Dispose();
            actualizaData();


        }//boton para abrir

        private void Modificar_Click(object sender, EventArgs e)
        {

            if (EntidadText.Text == "")
            {
                MessageBox.Show("la entidad no puede estar vacia");
            }
            else
            {
                if (buscaRepetidos(EntidadText.Text))
                {
                   // archivo.Modifica_entidad(entidad[dirEntidad].GS_Dir_entidad, entidad[dirEntidad]);
                    entidad[dirEntidad].GS_NombreEntidad = convierteNombre(EntidadText.Text);
                    ordena(); actualizaIndices();
                    entidad[entidad.Count - 1].GS_Dir_Sig_entidad = -1;
                    archivo.Modifica_entidad(entidad[entidad.Count - 1].GS_Dir_entidad, entidad[entidad.Count - 1]);
                    
                    actualizaData();
                }
                else
                {
                    MessageBox.Show("NO SE PUEDEN REPETIR LOS CAMPOS");
                }
            }
            EntidadText.Text = "";
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            EntidadText.Text = "";

            try
            {
                if (dirEntidad >= 1 && dirEntidad < entidad.Count - 1)// si no es el primero ni el ultimo 
                {
                    // entidad[dirEntidad - 1].GS_Dir_Sig_entidad = entidad[dirEntidad+1].GS_Dir_Sig_entidad;
                    //MessageBox.Show(entidad[dirEntidad + 1].GS_Dir_Sig_entidad.ToString());
                    entidad.RemoveAt(dirEntidad);
                    actualizaIndices();
                }
                else if (dirEntidad == 0 && entidad.Count > 1) // si elimino el primero y existen mas datos
                {
                    archivo.Modifica_cab(entidad[dirEntidad + 1].GS_Dir_entidad); // cambiar la cabezera al siguiente del primero
                    entidad.RemoveAt(dirEntidad);
                    actualizaIndices();
                }

                else if (dirEntidad == 0 && entidad.Count <= 1) // si es el primero  y no hay mas
                {  //si se elimina el primero y no hay mas la cabezera apuntara a -1
                    archivo.Modifica_cab(-1);
                    entidad.RemoveAt(dirEntidad);
                }
                else if (dirEntidad == entidad.Count - 1)// si es el ultimo 
                {

                    entidad[dirEntidad - 1].GS_Dir_Sig_entidad = entidad[dirEntidad].GS_Dir_Sig_entidad;
                    entidad.RemoveAt(dirEntidad);
                    actualizaIndices();
                }
                //falta eliminar el ultimo y falta checar error cuand se elimina el primero
                actualizaData();
            }
            catch { MessageBox.Show("No existen mas datos"); }
        }

        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            if (entidad != null) entidad.Clear();
                 actualizaData();

            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = path;
            if (op.ShowDialog() == DialogResult.OK) {
                habilita("opcion1");
                archivo.GS_path = op.FileName;
                op.Dispose();
                long cab = archivo.Dame_cabezera();
                Stream s = new FileStream(archivo.GS_path, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(s);
                try
                {
                    s.Seek(cab, SeekOrigin.Begin);
                    while (cab != -1)
                    {
                        long diratrib, direntidad, dirDatos, dirnext;
                        char[] c;
                        Entidad eaux = new Entidad();
                        c = r.ReadChars(30);
                        diratrib = r.ReadInt64();
                        direntidad = r.ReadInt64();
                        dirDatos = r.ReadInt64();
                        dirnext = r.ReadInt64();

                        eaux.GS_NombreEntidad = c;
                        eaux.GS_Dir_atributos = diratrib;
                        eaux.GS_Dir_entidad = direntidad;
                        eaux.GS_Dir_datos = dirDatos;
                        eaux.GS_Dir_Sig_entidad = dirnext;
                        cab = dirnext;
                        if (cab != -1)
                            s.Seek(cab, SeekOrigin.Begin);
                        entidad.Add(eaux);
                        //      MessageBox.Show(new string(eaux.GS_NombreEntidad));
                    }
                }
                catch { MessageBox.Show("NO EXISTEN DATOS PARA MOSTRAR"); }
                op.Dispose();
                
                s.Close();
                s.Dispose();
                r.Close();
                r.Dispose();
                actualizaData();
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e) // nuevo documento
        {
            if (entidad != null) entidad.Clear();
              actualizaData();
            SaveFileDialog sv = new SaveFileDialog();
            sv.InitialDirectory = path;
            if (DialogResult.OK == sv.ShowDialog()) {
                archivo.GS_path = sv.FileName;
                archivo.creaArchivo();
                habilita("opcion2");
            }
            sv.Dispose();
            
        }

        private void atributosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ATRIBUTOS(entidad,archivo).Show();
        }


        private void habilita(String op)
        {

            switch (op)
            {
                case "opcion1":
                    Nuevo.Enabled = true;
                    Modificar.Enabled = true;
                    Eliminar.Enabled = true;
                    Grabar.Enabled = true;
                    button1.Enabled = true;
                    EntidadText.Enabled = true;
                    break;
                case "opcion2":
                    Nuevo.Enabled = true;
                    Modificar.Enabled = false;
                    Eliminar.Enabled = false;
                    Grabar.Enabled = true;
                    button1.Enabled = true;
                    EntidadText.Enabled = true;
                    break;
            }




        }

        private void datosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new datos(entidad, archivo).Show();
        }
    }
}
