using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Diccionario
{
    class Archivo
    {
        public String nombre;

      
        public void CreaArchivo()
        {
            long cab = -1;

            Console.WriteLine("Escribe el nombre del archivo");
            nombre = Console.ReadLine();
            nombre += ".dic";
            FileStream stream = new FileStream(nombre, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(cab);
            
            writer.Close();
            stream.Close();
        }

     
        public bool abreArchivo()
        {
            string nombreArch;
            bool band = false;

            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory);
            FileInfo[] nombres = dir.GetFiles();
            Console.WriteLine("Los archivos que se encontraron son:");
            foreach (FileInfo file in nombres)
            {
                if (file.Extension.Contains(".dic"))
                    Console.WriteLine(file.Name);
            }
            Console.WriteLine("    ");
            Console.WriteLine("Escribe el nombre del archivo");
            nombreArch = Console.ReadLine();
            nombre = nombreArch;
            nombre += ".dic";
            foreach (FileInfo file in nombres)
            {
                if (string.Compare(file.Name, nombre) == 0)
                {
                    band = true;
                }
            }
            if (band)
            {
                FileStream stream = new FileStream(nombre, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                BinaryReader reader = new BinaryReader(stream);

                reader.Close();
                reader.Dispose();
                stream.Close();
                stream.Dispose();
            }
            return band;
        }

       
        public long EscribeEntidad(Entidades ent)
        {
            long pos = 0;
            FileStream stream;
            BinaryWriter writer;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            writer = new BinaryWriter(stream);
            pos = tam();
            stream.Seek(pos, SeekOrigin.Begin);
            writer.Write(ent.nombre);
            writer.Write(ent.atrb);
            writer.Write(ent.ApDatos);
            writer.Write(ent.sig);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();

            return pos;
        }

      
        public long escribeAtributo(Atributos atrib)
        {
            long pos = -1;
            FileStream stream;
            BinaryWriter writer;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.ReadWrite);
            writer = new BinaryWriter(stream);
            pos = tam();
            stream.Seek(pos, SeekOrigin.Begin);
            writer.Write(atrib.nombre);
            writer.Write(atrib.tipo);
            writer.Write(atrib.tam);
            writer.Write(atrib.esClave);
            writer.Write(atrib.siguienteAtrib);

            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();

            return pos;

        }

        public long escribeBloque(Bloque bloque, List<Atributos> listaAtrib)
        {
            int lenght = dameTamaño(listaAtrib);
            FileStream stream;
            BinaryWriter writer;
            long pos;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.ReadWrite);
            writer = new BinaryWriter(stream);
            pos = tam();
            stream.Seek(pos, SeekOrigin.Begin);
            writer.Write(bloque.bloque.ToArray());
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();

            return pos;
        }

     
        public long escribeIndice(indice indice)
        {
            FileStream stream;
            BinaryWriter writer;
            long pos;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.ReadWrite);
            writer = new BinaryWriter(stream);
            stream.Seek(0, SeekOrigin.End);
            pos = stream.Position;
            writer.Write(indice.dameIni);
            writer.Write(indice.dameFin);
            writer.Write(indice.ApDatos);
            writer.Write(indice.ApSig);

            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();

            return pos;
        }

       
        public void insertaEntidad(Entidades ent, long pos)
        {
            char[] nom = new char[30];
            Entidades aux, entA = new Entidades(nom);
            long cab = dameCab();
            long posAnt = 0;
            string auxent, auxEntA;

            if (cab == -1)
            {
                reescribeCab(pos);
            }
            else
            {
                aux = leeEntidad(cab);
                auxent = new string(aux.nombre);
                auxEntA = new string(ent.nombre);
                while (cab != -1 && string.Compare(auxEntA, auxent) > 0)
                {
                    entA = aux;
                    posAnt = cab;
                    cab = aux.sig;
                    if (cab != -1)
                    {
                        aux = leeEntidad(cab);
                        auxent = new string(aux.nombre);
                    }
                }
                if (cab == dameCab())
                {
                    ent.sig = cab;
                    reescribeCab(pos);
                    reescribeEntidad(ent, pos);
                }
                else
                {
                    ent.sig = entA.sig;
                    entA.sig = pos;
                    reescribeEntidad(entA, posAnt);
                    reescribeEntidad(ent, pos);
                }
            }
        }

        public void insertaAtributo(Entidades ent, long posEnt, Atributos atrib, long posAtrib)
        {
            long cabAt = -1;
            long posAnt = -1;
            Atributos aAtrib;
            Atributos atribAnt = new Atributos();
            string stAtrib = new string(atrib.nombre);
            string stAux;

            if (ent.atrb == -1)
            {
                ent.atrb = posAtrib;
                reescribeEntidad(ent, posEnt);
            }
            else
            {
                cabAt = ent.atrb;
                aAtrib = leeAtrib(cabAt);
                stAux = new string(aAtrib.nombre);
                if (String.Compare(stAux, stAtrib) > 0)
                {
                    atrib.siguienteAtrib = cabAt;
                    ent.atrb = posAtrib;
                    reescribeEntidad(ent, posEnt);
                    reescribeAtributo(atrib, posAtrib);
                }
                else
                {
                    while (cabAt != -1 && string.Compare(stAux, stAtrib) < 0)
                    {
                        posAnt = cabAt;
                        atribAnt = aAtrib;
                        cabAt = aAtrib.siguienteAtrib;
                        if (cabAt != -1)
                        {
                            aAtrib = leeAtrib(cabAt);
                            stAux = new string(aAtrib.nombre);
                        }
                    }
                    atrib.siguienteAtrib = atribAnt.siguienteAtrib;
                    reescribeAtributo(atrib, posAtrib);
                    atribAnt.siguienteAtrib = posAtrib;
                    reescribeAtributo(atribAnt, posAnt);
                }
            }
        }

        
        public Entidades leeEntidad(long dir)
        {
            char[] nom = new char[30];
            Entidades ent = new Entidades(nom);
            FileStream stream;
            BinaryReader reader;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.Read);
            reader = new BinaryReader(stream);
            stream.Seek(dir, SeekOrigin.Begin);
            ent.nombre = reader.ReadChars(30);
            ent.atrb = reader.ReadInt64();
            ent.ApDatos = reader.ReadInt64();
            ent.sig = reader.ReadInt64();
            reader.Close();
            reader.Dispose();
            stream.Close();
            stream.Dispose();
            return ent;
        }

   
        public indice leeIndice(long dir)
        {
            indice indice = new indice();
            FileStream stream;
            BinaryReader reader;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.Read);
            reader = new BinaryReader(stream);
            stream.Seek(dir, SeekOrigin.Begin);
            indice.dameIni = reader.ReadInt32();
            indice.dameFin = reader.ReadInt32();
            indice.ApDatos = reader.ReadInt64();
            indice.ApSig = reader.ReadInt64();

            reader.Close();
            reader.Dispose();
            stream.Close();
            stream.Dispose();

            return indice;
        }

      
        public Atributos leeAtrib(long pos)
        {
            Atributos atrib = new Atributos();
            FileStream stream;
            BinaryReader reader;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.Read);
            reader = new BinaryReader(stream);
            stream.Seek(pos, SeekOrigin.Begin);
            atrib.nombre = reader.ReadChars(30);
            atrib.tipo = reader.ReadInt16();
            atrib.tam = reader.ReadInt32();
            atrib.esClave = reader.ReadBoolean();
            atrib.siguienteAtrib = reader.ReadInt64();
            reader.Close();
            reader.Dispose();
            stream.Close();
            stream.Dispose();
            return atrib;
        }

        public Bloque leeBloque(long pos, List<Atributos> listaAtrib)
        {
            int tam = dameTamaño(listaAtrib);
            Bloque bloque = new Bloque();
            bloque.bloque = new List<byte>();

            FileStream stream;
            BinaryReader reader;
            stream = new FileStream(nombre, FileMode.Open, FileAccess.Read);
            reader = new BinaryReader(stream);
            stream.Seek(pos, SeekOrigin.Begin);
            bloque.bloque.AddRange(reader.ReadBytes(tam));
            reader.Close();
            reader.Dispose();
            stream.Close();
            stream.Dispose();
            return bloque;
        }

  
        public void reescribeCab(long pos)
        {
            FileStream stream;
            BinaryWriter writer;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.ReadWrite);
            writer = new BinaryWriter(stream);
            stream.Seek(0, SeekOrigin.Begin);
            writer.Write(pos);

            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
        }


        public void reescribeEntidad(Entidades ent, long pos)
        {
            FileStream stream;
            BinaryWriter writer;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.ReadWrite);
            writer = new BinaryWriter(stream);
            stream.Seek(pos, SeekOrigin.Begin);
            writer.Write(ent.nombre);
            writer.Write(ent.atrb);
            writer.Write(ent.ApDatos);
            writer.Write(ent.sig);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
        }

    
        public void reescribeAtributo(Atributos atrib, long pos)
        {
            FileStream stream;
            BinaryWriter writer;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.ReadWrite);
            writer = new BinaryWriter(stream);
            stream.Seek(pos, SeekOrigin.Begin);
            writer.Write(atrib.nombre);
            writer.Write(atrib.tipo);
            writer.Write(atrib.tam);
            writer.Write(atrib.esClave);
            writer.Write(atrib.siguienteAtrib);
            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();

        }

    
        public void reescribeBloque(Bloque bloque, long pos)
        {
            FileStream stream;
            BinaryWriter writer;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.ReadWrite);
            writer = new BinaryWriter(stream);
            stream.Seek(pos, SeekOrigin.Begin);
            writer.Write(bloque.bloque.ToArray());

            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
        }

   
        public void reescribeIndice(indice indice, long posInd)
        {
            FileStream stream;
            BinaryWriter writer;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.ReadWrite);
            writer = new BinaryWriter(stream);
            stream.Seek(posInd, SeekOrigin.Begin);
            writer.Write(indice.dameIni);
            writer.Write(indice.dameFin);
            writer.Write(indice.ApDatos);
            writer.Write(indice.ApSig);

            writer.Close();
            writer.Dispose();
            stream.Close();
            stream.Dispose();
        }

      
        public long EliminaEntidad(char[] nomEnt)
        {
            long pos = dameCab(), posAnt = 0;
            char[] nom = new char[30];
            Entidades ent = leeEntidad(pos), entAnt = new Entidades(nom);
            string nombre, auxent;

            auxent = new string(nomEnt);
            nombre = new string(ent.nombre);
            if (String.Compare(nombre, auxent) == 0)
            {
                reescribeCab(ent.sig);
                return pos;
            }
            else
            {
                while (pos != 1 && String.Compare(nombre, auxent) < 0)
                {
                    posAnt = pos;
                    entAnt = ent;
                    pos = ent.sig;
                    if (pos != 1)
                    {
                        ent = leeEntidad(pos);
                        nombre = new string(ent.nombre);
                    }
                }
                if (String.Compare(nombre, auxent) == 0)
                {
                    entAnt.sig = ent.sig;
                    reescribeEntidad(entAnt, posAnt);
                }
            }
            return pos;
        }

       
        public long eliminaAtributo(Entidades ent, long posEnt, char[] nomAtrib)
        {
            long cabAtrib = ent.atrb;
            long posAnt;
            Atributos atrib;
            Atributos atribAnt;
            string stAtrib;
            string chAtrib = new string(nomAtrib);

            if (cabAtrib != -1)
            {
                atrib = leeAtrib(cabAtrib);
                stAtrib = new string(atrib.nombre);
                if (string.Compare(stAtrib, chAtrib) == 0)
                {
                    ent.atrb = atrib.siguienteAtrib;
                    reescribeEntidad(ent, posEnt);
                }
                else
                {
                    posAnt = cabAtrib;
                    atribAnt = atrib;
                    while (cabAtrib != -1 && string.Compare(stAtrib, chAtrib) < 0)
                    {
                        posAnt = cabAtrib;
                        atribAnt = atrib;
                        cabAtrib = atrib.siguienteAtrib;
                        if (cabAtrib != -1)
                        {
                            atrib = leeAtrib(cabAtrib);
                            stAtrib = new string(atrib.nombre);
                        }
                    }
                    if (string.Compare(stAtrib, chAtrib) == 0)
                    {
                        atribAnt.siguienteAtrib = atrib.siguienteAtrib;
                        reescribeAtributo(atribAnt, posAnt);
                    }
                }
            }
            return cabAtrib;
        }

        public long tam()
        {
            long pos;

            FileStream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            pos = stream.Length;
            stream.Close();
            stream.Dispose();
            return pos;
        }

 
        public int dameTamaño(List<Atributos> lista)
        {
            int tam = 0;
            foreach (Atributos atrib in lista)
            {
                tam += atrib.tam;
            }
            tam += sizeof(long);
            return tam;
        }

      
        public long dameCab()
        {
            long cab = 0;
            FileStream stream;
            BinaryReader reader;

            stream = new FileStream(nombre, FileMode.Open, FileAccess.Read);
            reader = new BinaryReader(stream);
            stream.Seek(0, SeekOrigin.Begin);
            cab = reader.ReadInt64();

            reader.Close();
            reader.Dispose();
            stream.Close();
            stream.Dispose();
            return cab;
        }
    }
}
