
/*
░▐█▀▀▒▐█▀█▒▄█▀▀█░▐██▒██░░░▒▐█▀▀█▌▒██▄░▒█▌
░▐█▀▀▒▐█▄█▒▀▀█▄▄─░█▌▒██░░░▒▐█▄▒█▌▒▐█▒█▒█░
░▐█▄▄▒▐█░░▒█▄▄█▀░▐██▒██▄▄█▒▐██▄█▌▒██░▒██▌
Autor: Aarón Miranda Victorino
Proyecto : Diccionario de datos
Materia: Estructura de archivos
Correo: epsilon11101@gmail.com
Clase: Archivo
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace Diccionario_de_datos
{
    
    public class Archivo
    {

        private BinaryReader reader;
        private BinaryWriter writer;
        private FileStream stream;
        private String path;

        
        public Archivo() {
        }

        public String GS_path
        {
            get { return path; }
            set { path = value; }
        }
        public void creaArchivo()
        {
            
            try
            {
                long cabezera = -1;
                stream = new FileStream(GS_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                writer = new BinaryWriter(stream);
                writer.Write(cabezera);
                writer.Close();
                stream.Close();
            }
            catch(IOException e) {

                MessageBox.Show(e.Message);

            }
        }
  
       


        public void insertaAtributo(Atrib a)
        {
           
            long tam_archivo = Tam_archivo();
            stream = new FileStream(GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            writer = new BinaryWriter(stream);
            stream.Seek(tam_archivo, SeekOrigin.Begin);
            writer.Write(a.GS_nombre);
            writer.Write(a.GS_tipo);
            writer.Write(a.GS_longitud);
            writer.Write(a.GS_dir_atributo);
            writer.Write(a.GS_indice);
            writer.Write(a.GS_dir_indice);
            writer.Write(a.GS_dir_sig_atrib);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
        }
        public void insertaListaEntidad(Entidad e)
        {
            long pos = Dame_cabezera();
            long tam_archivo = Tam_archivo();
            stream = new FileStream(GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            writer = new BinaryWriter(stream);
            if (pos == -1) stream.Seek(pos, SeekOrigin.Begin);
            else stream.Seek(tam_archivo, SeekOrigin.Begin);
           
            
            writer.Write(e.GS_NombreEntidad);
            writer.Write(e.GS_Dir_atributos);
            writer.Write(e.GS_Dir_entidad);
            writer.Write(e.GS_Dir_datos);
            writer.Write(e.GS_Dir_Sig_entidad);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
        }
        public long Tam_archivo()
        {
           
                long tam;
                stream = new FileStream(GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                tam = stream.Length;
                stream.Close();
                stream.Dispose();
                return tam;
            
        }

        public long Dame_cabezera()
        {
            try
            {
                long cab = 0;
                stream = new FileStream(GS_path, FileMode.Open, FileAccess.Read);
                
                reader = new BinaryReader(stream);
                stream.Seek(0, SeekOrigin.Begin);
                cab = reader.ReadInt64();
                reader.Close();
                reader.Dispose();
                stream.Close();
                stream.Dispose();
                return cab;
            }
            catch { MessageBox.Show("Necesitas abrir un archivo"); return -1; }
        }
        public void Modifica_cab(long new_cabezera)
        {
            stream = new FileStream(GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            writer = new BinaryWriter(stream);
            stream.Seek(0, SeekOrigin.Begin);
            writer.Write(new_cabezera);
            stream.Close();
            stream.Dispose();
            writer.Close();
            writer.Dispose();
        }
        
        public void Modifica_entidad(long direccion, Entidad ent) {
            
            stream = new FileStream(GS_path, FileMode.Open, FileAccess.Write);
            writer = new BinaryWriter(stream);
            stream.Seek(direccion,SeekOrigin.Begin);
            writer.Write(ent.GS_NombreEntidad);
            writer.Write(ent.GS_Dir_atributos);
            writer.Write(ent.GS_Dir_entidad);
            writer.Write(ent.GS_Dir_datos);
            writer.Write(ent.GS_Dir_Sig_entidad);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
        }

        public void Modifica_atributo(long direccion, Atrib a)
        {
            stream = new FileStream(GS_path, FileMode.Open, FileAccess.Write);
            writer = new BinaryWriter(stream);
            stream.Seek(direccion, SeekOrigin.Begin);
            writer.Write(a.GS_nombre);
            writer.Write(a.GS_tipo);
            writer.Write(a.GS_longitud);
            writer.Write(a.GS_dir_atributo);
            writer.Write(a.GS_indice);
            writer.Write(a.GS_dir_indice);
            writer.Write(a.GS_dir_sig_atrib);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
        }
    }
}
