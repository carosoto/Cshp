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
        private long dir_inicial;
        private long dir_final;
        private long dir_valor;
        private long dir_sig_cubeta;
        private int valor_entero;
        private string valor_cadena;
        

        public cubeta()
        {
            dir_sig_cubeta = -1;
            dir_inicial = -1;
            dir_final = -1;
            dir_valor = -1;
            valor_entero = -1;
            valor_cadena = "null";
        }

        public long GS_dirSigCubeta
        {
            get { return dir_sig_cubeta; }
            set { dir_sig_cubeta = value; }
        }

        public long GS_dirInicial{
            get { return dir_inicial; }
            set { dir_inicial = value; }
            }
        public long GS_dirFinal
        {
            get { return dir_final; }
            set { dir_final = value; }
        }
        public long GS_dirvalor
        {
            get { return dir_valor; }
            set { dir_valor = value; }
        }

        public int GS_valor
        {
            get { return valor_entero; }
            set { valor_entero = value; }
        }

        public String GS_cadena
        {
            get { return valor_cadena; }
            set { valor_cadena = value; }
        }

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
            if (posCubeta == 2) writer.Write(dir_sig_cubeta); // escribe solamente en la 3a cubeta
            writer.Write(dir_final);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();




        }

        public void asignaMemoriaCadena(Archivo arch) { }

    }
}
