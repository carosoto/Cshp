using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    class Cajon
    {
        private long  dir_inicial;
        private long dir_final;
        private long direccion_cubeta;
        private List<cubeta> Cubeta;
        public Cajon()
        {
            dir_inicial = dir_final = direccion_cubeta = -1;
            Cubeta = new List<cubeta>();

        }

        public long GS_dirCubeta
        {
            get { return direccion_cubeta; }
            set { direccion_cubeta = value; }
        }

        public long GS_dirFinal
        {
            get { return GS_dirFinal; }
            set { GS_dirFinal = value; }
        }

        public long GS_dirInicial
        {
            get { return dir_inicial; }
            set { dir_inicial = value; }
        }



    }
}
