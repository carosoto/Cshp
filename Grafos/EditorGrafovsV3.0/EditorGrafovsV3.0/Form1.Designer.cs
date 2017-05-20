namespace EditorGrafovsV3._0
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.metroToolbar1 = new DevComponents.DotNetBar.Metro.MetroToolbar();
            this.MenuIconos = new System.Windows.Forms.ToolStrip();
            this.BotonAbrir = new System.Windows.Forms.ToolStripButton();
            this.BotonGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BotonVertice = new System.Windows.Forms.ToolStripButton();
            this.MueveNodo = new System.Windows.Forms.ToolStripButton();
            this.BorrarNodo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NoDirigida = new System.Windows.Forms.ToolStripButton();
            this.AristaDirigida = new System.Windows.Forms.ToolStripButton();
            this.BorrarArista = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EliminarGrafo = new System.Windows.Forms.ToolStripButton();
            this.MoverGrafo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Recorrido = new System.Windows.Forms.ToolStripButton();
            this.Union = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.Cn = new System.Windows.Forms.ToolStripButton();
            this.Kn = new System.Windows.Forms.ToolStripButton();
            this.Wn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.Colorarios = new System.Windows.Forms.ToolStripButton();
            this.Homeomorfico = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.Complemento = new System.Windows.Forms.ToolStripButton();
            this.Euler = new System.Windows.Forms.ToolStripButton();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.MenuIconos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroToolbar1
            // 
            // 
            // 
            // 
            this.metroToolbar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroToolbar1.ContainerControlProcessDialogKey = true;
            this.metroToolbar1.Location = new System.Drawing.Point(0, 0);
            this.metroToolbar1.Name = "metroToolbar1";
            this.metroToolbar1.Size = new System.Drawing.Size(0, 28);
            this.metroToolbar1.TabIndex = 0;
            // 
            // MenuIconos
            // 
            this.MenuIconos.BackColor = System.Drawing.Color.Silver;
            this.MenuIconos.ForeColor = System.Drawing.Color.Black;
            this.MenuIconos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuIconos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BotonAbrir,
            this.BotonGuardar,
            this.toolStripSeparator3,
            this.BotonVertice,
            this.MueveNodo,
            this.BorrarNodo,
            this.toolStripSeparator1,
            this.NoDirigida,
            this.AristaDirigida,
            this.BorrarArista,
            this.toolStripSeparator2,
            this.EliminarGrafo,
            this.MoverGrafo,
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.Recorrido,
            this.Union,
            this.toolStripSeparator5,
            this.Cn,
            this.Kn,
            this.Wn,
            this.toolStripSeparator6,
            this.Colorarios,
            this.Homeomorfico,
            this.toolStripSeparator7,
            this.Complemento,
            this.Euler});
            this.MenuIconos.Location = new System.Drawing.Point(0, 0);
            this.MenuIconos.Name = "MenuIconos";
            this.MenuIconos.Size = new System.Drawing.Size(1016, 27);
            this.MenuIconos.TabIndex = 0;
            this.MenuIconos.Text = "MenuIconos";
            // 
            // BotonAbrir
            // 
            this.BotonAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BotonAbrir.Image = ((System.Drawing.Image)(resources.GetObject("BotonAbrir.Image")));
            this.BotonAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BotonAbrir.Name = "BotonAbrir";
            this.BotonAbrir.Size = new System.Drawing.Size(24, 24);
            this.BotonAbrir.Text = "Abrir";
            // 
            // BotonGuardar
            // 
            this.BotonGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BotonGuardar.Image = ((System.Drawing.Image)(resources.GetObject("BotonGuardar.Image")));
            this.BotonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BotonGuardar.Name = "BotonGuardar";
            this.BotonGuardar.Size = new System.Drawing.Size(24, 24);
            this.BotonGuardar.Text = "Guardar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // BotonVertice
            // 
            this.BotonVertice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BotonVertice.Image = ((System.Drawing.Image)(resources.GetObject("BotonVertice.Image")));
            this.BotonVertice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BotonVertice.Name = "BotonVertice";
            this.BotonVertice.Size = new System.Drawing.Size(24, 24);
            this.BotonVertice.Text = "Vertice";
            this.BotonVertice.Click += new System.EventHandler(this.BotonVertice_Click);
            // 
            // MueveNodo
            // 
            this.MueveNodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MueveNodo.Image = ((System.Drawing.Image)(resources.GetObject("MueveNodo.Image")));
            this.MueveNodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MueveNodo.Name = "MueveNodo";
            this.MueveNodo.Size = new System.Drawing.Size(24, 24);
            this.MueveNodo.Text = "Mover Nodo";
            this.MueveNodo.Click += new System.EventHandler(this.MueveNodo_Click);
            // 
            // BorrarNodo
            // 
            this.BorrarNodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BorrarNodo.Image = ((System.Drawing.Image)(resources.GetObject("BorrarNodo.Image")));
            this.BorrarNodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BorrarNodo.Name = "BorrarNodo";
            this.BorrarNodo.Size = new System.Drawing.Size(24, 24);
            this.BorrarNodo.Text = "BorrarNodo";
            this.BorrarNodo.Click += new System.EventHandler(this.BorrarNodo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // NoDirigida
            // 
            this.NoDirigida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NoDirigida.Image = ((System.Drawing.Image)(resources.GetObject("NoDirigida.Image")));
            this.NoDirigida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NoDirigida.Name = "NoDirigida";
            this.NoDirigida.Size = new System.Drawing.Size(24, 24);
            this.NoDirigida.Text = "Arista No Dirigida";
            this.NoDirigida.Click += new System.EventHandler(this.NoDirigida_Click);
            // 
            // AristaDirigida
            // 
            this.AristaDirigida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AristaDirigida.Image = ((System.Drawing.Image)(resources.GetObject("AristaDirigida.Image")));
            this.AristaDirigida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AristaDirigida.Name = "AristaDirigida";
            this.AristaDirigida.Size = new System.Drawing.Size(24, 24);
            this.AristaDirigida.Text = "Arista Dirigida";
            this.AristaDirigida.Click += new System.EventHandler(this.AristaDirigida_Click);
            // 
            // BorrarArista
            // 
            this.BorrarArista.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BorrarArista.Image = ((System.Drawing.Image)(resources.GetObject("BorrarArista.Image")));
            this.BorrarArista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BorrarArista.Name = "BorrarArista";
            this.BorrarArista.Size = new System.Drawing.Size(24, 24);
            this.BorrarArista.Text = "BorrarArista";
            this.BorrarArista.Click += new System.EventHandler(this.BorrarArista_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // EliminarGrafo
            // 
            this.EliminarGrafo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EliminarGrafo.Image = ((System.Drawing.Image)(resources.GetObject("EliminarGrafo.Image")));
            this.EliminarGrafo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EliminarGrafo.Name = "EliminarGrafo";
            this.EliminarGrafo.Size = new System.Drawing.Size(24, 24);
            this.EliminarGrafo.Text = "EliminarGrafo";
            this.EliminarGrafo.Click += new System.EventHandler(this.EliminarGrafo_Click);
            // 
            // MoverGrafo
            // 
            this.MoverGrafo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoverGrafo.Image = ((System.Drawing.Image)(resources.GetObject("MoverGrafo.Image")));
            this.MoverGrafo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoverGrafo.Name = "MoverGrafo";
            this.MoverGrafo.Size = new System.Drawing.Size(24, 24);
            this.MoverGrafo.Text = "MoverGrafo";
            this.MoverGrafo.Click += new System.EventHandler(this.MoverGrafo_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // Recorrido
            // 
            this.Recorrido.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Recorrido.Image = ((System.Drawing.Image)(resources.GetObject("Recorrido.Image")));
            this.Recorrido.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Recorrido.Name = "Recorrido";
            this.Recorrido.Size = new System.Drawing.Size(24, 24);
            this.Recorrido.Text = "Recorrido";
            this.Recorrido.Click += new System.EventHandler(this.Recorrido_Click);
            // 
            // Union
            // 
            this.Union.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Union.Image = ((System.Drawing.Image)(resources.GetObject("Union.Image")));
            this.Union.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Union.Name = "Union";
            this.Union.Size = new System.Drawing.Size(24, 24);
            this.Union.Text = "Union";
            this.Union.Click += new System.EventHandler(this.Union_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // Cn
            // 
            this.Cn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Cn.Image = ((System.Drawing.Image)(resources.GetObject("Cn.Image")));
            this.Cn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cn.Name = "Cn";
            this.Cn.Size = new System.Drawing.Size(24, 24);
            this.Cn.Text = "Cn";
            this.Cn.Click += new System.EventHandler(this.Cn_Click);
            // 
            // Kn
            // 
            this.Kn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Kn.Image = ((System.Drawing.Image)(resources.GetObject("Kn.Image")));
            this.Kn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Kn.Name = "Kn";
            this.Kn.Size = new System.Drawing.Size(24, 24);
            this.Kn.Text = "Kn";
            this.Kn.Click += new System.EventHandler(this.Kn_Click);
            // 
            // Wn
            // 
            this.Wn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Wn.Image = ((System.Drawing.Image)(resources.GetObject("Wn.Image")));
            this.Wn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Wn.Name = "Wn";
            this.Wn.Size = new System.Drawing.Size(24, 24);
            this.Wn.Text = "Wn";
            this.Wn.Click += new System.EventHandler(this.Wn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // Colorarios
            // 
            this.Colorarios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Colorarios.Image = ((System.Drawing.Image)(resources.GetObject("Colorarios.Image")));
            this.Colorarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Colorarios.Name = "Colorarios";
            this.Colorarios.Size = new System.Drawing.Size(24, 24);
            this.Colorarios.Text = "Colorarios";
            this.Colorarios.Click += new System.EventHandler(this.Colorarios_Click);
            // 
            // Homeomorfico
            // 
            this.Homeomorfico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Homeomorfico.Image = ((System.Drawing.Image)(resources.GetObject("Homeomorfico.Image")));
            this.Homeomorfico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Homeomorfico.Name = "Homeomorfico";
            this.Homeomorfico.Size = new System.Drawing.Size(24, 24);
            this.Homeomorfico.Text = "Homeomorfico";
            this.Homeomorfico.Click += new System.EventHandler(this.Homeomorfico_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // Complemento
            // 
            this.Complemento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Complemento.Image = ((System.Drawing.Image)(resources.GetObject("Complemento.Image")));
            this.Complemento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Complemento.Name = "Complemento";
            this.Complemento.Size = new System.Drawing.Size(24, 24);
            this.Complemento.Text = "Complemento";
            this.Complemento.Click += new System.EventHandler(this.Complemento_Click);
            // 
            // Euler
            // 
            this.Euler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Euler.Image = ((System.Drawing.Image)(resources.GetObject("Euler.Image")));
            this.Euler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Euler.Name = "Euler";
            this.Euler.Size = new System.Drawing.Size(24, 24);
            this.Euler.Text = "Euler";
            this.Euler.Click += new System.EventHandler(this.Euler_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.Transparent;
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.Silver, System.Drawing.Color.Purple);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(28, 421);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 568);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.MenuIconos);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MenuIconos.ResumeLayout(false);
            this.MenuIconos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroToolbar metroToolbar1;
        private System.Windows.Forms.ToolStrip MenuIconos;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ToolStripButton BotonAbrir;
        private System.Windows.Forms.ToolStripButton BotonGuardar;
        private System.Windows.Forms.ToolStripButton BotonVertice;
        private System.Windows.Forms.ToolStripButton NoDirigida;
        private System.Windows.Forms.ToolStripButton AristaDirigida;
        private System.Windows.Forms.ToolStripButton MueveNodo;
        private System.Windows.Forms.ToolStripButton BorrarNodo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BorrarArista;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton EliminarGrafo;
        private System.Windows.Forms.ToolStripButton MoverGrafo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton Recorrido;
        private System.Windows.Forms.ToolStripButton Union;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton Cn;
        private System.Windows.Forms.ToolStripButton Kn;
        private System.Windows.Forms.ToolStripButton Wn;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton Colorarios;
        private System.Windows.Forms.ToolStripButton Homeomorfico;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton Complemento;
        private System.Windows.Forms.ToolStripButton Euler;
    }
}

