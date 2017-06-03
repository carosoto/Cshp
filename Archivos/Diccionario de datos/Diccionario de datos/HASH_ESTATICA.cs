/*
░▐█▀▀▒▐█▀█▒▄█▀▀█░▐██▒██░░░▒▐█▀▀█▌▒██▄░▒█▌
░▐█▀▀▒▐█▄█▒▀▀█▄▄─░█▌▒██░░░▒▐█▄▒█▌▒▐█▒█▒█░
░▐█▄▄▒▐█░░▒█▄▄█▀░▐██▒██▄▄█▒▐██▄█▌▒██░▒██▌
Autor: Aarón Miranda Victorino
Proyecto : Diccionario de datos
Materia: Estructura de archivos
Correo: epsilon11101@gmail.com
Clase: HASH_ESTATICA
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Diccionario_de_datos
{// el cajon almacena las direcciones iniciales de las cubetas
    // las cubetas almacenan el valor y la direccion
    class HASH_ESTATICA
    {
        
          
         
        private List<Cajon> cajon;

        //constructor
        public HASH_ESTATICA()
        {
            cajon = new List<Cajon>();
        }
       //crear un cajon y asignar memoria
        public void Creacajon(Archivo arch)
        {
            for(int i = 0; i < 3; i++)
            {
                Cajon c = new Cajon();
                c.asignaMemoriaCajon(arch,i);
                cajon.Add(c);
            }
            cajon[0].AgregaCubetaEnteros(arch);
            cajon[0].GS_dirCubeta = cajon[0].GS_cubeta[0].GS_dirInicial;
            cajon[0].modificaCajon(arch);
        }
        //retorna direccion inicial de primer cajon
        public long direccionInicial()
        {
            return cajon[0].GS_dirInicial;
        }
        //metodo de acceso de cajones
        public List<Cajon> GS_CAJON
        {
            get { return cajon; }
            set { cajon = value; }
        }
        //asigna valor a las nuevas cubetas
        public void agregaValorenNuevaCubeta(Archivo arch, int caso, int valor, long dirValor)
        {
            int indice = 0;
            switch (caso)
            {
                case 0:
                    if(cajon[0].GS_cubeta[2].GS_dirSigCubeta == -1)
                    {
                        cajon[0].AgregaCubetaDesbordada(arch);
                        cajon[0].GS_cubeta[3].GS_valor = valor;
                        cajon[0].GS_cubeta[3].GS_dirvalor = dirValor;
                    }
                    else
                    {
                        indice = cajon[0].GS_CantidadValores() - 1;
                        if (indice >= 2 && indice < 5)
                        {
                            cajon[0].GS_cubeta[indice + 1].GS_valor = valor;
                            cajon[0].GS_cubeta[indice + 1].GS_dirvalor = dirValor;
                        }
                    }
                    break;
                case 1:
                    if (cajon[1].GS_cubeta[2].GS_dirSigCubeta == -1)
                    {
                        cajon[1].AgregaCubetaDesbordada(arch);
                        cajon[1].GS_cubeta[3].GS_valor = valor;
                        cajon[1].GS_cubeta[3].GS_dirvalor = dirValor;
                    }
                    else
                    {
                        indice = cajon[1].GS_CantidadValores() - 1;
                        if (indice >= 2 && indice < 5)
                        {
                            cajon[1].GS_cubeta[indice + 1].GS_valor = valor;
                            cajon[1].GS_cubeta[indice + 1].GS_dirvalor = dirValor;
                        }
                    }
                    break;
                case 2:
                    if (cajon[2].GS_cubeta[2].GS_dirSigCubeta == -1)
                    {
                        cajon[2].AgregaCubetaDesbordada(arch);
                        cajon[2].GS_cubeta[3].GS_valor = valor;
                        cajon[2].GS_cubeta[3].GS_dirvalor = dirValor;
                    }
                    else
                    {
                        indice = cajon[2].GS_CantidadValores() - 1;
                        if (indice >= 2 && indice < 5)
                        {
                            cajon[2].GS_cubeta[indice + 1].GS_valor = valor;
                            cajon[2].GS_cubeta[indice + 1].GS_dirvalor = dirValor;
                        }
                    }
                    break;
            }

            modifica(caso, arch);
        }
        
        //funcion para agregar valores enteros 
        public void agregaValorEntero(int valor,long dirValor,Archivo arch)
        {
            int modulo = valor % 3;
            int indice = 0;
            switch (modulo)
            {
                case 0:
                    cajon[0].GS_color = Color.Red;
                    indice = cajon[0].GS_CantidadValores() - 1;
                    if (indice >= 0 && indice < 2)
                    {
                        cajon[0].GS_cubeta[indice+1].GS_valor = valor;
                        cajon[0].GS_cubeta[indice+1].GS_dirvalor = dirValor;
                    }
                    else if(indice < 0 )
                    {
                        cajon[0].GS_cubeta[0].GS_valor = valor;
                        cajon[0].GS_cubeta[0].GS_dirvalor = dirValor;
                    }
                    else
                    {
                        agregaValorenNuevaCubeta(arch,modulo,valor,dirValor);
                    }
                    
                    break;
                case 1:

                    cajon[1].GS_color = Color.Purple;
                    indice = cajon[1].GS_CantidadValores() - 1;
                    if (indice >= 0 && indice < 2 && cajon[1].GS_dirCubeta != -1)
                    {
                            cajon[1].GS_cubeta[indice+1].GS_valor = valor;
                            cajon[1].GS_cubeta[indice+1].GS_dirvalor = dirValor;
                        
                    }
                    else  if(indice < 0 && cajon[1].GS_dirCubeta == -1)
                    {
                        
                        cajon[1].AgregaCubetaEnteros(arch);
                        indice = cajon[1].GS_CantidadValores() - 1;
                        if(indice < 0)
                        {
                            cajon[1].GS_cubeta[0].GS_valor = valor;
                            cajon[1].GS_cubeta[0].GS_dirvalor = dirValor;
                        }
                    }
                    else
                    {
                        agregaValorenNuevaCubeta(arch, modulo, valor, dirValor);
                    }
                    break;
                case 2:
                    cajon[2].GS_color = Color.Blue;
                    indice = cajon[2].GS_CantidadValores() - 1;
                    if (indice >= 0 && indice < 2 && cajon[2].GS_dirCubeta != -1)
                    {
                        cajon[2].GS_cubeta[indice+1].GS_valor = valor;
                        cajon[2].GS_cubeta[indice+1].GS_dirvalor = dirValor;

                    }
                    // inicializar cubeta 
                    else  if(indice < 0 && cajon[2].GS_dirCubeta == -1)
                    {

                        cajon[2].AgregaCubetaEnteros(arch);
                        indice = cajon[2].GS_CantidadValores() - 1;
                      
                        if(indice < 0)
                        {
                            cajon[2].GS_cubeta[0].GS_valor = valor;
                            cajon[2].GS_cubeta[0].GS_dirvalor = dirValor;
                        }
                    }
                    else
                    {
                        agregaValorenNuevaCubeta(arch, modulo, valor, dirValor);
                    }
                    break;
            }

            modifica(modulo,arch);
        }
        //reiniciar valores de cajones y cubetas
        public void reiniciaValores()
        {
            foreach(Cajon c in GS_CAJON)
            {
                foreach(cubeta cu in c.GS_cubeta)
                {
                    cu.GS_valor = -1;
                    cu.GS_dirvalor = -1;
                }
            }
            
        }
        //agrega valores a cubeta y cajones

        public void AgregaValores(DataGridView tabla, int filas,int posCelda,Archivo arch) {

            int c1, c2, c3;
            c1 = c2 = c3 = 0;
            for(int i = 0; i < filas; i++)
            {
                int modulo = Convert.ToInt32(tabla.Rows[i].Cells[posCelda].Value) % 3;
                switch (modulo)
                {

                    case 0:
                        reiniciaValores(c1++,modulo, Convert.ToInt32(tabla.Rows[i].Cells[posCelda].Value), Convert.ToInt64(tabla.Rows[i].Cells[0].Value),arch);
                        break;
                    case 1:
                        reiniciaValores(c2++, modulo, Convert.ToInt32(tabla.Rows[i].Cells[posCelda].Value), Convert.ToInt64(tabla.Rows[i].Cells[0].Value),arch);
                        break;
                    case 2:
                        reiniciaValores(c3++, modulo, Convert.ToInt32(tabla.Rows[i].Cells[posCelda].Value), Convert.ToInt64(tabla.Rows[i].Cells[0].Value),arch);
                        break;
                }


               
            }
           

        }
        //reinicia valores especificos

        public void reiniciaValores(int contador,int modulo, int valor , long dirValor,Archivo arch)
        {
            if (cajon[modulo].GS_dirCubeta != -1)
            {
                cajon[modulo].GS_cubeta[contador].GS_valor = valor;
                cajon[modulo].GS_cubeta[contador].GS_dirvalor = dirValor;
            }
            else
            {
                cajon[modulo].AgregaCubetaEnteros(arch);
                cajon[modulo].GS_cubeta[contador].GS_valor = valor;
                cajon[modulo].GS_cubeta[contador].GS_dirvalor = dirValor;
            }
            modifica(modulo, arch);

        }
        //modificar cajon

        private void modifica(int modulo,Archivo arch)
        {
            foreach (Cajon c in GS_CAJON)
            {

                cajon[modulo].modificaCajon(arch);
                for (int i = 0; i < c.GS_cubeta.Count; i++)
                {
                    c.GS_cubeta[i].modificaValores(arch);
                }

            }
        }



    }

}
