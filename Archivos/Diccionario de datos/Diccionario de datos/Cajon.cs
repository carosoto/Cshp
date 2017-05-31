using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Diccionario_de_datos
{
    //agregar metodo para asignar memoria
    class Cajon
    {
        private long  dir_inicial;
        private long dir_final;
        private long direccion_cubeta;
        private List<cubeta> Cubeta;
        private Color c;
        
        public Cajon()
        {
            dir_inicial = dir_final = direccion_cubeta = -1;
            Cubeta = new List<cubeta>();
            c = Color.Black;

        }
        public Color GS_color
        {
            get { return c; }
            set { c = value; }
        }
        public void AgregaCubetaEnteros(Archivo arch)
        {
            for(int i = 0; i < 3; i++)
            {
                cubeta c = new cubeta();
                c.asignaMemoriaEnteros(arch,i);
                Cubeta.Add(c);
            }

            GS_dirCubeta = Cubeta[0].GS_dirInicial;
        }

        public void AgregaCubetaDesbordada(Archivo arch)
        {
            for (int i = 0; i < 3; i++)
            {
                cubeta c = new cubeta();
                c.asignaMemoriaEnteros(arch, i);
                Cubeta.Add(c);
            }

            Cubeta[2].GS_dirSigCubeta = Cubeta[3].GS_dirInicial;
        }

        public void asignaMemoriaCajon(Archivo arch, int i)
        {
            long dir_inicial = 0;
            dir_inicial = arch.Tam_archivo();
            GS_dirInicial = dir_inicial;
            FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            BinaryWriter writer = new BinaryWriter(stream);
            stream.Seek(dir_inicial, SeekOrigin.Begin);
            writer.Write(GS_dirInicial);
            writer.Write(GS_dirCubeta);
            if(i < 2)
            GS_dirFinal = GS_dirInicial + 24;
            writer.Write(GS_dirFinal);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
            
        }

        public List<cubeta> GS_cubeta
        {
            get { return Cubeta; }
            set { Cubeta = value; }
        }

        public long GS_dirCubeta
        {
            get { return direccion_cubeta; }
            set { direccion_cubeta = value; }
        }

        public long GS_dirFinal
        {
            get { return dir_final; }
            set { dir_final = value; }
        }

        public long GS_dirInicial
        {
            get { return dir_inicial; }
            set { dir_inicial = value; }
        }

        public int GS_CantidadValores()
        {
            int total = 0;
            foreach (cubeta c in Cubeta)
            {
                if(c.GS_valor != -1)
                {
                    total++;
                }

            }
            return total;
        }
        
        public void modificaCajon(Archivo arch)
        {
            long dir_inicial = 0;
            dir_inicial = GS_dirInicial;
            FileStream stream = new FileStream(arch.GS_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            BinaryWriter writer = new BinaryWriter(stream);
            stream.Seek(dir_inicial, SeekOrigin.Begin);
            writer.Write(GS_dirInicial);
            writer.Write(GS_dirCubeta);
            writer.Write(GS_dirFinal);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
        }

    }
}
