
namespace proyecto1
{
    partial class ValidarReserva
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
            this.panelValidaCheckIn = new System.Windows.Forms.Panel();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.txtCheckIn = new System.Windows.Forms.TextBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.panelValidaCheckIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelValidaCheckIn
            // 
            this.panelValidaCheckIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelValidaCheckIn.Controls.Add(this.lblCheckIn);
            this.panelValidaCheckIn.Controls.Add(this.txtCheckIn);
            this.panelValidaCheckIn.Controls.Add(this.btnValidar);
            this.panelValidaCheckIn.Location = new System.Drawing.Point(38, 29);
            this.panelValidaCheckIn.Name = "panelValidaCheckIn";
            this.panelValidaCheckIn.Size = new System.Drawing.Size(230, 189);
            this.panelValidaCheckIn.TabIndex = 5;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCheckIn.Location = new System.Drawing.Point(13, 37);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(200, 18);
            this.lblCheckIn.TabIndex = 0;
            this.lblCheckIn.Text = "Ingrese Código Reserva";
            // 
            // txtCheckIn
            // 
            this.txtCheckIn.Location = new System.Drawing.Point(56, 71);
            this.txtCheckIn.Name = "txtCheckIn";
            this.txtCheckIn.Size = new System.Drawing.Size(121, 23);
            this.txtCheckIn.TabIndex = 1;
            this.txtCheckIn.TextChanged += new System.EventHandler(this.txtCheckIn_TextChanged);
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(65, 115);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(101, 35);
            this.btnValidar.TabIndex = 2;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // ValidarReserva
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(317, 264);
            this.Controls.Add(this.panelValidaCheckIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ValidarReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ValidarReserva";
            this.Load += new System.EventHandler(this.ValidarReserva_Load);
            this.panelValidaCheckIn.ResumeLayout(false);
            this.panelValidaCheckIn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelValidaCheckIn;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.TextBox txtCheckIn;
        private System.Windows.Forms.Button btnValidar;
    }
}