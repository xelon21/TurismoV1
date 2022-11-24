namespace proyecto1
{
    partial class ServicioExtra
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
            this.panelIngresoDepartamento2 = new System.Windows.Forms.Panel();
            this.dgvServicioExtra = new System.Windows.Forms.DataGridView();
            this.panelIngresoDepartamento = new System.Windows.Forms.Panel();
            this.cmbTipoServicio = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.btnIngresarDepartamento = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.txtTarifa = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.btnVolverDepartamento = new System.Windows.Forms.Button();
            this.label54 = new System.Windows.Forms.Label();
            this.cmbZona = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.panelFormularioDepartamento.SuspendLayout();
            this.panelIngresoDepartamento2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicioExtra)).BeginInit();
            this.panelIngresoDepartamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormularioDepartamento
            // 
            this.panelFormularioDepartamento.BackColor = System.Drawing.Color.White;
            this.panelFormularioDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFormularioDepartamento.Controls.Add(this.panelIngresoDepartamento2);
            this.panelFormularioDepartamento.Controls.Add(this.panelIngresoDepartamento);
            this.panelFormularioDepartamento.Controls.Add(this.btnVolverDepartamento);
            this.panelFormularioDepartamento.Controls.Add(this.label54);
            this.panelFormularioDepartamento.Location = new System.Drawing.Point(12, 12);
            this.panelFormularioDepartamento.Name = "panelFormularioDepartamento";
            this.panelFormularioDepartamento.Size = new System.Drawing.Size(795, 534);
            this.panelFormularioDepartamento.TabIndex = 22;
            // 
            // panelIngresoDepartamento2
            // 
            this.panelIngresoDepartamento2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIngresoDepartamento2.Controls.Add(this.dgvServicioExtra);
            this.panelIngresoDepartamento2.Location = new System.Drawing.Point(24, 348);
            this.panelIngresoDepartamento2.Name = "panelIngresoDepartamento2";
            this.panelIngresoDepartamento2.Size = new System.Drawing.Size(745, 113);
            this.panelIngresoDepartamento2.TabIndex = 8;
            // 
            // dgvServicioExtra
            // 
            this.dgvServicioExtra.AllowUserToAddRows = false;
            this.dgvServicioExtra.AllowUserToDeleteRows = false;
            this.dgvServicioExtra.AllowUserToResizeRows = false;
            this.dgvServicioExtra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicioExtra.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvServicioExtra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvServicioExtra.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvServicioExtra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicioExtra.Location = new System.Drawing.Point(-1, -1);
            this.dgvServicioExtra.Name = "dgvServicioExtra";
            this.dgvServicioExtra.ReadOnly = true;
            this.dgvServicioExtra.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvServicioExtra.RowHeadersVisible = false;
            this.dgvServicioExtra.RowTemplate.Height = 25;
            this.dgvServicioExtra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicioExtra.Size = new System.Drawing.Size(745, 113);
            this.dgvServicioExtra.TabIndex = 32;
            // 
            // panelIngresoDepartamento
            // 
            this.panelIngresoDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIngresoDepartamento.Controls.Add(this.dtpFechaPago);
            this.panelIngresoDepartamento.Controls.Add(this.label14);
            this.panelIngresoDepartamento.Controls.Add(this.cmbZona);
            this.panelIngresoDepartamento.Controls.Add(this.cmbTipoServicio);
            this.panelIngresoDepartamento.Controls.Add(this.label47);
            this.panelIngresoDepartamento.Controls.Add(this.btnIngresarDepartamento);
            this.panelIngresoDepartamento.Controls.Add(this.label46);
            this.panelIngresoDepartamento.Controls.Add(this.txtTarifa);
            this.panelIngresoDepartamento.Controls.Add(this.label49);
            this.panelIngresoDepartamento.Controls.Add(this.label50);
            this.panelIngresoDepartamento.Location = new System.Drawing.Point(24, 83);
            this.panelIngresoDepartamento.Name = "panelIngresoDepartamento";
            this.panelIngresoDepartamento.Size = new System.Drawing.Size(745, 237);
            this.panelIngresoDepartamento.TabIndex = 7;
            // 
            // cmbTipoServicio
            // 
            this.cmbTipoServicio.FormattingEnabled = true;
            this.cmbTipoServicio.Items.AddRange(new object[] {
            "Administrador",
            "Usuario",
            "Cliente"});
            this.cmbTipoServicio.Location = new System.Drawing.Point(467, 61);
            this.cmbTipoServicio.Name = "cmbTipoServicio";
            this.cmbTipoServicio.Size = new System.Drawing.Size(202, 23);
            this.cmbTipoServicio.TabIndex = 22;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(382, 64);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(80, 15);
            this.label47.TabIndex = 27;
            this.label47.Text = "Tipo Servicio: ";
            // 
            // btnIngresarDepartamento
            // 
            this.btnIngresarDepartamento.Location = new System.Drawing.Point(303, 166);
            this.btnIngresarDepartamento.Name = "btnIngresarDepartamento";
            this.btnIngresarDepartamento.Size = new System.Drawing.Size(150, 38);
            this.btnIngresarDepartamento.TabIndex = 2;
            this.btnIngresarDepartamento.Text = "Agregar Servicio";
            this.btnIngresarDepartamento.UseVisualStyleBackColor = true;
            this.btnIngresarDepartamento.Click += new System.EventHandler(this.btnIngresarDepartamento_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(61, 97);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(74, 15);
            this.label46.TabIndex = 28;
            this.label46.Text = "Fecha Pago: ";
            // 
            // txtTarifa
            // 
            this.txtTarifa.Location = new System.Drawing.Point(140, 61);
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.Size = new System.Drawing.Size(202, 23);
            this.txtTarifa.TabIndex = 5;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(5, 118);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(0, 15);
            this.label49.TabIndex = 10;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(92, 64);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(41, 15);
            this.label50.TabIndex = 4;
            this.label50.Text = "Tarifa: ";
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
            this.label54.Location = new System.Drawing.Point(328, 42);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(137, 18);
            this.label54.TabIndex = 0;
            this.label54.Text = "Servicios Extras";
            // 
            // cmbZona
            // 
            this.cmbZona.FormattingEnabled = true;
            this.cmbZona.Items.AddRange(new object[] {
            "Administrador",
            "Usuario",
            "Cliente"});
            this.cmbZona.Location = new System.Drawing.Point(467, 94);
            this.cmbZona.Name = "cmbZona";
            this.cmbZona.Size = new System.Drawing.Size(202, 23);
            this.cmbZona.TabIndex = 35;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(413, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 15);
            this.label14.TabIndex = 36;
            this.label14.Text = "Zona: ";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Location = new System.Drawing.Point(140, 94);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(202, 23);
            this.dtpFechaPago.TabIndex = 37;
            // 
            // ServicioExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 563);
            this.Controls.Add(this.panelFormularioDepartamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ServicioExtra";
            this.Text = "ServicioExtra";
            this.Load += new System.EventHandler(this.ServicioExtra_Load);
            this.panelFormularioDepartamento.ResumeLayout(false);
            this.panelFormularioDepartamento.PerformLayout();
            this.panelIngresoDepartamento2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicioExtra)).EndInit();
            this.panelIngresoDepartamento.ResumeLayout(false);
            this.panelIngresoDepartamento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelFormularioDepartamento;
        private System.Windows.Forms.Panel panelIngresoDepartamento2;
        private System.Windows.Forms.DataGridView dgvServicioExtra;
        private System.Windows.Forms.Panel panelIngresoDepartamento;
        private System.Windows.Forms.ComboBox cmbTipoServicio;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Button btnIngresarDepartamento;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox txtTarifa;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Button btnVolverDepartamento;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.ComboBox cmbZona;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
    }
}