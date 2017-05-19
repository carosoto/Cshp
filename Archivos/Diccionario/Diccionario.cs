using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Diccionario
{
    class Diccionario
    {
        public Archivo arch;
        public List<Entidades> ListaEnt;
        public long cab;

        
        public Diccionario()
        {
            arch = new Archivo();
            ListaEnt = new List<Entidades>();
            cab = -1;
            menuPrincipal();
        }

        /// <summary>
        /// Metodo para hacer el Menu Principal de la Secuencial.
        /// </summary>
        public void menuPrincipal()
        {
            int opcion = -1;

            do
            {
                Console.Clear();
                //Console.BackgroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("___________________________________________________\n");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("____________SECUENCIAL INDEXADA________________\n");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("____________________MENU___________________________\n");
                Console.Write("1).-Abrir\n");
                Console.Write("2).-Nuevo\n");
                Console.Write("3).-Diccionario Datos\n");
                Console.Write("4).-Salir\n");
                Console.Write("\t\tOpcion: ");
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Escribe una opcion numerica");
                    System.Threading.Thread.Sleep(1000);
                    menuPrincipal();
                }
            } while (opcion > 3);
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    if (arch.abreArchivo())
                    {
                        menuArchivo();
                    }
                    else
                    {
                        Console.WriteLine("No existe el archivo...");
                        System.Threading.Thread.Sleep(1000);
                        menuPrincipal();
                    }
                    break;
                case 2:
                    Console.Clear();
                    arch.CreaArchivo();
                    menuArchivo();
                    break;
                case 3:
                    Console.WriteLine("NECESITAS CREAR UN ARCHIVO NUEVO O ABRIRLO");
                    break;
                case 4:
                    Environment.Exit(1);
                    break;
                default:
                    break;
            }
        }

        public void menuArchivo()
        {
            int opcion = -1;

            do
            {
                Console.Clear();
                //Console.BackgroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("___________________________________________________\n");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("____________SECUENCIAL INDEXADA________________\n");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("____________________MENU_ENTIDADES______________________\n");
                Console.WriteLine("1.- Alta de Entidades.");
                Console.WriteLine("2.- Baja de Entidades.");
                Console.WriteLine("3.- Consulta de Entidades.");
                Console.WriteLine("4.- Modificar Entidades.");
                Console.WriteLine("5.- Menu de Atributos.");
                Console.WriteLine("6.- Menu de Datos");
                Console.WriteLine("7.- Salir");
                Console.WriteLine("\nOpcion:");
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Escribe una opcion numerica");
                    System.Threading.Thread.Sleep(1000);
                    menuArchivo();
                }

            } while (opcion > 7);
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    altaEntidad();
                    break;
                case 2:
                    bajaEntidad();
                    break;
                case 3:
                    consultaEntidad();
                    break;
                case 4:
                    modificaEntidad();
                    break;
                case 5:
                    menuAtributos();
                    break;
                case 6:
                    menuDatos();
                    break;
                case 7:
                    menuPrincipal();
                    break;
            }
        }

        private void menuAtributos()
        {
            int opcion = -1;

            do
            {
                Console.Clear();
                //Console.BackgroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("___________________________________________________\n");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("____________SECUENCIAL INDEXADA________________\n");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("____________________MENU_ATRIBUTOS_____________________\n");
                Console.WriteLine("1.- Alta Atributo.");
                Console.WriteLine("2.- Baja de Atributo.");
                Console.WriteLine("3.- Consulta De Atributos.");
                Console.WriteLine("4.- Modificar un Atributo.");
                Console.WriteLine("5.- Salir");
                Console.WriteLine("\nOpcion:");
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Escribe una opcion numerica");
                    System.Threading.Thread.Sleep(1000);
                    menuAtributos();
                }
            } while (opcion > 6);
            switch (opcion)
            {
                case 1:
                    altaAtributo();
                    break;
                case 2:
                    bajaAtributo();
                    break;
                case 3:
                    consultaAtributos();
                    break;
                case 4:
                    modificaAtributo();
                    break;
                case 5:
                    menuArchivo();
                    break;
            }
        }

        public void menuDatos()
        {
            int opcion = -1;
            indexada org = new indexada(this);

            do
            {
                Console.Clear();
                //Console.BackgroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("___________________________________________________\n");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("____________SECUENCIAL INDEXADA________________\n");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("____________________MENU__DATOS_________________________\n");
                Console.WriteLine("");
                Console.WriteLine("1.- Alta Indexada");
                Console.WriteLine("2.- Baja Indexada");
                Console.WriteLine("3.- Consultar Datos");
                Console.WriteLine("4.- Modificar Datos");
                Console.WriteLine("5.- Salir");
                Console.WriteLine("\nOpcion:");
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Escribe una opcion numerica");
                    System.Threading.Thread.Sleep(1000);
                    menuAtributos();
                }
            } while (opcion > 6);
            switch (opcion)
            {
                case 1:
                    org.altaIndexada();
                    break;
                case 2:
                    org.bajaIndexada();
                    break;
                case 3:
                    org.consultaIndexada();
                    break;
                case 4:
                    org.modificaindexada();
                    break;
                case 5:
                    menuAtributos();
                    break;
            }
        }

        public void altaEntidad()
        {
            string nombre;
            char[] nom = new char[30];
            long pos;
            Console.WriteLine("Escribe el nombre de la entidad:");
            nombre = Console.ReadLine();
            if (nombre.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("Escribe un nombre:");
                System.Threading.Thread.Sleep(1000);
                menuArchivo();
            }
            nom = convierte(nombre);
            Entidades ent = new Entidades(nom);
            ent.pos = arch.tam();
            if (buscaEntNombre(nom) == false)
            {
                pos = arch.EscribeEntidad(ent);
                arch.insertaEntidad(ent, pos);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("La entidad ya existe");
                System.Threading.Thread.Sleep(1000);
            }
            menuArchivo();
        }
        public bool buscaEntNombre(char[] nombre)
        {
            Entidades ent;
            long pos = arch.dameCab();
            string auxNom = new string(nombre), auxEnt;

            while (pos != -1)
            {
                ent = arch.leeEntidad(pos);
                auxEnt = new string(ent.nombre);
                if (string.Compare(auxEnt, auxNom) == 0)
                {
                    return true;
                }
                pos = ent.sig;
            }

            return false;
        }
        public void altaAtributo()
        {
            string nombre;
            string resp;
            char[] nomEnt = new char[30];
            char[] nomAt = new char[30];
            long posEnt = -1, posAtrib = -1;
            Entidades ent;
            Atributos atrib;

            imprimeEntidades();
            nombre = pideNomEnt();
            nomEnt = convierte(nombre);
            posEnt = damePosEnt(nomEnt);
            if (posEnt != 0)
            {
                ent = arch.leeEntidad(posEnt);
                if (ent.ApDatos == -1)
                {
                    atrib = dameAtributo();

                    if (buscaAtrib(ent, atrib.nombre) == false)
                    {
                        if (buscaClave(ent) == true)
                        {
                            Console.WriteLine("Quieres que el atributo sea clave primaria??");
                            do
                            {
                                Console.WriteLine("SI o NO");
                                resp = Console.ReadLine();
                            } while (resp != "si" && resp != "no");
                            if (resp == "si")
                            {
                                atrib.esClave = true;
                            }
                            else
                            {
                                atrib.esClave = false;
                            }
                        }
                        posAtrib = arch.escribeAtributo(atrib);
                        arch.insertaAtributo(ent, posEnt, atrib, posAtrib);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Este atributo YA existe");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("Ya existen datos en esta entidad, No es posible agregar atributos");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No existe esta entidad");
                System.Threading.Thread.Sleep(1000);
            }
            menuAtributos();
        }

        public void bajaEntidad()
        {
            string nombre;
            char[] nom = new char[30];
            long pos;
            Entidades ent;

            Console.Clear();
            imprimeEntidades();
            Console.WriteLine("Escribe el nombre de la entidad:");
            nombre = Console.ReadLine();
            nom = convierte(nombre);
            pos = damePosEnt(nom);
            if (pos != -1)
            {
                ent = arch.leeEntidad(pos);
                if (ent.ApDatos == -1)
                    pos = arch.EliminaEntidad(nom);
                else
                {
                    Console.WriteLine("La entidad YA tiene datos. No es posible eliminar");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No existe esta entidad");
                System.Threading.Thread.Sleep(1000);
            }
            menuArchivo();
        }

        public void bajaAtributo()
        {
            string nomEnt;
            string nomAtrib;
            char[] charEnt = new char[30];
            char[] charAtrib = new char[30];
            long posEnt;
            Entidades ent;

            Console.Clear();
            imprimeEntidades();
            Console.WriteLine("Escribe el nombre de la entidad");
            nomEnt = Console.ReadLine();
            charEnt = convierte(nomEnt);
            if (buscaEntNombre(charEnt))
            {
                posEnt = damePosEnt(charEnt);
                ent = arch.leeEntidad(posEnt);
                if (ent.ApDatos == -1)
                {
                    imprimeAtributos(ent);
                    Console.WriteLine("Escribe el nombre del atributo");
                    nomAtrib = Console.ReadLine();
                    charAtrib = convierte(nomAtrib);
                    if (buscaAtrib(ent, charAtrib))
                    {
                        posEnt = arch.eliminaAtributo(ent, posEnt, charAtrib);
                    }
                    else
                    {
                        Console.WriteLine("Este atributo NO existe");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("La entidad YA tiene datos. No es posible eliminar atributos");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Esta entidad NO existe");
                System.Threading.Thread.Sleep(1000);
            }
            menuAtributos();
        }

        public void consultaEntidad()
        {
            long aux = 0;
            Entidades ent;

            Console.Clear();
            aux = arch.dameCab();
            while (aux != -1)
            {
                ent = arch.leeEntidad(aux);
                Console.Write("Nombre: ");
                Console.WriteLine(ent.nombre);
                Console.Write("Posicion: ");
                Console.WriteLine(aux);
                Console.Write("Atributos: ");
                Console.WriteLine(ent.atrb);
                Console.Write("AptrSig: ");
                Console.WriteLine(ent.sig);
                Console.WriteLine(" ");
                aux = ent.sig;
            }
            Console.ReadLine();
            menuArchivo();
        }

        public void consultaAtributos()
        {
            long aux = 0;
            long posAtrib = 0;
            Entidades ent;
            string nomEnt;
            char[] charEnt = new char[30];
            Atributos atrib;

            Console.Clear();
            imprimeEntidades();
            Console.WriteLine("Escribe el nombre de la entidad:");
            nomEnt = Console.ReadLine();
            charEnt = convierte(nomEnt);
            if (buscaEntNombre(charEnt))
            {
                aux = damePosEnt(charEnt);
                ent = arch.leeEntidad(aux);
                posAtrib = ent.atrb;
                while (posAtrib != -1)
                {
                    atrib = arch.leeAtrib(posAtrib);
                    Console.WriteLine(" ");
                    Console.Write("Nombre: ");
                    Console.WriteLine(atrib.nombre);
                    Console.Write("Posicion: ");
                    Console.WriteLine(posAtrib);
                    Console.Write("Tipo: ");
                    switch (atrib.tipo)
                    {
                        case 1:
                            Console.WriteLine("Cadena");
                            break;
                        case 2:
                            Console.WriteLine("Entero");
                            break;
                        case 3:
                            Console.WriteLine("Flotante");
                            break;
                        case 4:
                            Console.WriteLine("Caracter");
                            break;
                    }
                    Console.Write("Tamaño: ");
                    if (atrib.tipo == 1)
                        Console.WriteLine(atrib.tam / sizeof(char));
                    else
                        Console.WriteLine(atrib.tam);
                    Console.Write("Siguiente: ");
                    Console.WriteLine(atrib.siguienteAtrib);
                    posAtrib = atrib.siguienteAtrib;
                }
            }
            else
            {
                Console.WriteLine("Esta entidad NO existe");
                System.Threading.Thread.Sleep(1000);
            }
            Console.ReadLine();
            menuAtributos();

        }

        public void imprimeEntidades()
        {
            long aux = 0;
            Entidades ent;

            Console.Clear();
            aux = arch.dameCab();
            while (aux != -1)
            {
                ent = arch.leeEntidad(aux);
                Console.Write("Nombre: ");
                Console.WriteLine(ent.nombre);
                aux = ent.sig;
            }
        }

        public void imprimeAtributos(Entidades ent)
        {
            long aux = ent.atrb;
            Atributos atrib;

            while (aux != -1)
            {
                atrib = arch.leeAtrib(aux);
                Console.Write(atrib.nombre);
                switch (atrib.tipo)
                {
                    case 1:
                        Console.WriteLine("Cadena");
                        break;
                    case 2:
                        Console.WriteLine("Entero");
                        break;
                    case 3:
                        Console.WriteLine("Flotante");
                        break;
                    case 4:
                        Console.WriteLine("Char");
                        break;
                }
                aux = atrib.siguienteAtrib;
            }
        }

        public static string dameCadFija(string cad, int tam)
        {
            char[] arr = new char[tam];
            for (int i = 0; i < tam && i < cad.Length; i++)
            {
                arr[i] = cad[i];
            }
            cad = new string(arr);
            return cad;
        }

        public void modificaEntidad()
        {
            long aux = 0, pos = 0;
            Entidades ent;
            string nombreEnt;
            char[] nom = new char[30];
            char[] nomN = new char[30];
            do
            {
                Console.Clear();
                imprimeEntidades();
                Console.WriteLine("Escribe el nombre de la entidad a modificar:");
                nombreEnt = Console.ReadLine();
                nom = convierte(nombreEnt);
            } while (buscaEntNombre(nom) == false);
            if (buscaEntNombre(nom))
            {
                pos = damePosEnt(nom);
                ent = arch.leeEntidad(pos);
                if (ent.ApDatos == -1)
                {
                    Console.WriteLine("Escribe el nuevo nombre de la entidad:");
                    nombreEnt = Console.ReadLine();
                    nomN = convierte(nombreEnt);
                    if (!buscaEntNombre(nomN))
                    {
                        aux = damePosEnt(nom);
                        ent = arch.leeEntidad(aux);
                        Entidades entN = new Entidades(nomN);
                        entN.atrb = ent.atrb;
                        entN.ApDatos = ent.ApDatos;
                        pos = arch.EliminaEntidad(nom);
                        arch.reescribeEntidad(entN, pos);
                        arch.insertaEntidad(entN, pos);
                    }
                    else
                    {
                        Console.WriteLine("La Entidad Ya existe");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("La entidad YA tiene datos. No es posible modificar");
                    Console.ReadLine();
                }
            }
            menuArchivo();
        }

        public void modificaAtributo()
        {
            string nomEnt;
            string nomAtrib;
            char[] chEnt = new char[30];
            char[] chAtrib = new char[30];
            long posEnt;
            long posAtrib;
            long posViejo;
            Entidades ent;
            Atributos viejo, atribN;

            Console.Clear();
            imprimeEntidades();
            Console.WriteLine("Escribe el nombre de la entidad:");
            nomEnt = Console.ReadLine();
            chEnt = convierte(nomEnt);
            if (buscaEntNombre(chEnt))
            {
                posEnt = damePosEnt(chEnt);
                ent = arch.leeEntidad(posEnt);
                if (ent.ApDatos == -1)
                {
                    imprimeAtributos(ent);
                    Console.WriteLine("Escribe el nombre del atributo a modificar:");
                    nomAtrib = Console.ReadLine();
                    chAtrib = convierte(nomAtrib);
                    if (buscaAtrib(ent, chAtrib))
                    {
                        posViejo = damePosAtrib(ent, chAtrib);
                        viejo = arch.leeAtrib(posViejo);
                        Console.Clear();
                        Console.WriteLine("Datos del nuevo atributo");
                        atribN = dameAtributo();
                        if (buscaAtrib(ent, atribN.nombre))
                        {
                            if (atribN.tipo != viejo.tipo)
                            {
                                posAtrib = arch.eliminaAtributo(ent, posEnt, chAtrib);
                                arch.reescribeAtributo(atribN, posAtrib);
                                arch.insertaAtributo(ent, posEnt, atribN, posAtrib);
                            }
                            else
                            {
                                Console.WriteLine("Ya existe un atributo con este nombre!!");
                                System.Threading.Thread.Sleep(1000);
                            }
                        }
                        else
                        {
                            //El atributo no existe
                            posAtrib = arch.eliminaAtributo(ent, posEnt, chAtrib);
                            arch.reescribeAtributo(atribN, posAtrib);
                            arch.insertaAtributo(ent, posEnt, atribN, posAtrib);
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO se encontro el atributo");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("La entidad ya tiene datos. No es posible modificar atributos");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("La Entidad no existe");
                System.Threading.Thread.Sleep(1000);
            }
            menuAtributos();
        }

        public long buscaEntidad(Entidades ent)
        {
            long pos = arch.dameCab();
            Entidades entA;
            string auxEnt = new string(ent.nombre), auxEntA;

            while (cab != -1)
            {
                entA = arch.leeEntidad(cab);
                auxEntA = new string(entA.nombre);
                if (String.Compare(auxEnt, auxEntA) == 0)
                {
                    return pos;
                }
                pos = entA.sig;
            }

            return 0;
        }

        public bool buscaAtrib(Entidades ent, char[] nomAtrib)
        {
            Atributos atrib;
            long cabAtrib;
            string stAtrib, stNom = new string(nomAtrib);

            cabAtrib = ent.atrb;
            while (cabAtrib != -1)
            {
                atrib = arch.leeAtrib(cabAtrib);
                stAtrib = new string(atrib.nombre);
                if (string.Compare(stAtrib, stNom) == 0)
                    return true;
                cabAtrib = atrib.siguienteAtrib;
            }
            return false;
        }

        public bool buscaClave(Entidades ent)
        {
            long cabAtrib;
            bool band = true;
            Atributos atrib;

            cabAtrib = ent.atrb;
            while (cabAtrib != -1)
            {
                atrib = arch.leeAtrib(cabAtrib);
                if (atrib.esClave == true)
                    band = false;
                cabAtrib = atrib.siguienteAtrib;
            }
            return band;
        }

        public long damePosEnt(char[] nomEnt)
        {
            long cab = arch.dameCab();
            Entidades ent;
            string stEnt, stNom = new string(nomEnt); ;

            while (cab != -1)
            {
                ent = arch.leeEntidad(cab);
                stEnt = new string(ent.nombre);
                if (string.Compare(stEnt, stNom) == 0)
                {
                    return cab;
                }
                cab = ent.sig;
            }

            return -1;
        }

        public long damePosAtrib(Entidades ent, char[] nomAtrib)
        {
            long cab = ent.atrb;
            Atributos aux;
            string stAux, sAtrib = new string(nomAtrib);

            while (cab != 1)
            {
                aux = arch.leeAtrib(cab);
                stAux = new string(aux.nombre);
                if (string.Compare(stAux, sAtrib) == 0)
                {
                    return cab;
                }
                cab = aux.siguienteAtrib;
            }
            return -1;
        }

        

        public string pideNomAtrib()
        {
            Console.Clear();
            Console.WriteLine("Escribe el nombre del atributo:");
            return Console.ReadLine();
        }

        public Atributos dameAtributo()
        {
            Atributos atrib = new Atributos();
            string Aux;
            Int16 tipo = -1;
            int tam = 0;

            Console.WriteLine("Escribe el nombre del atributo");
            Aux = Console.ReadLine();
            if (Aux.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("Escribe un nombre");
                System.Threading.Thread.Sleep(1000);
                menuAtributos();
            }
            atrib.nombre = convierte(Aux);
            do
            {
                Console.Clear();
                Console.WriteLine("1.- Cadena");
                Console.WriteLine("2.- Entero");
                Console.WriteLine("3.- Flotante");
                Console.WriteLine("4.- Char");
                Console.WriteLine("Escribe el tipo de atributo");
                try
                {
                    tipo = Convert.ToInt16(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Escribe una opcion numerica");
                    System.Threading.Thread.Sleep(1000);
                }
            } while (tipo >= 5);
            atrib.tipo = tipo;
            switch (tipo)
            {
                case 1:
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Escribe el tamaño de la cadena");
                        try
                        {
                            tam = Convert.ToInt16(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Escribe una opcion numerica");
                            System.Threading.Thread.Sleep(1000);
                        }
                        atrib.tam = sizeof(char) * tam;
                    } while (tam == 0);
                    break;
                case 2:
                    atrib.tam = sizeof(int);
                    break;
                case 3:
                    atrib.tam = sizeof(double);
                    break;
                case 4:
                    atrib.tam = sizeof(char);
                    break;
            }
            atrib.siguienteAtrib = -1;
            return atrib;
        }

        public string pideNomEnt()
        {
            Console.WriteLine("Escribe el nombre de la entidad:");
            return Console.ReadLine();
        }

        public static char[] convierte(string palabra)
        {
            char[] aux = new char[30];
            int i = 0;
            foreach (char a in palabra)
            {
                aux[i] = a;
                i++;
            }
            return aux;
        }

        public List<Entidades> dameEntidades()
        {
            List<Entidades> listaEntidades = new List<Entidades>();
            long cabEnt = arch.dameCab();
            Entidades ent = null;

            while (cabEnt != -1)
            {
                ent = arch.leeEntidad(cabEnt);
                ent.atributos = dameAtributos(ent);
                listaEntidades.Add(ent);
            }
            return listaEntidades;
        }

        public List<Atributos> dameAtributos(Entidades ent)
        {
            List<Atributos> atributos = new List<Atributos>();
            Atributos atributo = null;
            long cabAtrib = ent.atrb;

            while (cabAtrib != -1)
            {
                atributo = arch.leeAtrib(cabAtrib);
                atributo.posicion = cabAtrib;
                atributos.Add(atributo);
                cabAtrib = atributo.siguienteAtrib;
            }

            return atributos;
        }

        internal void iniciaSecuencia()
        {
            List<Entidades> listaEntidades = dameEntidades();
        }
    }
}
