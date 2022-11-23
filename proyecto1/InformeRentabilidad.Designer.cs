namespace proyecto1
{
    partial class InformeRentabilidad
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
            this.panelFormularioDepartamento = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvInforme3 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.panelIngresoDepartamento2 = new System.Windows.Forms.Panel();
            this.dgvInforme2 = new System.Windows.Forms.DataGridView();
            this.dgvInforme = new System.Windows.Forms.DataGridView();
            this.btnVolverDepartamento = new System.Windows.Forms.Button();
            this.label54 = new System.Windows.Forms.Label();
            this.GuardarPdf = new System.Windows.Forms.SaveFileDialog();
            this.panelFormularioDepartamento.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme3)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelIngresoDepartamento2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFormularioDepartamento
            // 
            this.panelFormularioDepartamento.BackColor = System.Drawing.Color.White;
            this.panelFormularioDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFormularioDepartamento.Controls.Add(this.panel1);
            this.panelFormularioDepartamento.Controls.Add(this.button2);
            this.panelFormularioDepartamento.Controls.Add(this.panel3);
            this.panelFormularioDepartamento.Controls.Add(this.panelIngresoDepartamento2);
            this.panelFormularioDepartamento.Controls.Add(this.btnVolverDepartamento);
            this.panelFormularioDepartamento.Controls.Add(this.label54);
            this.panelFormularioDepartamento.Location = new System.Drawing.Point(12, 12);
            this.panelFormularioDepartamento.Name = "panelFormularioDepartamento";
            this.panelFormularioDepartamento.Size = new System.Drawing.Size(795, 534);
            this.panelFormularioDepartamento.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvInforme3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(223, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 95);
            this.panel1.TabIndex = 35;
            // 
            // dgvInforme3
            // 
            this.dgvInforme3.AllowUserToAddRows = false;
            this.dgvInforme3.AllowUserToDeleteRows = false;
            this.dgvInforme3.AllowUserToResizeRows = false;
            this.dgvInforme3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInforme3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInforme3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInforme3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInforme3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInforme3.Location = new System.Drawing.Point(3, 24);
            this.dgvInforme3.Name = "dgvInforme3";
            this.dgvInforme3.ReadOnly = true;
            this.dgvInforme3.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInforme3.RowHeadersVisible = false;
            this.dgvInforme3.RowTemplate.Height = 25;
            this.dgvInforme3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInforme3.Size = new System.Drawing.Size(364, 60);
            this.dgvInforme3.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(129, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 18);
            this.label3.TabIndex = 34;
            this.label3.Text = "Rentabilidad";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(596, 493);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Imprimir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnFiltrar);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dtpHasta);
            this.panel3.Controls.Add(this.dtpInicio);
            this.panel3.Location = new System.Drawing.Point(24, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(745, 84);
            this.panel3.TabIndex = 33;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(533, 30);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(135, 23);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inicio";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(262, 30);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 23);
            this.dtpHasta.TabIndex = 1;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(30, 30);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 23);
            this.dtpInicio.TabIndex = 0;
            // 
            // panelIngresoDepartamento2
            // 
            this.panelIngresoDepartamento2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIngresoDepartamento2.Controls.Add(this.dgvInforme2);
            this.panelIngresoDepartamento2.Controls.Add(this.dgvInforme);
            this.panelIngresoDepartamento2.Location = new System.Drawing.Point(24, 164);
            this.panelIngresoDepartamento2.Name = "panelIngresoDepartamento2";
            this.panelIngresoDepartamento2.Size = new System.Drawing.Size(745, 211);
            this.panelIngresoDepartamento2.TabIndex = 8;
            // 
            // dgvInforme2
            // 
            this.dgvInforme2.AllowUserToAddRows = false;
            this.dgvInforme2.AllowUserToDeleteRows = false;
            this.dgvInforme2.AllowUserToResizeRows = false;
            this.dgvInforme2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInforme2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInforme2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInforme2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInforme2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInforme2.Location = new System.Drawing.Point(380, -1);
            this.dgvInforme2.Name = "dgvInforme2";
            this.dgvInforme2.ReadOnly = true;
            this.dgvInforme2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInforme2.RowHeadersVisible = false;
            this.dgvInforme2.RowTemplate.Height = 25;
            this.dgvInforme2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInforme2.Size = new System.Drawing.Size(364, 207);
            this.dgvInforme2.TabIndex = 33;
            // 
            // dgvInforme
            // 
            this.dgvInforme.AllowUserToAddRows = false;
            this.dgvInforme.AllowUserToDeleteRows = false;
            this.dgvInforme.AllowUserToResizeRows = false;
            this.dgvInforme.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInforme.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInforme.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInforme.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInforme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInforme.Location = new System.Drawing.Point(-1, -1);
            this.dgvInforme.Name = "dgvInforme";
            this.dgvInforme.ReadOnly = true;
            this.dgvInforme.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInforme.RowHeadersVisible = false;
            this.dgvInforme.RowTemplate.Height = 25;
            this.dgvInforme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInforme.Size = new System.Drawing.Size(375, 207);
            this.dgvInforme.TabIndex = 32;
            // 
            // btnVolverDepartamento
            // 
            this.btnVolverDepartamento.Location = new System.Drawing.Point(24, 493);
            this.btnVolverDepartamento.Name = "btnVolverDepartamento";
            this.btnVolverDepartamento.Size = new System.Drawing.Size(75, 23);
            this.btnVolverDepartamento.TabIndex = 5;
            this.btnVolverDepartamento.Text = "Volver";
            this.btnVolverDepartamento.UseVisualStyleBackColor = true;
            this.btnVolverDepartamento.Click += new System.EventHandler(this.btnVolverDepartamento_Click);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label54.Location = new System.Drawing.Point(303, 15);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(173, 18);
            this.label54.TabIndex = 0;
            this.label54.Text = "Informe Rentabilidad";
            // 
            // GuardarPdf
            //      
            // 
            // InformeRentabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 559);
            this.Controls.Add(this.panelFormularioDepartamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InformeRentabilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformeRentabilidad";
            this.panelFormularioDepartamento.ResumeLayout(false);
            this.panelFormularioDepartamento.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelIngresoDepartamento2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormularioDepartamento;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Panel panelIngresoDepartamento2;
        private System.Windows.Forms.DataGridView dgvInforme;
        private System.Windows.Forms.Button btnVolverDepartamento;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.DataGridView dgvInforme2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvInforme3;
        private System.Windows.Forms.SaveFileDialog GuardarPdf;
    }
}