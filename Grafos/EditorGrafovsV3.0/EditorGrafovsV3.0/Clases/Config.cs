using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace EditorGrafovsV3._0.Clases
{
    [Serializable]
   public class Config
    {
       
        

            private short radio;
            private float tamaño_arista;
            private Color color_relleno, color_contorno;
            private Color color_linea;
            private Color color_letra;
            private Color color_fondo;
            Font tipo_letra;
            public float GS_tamañoArista
            {
                get { return tamaño_arista; }
                set { tamaño_arista = value; }
            }
            public short GS_radio
            {
                get { return radio; }
                set { radio = value; }
            }
            public Color GS_colorRelleno
            {
                get { return color_relleno; }
                set { color_relleno = value; }
            }

            public Color GS_colorContorno
            {
                get { return color_contorno; }
                set { color_contorno = value; }
            }
            public Color GS_colorLinea
            {
                get { return color_linea; }
                set { color_linea = value; }
            }
            public Color GS_colorLetra
            {
                get { return color_letra; }
                set { color_letra = value; }
            }
            public Color GS_colorFondo
            {
                get { return color_fondo; }
                set { color_fondo = value; }
            }
            public Font GS_tipoLetra
            {
                get { return tipo_letra; }
                set { tipo_letra = value; }
            }
            public Config()
            {

            }
        }
    }

