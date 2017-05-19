using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EditorGrafovsV3._0.Clases;
namespace EditorGrafovsV3._0
{
    public partial class Configuracion : DevComponents.DotNetBar.Metro.MetroForm
    {
        
        public delegate void dame_datos(Config configuracion);
        public event dame_datos obtener;
        private ColorDialog c;
        private FontDialog f;
        private Color color_nodo, color_contorno, color_arista, color_letra, color_fondo;
        private Font tipo_letra;
        private short radio, op;
        private float tamaño_arista;
        private Config config;
        public Configuracion(Color fondo)
        {
            InitializeComponent();
            c = new ColorDialog();
            f = new FontDialog();
            tipo_letra = new Font("Arial", 10);
            color_contorno = System.Drawing.Color.Black;
            color_nodo = System.Drawing.Color.Azure;
            color_arista = System.Drawing.Color.Black;
            color_letra = System.Drawing.Color.Black;
            color_fondo = fondo;
            tamaño_arista = 1;
            radio = 20;
            Tamanio.SelectedIndex = 0;
            config = new Config();
            actualiza();
        }
        public Configuracion(Config aux)
        {
            InitializeComponent();
            c = new ColorDialog();
            f = new FontDialog();
            tipo_letra = aux.GS_tipoLetra;
            color_contorno = aux.GS_colorContorno;
            color_nodo = aux.GS_colorRelleno;
            color_arista = aux.GS_colorLinea;
            color_letra = aux.GS_colorLetra;
            color_fondo = aux.GS_colorFondo;
            radio = aux.GS_radio;
            tamaño_arista = aux.GS_tamañoArista;
            Tamanio.Text = radio.ToString();
            numericUpDown1.Value = (decimal)aux.GS_tamañoArista;
            config = new Config();
            actualiza();
        }

        private void Color_Click(object sender, EventArgs e) //color_fondo
        {
            c.ShowDialog();
            switch (op)
            {
                case 1:
                    color_nodo = c.Color;
                    break;
                case 2:
                    color_letra = c.Color;
                    break;
                case 4:
                    color_arista = c.Color;
                    break;
                case 5:
                    color_fondo = c.Color;
                    break;
            }


            this.Invalidate();
        }

        private void letra_Select_CheckedChanged(object sender, EventArgs e)
        {
            op = 2;
            button1.Enabled = false;
            Tamanio.Enabled = false;
            letra.Enabled = true;
            numericUpDown1.Enabled = false;
        }

        private void Tamanio_SelectedIndexChanged(object sender, EventArgs e)
        {
            radio = Convert.ToInt16(Tamanio.SelectedItem);
            this.Invalidate();
        }

        private void arista_Select_CheckedChanged(object sender, EventArgs e)
        {
            op = 4;
            button1.Enabled = false;
            Tamanio.Enabled = false;
            Tamanio.Visible = false;
            letra.Enabled = false;
            numericUpDown1.Enabled = true;
            numericUpDown1.Visible = true;
        }

        private void actualiza()
        {
            config.GS_colorRelleno = color_nodo;
            config.GS_colorContorno = color_contorno;
            config.GS_tipoLetra = tipo_letra;
            config.GS_colorLinea = color_arista;
            config.GS_colorLetra = color_letra;
            config.GS_colorFondo = color_fondo;
            config.GS_radio = radio;
            config.GS_tamañoArista = tamaño_arista;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            actualiza();
            obtener(config);
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            tamaño_arista = (float)numericUpDown1.Value;
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.ShowDialog();
            color_contorno = c.Color;
            this.Invalidate();
        }

        private void fondo_Select_CheckedChanged(object sender, EventArgs e)
        {
            op = 5;
            button1.Enabled = false;
            Tamanio.Enabled = false;
            letra.Enabled = false;
            numericUpDown1.Enabled = false;

        }

        private void Configuracion_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(color_fondo), 40, 170, 85, 85);
            e.Graphics.FillRectangle(new SolidBrush(color_fondo), 40, 170, 85, 85);
            e.Graphics.FillEllipse(new SolidBrush(color_nodo), 70, 200, radio, radio);
            e.Graphics.DrawEllipse(new Pen(color_contorno), 70, 200, radio, radio);
            e.Graphics.DrawString("A", tipo_letra, new SolidBrush(color_letra), 65 + radio / 2, 195 + radio / 2);
            e.Graphics.DrawLine(new Pen(color_arista, tamaño_arista), 50, 175, 50, 245);
        }

        private void letra_Click(object sender, EventArgs e)
        {
            f.ShowDialog();
            f.MinSize = 5;
            f.MaxSize = 10;
            color_letra = f.Color;
            tipo_letra = f.Font;
            this.Invalidate();
        }

        private void vertice_Select_CheckedChanged(object sender, EventArgs e)
        {
            op = 1;
            button1.Enabled = true;
            Tamanio.Enabled = true;
            letra.Enabled = false;
            Tamanio.Visible = true;
            numericUpDown1.Visible = false;
        }

        public Config GS_config
        {
            get { return config; }
        }

    }
}
