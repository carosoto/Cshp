using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafovsV3._0.Clases
{
    [Serializable]
    public class Banderas
    {
        /************************************************+Variables***********************************************************/
        private List<Boolean> flags;
        private List<String> nombres;
        /***********************************************Constructor************************************************************/
        public Banderas()
        {

            flags = new List<Boolean>();
            nombres = new List<string>();
        }

        /************************************************Metodos de acceso*****************************************************/
        public Boolean dame_bandera(String nombre)
        {
            int i = 0;
            for(; i < nombres.Count; i++) { if (nombre == nombres[i]) break; }

            return flags[i];
        }
        public void modifica_bandera(String nombre , Boolean new_value)
        {
            int i = 0;
            for (; i < nombres.Count; i++) { if (nombre == nombres[i]) break; }
            flags[i] = new_value;
        }


        /************************************************Metodos de clase*****************************************************/

        public void nueva_bandera(String nombre, Boolean value)
        {
            nombres.Add(nombre);
            flags.Add(value);
        }




    }
}
