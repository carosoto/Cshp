using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{// el cajon almacena las direcciones iniciales de las cubetas
    // las cubetas almacenan el valor y la direccion
    class HASH_ESTATICA
    {
        private List<Cajon> cajon;

        public HASH_ESTATICA()
        {
            cajon = new List<Cajon>();
        }

        public void Creacajon(Archivo arch)
        {
            for(int i = 0; i < 3; i++)
            {
                Cajon c = new Cajon();
                c.asignaMemoriaCajon(arch);
            }
            cajon[0].AgregaCubetaEnteros(arch);
        }

    }

}
