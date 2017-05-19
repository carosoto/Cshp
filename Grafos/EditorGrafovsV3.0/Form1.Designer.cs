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
            this.BotonVertice = new System.Windows.Forms.ToolStripButton();
            this.MueveNodo = new System.Windows.Forms.ToolStripButton();
            this.NoDirigida = new System.Windows.Forms.ToolStripButton();
            this.AristaDirigida = new System.Windows.Forms.ToolStripButton();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MenuIconos.SuspendLayout();
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
            this.MenuIconos.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuIconos.ForeColor = System.Drawing.Color.Black;
            this.MenuIconos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuIconos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BotonAbrir,
            this.BotonGuardar,
            this.BotonVertice,
            this.MueveNodo,
            this.NoDirigida,
            this.AristaDirigida});
            this.MenuIconos.Location = new System.Drawing.Point(0, 0);
            this.MenuIconos.Name = "MenuIconos";
            this.MenuIconos.Size = new System.Drawing.Size(25, 568);
            this.MenuIconos.TabIndex = 0;
            this.MenuIconos.Text = "MenuIconos";
            // 
            // BotonAbrir
            // 
            this.BotonAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BotonAbrir.Image = ((System.Drawing.Image)(resources.GetObject("BotonAbrir.Image")));
            this.BotonAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BotonAbrir.Name = "BotonAbrir";
            this.BotonAbrir.Size = new System.Drawing.Size(22, 24);
            this.BotonAbrir.Text = "Abrir";
            // 
            // BotonGuardar
            // 
            this.BotonGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BotonGuardar.Image = ((System.Drawing.Image)(resources.GetObject("BotonGuardar.Image")));
            this.BotonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BotonGuardar.Name = "BotonGuardar";
            this.BotonGuardar.Size = new System.Drawing.Size(22, 24);
            this.BotonGuardar.Text = "Guardar";
            // 
            // BotonVertice
            // 
            this.BotonVertice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BotonVertice.Image = ((System.Drawing.Image)(resources.GetObject("BotonVertice.Image")));
            this.BotonVertice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BotonVertice.Name = "BotonVertice";
            this.BotonVertice.Size = new System.Drawing.Size(22, 24);
            this.BotonVertice.Text = "Vertice";
            this.BotonVertice.Click += new System.EventHandler(this.BotonVertice_Click);
            // 
            // MueveNodo
            // 
            this.MueveNodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MueveNodo.Image = ((System.Drawing.Image)(resources.GetObject("MueveNodo.Image")));
            this.MueveNodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MueveNodo.Name = "MueveNodo";
            this.MueveNodo.Size = new System.Drawing.Size(22, 24);
            this.MueveNodo.Text = "Mover Nodo";
            this.MueveNodo.Click += new System.EventHandler(this.MueveNodo_Click);
            // 
            // NoDirigida
            // 
            this.NoDirigida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NoDirigida.Image = ((System.Drawing.Image)(resources.GetObject("NoDirigida.Image")));
            this.NoDirigida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NoDirigida.Name = "NoDirigida";
            this.NoDirigida.Size = new System.Drawing.Size(22, 24);
            this.NoDirigida.Text = "Arista No Dirigida";
            this.NoDirigida.Click += new System.EventHandler(this.NoDirigida_Click);
            // 
            // AristaDirigida
            // 
            this.AristaDirigida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AristaDirigida.Image = ((System.Drawing.Image)(resources.GetObject("AristaDirigida.Image")));
            this.AristaDirigida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AristaDirigida.Name = "AristaDirigida";
            this.AristaDirigida.Size = new System.Drawing.Size(22, 24);
            this.AristaDirigida.Text = "Arista Dirigida";
            this.AristaDirigida.Click += new System.EventHandler(this.AristaDirigida_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.Transparent;
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.Silver, System.Drawing.Color.Purple);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(726, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(726, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 568);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

