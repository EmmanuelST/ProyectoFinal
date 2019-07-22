namespace ProyectoFinal.UI.Consultas
{
    partial class cAgricultor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DesdedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.HastadateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FechacheckBox = new System.Windows.Forms.CheckBox();
            this.Imprimirbutton = new System.Windows.Forms.Button();
            this.ConsultadataGridView = new System.Windows.Forms.DataGridView();
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.CriteriotextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FiltrocomboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DesdedateTimePicker);
            this.groupBox1.Controls.Add(this.HastadateTimePicker);
            this.groupBox1.Controls.Add(this.FechacheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 73);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Desde:";
            // 
            // DesdedateTimePicker
            // 
            this.DesdedateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.DesdedateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DesdedateTimePicker.Location = new System.Drawing.Point(5, 47);
            this.DesdedateTimePicker.Name = "DesdedateTimePicker";
            this.DesdedateTimePicker.Size = new System.Drawing.Size(96, 20);
            this.DesdedateTimePicker.TabIndex = 12;
            this.DesdedateTimePicker.ValueChanged += new System.EventHandler(this.DesdedateTimePicker_ValueChanged);
            // 
            // HastadateTimePicker
            // 
            this.HastadateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.HastadateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HastadateTimePicker.Location = new System.Drawing.Point(108, 47);
            this.HastadateTimePicker.Name = "HastadateTimePicker";
            this.HastadateTimePicker.Size = new System.Drawing.Size(96, 20);
            this.HastadateTimePicker.TabIndex = 14;
            this.HastadateTimePicker.ValueChanged += new System.EventHandler(this.HastadateTimePicker_ValueChanged);
            // 
            // FechacheckBox
            // 
            this.FechacheckBox.AutoSize = true;
            this.FechacheckBox.Location = new System.Drawing.Point(6, 11);
            this.FechacheckBox.Name = "FechacheckBox";
            this.FechacheckBox.Size = new System.Drawing.Size(102, 17);
            this.FechacheckBox.TabIndex = 15;
            this.FechacheckBox.Text = "Filtrar por Fecha";
            this.FechacheckBox.UseVisualStyleBackColor = true;
            this.FechacheckBox.CheckedChanged += new System.EventHandler(this.FechacheckBox_CheckedChanged);
            // 
            // Imprimirbutton
            // 
            this.Imprimirbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Imprimirbutton.Image = global::ProyectoFinal.Properties.Resources.imprimir;
            this.Imprimirbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Imprimirbutton.Location = new System.Drawing.Point(612, 483);
            this.Imprimirbutton.Name = "Imprimirbutton";
            this.Imprimirbutton.Size = new System.Drawing.Size(102, 39);
            this.Imprimirbutton.TabIndex = 30;
            this.Imprimirbutton.Text = "Imprirmir";
            this.Imprimirbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Imprimirbutton.UseVisualStyleBackColor = true;
            // 
            // ConsultadataGridView
            // 
            this.ConsultadataGridView.AllowUserToAddRows = false;
            this.ConsultadataGridView.AllowUserToDeleteRows = false;
            this.ConsultadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsultadataGridView.Location = new System.Drawing.Point(10, 91);
            this.ConsultadataGridView.Name = "ConsultadataGridView";
            this.ConsultadataGridView.ReadOnly = true;
            this.ConsultadataGridView.Size = new System.Drawing.Size(704, 386);
            this.ConsultadataGridView.TabIndex = 29;
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Image = global::ProyectoFinal.Properties.Resources.buscaTyni;
            this.Buscarbutton.Location = new System.Drawing.Point(668, 43);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(46, 23);
            this.Buscarbutton.TabIndex = 28;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // CriteriotextBox
            // 
            this.CriteriotextBox.Location = new System.Drawing.Point(443, 44);
            this.CriteriotextBox.Name = "CriteriotextBox";
            this.CriteriotextBox.Size = new System.Drawing.Size(208, 20);
            this.CriteriotextBox.TabIndex = 27;
            this.CriteriotextBox.TextChanged += new System.EventHandler(this.CriteriotextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Criterio:";
            // 
            // FiltrocomboBox
            // 
            this.FiltrocomboBox.FormattingEnabled = true;
            this.FiltrocomboBox.Items.AddRange(new object[] {
            "Todo",
            "Id",
            "Nombre",
            "Usuario"});
            this.FiltrocomboBox.Location = new System.Drawing.Point(238, 45);
            this.FiltrocomboBox.Name = "FiltrocomboBox";
            this.FiltrocomboBox.Size = new System.Drawing.Size(193, 21);
            this.FiltrocomboBox.TabIndex = 25;
            this.FiltrocomboBox.SelectedIndexChanged += new System.EventHandler(this.FiltrocomboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Filtro:";
            // 
            // cAgricultor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 526);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Imprimirbutton);
            this.Controls.Add(this.ConsultadataGridView);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.CriteriotextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FiltrocomboBox);
            this.Controls.Add(this.label3);
            this.Name = "cAgricultor";
            this.Text = "Consulta de Agricultores";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DesdedateTimePicker;
        private System.Windows.Forms.DateTimePicker HastadateTimePicker;
        private System.Windows.Forms.CheckBox FechacheckBox;
        private System.Windows.Forms.Button Imprimirbutton;
        private System.Windows.Forms.DataGridView ConsultadataGridView;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.TextBox CriteriotextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox FiltrocomboBox;
        private System.Windows.Forms.Label label3;
    }
}