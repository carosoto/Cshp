/*
░▐█▀▀▒▐█▀█▒▄█▀▀█░▐██▒██░░░▒▐█▀▀█▌▒██▄░▒█▌
░▐█▀▀▒▐█▄█▒▀▀█▄▄─░█▌▒██░░░▒▐█▄▒█▌▒▐█▒█▒█░
░▐█▄▄▒▐█░░▒█▄▄█▀░▐██▒██▄▄█▒▐██▄█▌▒██░▒██▌
Autor: Aarón Miranda Victorino
Proyecto : Diccionario de datos
Materia: Estructura de archivos
Correo: epsilon11101@gmail.com
Clase: cubeta
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{

    //faltantes:
    // agrega metodo para asignar memoria
    class cubeta
    {
        //variables de instancia
        private long dir_inicial;
        private long dir_final;
        private long dir_valor;
        private long dir_sig_cubeta;
        private int valor_entero;
        private string valor_cadena;
       
        //constructor
        public cubeta()
        {
            dir_sig_cubeta = -1;
            dir_inicial = -1;
            dir_final = -1;
            dir_valor = -1;
            valor_entero = -1;
            valor_cadena = "null";
           
        }
        //obtener y modificar la direccion siguiente de la cubeta
        public long GS_dirSigCubeta
        {
            get { return dir_sig_cubeta; }
            set { dir_sig_cubeta = value; }
        }
        //obtener y modificar la direccion inicial de la cubeta
        public long GS_dirInicial{
            get { return dir_inicial; }
            set { dir_inicial = value; }
            }
        //obtener y modificar la direccion final de la cubeta
        public long GS_dirFinal
        {
            get { return dir_final; }
            set { dir_final = value; }
        }
        //obtener y modificar la direccion del valor
        public long GS_dirvalor
        {
            get { return dir_valor; }
            set { dir_valor = value; }
        }
        //obtener y modificar el valor 
        public int GS_valor
        {
            get { return valor_entero; }
            set { valor_entero = value; }
        }
        
        //asignar  memoria 
        public void  asignaMemoriaEnteros(Archivo arch,int posCubeta)
        {
            long dir_inicial = 0;
            dir_inicial = arch.Tam_archivo();
            GS_dirInicial = dir_inicial;
            FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            BinaryWriter writer = new BinaryWriter(stream);
            stream.Seek(dir_inicial, SeekOrigin.Begin);
            writer.Write(GS_dirInicial);
            writer.Write(dir_valor);
            writer.Write(valor_entero);
            writer.Write(dir_sig_cubeta); // escribe solamente en la 3a cubeta
            if (posCubeta < 2) dir_final = dir_inicial + 36;
            

                writer.Write(dir_final);
            
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
            
        }
        //modificar valores
        public void modificaValores(Archivo arch)
        {
            long dir_inicial = 0;
            dir_inicial = GS_dirInicial;
            FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            BinaryWriter writer = new BinaryWriter(stream);
            stream.Seek(dir_inicial, SeekOrigin.Begin);
            writer.Write(GS_dirInicial);
            writer.Write(dir_valor);
            writer.Write(valor_entero);
            writer.Write(dir_sig_cubeta); // escribe solamente en la 3a cubeta
            writer.Write(dir_final);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
        }
        

    }
}
