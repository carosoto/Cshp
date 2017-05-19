using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Diccionario
{
    class indexada
    {
          Diccionario dic;

        public indexada(Diccionario diccionario)
        {
            this.dic = diccionario;
        }

        public void altaIndexada()
        {
            char[] nomEnt = new char[30];
            List<Atributos> listaAtrib = new List<Atributos>();
            Entidades ent;
            string aux;
            long posEnt;
            long pos;
            indice indice = null;
            Bloque bl = new Bloque();
            long posInd;

            Console.Clear();
            dic.imprimeEntidades();
            aux = dic.pideNomEnt();
            nomEnt = Diccionario.convierte(aux);
            posEnt = dic.damePosEnt(nomEnt);
            if (posEnt != -1)
            {
                ent = dic.arch.leeEntidad(posEnt);
                listaAtrib = dic.dameAtributos(ent);
                if (Entidades.tieneClave(listaAtrib))
                {
                    bl.bloque = pideBloque(listaAtrib);
                    posInd = damePosInd(ent, posEnt, bl, listaAtrib);
                    indice = dic.arch.leeIndice(posInd);
                    if (buscaBloque(indice, bl, listaAtrib) == false)
                    {
                        pos = dic.arch.escribeBloque(bl, listaAtrib);
                        insertaBloque(indice, posInd, bl, pos, listaAtrib);
                    }
                    else
                    {
                        Console.WriteLine("Este dato YA existe");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("La entidad NO tiene clave primaria");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("No existe esta entidad!!");
                Console.ReadLine();
            }
            dic.menuDatos();
        }

        public void consultaIndexada()
        {
            char[] nomEnt = new char[30];
            Entidades ent;
            string aux;
            long posEnt;

            Console.Clear();
            dic.imprimeEntidades();
            aux = dic.pideNomEnt();
            nomEnt = Diccionario.convierte(aux);
            posEnt = dic.damePosEnt(nomEnt);
            if (posEnt != -1)
            {
                ent = dic.arch.leeEntidad(posEnt);
                imprimeDatos(ent);
            }
            Console.ReadLine();
            dic.menuDatos();
        }

        public void bajaIndexada()
        {
            char[] nomEnt = new char[30];
            List<Atributos> listaAtrib = new List<Atributos>();
            Entidades ent;
            string aux;
            long posEnt;
            long pos;
            indice indice = null;
            Bloque bl = new Bloque();
            long posInd;

            Console.Clear();
            dic.imprimeEntidades();
            aux = dic.pideNomEnt();
            nomEnt = Diccionario.convierte(aux);
            posEnt = dic.damePosEnt(nomEnt);
            if (posEnt != -1)
            {
                ent = dic.arch.leeEntidad(posEnt);
                listaAtrib = dic.dameAtributos(ent);
                imprimeDatos(ent);
                if (tieneClave(listaAtrib))
                {
                    bl.bloque = pideBloqueClave(listaAtrib);
                    indice = buscaIndXbloque(bl, listaAtrib);
                    posInd = buscaIndice(ent, indice);
                    if (posInd != -1)
                    {
                        indice = dic.arch.leeIndice(posInd);
                        pos = eliminaBloque(indice, posInd, bl, listaAtrib);
                        indice = dic.arch.leeIndice(posInd);
                        if (indice.ApDatos == -1)
                        {
                            eliminaIndice(ent, posEnt, indice);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontro el Indice: {0}", indice.dameIni.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("La entidad NO tiene atributos clave");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("No existe esta entidad");
                Console.ReadLine();
            }
            dic.menuDatos();
        }

        public void modificaindexada()
        {
            string aux;
            char[] nomEnt = new char[30];
            long posEnt, posBloque, posIndice;
            long posMod;
            Entidades ent;
            Bloque bloque = new Bloque();
            Bloque modificado;
            List<Atributos> listAtrib;
            indice indice = null;
            indice IndMod = null;

            Console.Clear();
            dic.imprimeEntidades();
            aux = dic.pideNomEnt();
            nomEnt = Diccionario.convierte(aux);
            posEnt = dic.damePosEnt(nomEnt);
            if (posEnt != -1)
            {
                ent = dic.arch.leeEntidad(posEnt);
                imprimeDatos(ent);
                listAtrib = dic.dameAtributos(ent);
                if (tieneClave(listAtrib))
                {
                    bloque.bloque = pideBloqueClave(listAtrib);
                    posIndice = damePosInd(ent, posEnt, bloque, listAtrib);
                    indice = dic.arch.leeIndice(posIndice);
                    if (buscaBloque(indice, bloque, listAtrib))
                    {
                        bloque.bloque = dameBloqueEntero(indice, bloque, listAtrib);
                        posBloque = damePosBloque(indice, bloque, listAtrib);
                        modificado = new Bloque();
                        modificado.bloque = pideBloque(listAtrib);
                        if (comparaBloque(bloque, modificado, listAtrib) == 0)
                        {
                            //mismo atributo clave
                            modificado.ponApuntador(Bloque.dameApSig(bloque));
                            dic.arch.reescribeBloque(modificado, posBloque);
                        }
                        else
                        {
                            posMod = damePosInd(ent, posEnt, modificado, listAtrib);
                            IndMod = dic.arch.leeIndice(posMod);
                            indice = dic.arch.leeIndice(posIndice);
                            if (!buscaBloque(IndMod, modificado, listAtrib) && !buscaBloque(indice, modificado, listAtrib))
                            {
                                posBloque = eliminaBloque(indice, posIndice, bloque, listAtrib);
                                dic.arch.reescribeBloque(modificado, posBloque);
                                if (indice.dameIni != IndMod.dameIni)
                                {

                                    insertaBloque(IndMod, posMod, modificado, posBloque, listAtrib);
                                }
                                else
                                {
                                    insertaBloque(indice, posIndice, modificado, posBloque, listAtrib);
                                }
                                indice = dic.arch.leeIndice(posIndice);
                                if (indice.ApDatos == -1)
                                {
                                    eliminaIndice(ent, posEnt, indice);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("El dato NO existe");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("La entidad NO tiene clave primaria");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("La entidad NO existe");
                Console.ReadLine();
            }
            dic.menuDatos();
        }

        public void imprimeDatos(Entidades ent)
        {
            string aux, cad;
            long cabInd;
            long cabDatos;
            double flot;
            int tam, entero, pos;
            char car;
            Bloque bloque = null;
            indice indice = null;
            List<Atributos> listAtrib = new List<Atributos>();

            listAtrib = dic.dameAtributos(ent);
            cabInd = ent.ApDatos;
            while (cabInd != -1)
            {
                indice = dic.arch.leeIndice(cabInd);
                aux = indice.dameIni.ToString() + " - " + indice.dameFin.ToString();
                Console.WriteLine("Indice : {0}", aux);
                cabDatos = indice.ApDatos;
                while (cabDatos != -1)
                {
                    bloque = dic.arch.leeBloque(cabDatos, listAtrib);
                    pos = sizeof(long);
                    foreach (Atributos atrib in listAtrib)
                    {
                        aux = new string(atrib.nombre);
                        switch (atrib.tipo)
                        {
                            case 1:
                                tam = sizeof(char) * atrib.tam;
                                cad = Bloque.dameCad(bloque.bloque.GetRange(pos, atrib.tam));
                                Console.WriteLine("{0}: {1}", aux, cad);
                                pos += atrib.tam;
                                break;
                            case 2:
                                entero = BitConverter.ToInt32(bloque.bloque.GetRange(pos, atrib.tam).ToArray(), 0);
                                Console.WriteLine("{0}: {1}", aux, entero);
                                pos += atrib.tam;
                                break;
                            case 3:
                                flot = BitConverter.ToDouble(bloque.bloque.GetRange(pos, atrib.tam).ToArray(), 0);
                                Console.WriteLine("{0}: {1}", aux, flot);
                                pos += atrib.tam;
                                break;
                            case 4:
                                car = BitConverter.ToChar(bloque.bloque.GetRange(pos, atrib.tam).ToArray(), 0);
                                Console.WriteLine("{0}: {1}", aux, car);
                                pos += atrib.tam;
                                break;
                        }
                    }
                    //Console.WriteLine();
                    cabDatos = Bloque.dameApSig(bloque);
                }
                cabInd = indice.ApSig;
            }
        }

        bool tieneClave(List<Atributos> lista)
        {
            bool band = false;

            foreach (Atributos atrib in lista)
            {
                if (atrib.esClave)
                {
                    band = true;
                }
            }
            return band;
        }

        public List<byte> pideBloque(List<Atributos> lista)
        {
            List<byte> bloque = new List<byte>();
            long pos = -1;
            string cad, nom;
            int entero;
            float flotante;
            char caracter;
            string aux = null;

            bloque.AddRange(BitConverter.GetBytes(pos));
            foreach (Atributos atrib in lista)
            {
                nom = new string(atrib.nombre);
                Console.WriteLine("Dame la clave " + nom);
                switch (atrib.tipo)
                {
                    case 1:
                        cad = Console.ReadLine();
                        aux = completaCad(cad, atrib.tam);
                        bloque.AddRange(Bloque.cadenaBytes(aux));
                        break;
                    case 2:
                        while (!int.TryParse(Console.ReadLine(), out entero)) ;
                        bloque.AddRange(BitConverter.GetBytes(entero));
                        break;
                    case 3:
                        while (!float.TryParse(Console.ReadLine(), out flotante)) ;
                        bloque.AddRange(BitConverter.GetBytes(flotante));
                        break;
                    case 4:
                        while (!char.TryParse(Console.ReadLine(), out caracter)) ;
                        bloque.AddRange(BitConverter.GetBytes(caracter));
                        break;
                }
            }
            return bloque;
        }

        long damePosInd(Entidades ent, long posEnt, Bloque bloque, List<Atributos> listaAtrib)
        {

            indice indBloque = buscaIndXbloque(bloque, listaAtrib);
            long posInd = buscaIndice(ent, indBloque);

            if (posInd == -1)
            {
                posInd = dic.arch.escribeIndice(indBloque);
                insertaIndice(ent, posEnt, indBloque, posInd);
                return buscaIndice(ent, indBloque);

            }
            return posInd;
        }

        public indice buscaIndXbloque(Bloque bloque, List<Atributos> listaAtrib)
        {
            int pos = sizeof(long);
            int ent;
            char car;
            string cad;
            double flot;
            Atributos clave = null;
            List<byte> aux;
            indice indice = null;

            foreach (Atributos atrib in listaAtrib)
            {
                if (atrib.esClave)
                {
                    clave = atrib;
                    break;
                }
                pos += atrib.tam;
            }

            aux = bloque.bloque.GetRange(pos, clave.tam);
            indice = new indice();
            switch (clave.tipo)
            {
                case 1:
                    cad = Bloque.dameCad(aux);
                    ent = (int)cad.ToUpper()[0];
                    indice.dameIni = (((ent - 65) / 3) + 1);
                    indice.dameFin = indice.dameIni;
                    break;
                case 2:
                    ent = BitConverter.ToInt32(aux.ToArray(), 0);
                    indice.dameIni = (ent / 10) * 10;
                    indice.dameFin = indice.dameIni + 9;
                    break;
                case 3:
                    flot = BitConverter.ToDouble(aux.ToArray(), 0);
                    ent = (int)Math.Floor(flot);
                    indice.dameIni = (ent / 10) * 10;
                    indice.dameFin = indice.dameIni + 9;
                    break;
                case 4:
                    car = BitConverter.ToChar(aux.ToArray(), 0);
                    ent = (int)car.ToString().ToUpper()[0];
                    indice.dameIni = (((ent - 65) / 3) + 1);
                    indice.dameFin = indice.dameIni;
                    break;
            }
            return indice;

        }

        public bool buscaBloque(indice indice, Bloque bloque, List<Atributos> listaAtrib)
        {
            Bloque bAux = new Bloque();
            long cab = indice.ApDatos;

            if (cab != -1)
            {
                bAux = dic.arch.leeBloque(cab, listaAtrib);
                while (cab != -1 && comparaBloque(bloque, bAux, listaAtrib) > 0)
                {
                    cab = Bloque.dameApSig(bAux);
                    if (cab != -1)
                    {
                        bAux = dic.arch.leeBloque(cab, listaAtrib);
                    }
                }
                if (comparaBloque(bloque, bAux, listaAtrib) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public long buscaIndice(Entidades ent, indice indice)
        {
            long cabInd;
            indice indAux;

            cabInd = ent.ApDatos;
            if (cabInd == -1)
                return cabInd;
            else
            {
                indAux = dic.arch.leeIndice(cabInd);
            }

            while (cabInd != -1 && indAux.dameIni != indice.dameIni && indAux.dameFin != indice.dameFin)
            {
                cabInd = indAux.ApSig;
                if (cabInd != -1)
                {
                    indAux = dic.arch.leeIndice(cabInd);
                }
            }

            if (indAux.dameIni == indice.dameIni)
                return cabInd;
            else
                return -1;
        }

        public void insertaIndice(Entidades ent, long posEnt, indice indice, long posInd)
        {
            long cabInd;
            long posAnt;
            indice indAux = null;
            indice indAnt = null;

            cabInd = ent.ApDatos;
            if (cabInd == -1)
            {
                ent.ApDatos = posInd;
                dic.arch.reescribeEntidad(ent, posEnt);
            }
            else
            {
                indAux = dic.arch.leeIndice(cabInd);
                if (indice.dameIni < indAux.dameIni)
                {
                    indice.ApSig = cabInd;
                    ent.ApDatos = posInd;
                    dic.arch.reescribeEntidad(ent, posEnt);
                    dic.arch.reescribeIndice(indice, posInd);
                }
                else
                {
                    posAnt = cabInd;
                    indAnt = indAux;
                    while (cabInd != -1 && indAux.dameIni < indice.dameIni)
                    {
                        posAnt = cabInd;
                        indAnt = indAux;
                        cabInd = indAux.ApSig;
                        if (cabInd != -1)
                        {
                            indAux = dic.arch.leeIndice(cabInd);
                        }
                    }
                    indice.ApSig = indAnt.ApSig;
                    indAnt.ApSig = posInd;
                    dic.arch.reescribeIndice(indAnt, posAnt);
                    indAux = dic.arch.leeIndice(posAnt);
                    dic.arch.reescribeIndice(indice, posInd);
                }
            }
        }

        public void insertaBloque(indice indice, long posInd, Bloque bloque, long posBloque, List<Atributos> listAtrib)
        {
            long cab = indice.ApDatos;
            long posAnt;
            Bloque auxB = new Bloque();
            Bloque ant = new Bloque();

            if (cab == -1)
            {
                indice.ApDatos = posBloque;
                dic.arch.reescribeIndice(indice, posInd);
            }
            else
            {
                auxB = dic.arch.leeBloque(cab, listAtrib);
                if (comparaBloque(auxB, bloque, listAtrib) > 0)
                {
                    bloque.ponApuntador(cab);
                    indice.ApDatos = posBloque;
                    dic.arch.reescribeIndice(indice, posInd);
                    dic.arch.reescribeBloque(bloque, posBloque);
                }
                else
                {
                    posAnt = cab;
                    ant = auxB;
                    while (cab != -1 && comparaBloque(auxB, bloque, listAtrib) < 0)
                    {
                        posAnt = cab;
                        ant = auxB;
                        cab = Bloque.dameApSig(auxB);
                        if (cab != -1)
                        {
                            auxB = dic.arch.leeBloque(cab, listAtrib);
                        }
                    }
                    bloque.ponApuntador(Bloque.dameApSig(ant));
                    ant.ponApuntador(posBloque);
                    dic.arch.reescribeBloque(ant, posAnt);
                    dic.arch.reescribeBloque(bloque, posBloque);
                }
            }
        }

        public long eliminaBloque(indice indice, long posInd, Bloque bloque, List<Atributos> listAtrib)
        {
            long cabD = indice.ApDatos;
            long posAnt;
            Bloque bloqeuAux;
            Bloque bloqueAnt;

            if (cabD != -1)
            {
                bloqeuAux = dic.arch.leeBloque(cabD, listAtrib);
                if (comparaBloque(bloqeuAux, bloque, listAtrib) == 0)
                {
                    indice.ApDatos = Bloque.dameApSig(bloqeuAux);
                    dic.arch.reescribeIndice(indice, posInd);
                }
                else
                {
                    posAnt = cabD;
                    bloqueAnt = bloqeuAux;
                    while (cabD != -1 && comparaBloque(bloque, bloqeuAux, listAtrib) > 0)
                    {
                        posAnt = cabD;
                        bloqueAnt = bloqeuAux;
                        cabD = Bloque.dameApSig(bloqeuAux);
                        if (cabD != -1)
                        {
                            bloqeuAux = dic.arch.leeBloque(cabD, listAtrib);
                        }
                    }
                    if (comparaBloque(bloqeuAux, bloque, listAtrib) == 0)
                    {
                        bloqueAnt.ponApuntador(Bloque.dameApSig(bloqeuAux));
                        dic.arch.reescribeBloque(bloqueAnt, posAnt);
                    }
                }
            }
            return cabD;
        }

        public void eliminaIndice(Entidades ent, long posEnt, indice indice)
        {
            long cabInd;
            indice indAux;
            indice indAnt;
            long posAnt;

            if (ent.ApDatos != -1)
            {
                cabInd = ent.ApDatos;
                indAux = dic.arch.leeIndice(cabInd);
                if (indAux.dameIni == indice.dameIni)
                {
                    ent.ApDatos = indAux.ApSig;
                    dic.arch.reescribeEntidad(ent, posEnt);
                }
                else
                {
                    indAnt = indAux;
                    posAnt = cabInd;
                    while (cabInd != -1 && indAux.dameIni < indice.dameIni)
                    {
                        indAnt = indAux;
                        posAnt = cabInd;
                        cabInd = indAux.ApSig;
                        if (cabInd != -1)
                        {
                            indAux = dic.arch.leeIndice(cabInd);
                        }
                    }
                    if (indice.dameIni == indAux.dameIni)
                    {
                        indAnt.ApSig = indAux.ApSig;
                        dic.arch.reescribeIndice(indAnt, posAnt);
                    }
                }
            }
        }

        public int comparaBloque(Bloque b1, Bloque b2, List<Atributos> listAtrib)
        {
            int res = 0;
            Atributos clave = null;
            int pos = sizeof(long);
            int ent1, ent2;
            double flot1, flot2;
            char car1, car2;
            string cad1, cad2;
            List<byte> aux1, aux2;

            foreach (Atributos atrib in listAtrib)
            {
                if (atrib.esClave)
                {
                    clave = atrib;
                    break;
                }
                pos += atrib.tam;
            }

            aux1 = b1.bloque.GetRange(pos, clave.tam);
            aux2 = b2.bloque.GetRange(pos, clave.tam);

            switch (clave.tipo)
            {
                case 1:
                    cad1 = BitConverter.ToString(aux1.ToArray());
                    cad2 = BitConverter.ToString(aux2.ToArray());
                    return cad1.CompareTo(cad2);
                break;
                case 2:
                    ent1 = BitConverter.ToInt32(aux1.ToArray(), 0);
                    ent2 = BitConverter.ToInt32(aux2.ToArray(), 0);
                    return ent1.CompareTo(ent2);
                break;
                case 3:
                    flot1 = BitConverter.ToDouble(aux1.ToArray(), 0);
                    flot2 = BitConverter.ToDouble(aux2.ToArray(), 0);
                    return flot1.CompareTo(flot2);
                break;
                case 4:
                    car1 = BitConverter.ToChar(aux1.ToArray(), 0);
                    car2 = BitConverter.ToChar(aux2.ToArray(), 0);
                    return car1.CompareTo(car2);
                break;
            }
            return res;
        }

        public List<byte> pideBloqueClave(List<Atributos> lista)
        {
            List<byte> bloque = new List<byte>();
            byte[] espacio;
            string cad, aux;
            long aptr = -1;
            double flot;
            int ent;
            char car;

            bloque.AddRange(BitConverter.GetBytes(aptr));
            foreach (Atributos atrib in lista)
            {
                aux = new string(atrib.nombre);
                if (atrib.tipo == 1)
                {
                    if (atrib.esClave)
                    {
                        Console.WriteLine("Escribe {0} clave(cadena[{1}]:", aux, atrib.tam / sizeof(char));
                        cad = Diccionario.dameCadFija(Console.ReadLine(), atrib.tam);
                        bloque.AddRange(Bloque.cadenaBytes(cad));
                    }
                    else
                    {
                        espacio = new byte[atrib.tam];
                        bloque.AddRange(espacio);
                    }
                }
                else
                {
                    if (!atrib.esClave)
                    {
                        espacio = new byte[atrib.tam];
                        bloque.AddRange(espacio);
                    }
                    else
                    {
                        switch (atrib.tipo)
                        {
                            case 2:
                                Console.WriteLine("Escribe {0} clave (entero)", aux);
                                while (!int.TryParse(Console.ReadLine(), out ent)) ;
                                bloque.AddRange(BitConverter.GetBytes(ent));
                                break;
                            case 3:
                                Console.WriteLine("Escribe {0} clave (double)", aux);
                                while (!double.TryParse(Console.ReadLine(), out flot)) ;
                                bloque.AddRange(BitConverter.GetBytes(flot));
                                break;
                            case 4:
                                Console.WriteLine("Escribe {0} clave (char)", aux);
                                while (!char.TryParse(Console.ReadLine(), out car)) ;
                                bloque.AddRange(BitConverter.GetBytes(car));
                                break;
                        }
                    }
                }
            }
            return bloque;
        }

        public List<byte> dameBloqueEntero(indice indice, Bloque bloque, List<Atributos> listAtrib)
        {
            Bloque aux = null;
            Atributos clave;
            long datos;
            Bloque auxB;

            if (indice.ApDatos == -1)
            {
                aux = null;
            }
            else
            {
                clave = dameAtribClave(listAtrib);
                datos = indice.ApDatos;
                while (datos != -1)
                {
                    auxB = dic.arch.leeBloque(datos, listAtrib);
                    if (comparaBloque(bloque, auxB, listAtrib) == 0)
                    {
                        aux = auxB;
                        break;
                    }
                    datos = BitConverter.ToInt64(auxB.bloque.GetRange(0, sizeof(long)).ToArray(), 0);
                }
            }
            return aux.bloque;
        }

        public long damePosBloque(indice indice, Bloque bloque, List<Atributos> listaAtrib)
        {
            Bloque bloqueAux;
            long cabD = indice.ApDatos;

            if (cabD != -1)
            {
                while (cabD != -1)
                {
                    bloqueAux = dic.arch.leeBloque(cabD, listaAtrib);
                    if (comparaBloque(bloqueAux, bloque, listaAtrib) == 0)
                    {
                        return cabD;
                    }
                    else
                    {
                        cabD = Bloque.dameApSig(bloqueAux);
                    }
                }
            }
            return -1;
        }

        public string completaCad(string cad, int tam)
        {
            char[] arr = new char[tam / sizeof(char)];
            for (int i = 0; i < cad.Length; i++)
            {
                arr[i] = cad[i];
            }
            string res = new string(arr, 0, tam / sizeof(char));

            return res;
        }

        public Atributos dameAtribClave(List<Atributos> listaAtrib)
        {
            foreach (Atributos atrib in listaAtrib)
            {
                if (atrib.esClave)
                {
                    return atrib;

                }
            }
            return null;
        }

    }
}
