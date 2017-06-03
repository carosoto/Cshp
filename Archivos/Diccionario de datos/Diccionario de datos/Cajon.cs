/*
░▐█▀▀▒▐█▀█▒▄█▀▀█░▐██▒██░░░▒▐█▀▀█▌▒██▄░▒█▌
░▐█▀▀▒▐█▄█▒▀▀█▄▄─░█▌▒██░░░▒▐█▄▒█▌▒▐█▒█▒█░
░▐█▄▄▒▐█░░▒█▄▄█▀░▐██▒██▄▄█▒▐██▄█▌▒██░▒██▌
Autor: Aarón Miranda Victorino
Proyecto : Diccionario de datos
Materia: Estructura de archivos
Correo: epsilon11101@gmail.com
Clase: Cajon
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Diccionario_de_datos
{
    
    class Cajon
    {
        //variabes de instancia
        private long  dir_inicial;
        private long dir_final;
        private long direccion_cubeta;
        private List<cubeta> Cubeta;
        private Color c;
        
        //constructor
        public Cajon()
        {
            dir_inicial = dir_final = direccion_cubeta = -1;
            Cubeta = new List<cubeta>();
            c = Color.Black;

        }
        //color para modificar las celdas de su datagridview
        public Color GS_color
        {
            get { return c; }
            set { c = value; }
        }
        //agrega cubeta de valores enteros
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
        //crear una nueva cubeta
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
        //Asignar memoria a un cajon en el archivo
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
        //obtener las cubetas  creadas
        public List<cubeta> GS_cubeta
        {
            get { return Cubeta; }
            set { Cubeta = value; }
        }
        //obtener direccion de la cubeta
        public long GS_dirCubeta
        {
            get { return direccion_cubeta; }
            set { direccion_cubeta = value; }
        }
        //obtener la direccion final
        public long GS_dirFinal
        {
            get { return dir_final; }
            set { dir_final = value; }
        }
        //obtener la direccion inicial
        public long GS_dirInicial
        {
            get { return dir_inicial; }
            set { dir_inicial = value; }
        }
        //obtener la cantidad de valores que tiene cada registro de la cubeta
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
        //modificar cajon 
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
