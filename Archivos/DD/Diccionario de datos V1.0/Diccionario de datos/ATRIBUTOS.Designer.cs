namespace Diccionario_de_datos
{
    partial class ATRIBUTOS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATRIBUTOS));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.Longitud = new System.Windows.Forms.TextBox();
            this.Entidad = new System.Windows.Forms.ComboBox();
            this.Tipo = new System.Windows.Forms.ComboBox();
            this.Clave = new System.Windows.Forms.ComboBox();
            this.Nuevo = new System.Windows.Forms.Button();
            this.Modificar = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Grabar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Actualiza = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(27, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(319, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Longitud";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(319, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo de clave";
            // 
            // Nombre
            // 
            this.Nombre.BackColor = System.Drawing.Color.Silver;
            this.Nombre.Enabled = false;
            this.Nombre.ForeColor = System.Drawing.Color.Black;
            this.Nombre.Location = new System.Drawing.Point(113, 59);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(100, 26);
            this.Nombre.TabIndex = 5;
            // 
            // Longitud
            // 
            this.Longitud.BackColor = System.Drawing.Color.Silver;
            this.Longitud.Enabled = false;
            this.Longitud.ForeColor = System.Drawing.Color.Black;
            this.Longitud.Location = new System.Drawing.Point(448, 12);
            this.Longitud.Name = "Longitud";
            this.Longitud.Size = new System.Drawing.Size(121, 26);
            this.Longitud.TabIndex = 6;
            // 
            // Entidad
            // 
            this.Entidad.BackColor = System.Drawing.Color.Silver;
            this.Entidad.Enabled = false;
            this.Entidad.ForeColor = System.Drawing.Color.Black;
            this.Entidad.FormattingEnabled = true;
            this.Entidad.Location = new System.Drawing.Point(113, 15);
            this.Entidad.Name = "Entidad";
            this.Entidad.Size = new System.Drawing.Size(121, 28);
            this.Entidad.TabIndex = 7;
            this.Entidad.SelectedIndexChanged += new System.EventHandler(this.Entidad_SelectedIndexChanged);
            // 
            // Tipo
            // 
            this.Tipo.BackColor = System.Drawing.Color.Silver;
            this.Tipo.Enabled = false;
            this.Tipo.ForeColor = System.Drawing.Color.Black;
            this.Tipo.FormattingEnabled = true;
            this.Tipo.Items.AddRange(new object[] {
            "INT",
            "CHAR"});
            this.Tipo.Location = new System.Drawing.Point(113, 98);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(121, 28);
            this.Tipo.TabIndex = 8;
            this.Tipo.SelectedIndexChanged += new System.EventHandler(this.Tipo_SelectedIndexChanged);
            // 
            // Clave
            // 
            this.Clave.BackColor = System.Drawing.Color.Silver;
            this.Clave.Enabled = false;
            this.Clave.ForeColor = System.Drawing.Color.Black;
            this.Clave.FormattingEnabled = true;
            this.Clave.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.Clave.Location = new System.Drawing.Point(448, 59);
            this.Clave.Name = "Clave";
            this.Clave.Size = new System.Drawing.Size(121, 28);
            this.Clave.Sorted = true;
            this.Clave.TabIndex = 9;
            // 
            // Nuevo
            // 
            this.Nuevo.BackColor = System.Drawing.Color.Silver;
            this.Nuevo.ForeColor = System.Drawing.Color.Black;
            this.Nuevo.Location = new System.Drawing.Point(843, 10);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(89, 30);
            this.Nuevo.TabIndex = 10;
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.UseVisualStyleBackColor = false;
            this.Nuevo.Click += new System.EventHandler(this.Nuevo_Click);
            // 
            // Modificar
            // 
            this.Modificar.BackColor = System.Drawing.Color.Silver;
            this.Modificar.ForeColor = System.Drawing.Color.Black;
            this.Modificar.Location = new System.Drawing.Point(843, 53);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(89, 39);
            this.Modificar.TabIndex = 11;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseVisualStyleBackColor = false;
            this.Modificar.Click += new System.EventHandler(this.Modificar_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.BackColor = System.Drawing.Color.Silver;
            this.Eliminar.Enabled = false;
            this.Eliminar.ForeColor = System.Drawing.Color.Black;
            this.Eliminar.Location = new System.Drawing.Point(989, 110);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(89, 33);
            this.Eliminar.TabIndex = 12;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = false;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // Grabar
            // 
            this.Grabar.BackColor = System.Drawing.Color.Silver;
            this.Grabar.Enabled = false;
            this.Grabar.ForeColor = System.Drawing.Color.Black;
            this.Grabar.Location = new System.Drawing.Point(480, 122);
            this.Grabar.Name = "Grabar";
            this.Grabar.Size = new System.Drawing.Size(89, 31);
            this.Grabar.TabIndex = 13;
            this.Grabar.Text = "Grabar";
            this.Grabar.UseVisualStyleBackColor = false;
            this.Grabar.Click += new System.EventHandler(this.Grabar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(31, 196);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1109, 322);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tipo";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Longitud";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Dir Atrib";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tipo Clave";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Dir Indice";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "DirSigAtrib";
            this.Column7.Name = "Column7";
            // 
            // Actualiza
            // 
            this.Actualiza.BackColor = System.Drawing.Color.Silver;
            this.Actualiza.ForeColor = System.Drawing.Color.Black;
            this.Actualiza.Location = new System.Drawing.Point(988, 59);
            this.Actualiza.Name = "Actualiza";
            this.Actualiza.Size = new System.Drawing.Size(90, 36);
            this.Actualiza.TabIndex = 16;
            this.Actualiza.Text = "Actualizar";
            this.Actualiza.UseVisualStyleBackColor = false;
            this.Actualiza.Click += new System.EventHandler(this.Actualiza_Click);
            // 
            // ATRIBUTOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 530);
            this.Controls.Add(this.Actualiza);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Grabar);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.Modificar);
            this.Controls.Add(this.Nuevo);
            this.Controls.Add(this.Clave);
            this.Controls.Add(this.Tipo);
            this.Controls.Add(this.Entidad);
            this.Controls.Add(this.Longitud);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ATRIBUTOS";
            this.Text = "ATRIBUTOS";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.TextBox Longitud;
        private System.Windows.Forms.ComboBox Entidad;
        private System.Windows.Forms.ComboBox Tipo;
        private System.Windows.Forms.ComboBox Clave;
        private System.Windows.Forms.Button Nuevo;
        private System.Windows.Forms.Button Modificar;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button Grabar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button Actualiza;
    }
}