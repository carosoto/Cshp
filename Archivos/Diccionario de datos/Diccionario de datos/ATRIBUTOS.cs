
/*
░▐█▀▀▒▐█▀█▒▄█▀▀█░▐██▒██░░░▒▐█▀▀█▌▒██▄░▒█▌
░▐█▀▀▒▐█▄█▒▀▀█▄▄─░█▌▒██░░░▒▐█▄▒█▌▒▐█▒█▒█░
░▐█▄▄▒▐█░░▒█▄▄█▀░▐██▒██▄▄█▒▐██▄█▌▒██░▒██▌
Autor: Aarón Miranda Victorino
Proyecto : Diccionario de datos
Materia: Estructura de archivos
Correo: epsilon11101@gmail.com
Clase: ATRIBUTO
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Diccionario_de_datos
{
    public partial class ATRIBUTOS : DevComponents.DotNetBar.Metro.MetroForm
    {
        private List<Entidad> ent_;
        private List<Atrib> atrib_;
        private Archivo arch;
        private char type;
        private int index_entidad, index_atributo;
        public ATRIBUTOS(List<Entidad> ent, Archivo arch)
        {
            ent_ = new List<Entidad>();
            atrib_ = new List<Atrib>();
            this.arch = arch;
            type = '-';
            ent_ = ent;
            index_entidad = index_atributo = 0;
            InitializeComponent();
            foreach (Entidad e in ent_) {
                Entidad.Items.Add(new String(e.GS_NombreEntidad));

            }
            Entidad.Enabled = true;
        }

        private void Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tipo.Text == "INT") { type = 'I'; Longitud.Text = "4"; }
            else if (Tipo.Text == "CHAR") { type = 'C'; Longitud.Text = ""; }
        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            
            Modificar.Enabled = true;
            Eliminar.Enabled = true;

            Atrib a = new Atrib();
            if (Nombre.Text != "" && Tipo.Text != "" && Longitud.Text != "" && Clave.Text != "") {

                if (!busca_Repetidos(Nombre.Text))
                {
                   
                    a.GS_nombre = convierteNombre(Nombre.Text);
                    a.GS_tipo = type;
                    a.GS_longitud = Convert.ToInt16(Longitud.Text);
                    a.GS_dir_atributo = arch.Tam_archivo();
                    a.GS_indice = Convert.ToInt16(Clave.SelectedItem);
                    a.GS_dir_indice = -1;
                    a.GS_dir_sig_atrib = -1;
                    ent_[index_entidad].GS_atrib.Add(a);
                    if (ent_[index_entidad].GS_atrib.Count == 1)
                    {
                        ent_[index_entidad].GS_Dir_atributos = a.GS_dir_atributo;
                        arch.Modifica_entidad(ent_[index_entidad].GS_Dir_entidad, ent_[index_entidad]);
                    }

                    arch.insertaAtributo(a);
                    acomodaDirecciones();
                    actualizaData();
                    borrarDatos();
                }
                else { MessageBox.Show("EL CAMPO YA EXISTE"); }

            }
            else
            {
                MessageBox.Show("NO SE PUEDEN DEJAR CAMPOS VACIOS");
            }

        }
    
        private void acomodaDirecciones()
        {
            if (ent_[index_entidad].GS_atrib.Count > 1) {
                for (int i = 0; i < ent_[index_entidad].GS_atrib.Count - 1; i++)
                {
                    ent_[index_entidad].GS_atrib[i].GS_dir_sig_atrib = ent_[index_entidad].GS_atrib[i + 1].GS_dir_atributo;
                }
                ent_[index_entidad].GS_atrib[ent_[index_entidad].GS_atrib.Count - 1].GS_dir_sig_atrib = -1; //ultimo atrib

                for (int i = 0; i < ent_[index_entidad].GS_atrib.Count ; i++)
                {
                    arch.Modifica_atributo(ent_[index_entidad].GS_atrib[i].GS_dir_atributo, ent_[index_entidad].GS_atrib[i]);
                }

            }


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

        private void Entidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            index_entidad = Entidad.Items.IndexOf(Entidad.SelectedItem);
            leerArchivo();
            Grabar.Enabled = true;
          //  borrarDatos();
        }

        private void leerArchivo()
        {



            arch.GS_path = arch.GS_path;
            long cab = ent_[index_entidad].GS_Dir_atributos;
            ent_[index_entidad].GS_atrib.Clear();
            Stream s = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(s);
            try
            {
                s.Seek(cab, SeekOrigin.Begin);
                while (cab != -1)
                {

                    Atrib aux = new Atrib();
                    aux.GS_nombre = r.ReadChars(30);
                    aux.GS_tipo = r.ReadChar();
                    aux.GS_longitud = r.ReadInt16();
                    aux.GS_dir_atributo = r.ReadInt64();
                    aux.GS_indice = r.ReadInt16();
                    aux.GS_dir_indice = r.ReadInt64();
                    aux.GS_dir_sig_atrib = r.ReadInt64();
                    cab = aux.GS_dir_sig_atrib;
                    if (cab != -1)
                        s.Seek(cab, SeekOrigin.Begin);
                    ent_[index_entidad].GS_atrib.Add(aux);
                }
            }
            catch { MessageBox.Show("NO EXISTEN DATOS PARA MOSTRAR"); }
            s.Close();
            s.Dispose();
            r.Close();
            r.Dispose();
            actualizaData();
        }

        private void actualizaData()
        {
            dataGridView1.Rows.Clear();

            foreach (Atrib a in  ent_[index_entidad].GS_atrib)
            {
                string nombre = new string(a.GS_nombre);
                dataGridView1.Rows.Add(nombre,a.GS_tipo,a.GS_longitud,a.GS_dir_atributo,a.GS_indice,a.GS_dir_indice,a.GS_dir_sig_atrib);
            }

        } // muestra datos en datagrid

        private void Modificar_Click(object sender, EventArgs e)
        {

            ent_[index_entidad].GS_atrib[index_atributo].GS_nombre = convierteNombre(Nombre.Text);
            ent_[index_entidad].GS_atrib[index_atributo].GS_tipo = type;
            ent_[index_entidad].GS_atrib[index_atributo].GS_longitud = Convert.ToInt16(Longitud.Text);
            ent_[index_entidad].GS_atrib[index_atributo].GS_indice = Convert.ToInt16(Clave.SelectedItem);
            
            arch.Modifica_atributo(ent_[index_entidad].GS_atrib[index_atributo].GS_dir_atributo, ent_[index_entidad].GS_atrib[index_atributo]);
            actualizaData();
            borrarDatos();
            
            
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (index_atributo >= 1 && index_atributo < ent_[index_entidad].GS_atrib.Count - 1)// si no es el primero ni el ultimo 
                {
                    ent_[index_entidad].GS_atrib[index_atributo - 1].GS_dir_sig_atrib = ent_[index_entidad].GS_atrib[index_atributo].GS_dir_sig_atrib;

                    ent_[index_entidad].GS_atrib.RemoveAt(index_atributo);
                    acomodaDirecciones();
                    actualizaData();
                }
                else if (index_atributo == 0 && ent_[index_entidad].GS_atrib.Count > 1) // si elimino el primero y existen mas datos
                {

                    ent_[index_entidad].GS_Dir_atributos = ent_[index_entidad].GS_atrib[index_atributo + 1].GS_dir_atributo;
                    arch.Modifica_entidad(ent_[index_entidad].GS_Dir_entidad, ent_[index_entidad]);
                    ent_[index_entidad].GS_atrib.RemoveAt(index_atributo);
                    acomodaDirecciones();
                    actualizaData();
                }

                else if (index_atributo == 0 && ent_[index_entidad].GS_atrib.Count <= 1) // si es el primero  y no hay mas
                {  //si se elimina el primero y no hay mas 
                    ent_[index_entidad].GS_Dir_atributos = -1;
                    arch.Modifica_entidad(ent_[index_entidad].GS_Dir_entidad, ent_[index_entidad]);
                    ent_[index_entidad].GS_atrib.RemoveAt(index_atributo);
                    acomodaDirecciones();
                    actualizaData();
                    Nombre.Enabled = false;
                    Tipo.Enabled = false;
                    Longitud.Enabled = false;
                    Clave.Enabled = false;
                    Grabar.Enabled = false;
                    Modificar.Enabled = false;
                    Eliminar.Enabled = false;
                }

                else if (index_atributo == ent_[index_entidad].GS_atrib.Count - 1)// si es el ultimo 
                {

                    ent_[index_entidad].GS_atrib[index_atributo - 1].GS_dir_sig_atrib = ent_[index_entidad].GS_atrib[index_atributo].GS_dir_sig_atrib;

                    ent_[index_entidad].GS_atrib.RemoveAt(index_atributo);
                    acomodaDirecciones();
                    actualizaData();
                }
                //falta eliminar el ultimo y falta checar error cuand se elimina el primero
                borrarDatos();
                actualizaData();
            }
            catch
            {
                MessageBox.Show("NO EXISTEN DATOS PARA MOSTRAR");
            }
        }

        private void Actualiza_Click(object sender, EventArgs e)
        {
            try
            {
                ent_.Clear();
                long cab = arch.Dame_cabezera();
                Stream s = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(s);

                s.Seek(cab, SeekOrigin.Begin);
                while (cab != -1)
                {
                    long diratrib, direntidad, dirDatos, dirnext;
                    char[] c;
                    Entidad eaux = new Entidad();
                    c = r.ReadChars(30);
                    // MessageBox.Show("nombre " + new string(c));
                    diratrib = r.ReadInt64();
                    // MessageBox.Show("dir atributo" + diratrib.ToString());
                    direntidad = r.ReadInt64();
                    // MessageBox.Show("dir entidad " + direntidad.ToString());
                    dirDatos = r.ReadInt64();
                    // MessageBox.Show("dir datos " + dirDatos.ToString());
                    dirnext = r.ReadInt64();
                    //MessageBox.Show("dir next " + dirnext.ToString());

                    eaux.GS_NombreEntidad = c;
                    eaux.GS_Dir_atributos = diratrib;
                    eaux.GS_Dir_entidad = direntidad;
                    eaux.GS_Dir_datos = dirDatos;
                    eaux.GS_Dir_Sig_entidad = dirnext;
                    cab = dirnext;
                    if (cab != -1)
                        s.Seek(cab, SeekOrigin.Begin);
                    ent_.Add(eaux);
                }


                s.Close();
                s.Dispose();
                r.Close();
                r.Dispose();
                actualizaData();

            }
            catch { }
            Entidad.Items.Clear();
            foreach (Entidad en in ent_)
            {
                Entidad.Items.Add(new String(en.GS_NombreEntidad));

            }
            actualizaData();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            Entidad.Enabled = true;
            Nombre.Enabled = true;
            Tipo.Enabled = true;
            Longitud.Enabled = true;
            Clave.Enabled = true;
            Grabar.Enabled = true;
            borrarDatos();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Nombre.Text = new string(ent_[index_entidad].GS_atrib[e.RowIndex].GS_nombre);
            Tipo.Text = ent_[index_entidad].GS_atrib[e.RowIndex].GS_tipo.ToString();
            Longitud.Text = ent_[index_entidad].GS_atrib[e.RowIndex].GS_longitud.ToString();
            Clave.Text = ent_[index_entidad].GS_atrib[e.RowIndex].GS_indice.ToString();
            index_atributo = e.RowIndex;
            Actualiza.Enabled = true;
            Eliminar.Enabled = true;
            Modificar.Enabled = true;
            Entidad.Enabled = true;
            Nombre.Enabled = true;
            Tipo.Enabled = true;
            Longitud.Enabled = true;
            Tipo.Enabled = true;
        }

        private void borrarDatos()
        {
         
            Nombre.Text = "";
            Tipo.Text = "";
            Longitud.Text = "";
            Clave.Text = "";
        }

        private Boolean busca_Repetidos(String nom)
        {
            foreach(Atrib A in ent_[index_entidad].GS_atrib)
            {
                if (String.Compare(new string(A.GS_nombre), nom) == 0) { return true; }
               
            }
            return false;
        }
    }
}
