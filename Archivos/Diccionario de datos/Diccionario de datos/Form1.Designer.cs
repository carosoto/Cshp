namespace Diccionario_de_datos
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
            this.label1 = new System.Windows.Forms.Label();
            this.EntidadText = new System.Windows.Forms.TextBox();
            this.Nuevo = new System.Windows.Forms.Button();
            this.Modificar = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Grabar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Atributos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Entidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Datos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sig_Entidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atributosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.atributosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.datosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entidad";
            // 
            // EntidadText
            // 
            this.EntidadText.BackColor = System.Drawing.Color.Silver;
            this.EntidadText.Enabled = false;
            this.EntidadText.ForeColor = System.Drawing.Color.Black;
            this.EntidadText.Location = new System.Drawing.Point(71, 32);
            this.EntidadText.Margin = new System.Windows.Forms.Padding(2);
            this.EntidadText.Name = "EntidadText";
            this.EntidadText.Size = new System.Drawing.Size(98, 20);
            this.EntidadText.TabIndex = 1;
            // 
            // Nuevo
            // 
            this.Nuevo.BackColor = System.Drawing.Color.Silver;
            this.Nuevo.Enabled = false;
            this.Nuevo.ForeColor = System.Drawing.Color.Black;
            this.Nuevo.Location = new System.Drawing.Point(30, 61);
            this.Nuevo.Margin = new System.Windows.Forms.Padding(2);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(61, 19);
            this.Nuevo.TabIndex = 2;
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.UseVisualStyleBackColor = false;
            this.Nuevo.Click += new System.EventHandler(this.Nuevo_Click);
            // 
            // Modificar
            // 
            this.Modificar.BackColor = System.Drawing.Color.Silver;
            this.Modificar.Enabled = false;
            this.Modificar.ForeColor = System.Drawing.Color.Black;
            this.Modificar.Location = new System.Drawing.Point(106, 61);
            this.Modificar.Margin = new System.Windows.Forms.Padding(2);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(61, 19);
            this.Modificar.TabIndex = 3;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseVisualStyleBackColor = false;
            this.Modificar.Click += new System.EventHandler(this.Modificar_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.BackColor = System.Drawing.Color.Silver;
            this.Eliminar.Enabled = false;
            this.Eliminar.ForeColor = System.Drawing.Color.Black;
            this.Eliminar.Location = new System.Drawing.Point(183, 61);
            this.Eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(61, 19);
            this.Eliminar.TabIndex = 4;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = false;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // Grabar
            // 
            this.Grabar.BackColor = System.Drawing.Color.Silver;
            this.Grabar.Enabled = false;
            this.Grabar.ForeColor = System.Drawing.Color.Black;
            this.Grabar.Location = new System.Drawing.Point(258, 61);
            this.Grabar.Margin = new System.Windows.Forms.Padding(2);
            this.Grabar.Name = "Grabar";
            this.Grabar.Size = new System.Drawing.Size(61, 19);
            this.Grabar.TabIndex = 5;
            this.Grabar.Text = "Grabar";
            this.Grabar.UseVisualStyleBackColor = false;
            this.Grabar.Click += new System.EventHandler(this.Grabar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Dir_Atributos,
            this.Dir_Entidad,
            this.Dir_Datos,
            this.Sig_Entidad});
            this.dataGridView1.Location = new System.Drawing.Point(8, 109);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(511, 252);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Dir_Atributos
            // 
            this.Dir_Atributos.HeaderText = "Dir Atributos";
            this.Dir_Atributos.Name = "Dir_Atributos";
            // 
            // Dir_Entidad
            // 
            this.Dir_Entidad.HeaderText = "Dir Entidad";
            this.Dir_Entidad.Name = "Dir_Entidad";
            // 
            // Dir_Datos
            // 
            this.Dir_Datos.HeaderText = "Dir Datos";
            this.Dir_Datos.Name = "Dir_Datos";
            // 
            // Sig_Entidad
            // 
            this.Sig_Entidad.HeaderText = "Sig Entidad";
            this.Sig_Entidad.Name = "Sig_Entidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Entidades";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Enabled = false;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(336, 60);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 19);
            this.button1.TabIndex = 9;
            this.button1.Text = "Actualiza";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.ForeColor = System.Drawing.Color.Black;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(531, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atributosToolStripMenuItem,
            this.atributosToolStripMenuItem1,
            this.datosToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 22);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // atributosToolStripMenuItem
            // 
            this.atributosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.abrirToolStripMenuItem1});
            this.atributosToolStripMenuItem.Name = "atributosToolStripMenuItem";
            this.atributosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.atributosToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.abrirToolStripMenuItem.Text = "Nuevo";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem1
            // 
            this.abrirToolStripMenuItem1.Name = "abrirToolStripMenuItem1";
            this.abrirToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.abrirToolStripMenuItem1.Text = "Abrir";
            this.abrirToolStripMenuItem1.Click += new System.EventHandler(this.abrirToolStripMenuItem1_Click);
            // 
            // atributosToolStripMenuItem1
            // 
            this.atributosToolStripMenuItem1.Name = "atributosToolStripMenuItem1";
            this.atributosToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.atributosToolStripMenuItem1.Text = "Atributos";
            this.atributosToolStripMenuItem1.Click += new System.EventHandler(this.atributosToolStripMenuItem1_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.Silver, System.Drawing.Color.MediumPurple);
            // 
            // datosToolStripMenuItem
            // 
            this.datosToolStripMenuItem.Name = "datosToolStripMenuItem";
            this.datosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.datosToolStripMenuItem.Text = "Datos";
            this.datosToolStripMenuItem.Click += new System.EventHandler(this.datosToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 369);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Grabar);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.Modificar);
            this.Controls.Add(this.Nuevo);
            this.Controls.Add(this.EntidadText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "ENTIDADES";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EntidadText;
        private System.Windows.Forms.Button Nuevo;
        private System.Windows.Forms.Button Modificar;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button Grabar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Atributos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Entidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Datos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sig_Entidad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atributosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem atributosToolStripMenuItem1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ToolStripMenuItem datosToolStripMenuItem;
    }
}

