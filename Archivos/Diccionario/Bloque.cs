using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diccionario
{
    class Bloque
    {
     
        public List<byte> bloque;
        private int tamaño;
        private int desplazamiento;

       
        public Bloque()
        {
            desplazamiento = 0;
        }

        public Bloque(int tam)
        {
            bloque = new List<byte>();
            desplazamiento = 0;
        }

      
        public List<byte> dameBloque
        {
            get { return bloque; }
            set { bloque = value; }
        }

       
        public int tam
        {
            get { return tamaño; }
            set { tamaño = value; }
        }

   
        public int desp
        {
            get { return desplazamiento; }
            set { desplazamiento = value; }
        }

        public static long dameApSig(Bloque bloque)
        {
            return BitConverter.ToInt64(bloque.bloque.GetRange(0, sizeof(long)).ToArray(), 0);
        }

       
        public void meteDato(String args, string tipo, int tam)
        {
            byte[] dato = new byte[10];
            int entero;
            double flotante;
            char caracter;
            long dir;

            switch (tipo)
            {
                case "int":
                    entero = Convert.ToInt32(args);
                    dato = BitConverter.GetBytes(entero);
                    break;
                case "long":
                    dir = Convert.ToInt64(args);
                    dato = BitConverter.GetBytes(dir);
                    break;
                case "float":
                    flotante = Convert.ToDouble(args);
                    dato = BitConverter.GetBytes(flotante);
                    break;
                case "char":
                    caracter = Convert.ToChar(args);
                    dato = BitConverter.GetBytes(caracter);
                    break;
                case "string":
                    for (int j = 0; j < args.Length; j++)
                    {
                        dato = BitConverter.GetBytes(args[j]);
                        for (int i = 0; i < dato.Length; i++)
                            bloque[i + desplazamiento] = dato[i];
                        desplazamiento += dato.Length;
                    }
                    desplazamiento += (int)((tam - args.Length) * 2);
                    break;
            }
            if (tipo != "string")
            {
                for (int i = 0; i < dato.Length; i++)
                {
                    bloque[i + desplazamiento] = dato[i];
                }
                desplazamiento += dato.Length;
            }
        }

   
        public void ponApuntador(long dir)
        {
            bloque.RemoveRange(0, sizeof(long));
            bloque.InsertRange(0, BitConverter.GetBytes(dir));
        }

      
        public static List<byte> cadenaBytes(string cad)
        {
            List<byte> list = new List<byte>();
            for (int i = 0; i < cad.Length; i++)
            {
                list.AddRange(BitConverter.GetBytes(cad[i]));
            }
            return list;
        }

     
        public static String dameCad(List<byte> bloque)
        {
            String cad;
            char[] arr = new char[bloque.Count / sizeof(char)];

            for (int i = 0, j = 0; i < bloque.Count; i += sizeof(char), j++)
            {
                arr[j] = BitConverter.ToChar(bloque.GetRange(i, sizeof(char)).ToArray(), 0);
            }
            cad = new string(arr);
            return cad;
        }
    }
}
