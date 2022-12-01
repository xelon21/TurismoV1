namespace proyecto1
{
    partial class PagoSueldos
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbMedioPago = new System.Windows.Forms.ComboBox();
            this.cmbZonaEmpleado = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIngresarSueldo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.panelIngresoDepartamento2 = new System.Windows.Forms.Panel();
            this.dgvInformePago = new System.Windows.Forms.DataGridView();
            this.btnVolverDepartamento = new System.Windows.Forms.Button();
            this.label54 = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelFormularioDepartamento.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelIngresoDepartamento2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformePago)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFormularioDepartamento
            // 
            this.panelFormularioDepartamento.BackColor = System.Drawing.Color.White;
            this.panelFormularioDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFormularioDepartamento.Controls.Add(this.panel3);
            this.panelFormularioDepartamento.Controls.Add(this.panelIngresoDepartamento2);
            this.panelFormularioDepartamento.Controls.Add(this.btnVolverDepartamento);
            this.panelFormularioDepartamento.Controls.Add(this.label54);
            this.panelFormularioDepartamento.Location = new System.Drawing.Point(12, 12);
            this.panelFormularioDepartamento.Name = "panelFormularioDepartamento";
            this.panelFormularioDepartamento.Size = new System.Drawing.Size(890, 620);
            this.panelFormularioDepartamento.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmbEmpleado);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cmbMedioPago);
            this.panel3.Controls.Add(this.cmbZonaEmpleado);
            this.panel3.Controls.Add(this.txtDescripcion);
            this.panel3.Controls.Add(this.txtValorPago);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnIngresarSueldo);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dtpFechaPago);
            this.panel3.Location = new System.Drawing.Point(24, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(834, 357);
            this.panel3.TabIndex = 33;
            // 
            // cmbMedioPago
            // 
            this.cmbMedioPago.FormattingEnabled = true;
            this.cmbMedioPago.Location = new System.Drawing.Point(160, 149);
            this.cmbMedioPago.Name = "cmbMedioPago";
            this.cmbMedioPago.Size = new System.Drawing.Size(210, 23);
            this.cmbMedioPago.TabIndex = 19;
            // 
            // cmbZonaEmpleado
            // 
            this.cmbZonaEmpleado.FormattingEnabled = true;
            this.cmbZonaEmpleado.Location = new System.Drawing.Point(160, 91);
            this.cmbZonaEmpleado.Name = "cmbZonaEmpleado";
            this.cmbZonaEmpleado.Size = new System.Drawing.Size(210, 23);
            this.cmbZonaEmpleado.TabIndex = 18;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(508, 120);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(218, 67);
            this.txtDescripcion.TabIndex = 16;
            // 
            // txtValorPago
            // 
            this.txtValorPago.Location = new System.Drawing.Point(160, 178);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(100, 23);
            this.txtValorPago.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Medio de Pago: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Zona Empleado: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripción: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Valor Pago: ";
            // 
            // btnIngresarSueldo
            // 
            this.btnIngresarSueldo.Location = new System.Drawing.Point(331, 240);
            this.btnIngresarSueldo.Name = "btnIngresarSueldo";
            this.btnIngresarSueldo.Size = new System.Drawing.Size(154, 40);
            this.btnIngresarSueldo.TabIndex = 4;
            this.btnIngresarSueldo.Text = "Ingresar Sueldo";
            this.btnIngresarSueldo.UseVisualStyleBackColor = true;
            this.btnIngresarSueldo.Click += new System.EventHandler(this.btnIngresarSueldo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Pago: ";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Location = new System.Drawing.Point(508, 91);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(218, 23);
            this.dtpFechaPago.TabIndex = 1;
            // 
            // panelIngresoDepartamento2
            // 
            this.panelIngresoDepartamento2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIngresoDepartamento2.Controls.Add(this.dgvInformePago);
            this.panelIngresoDepartamento2.Location = new System.Drawing.Point(24, 421);
            this.panelIngresoDepartamento2.Name = "panelIngresoDepartamento2";
            this.panelIngresoDepartamento2.Size = new System.Drawing.Size(834, 137);
            this.panelIngresoDepartamento2.TabIndex = 8;
            // 
            // dgvInformePago
            // 
            this.dgvInformePago.AllowUserToAddRows = false;
            this.dgvInformePago.AllowUserToDeleteRows = false;
            this.dgvInformePago.AllowUserToResizeRows = false;
            this.dgvInformePago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInformePago.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInformePago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInformePago.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInformePago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInformePago.Location = new System.Drawing.Point(-1, -1);
            this.dgvInformePago.Name = "dgvInformePago";
            this.dgvInformePago.ReadOnly = true;
            this.dgvInformePago.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInformePago.RowHeadersVisible = false;
            this.dgvInformePago.RowTemplate.Height = 25;
            this.dgvInformePago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInformePago.Size = new System.Drawing.Size(834, 137);
            this.dgvInformePago.TabIndex = 32;
            // 
            // btnVolverDepartamento
            // 
            this.btnVolverDepartamento.Location = new System.Drawing.Point(24, 564);
            this.btnVolverDepartamento.Name = "btnVolverDepartamento";
            this.btnVolverDepartamento.Size = new System.Drawing.Size(98, 35);
            this.btnVolverDepartamento.TabIndex = 5;
            this.btnVolverDepartamento.Text = "Volver";
            this.btnVolverDepartamento.UseVisualStyleBackColor = true;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label54.Location = new System.Drawing.Point(356, 19);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(189, 18);
            this.label54.TabIndex = 0;
            this.label54.Text = "Ingresar Pago Sueldos";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(160, 120);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(210, 23);
            this.cmbEmpleado.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Empleado: ";
            // 
            // PagoSueldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 642);
            this.Controls.Add(this.panelFormularioDepartamento);
            this.Name = "PagoSueldos";
            this.Text = "PagoSueldos";
            this.panelFormularioDepartamento.ResumeLayout(false);
            this.panelFormularioDepartamento.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelIngresoDepartamento2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformePago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormularioDepartamento;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbMedioPago;
        private System.Windows.Forms.ComboBox cmbZonaEmpleado;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIngresarSueldo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Panel panelIngresoDepartamento2;
        private System.Windows.Forms.DataGridView dgvInformePago;
        private System.Windows.Forms.Button btnVolverDepartamento;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label label4;
    }
}